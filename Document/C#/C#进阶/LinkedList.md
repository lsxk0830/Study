### 链表的基础特性

 数组需要一块连续的内存空间来存储，对内存的要求比较高。**链表并不需要一块连续的内存空间，通过“指针”将一组零散的内存块串联起来使用**。链表的节点可以动态分配内存，使得链表的大小可以根据需要动态变化，而不受固定的内存大小的限制。特别是在需要频繁的插入和删除操作时，链表相比于数组具有更好的性能。最常见的链表结构分别是：单链表、双向链表和循环链表。

- 链表的基本单元是节点，每个节点包含两个部分：
  - 数据(Data)：存储节点所包含的信息。
  - 引用(Next)：指向下一个节点的引用，在双向链表中，包含指向前一个节点的引用。
- 链表的基本类型，主要包含三种类型：
  1. 单链表（Singly Linked List）：每个节点只包含一个指向下一个节点的引用。
     - 【时间复杂度】头部插入/删除：O(1)；尾部插入：O(n) ；中间插入/删除：O(n) 。
     - 【时间复杂度】按值查找：O(n) （需要遍历整个链表）；按索引查找：O(n) 。
     - 【空间复杂度】插入和删除：O(1)；查找：O(1)。
  2. 双链表（Doubly Linked List）：每个节点包含两个引用，一个指向下一个节点，一个指向前一个节点。
     - 【时间复杂度】头部插入/删除：O(1)；尾部插入/删除：O(1)；中间插入/删除：O(n) 。
     - 【时间复杂度】按值查找：O(n) ；按索引查找：O(n) 。
     - 【空间复杂度】O(n)。
  3. 循环链表： 尾节点的引用指向头节点，形成一个闭环。
     - 【时间复杂度】头部插入/删除：O(1)；尾部插入/删除：O(1)；中间插入/删除：O(n) 。
     - 【时间复杂度】按值查找：O(n) ；按索引查找：O(n) 。
     - 【空间复杂度】O(n)。

双链表虽然比较耗费内存，但是其在插入、删除、有序链表查询方面相对于单链表有明显的优先，这一点充分的体现了算法上的"用空间换时间"的设计思想。

------

### LinkedList数据存储

双向链表的每个节点都包含对前一个节点和后一个节点的引用，这种结构使得在链表中的两个方向上进行遍历和操作更为方便。

#### 节点结构

```c#
public sealed class LinkedListNode<T>
{
    internal LinkedList<T>? list; // 所属链表
    internal LinkedListNode<T>? next; // 后向指针
    internal LinkedListNode<T>? prev;// 前向指针
    internal T item; // 存储的数据
    ...
    public LinkedListNode(T value)
    {
        Value = value;
        Previous = null;
        Next = null;
    }
}
```

#### 链表头和尾

```c#
public class LinkedList<T> : ICollection<T>, ...
{
    public LinkedListNode<T>? First
    {
        get { return head; }
    }

    public LinkedListNode<T>? Last
    {
        get { return head?.prev; }
    }
    ...
}
```

LinkedList 本身维护了对链表头和尾的引用，分别指向第一个节点（头节点）和最后一个节点（尾节点）。通过将链表的节点（LinkedListNode）作为LinkedList 类的私有成员，可以隐藏链表节点的实现细节，提供更好的封装性。外部用户只需关注链表的公共接口而不需要了解节点的具体结构。并且可以更容易地扩展和维护链表的功能、可以控制对节点的访问权限、对链表的操作会影响到同一个链表的所有引用、可以表示空链表等优势。

### LinkedList数据读写

#### 插入元素

```c#
public LinkedListNode<T> AddLast(T value)
{
    LinkedListNode<T> result = new LinkedListNode<T>(this, value);
    if (head == null)
    {
        InternalInsertNodeToEmptyList(result);
    }
    else
    {
        InternalInsertNodeBefore(head, result);
    }
    return result;
}
```

以上代码展示了AddLast()的实现代码，这个方法是在双向链表的末尾添加一个新节点的操作，并根据链表是否为空采取不同的插入策略，确保插入操作的有效性，并返回了对新插入节点的引用。这里做为空和非空的场景区分是因为在双向链表中，头节点 head 的前一个节点是尾节点，而尾节点的下一个节点是头节点。因此，在链表为空的情况下，头节点即是尾节点，直接插入新节点即可。而在链表不为空的情况下，需要在头节点之前插入新节点，以保持链表的首尾相连。接下来我们分别来看一下InternalInsertNodeToEmptyList()和InternalInsertNodeBefore()方法。

