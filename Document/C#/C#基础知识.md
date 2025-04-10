#### 重载和重写的区别

- **位置**：重载在同类中，重写在父子类中

- **方法名、形参**：重载方法名相同参数列表不同，重写方法名和参数列表都相同

- **调用对象**：重载使用相同对象以不同参数调用，重写用不同对象以相同参数调用

- **时机**：重载时编译时多态，重写是运行时多态

  - 重载：通过方法签名区分，由编译器静态决定调用。
  - 重写：通过对象实际类型动态决定调用，是面向对象多态的核心体现。
  
  

#### 面向对象的三大特点

##### 封装

- 将不需要对外提供的内容都隐藏起来，只暴露必要的接口。
- 防止外部代码直接修改内部数据，确保数据安全性。

##### 继承

- **提高代码重用度**，增强软件可维护性的重要手段，符合开闭原则
- 继承最主要的作用就是**把子类的公共属性集合起来**，便与共同管理，使用起来也更加方便

##### 多态性

- 同一操作作用于不同对象时，可以产生不同的行为。

| **特性** |    **解决的问题**    |       **实际开发中的价值**        |
| :------: | :------------------: | :-------------------------------: |
|   封装   | 数据安全和代码模块化 |    减少耦合，提高代码可维护性     |
|   继承   | 代码冗余和层次化设计 |    促进代码复用，简化系统架构     |
|   多态   |    灵活的行为扩展    | 增强代码扩展性，支持开放-封闭原则 |



#### 值类型和引用类型有什么区别

| **对比项**          | **值类型 (Value Type)**                              | **引用类型 (Reference Type)**               |
| :------------------ | :--------------------------------------------------- | :------------------------------------------ |
| **存储位置**        | 栈（Stack）或作为引用类型的成员时存储在堆中          | 堆（Heap）                                  |
| **变量存储内容**    | 直接存储数据本身                                     | 存储指向堆中数据的引用（内存地址）          |
| **赋值行为**        | 复制完整数据（独立副本）                             | 复制引用（共享同一数据）                    |
| **默认值**          | 类型对应的零值（如 `int` 为 `0`，`bool` 为 `false`） | `null`                                      |
| **内存管理**        | 随作用域结束自动释放（无GC开销）                     | 由垃圾回收器（GC）管理                      |
| **性能**            | 访问快，无堆分配和GC压力                             | 堆分配和GC可能影响性能                      |
| **继承关系**        | 隐式继承 `System.ValueType`（不可被继承）            | 直接继承 `System.Object`（支持继承和多态）  |
| **是否可为 `null`** | 不能（除非使用 `Nullable<T>`，如 `int?`）            | 可以                                        |
| **典型示例**        | `int`, `double`, `struct`, `enum`, `char`            | `class`, `string`, `object`, `数组`, `接口` |
| **可变性**          | 通常设计为不可变（修改需创建副本）                   | 通常可变（直接修改引用对象）                |
| **装箱/拆箱**       | 需要装箱（转为 `object` 或接口时）                   | 无需装箱                                    |



#### private，public，protected，internal的区别

- public：无限制访问
- private：仅对该类公开
- protected：对该类和其派生类公开
- internal：只能在包含该类的程序集中访问该类



#### ArrayList和 List的主要区别

| **对比项**        | **`ArrayList`**                                  | **`List<T>`**                          |
| :---------------- | :----------------------------------------------- | :------------------------------------- |
| **所属命名空间**  | `System.Collections`                             | `System.Collections.Generic`           |
| **类型安全**      | 非泛型，存储 `object` 类型，可能引发类型转换异常 | 泛型，类型安全，编译时检查             |
| **装箱**          | 需要频繁装箱，性能较低                           | 无装箱拆箱，性能更高                   |
| **内存使用**      | 存储 `object`，可能占用更多内存                  | 直接存储指定类型 `T`，内存效率更高     |
| **初始化方式**    | `ArrayList list = new ArrayList();`              | `List<int> list = new List<int>();`    |
| **添加元素**      | `list.Add(1);`（可添加任意类型）                 | `list.Add(1);`（只能添加 `T` 类型）    |
| **读取元素**      | 需要强制类型转换：`int num = (int)list[0];`      | 直接获取正确类型：`int num = list[0];` |
| **是否支持 LINQ** | 支持，但需额外转换（如 `Cast<int>()`）           | 原生支持 LINQ 查询                     |
| **线程安全**      | 非线程安全（需手动同步）                         | 非线程安全（需手动同步）               |
| **推荐使用场景**  | 遗留代码、需要存储混合类型的集合                 | 现代代码，类型安全且高性能的集合       |



