### 核心数据结构：哈希表（Hash Table）

HashSet 的底层实现基于 **哈希表**，通过 **哈希函数** 将元素映射到内部数组（称为 **Bucket 桶**）的特定位置，实现快速查找、插入和删除。

------

### **关键组成部分**

- **哈希函数**（Hash Function）
  - **作用**：将元素的键（Key）转换为整数哈希码（Hash Code）。
  - **规则**：默认使用 `EqualityComparer<T>.Default.GetHashCode()`，可通过自定义 `IEqualityComparer<T>` 覆盖。

- **桶数组（Buckets）**
  - 内部维护一个 **动态扩容的数组**，每个位置称为一个桶（Bucket）。
  - 每个桶存储一个链表的头节点（或类似结构），用于解决哈希冲突。
- **条目（Entry）**

- 每个元素存储为一个Entry结构，包含：

  ```csharp
  struct Entry
  {
      public int HashCode;  // 哈希码（高位用于标记状态）
      public T Value;       // 元素值
      public int Next;      // 链表中下一个条目的索引
  }
  ```

------

### 哈希冲突解决：链地址法（Separate Chaining）

当不同元素通过哈希函数映射到同一桶时，采用 **链表** 连接冲突的条目：

- **插入冲突**：新条目添加到链表头部。
- **查找冲突**：遍历链表，使用 `Equals` 方法比较值。

------

### 动态扩容机制

- **负载因子（Load Factor）**：默认值为 0.72（当元素数量 / 桶数量 ≥ 负载因子时触发扩容）。
- 扩容过程
  1. 新建一个更大的桶数组（通常为原容量的 2 倍）。
  2. 重新计算所有元素的哈希码，分配到新桶中。
  3. 旧数组被垃圾回收。

------

###  核心操作的时间复杂度

| **操作** | **平均时间复杂度** | **最坏时间复杂度** |
| :------: | :----------------: | :----------------: |
|   插入   |        O(1)        |        O(n)        |
|   删除   |        O(1)        |        O(n)        |
|   查找   |        O(1)        |        O(n)        |

------

### 实现细节（以插入为例）

```csharp
public bool Add(T item)
{
    // 1. 计算哈希码
    int hashCode = comparer.GetHashCode(item) & 0x7FFFFFFF; // 确保非负
    // 2. 定位桶索引
    int bucketIndex = hashCode % buckets.Length;
    // 3. 遍历链表，检查是否已存在相同元素
    for (int i = buckets[bucketIndex]; i >= 0; i = entries[i].Next)
    {
        if (entries[i].HashCode == hashCode && comparer.Equals(entries[i].Value, item))
        {
            return false; // 已存在，插入失败
        }
    }
    // 4. 若需要扩容，则扩容并重新哈希
    if (count >= threshold) Resize();
    // 5. 创建新条目并插入链表头部
    int newIndex = count;
    entries[newIndex].HashCode = hashCode;
    entries[newIndex].Value = item;
    entries[newIndex].Next = buckets[bucketIndex];
    buckets[bucketIndex] = newIndex;
    count++;
    return true;
}
```

------

### 性能优化策略

- **素数容量（Prime Size）**：桶数量通常选择素数，减少哈希冲突。
- **快速模运算**：用位运算（如 `hashCode % size`）替代取模运算。
- **惰性删除**：删除条目时标记为“空”，避免频繁重组数据。

------

### 与 Dictionary 的区别

|   **特性**    |   **HashSet**    | **Dictionary<TKey, TValue>** |
| :-----------: | :--------------: | :--------------------------: |
| **存储内容**  |  仅值（唯一性）  |       键值对（键唯一）       |
| **内存开销**  | 较低（不存储键） |     较高（需存储键和值）     |
| **查找效率**  |    基于值哈希    |          基于键哈希          |
| `bucket` 数组 |   **采用素数**   |         **采用素数**         |
|   线程安全    | **不是线程安全** |       **不是线程安全**       |

------

### **总结**

HashSet 通过 **哈希表 + 链地址法** 实现高效去重和查找，其性能依赖于：

1. 哈希函数的均匀性。
2. 动态扩容机制。
3. 冲突解决策略。