```c#
private void InternalInsertNodeToEmptyList(LinkedListNode<T> newNode)
{
    //用于确保在调用此方法时链表必须为空。
    Debug.Assert(head == null && count == 0, "调用此方法时，LinkedList必须为空！");
    newNode.next = newNode;//将新节点的 next 指向自身
    newNode.prev = newNode;//将新节点的 prev 指向自身
    head = newNode;//将链表的头节点指向新节点
    version++; //增加链表的版本号
    count++;//增加链表中节点的数量
}
```

InternalInsertNodeToEmptyList()实现了在空链表中插入新节点的逻辑。在空链表中，新节点是唯一的节点，因此它的 next和prev都指向自身。新节点同时是头节点和尾节点。

```c#
private void InternalInsertNodeBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
{
    //新节点newNode的next引用指向目标节点node，
    //确保新节点newNode的next指向原来在链表中的位置。
    newNode.next = node;

    //新节点newNode的prev引用指向目标节点node的前一个节点，
    //在插入操作中保持链表的连接关系，确保newNode的前一个节点正确。
    newNode.prev = node.prev;

    //目标节点node前一个节点的next引用指向新节点newNode，新节点newNode插入完成
    node.prev!.next = newNode;

    //目标节点node的prev引用指向新节点newNode，
    //链表中目标节点node的前一个节点变成了新插入的节点newNode。
    node.prev = newNode;

    //用于追踪链表的结构变化，通过每次修改链表时增加
    //version的值，可以在迭代过程中检测到对链表的并发修改。
    version++;
    count++;
}
```

InternalInsertNodeBefore()用于实现链表中在指定节点前插入新节点,保证了插入操作的正确性和一致性，确保链表的连接关系和节点计数正确地维护。上面的代码已经做了逻辑说明。node.prev!.next = newNode;中的!确保在链表中插入新节点时，前一个节点不为 null，以防止潜在的空引用异常。版本号的增加是为了在并发操作中提供一种机制，使得在迭代过程中能够检测到链表的结构变化。这对于多线程环境下的链表操作是一种常见的实践，以避免潜在的并发问题。

#### 元素查询

LinkedList 实现元素的方法是Find()。

```c#
public LinkedListNode<T>? Find(T value)
{
    LinkedListNode<T>? node = head;
    EqualityComparer<T> c = EqualityComparer<T>.Default;
    if (node != null)
    {
        if (value != null)
        {
            do // 查找非空值的节点
            {
                if (c.Equals(node!.item, value))
                {
                    return node;
                }
                node = node.next;
            } while (node != head);
        }
        else
        {
            do // 查找空值的节点
            {
                if (node!.item == null)
                {
                    return node;
                }
                node = node.next;
            } while (node != head);
        }
    }
    return null; // 未找到节点
}
```

通过循环遍历链表中的每个节点，根据节点的值与目标值的比较，找到匹配的节点并返回。在链表中可能存在包含 null 值的节点，也可能存在包含非空值的节点，而这两种情况需要采用不同的比较方式。LinkedListNode? node = head; 初始化一个节点引用 node，开始时指向链表的头节点head。使用了do-while 循环确保至少执行一次，即使链表为空。为了防止潜在的空引用异常，使用了! 操作符来断言节点 node 不为 null。Find()方法对于链表中值的查询的时间复杂度是O(n)。

#### 元素移除

在InternalRemoveNode()方法中实现。

```c#
internal void InternalRemoveNode(LinkedListNode<T> node)
{
    if (node.next == node)
    {
        head = null; //将链表头head 设为null，表示链表为空。
    }
    else
    {
        node.next!.prev = node.prev;//将目标节点node后一个节点的prev引用指向目标节点node的前一个节点。
        node.prev!.next = node.next;//将目标节点node前一个节点的next引用指向目标节点node的后一个节点。

        if (head == node)
        {
            head = node.next; //如果目标节点node是链表头节点head，则将链表头head设为目标节点node的下一个节点。
        }
    }
    node.Invalidate();
    count--;
    version++;
}
```

在双向链表中删除指定节点node，首先判断链表中是否只有一个节点。如果链表只有一个节点，那么删除这个节点后链表就为空。调用 Invalidate 方法，用于清除节点的 list、prev 和 next 引用，使节点脱离链表。version++增加链表的版本号，用于在并发迭代过程中检测链表结构的变化。