#### GC（垃圾回收）产生的原因，如何避免？

GC为了避免内存溢出而产生的回收机制。

**原因**

- 堆内存分配
  - 引用类型的实例化（如 `new` 对象、字符串拼接等）
  - 装箱操作
- 当对象不再被引用时，GC 会将其标记为垃圾
- 临时对象

**避免策略**---【**减少堆内存分配**】

- 减少堆内存分配
  - 优先使用值类型
  - 避免装箱
  - 复用对象,减少new的次数,对象池
- 优化字符串操作
- 减少临时对象
- Unity中不在频繁调用的函数中反复进行堆内存分配
- List，new时候，规定内存大小




#### Interface与抽象类之间的不同

| **对比项**       | **接口（Interface）**                                    | **抽象类（Abstract Class）**                      |
| :--------------- | :------------------------------------------------------- | :------------------------------------------------ |
| **能否包含实现** | 不能（C# 8.0+ 支持默认实现，但不推荐滥用）               | 可以包含部分实现（抽象方法 + 具体方法）           |
| **成员类型**     | 只能包含方法、属性、事件、索引器（不能有字段、构造函数） | 可以包含字段、构造函数、方法、属性、事件等        |
| **继承机制**     | 支持多继承                                               | 单继承                                            |
| **访问修饰符**   | 默认 `public`（不能显式指定 `private`、`protected` 等）  | 可以指定 `public`、`protected`、`internal` 等     |
| **适用场景**     | 强调"能做什么"（如 `IDisposable`）                       | 提供**部分通用实现**，强调"是什么"（如 `Stream`） |
| **版本兼容性**   | 新增成员会破坏现有实现（除非使用默认方法）               | 新增非抽象方法不会破坏现有子类                    |
| **实例化**       | 不能直接实例化                                           | 不能直接实例化（必须通过子类）                    |



#### 关键字Sealed用在类声明和函数声明时的作用

- 类声明可防止其他类继承此类
- 方法声明时可防止派生类重写此方法



#### 反射的实现原理

在运行时动态获取类型信息、访问成员、调用方法或构造对象的机制。它的实现原理基于 **元数据 **和 **公共语言运行时（CLR）** 的动态支持。

- **元数据** 提供静态类型信息。
  - **元数据**简单地说就是一个数据表集合。每个托管模块都包含元数据表。主要有两种表：一种表描述源代码中定义的类型和成员，另一种描述源代码引用的类型和成员。
- **CLR** 在运行时动态解析元数据，支持反射操作。


```c#
foreach (Type type in assembly.GetTypes())
{
    string t = type.Name;
}
Type type = assembly.GetType("程序集.类名");//获取当前类的类型
Activator.CreateInstance(type); //创建此类型实例
MethodInfo mInfo = type.GetMethod("方法名");//获取当前方法
mInfo.Invoke(null,方法参数);
```



####  协程、Task 和UniTask 对比

|     **特性**     |             **协程 (Coroutine)**             |         **Task (System.Threading.Tasks)**         |                    **UniTask (Cysharp)**                     |
| :--------------: | :------------------------------------------: | :-----------------------------------------------: | :----------------------------------------------------------: |
|   **GC 分配**    |        高（每次 `yield` 生成新对象）         |        中等（基于 `Task` 的异步模型有 GC）        |              **零 GC**（基于值类型 `UniTask`）               |
|     **性能**     |      低效（依赖 Unity 主线程逐帧驱动）       |              高效（基于线程池调度）               |        **高效**（零开销异步，优化 Unity 主线程调度）         |
|   **线程安全**   |   仅主线程（需通过 `MonoBehaviour` 启动）    |        多线程安全（但需手动同步到主线程）         |          **主线程安全**（自动调度到 Unity 主线程）           |
|   **取消支持**   |         需手动实现（如 `bool` 标志）         |           原生支持 `CancellationToken`            |     **原生支持**（集成 `CancellationToken` 和超时控制）      |
| **生命周期管理** | 依赖 `MonoBehaviour`（对象销毁后需手动停止） |         需手动管理（如 `Task.Dispose()`）         |    **自动管理**（通过 `UniTaskTracker` 和 `PlayerLoop`）     |
|  **Unity 集成**  |                   原生支持                   | 需手动处理主线程同步（如 `MainThreadDispatcher`） | **深度集成**（直接支持 `UnityWebRequest`、`AsyncOperation` 等） |
|  **代码复杂度**  |            简单（但嵌套回调复杂）            |      中等（需处理 `async/await` 和线程同步）      |          **简单**（类似 `Task` 的语法，无回调地狱）          |
|   **适用场景**   |              简单延时、逐帧动画              |    多线程计算、I/O 密集型任务（非 Unity 项目）    |      **Unity 高性能异步**（如高频 UI 更新、网络请求等）      |
| **跨平台兼容性** |                   仅 Unity                   |                全平台（.NET 标准）                |                **全平台**（专为 Unity 优化）                 |

**总结与推荐**

1. **协程 (Coroutine)**
   - ✅ 适合简单延时逻辑（如 `yield return new WaitForSeconds`）。
   - ❌ 避免在复杂异步逻辑或高频调用中使用（GC 压力大）。
2. **Task (System.Threading.Tasks)**
   - ✅ 适合非 Unity 的 .NET 应用（如服务器端多线程计算）。
   - ❌ 在 Unity 中需谨慎使用（主线程同步复杂，GC 问题）。
3. **UniTask (Cysharp)**
   - ✅ **Unity 项目首选**（零 GC、高性能、生命周期安全）。
   - ✅ 适合高频网络请求、复杂异步流程、UI 交互。
   - ✅ 支持取消、超时、进度报告等高级功能。

**最终结论**

- **Unity 开发者**：优先使用 **UniTask**，替代协程和 `Task`。
- **非 Unity 的 .NET 项目**：使用原生 `Task`。
- **简单逻辑或兼容旧代码**：保留协程。



#### 在类的构造函数前加上static会报什么错?为什么?

- 静态构造函数不能添加访问修饰符
- 静态构造器前面不能有修饰符，是因为不能让外部调用



#### String、StringBuilder、StringBuffer

|   **特性**   |         **String**         |   **StringBuilder**    |      **StringBuffer**      |
| :----------: | :------------------------: | :--------------------: | :------------------------: |
|  **可变性**  |   ❌ 不可变（Immutable）    |   ✔️ 可变（Mutable）    |     ✔️ 可变（Mutable）      |
| **线程安全** |     ✔️（天然线程安全）      |      ❌ 非线程安全      |   ✔️ 线程安全（同步方法）   |
|   **性能**   | ⚠️ 低（频繁操作产生新对象） |   ✔️ 高（无同步开销）   |   ⚠️ 中（同步锁降低性能）   |
| **使用场景** |    常量字符串、少量操作    | 单线程下频繁字符串操作 |   多线程下频繁字符串操作   |
| **内存效率** | ❌ 低（大量拼接时浪费内存） |    ✔️ 高（原地修改）    |      ✔️ 高（原地修改）      |
| **方法同步** |          无需同步          |         无同步         | 方法用 `synchronized` 修饰 |



#### C#中常用容器类，各有什么特点

|                   **集合类型**                   | **底层数据结构** | **允许重复** | **有序性** | **访问方式** |            **操作时间复杂度**            |          **适用场景**          |         **注意事项**         |
| :----------------------------------------------: | :--------------: | :----------: | :--------: | :----------: | :--------------------------------------: | :----------------------------: | :--------------------------: |
|           [List<T>](./C# 进阶/List.md)           |     动态数组     |      ✅       |  插入顺序  |     索引     | 添加/删除末尾：O(1)；中间插入/删除：O(n) |  需快速随机访问，动态大小集合  |     扩容时需重新分配内存     |
| [Dictionary<key,value>](./C# 进阶/Dictionary.md) |      哈希表      |   Key唯一    |    无序    |     Key      |         添加/查找/删除：平均O(1)         |         键值对快速查找         | 需良好哈希函数，冲突影响性能 |
|        [HashSet<T>](./C# 进阶/HashSet.md)        |      哈希表      |      ❌       |    无序    |     元素     |         添加/查找/删除：平均O(1)         | 快速判断元素是否存在，去重操作 |        无法按索引访问        |
|          [Queue<T>](./C# 进阶/Queue.md)          |     循环数组     |      ✅       |  FIFO顺序  |  队首/队尾   |             入队/出队：O(1)              | 先进先出任务处理（如消息队列） |          非线程安全          |
|                     Stack<T>                     |       数组       |      ✅       |  LIFO顺序  |     栈顶     |             压栈/弹栈：O(1)              |   后进先出操作（如撤销功能）   |        容量不足时扩容        |
|     [LinkedList<T>](./C# 进阶/LinkedList.md)     |     双向链表     |      ✅       |  插入顺序  |   节点指针   |     插入/删除：O(1)（已知节点位置）      |    频繁在任意位置插入/删除     |      随机访问慢（O(n)）      |
|           [Array](./C# 进阶/Array.md)            |   固定长度数组   |      ✅       |  索引顺序  |     索引     |  随机访问：O(1)；插入/删除：需重建数组   |    固定大小集合，高性能场景    |          长度不可变          |

性能排序

- 插入性能： LinkedList > Dictionary > HashTable > List
- 遍历性能：List > LinkedList > Dictionary > HashTable
- 删除性能： Dictionary > LinkedList > HashTable > List

1. **Stack**：底层是数组，先进后出。
2. **Queue**：循环数组，头尾指针，先进先出，扩容是2倍或加4的较大值
3. **Dictionary**：数组+单链表的哈希表，扩容用最小素数，Entry和Bucket数组对应。负载因子 > 0.72
4. **HashSet**：类似Dictionary，但Entry没有key，只存value。
5. **List**：动态数组，自动扩容。




#### C#中unsafe关键字是用来做什么的？什么场合下使用？

非托管代码才需要这个关键字一般用在带指针操作的场合。 项目背包系统的任务装备栏使用到



#### C#中ref和out关键字有什么区别？

1. ref修饰引用参数。**参数必须赋值，带回返回值，又进又出**

2. out修饰输出参数。**参数可以不赋值，带回返回值之前必须明确赋值**， 引用参数和输出参数不会创建新的存储位置

3. 如果ref参数是值类型，原先的值类型数据，会随着方法里的数据改变而改变， 如果ref参数值引用类型，方法里重新赋值后，原对象堆中数据会改变，如果对引用类型再次创建新对象并赋值给ref参数，引用地址会重新指向新对象堆数据。方法结束后形参和新对象都会消失。实参还是指向原始对象，数据改变了



#### For，foreach，Enumerator.MoveNext的使用，与内存消耗情况

- for循环可以通过索引依次进行遍历
- foreach和Enumerator.MoveNext通过迭代的方式进行遍历
- foreach遍历数组（编译器优化为指针操作）。
- 遍历**非泛型集合**时（如 `ArrayList`）会产生 **装箱拆箱开销**，且每次迭代会创建 `IEnumerator` 对象



####  JIT和AOT区别

1、Just-In-Time -实时编译：执行慢，安装快，占空间小一点

2、Ahead-Of-Time -预先编译：执行快，安装慢，占内存大一点



#### C#中 委托和事件的区别

委托是方法集合

事件 = 委托 + 访问控制 

事件外部只能通过 `+=` 和 `-=` 订阅/取消订阅

事件基于委托的封装



#### 概述序列化

序列化简单理解成把对象转换为容易传输的格式的过程。比如，可以序列化一个对象，然后使用HTTP通过Internet在客户端和服务器端之间传输该对象




#### foreach迭代器遍历和for循环遍历的区别

- `底层实现`：foreach是通过指针偏移实现的，而for循环是通过索引实现的
- `编码结构`：foreach语句省去了for语句中设置循环起点和循环条件的过程
- `使用要求`：使用foreach语句遍历对象要求对象类型实现了枚举接口IEnumerable
- `使用效率`：foreach循环访问时会将对象的值复制到栈上，效率比for循环要低

**扩展1：foreach遍历的实现逻辑**

实现逻辑是：集合或数组实现了IEnumerable接口，并调用GetEnumerator抽象方法返回IEnumerator遍历器，通过使用IEnumerator这个工具来遍历这个类。

```c#
IEnumerable<object> obj = new IEnumerable<object>();
IEnumerator tor = obj.GetEnumerator();
while(tor.MoveNext)
{
    Console.Write(tor.Current);
}
```

**扩展2：为什么不能在foreach遍历中更改源集合？**

在foreach循环访问时会将集合中的每个值复制到栈上（引用类型复制的是地址），实际遍历的对象其实是一个复制出来的中间变量；在这个机制的存在下，foreach循环在执行速度上要比for循环慢；




#### 为什么dynamic font 在 unicode环境下优于 staticfont（字符串编码）

- 字符覆盖： Unicode 包含大量字符，包括各种语言的字母、符号、表情等。动态字体能够根据实际需要加载所需字符，确保应用程序能够正确显示和处理各种语言的文本。

- 国际化支持： 支持多语言应用程序需要处理不同字符集，而动态字体可以根据需要加载不同语言所需的字符。

- 节省资源： 在静态字体中，如果想要支持多种语言，可能需要包含大量字符，导致资源浪费。而动态字体则允许在运行时选择性地加载字符，以节省内存。

  

#### Mathf.Round和Mathf.Clamp和Mathf.Lerp含义？

- Mathf.Round：四舍五入

- Mathf.Clamp：左右限值

- Mathf.Lerp：插值



#### 什么是里氏替换原则？（C#多态）

里氏替换原则(Liskov Substitution Principle LSP)⾯向对象设计的基本原则之⼀。

1. 里氏替换原则中说，任何基类可以出现的地⽅，⼦类⼀定可以出现，作⽤⽅便扩展功能能
2. 子类可以实现父类的抽象方法，但是不能覆盖父类的非抽象方法。
3. 子类中可以增加自己特有的方法。
4. 当子类的方法重载父类的方法时，方法的前置条件（即方法的形参）要比父类方法的输入参数更宽松。
5. 当子类的方法实现父类的抽象方法时，方法的后置条件（即方法的返回值）要比父类更严格。

```c#
public class Animal
{
    public virtual void Eat(Food food)
    {
        // 父类方法的具体实现
    }
}

public class Meat : Food { }

public class Carnivore : Animal
{
    // 子类方法的前置条件更宽松，可以接受 Meat 或 Food
    public override void Eat(Meat meat)
    {
        // 子类方法的具体实现
    }
}
```

```c#
public abstract class Shape
{
    public abstract double GetArea();
}

public class Circle : Shape
{
    public override double GetArea()
    {
        // 子类方法返回比父类更具体的类型
        return Math.PI * radius * radius;
    }
}

```



#### 哈希表与字典对比

**`字典`**：

- 内部用了Hashtable作为存储结构
- 如果我们试图找到一个不存在的键，它将返回 / 抛出异常。

- 它比哈希表更快，因为没有装箱和拆箱，尤其是值类型。

- 仅公共静态成员是线程安全的。

- 字典是一种通用类型，这意味着我们可以将其与任何数据类型一起使用（创建时，必须同时指定键和值的数据类型）。

- Dictionay 是 Hashtable 的类型安全实现， Keys和Values是强类型的。

- Dictionary遍历输出的顺序，就是加入的顺序


**`哈希表`**：

-  如果我们尝试查找不存在的键，则返回 null。

- 它比字典慢，因为它需要装箱和拆箱。

- 哈希表中的所有成员都是线程安全的，

- 哈希表不是通用类型，

- Hashtable 是松散类型的数据结构，我们可以添加任何类型的键和值。

- HashTable是经过优化的，访问下标的对象先散列过，所以内部是无序散列的



#### MVC

MVC全名是Model View Controller，是模型(model)－视图(view)－控制器(controller)的缩写，一种软件设计典范。

业务逻辑、数据、界面显示分离的方法

- Model（模型）：**处理应用程序数据逻辑的部分**
- View（视图）：**处理数据显示的部分**
- Controller（控制器）：**用户交互的部分**



#### 控制反转和依赖注入

把A类对B类的控制权抽离出来，交给一个第三方去做，把控制权反转给第三方，就称作控制反转（IOC）。控制反转是一种思想，是能够解决问题的一种可能的结果，而依赖注入就是其最典型的实现方法。由第三方（IOC容器）来控制依赖，把他通过构造函数、属性或者工厂模式等方法，注入到类A内，这样就极大程度的对类A和类B进行了解耦



#### 状态同步、帧同步

- 状态同步：计算在服务器
  状态同步就是将逻辑放在了服务器，而客户端更像一个显示器
- 帧同步：计算在客户端

​		帧同步的逻辑是将固定帧数据转发给客户端，由客户端进行计算，服务器只做收集和转发，不做运算

具体细节

最终要同步的都是**数据状态**

同步=网络传输什么+逻辑在哪计算

|          | 传输内容 | 逻辑计算 | 断线重连 | 回放/观战 |
| -------- | -------- | -------- | -------- | --------- |
| 帧同步   | 操作     | 客户端   | 追历史帧 | 天然支持  |
| 状态同步 | 结果     | 服务端   | 下次同步 | 另外实现  |

