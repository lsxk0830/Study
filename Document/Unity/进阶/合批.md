# 合批优化汇总

## 前言

> 动态合批与静态合批其本质是对将多次绘制请求，在允许的条件下进行合并处理，减少 CPU 对 GPU 绘制请求的次数，达到提高性能的目的。

## 啥是合批？

> 批量渲染其实是个老生常谈的话题，它的另一个名字叫做“合批”。
> 在日常开发中，通常说到优化、提高帧率时，总是会提到它。

## 为啥要合批？

> 批量渲染是通过减少CPU向GPU发送渲染命令（DrawCall）的次数，以及减少GPU切换渲染状态的次数，尽量让GPU一次多做一些事情，来提升逻辑线和渲染线的整体效率。
> 但这是建立在GPU相对空闲，而CPU把更多的时间都耗费在渲染命令的提交上时，才有意义

## 调用**Draw Call性能消耗原因是啥？**

> 我们的应用中每一次渲染，进行的API调用都会经过Application->Runtime->Driver(驱动)->显卡(GPU)[[1\]](https://zhuanlan.zhihu.com/p/356211912#ref_1)，其中每一步都会有一定的耗时。
> 每调用一次渲染API并不是直接经过以上说的所有组件通知GPU执行我们的调用。
> Runtime会将所有的API调用先转换为设备无关的“**命令**”（之所以是设备无关的，主要是因为这样我们写的程序就可以运行在任何特性兼容的硬件上了。运行时库使不同的硬件架构相对我们变的透明。）
> Draw Call性能消耗原因是**命令从Runtime到Driver的过程中，CPU要发生从用户模式到内核模式的切换。**
> 模式切换对于CPU来说是一件非常耗时的工作，所以如果所有的API调用Runtime都直接发送渲染命令给Driver，那就会导致每次API调用都发生CPU模式切换，这个性能消耗是非常大的。
> Runtime中的Command Buffer可以将一些没有必要马上发送给Driver的命令缓冲起来，在适当的时机一起发送给Driver，进而在显卡执行。以这样的方式来寻求最少的CPU模式切换，提升效率。
>
> [【Unity游戏开发】合批优化汇总 - 知乎 (zhihu.com)](https://zhuanlan.zhihu.com/p/356211912)

解决渲染Batch过多的主要方法：

- 一个是合批，
- 一个是对Driver进行优化，降低Driver的性能开销。

## 合批优化的是CPU还是GPU？

[合批只是对CPU的优化，与GPU没有任何关系](https://link.zhihu.com/?target=https%3A//www.cnblogs.com/timeObjserver/p/10599327.html)

合批是节省了CPU的相关准备工作的工作量。

合批后，经过VS,PS，尝试测试，模板测试后，此时已没有了纹理，顶点，索引的概念，只剩下一个个孤立的像素，各像素间没有任何关系了。像素送到GPU后进行批量处理，呈现到屏幕硬件上。

因此合批与GPU没有任何关系，也几乎没有影响。不管是一批还是多批，最终在此帧送到GPU的像素数量是相等的，数据是相同的。合批与否，对GPU的影响仅是像素到达的慢了还是快了，几乎不影响GPU的性能

------

目前比较新的图形API如：DirectX12、Vulkan、Metal，在Driver上的性能消耗已经降低了很多。但是通过合批来降低渲染的Draw call仍然是十分必要的。这也是我们对Draw call优化唯一能够做的事情。接下来我们介绍一下几种常见的合批处理。

## 合批技术分离线合批和实时合批。

### **一、离线合批（Offline Batch）**

离线合批就是在游戏运行前，先用工具把相关资源做合批处理，以减轻引擎实时合批的负担。

适合离线合批的是静态模型和场景物件。如场景地表装饰面：石头/砖块等等。

离线合批方式有：

- \1. 美术利用专业建模工具合批。如3D Max/Maya等。
- \2. 利用引擎插件或工具。如Unity的插件MeshBaker和DrawCallMinimizer，可以将静态物体进行合批。
- \3. 自制离线合批工具。如果第三方插件无法满足项目需求，就要程序专门实现离线合批工具。

### 二、实时合批**（Runtime Batch）**

> Unity引擎内建了两种合批渲染技术：Static batching（静态合批）和Dynamic batching（动态合批）。

**2.1 静态合批（Static batching）**

静态合批是勾选Static，Unity在Build的时候，会自动下生成合并的网格，并将它以文件形式存储合并后的数据，这样在当场景被加载时，一次性提交整个合并模型的顶点数据，根据引擎的场景管理系统判断各个子模型的可见性。然后设置一次渲染状态，调用多次Draw call分别绘制每一个子模型。

**2.1.1 使用**

> PlayerSettings中开启static batching，对需要静态合批物体的Static打钩即可

![img](https://pic3.zhimg.com/80/v2-656e644a57a1ac53f71dc37856b3fd4e_1440w.webp)

通过勾选开关标记单位参与静态合批

**2.1.2 前提：**

> **共享相同的材质**
> 运行时不能移动，旋转或缩放

**2.1.3 优点**

静态合批采用了以空间换时间的策略来提升渲染效率。

静态合批**并不减少Draw call的数量*****（**但是在编辑器时由于计算方法区别Draw call数量是会显示减少了的*[[2\]](https://zhuanlan.zhihu.com/p/356211912#ref_2)[[3\]](https://zhuanlan.zhihu.com/p/356211912#ref_3)*）*，但是由于我们预先把所有的子模型的顶点变换到了世界空间下，并且这些子模型共享材质，所以在多次Draw call调用之间并没有渲染状态的切换，渲染API会缓存绘制命令，起到了渲染优化的目的。另外，在运行时所有的顶点位置处理不再需要进行计算，节约了计算资源。

**2.1.4 缺点**

![img](https://pic2.zhimg.com/80/v2-1a8b59ba4328ea57454f7bb54c228cc5_1440w.webp)

包含静态合批的场景体积大了一丢丢

- 打包之后体积增大，应用运行时所占用的内存体积也会增大。
- 需要额外的内存来存储合并的几何体。
- 注意如果多个GameObject在静态批处理之前共享相同的几何体，则会在编辑器或运行时为每个GameObject创建几何体的副本，这会增大内存的开销。例如，在密集的森林级别将树标记为静态可能会产生严重的内存影响。
- 静态合批在大多数平台上的限制是64k顶点和64k索引

**2.2 动态合批（Dynamic batching）**

动态合批是专门为优化场景中共享同一材质的动态GameObject的渲染设计的。目标是以最小的代价合并小型网格模型，减少Drawcall。

动态合批的原理也很简单，在进行场景绘制之前将所有的共享同一材质的模型的顶点信息变换到世界空间中，然后通过一次Draw call绘制多个模型，达到合批的目的。模型顶点变换的操作是由CPU完成的，所以这会带来一些CPU的性能消耗。

**2.2.1 使用**

> Unity自动处理

**2.2.2 前提**

> **共享相同的材质**

**2.2.3 限制**

1，900个顶点以下的模型。
2，如果我们使用了顶点坐标，法线，UV，那么就只能最多300个顶点。
3，如果我们使用了UV0，UV1，和切线，又更少了，只能最多150个顶点。
4，如果两个模型**缩放大小**不同，不能被合批的，即模型之间的缩放必须一致。
5，合并网格的**材质球的实例**必须相同。即材质球属性不能被区分对待，材质球对象实例必须是同一个。
6，如果他们有**Lightmap数据，必须相同**的才有机会合批。
7，使用多个pass的Shader是绝对不会被合批。因为Multi-pass Shader通常会导致一个物体要连续绘制多次，并切换渲染状态。这会打破其跟其他物体进行Dynamic batching的机会。
8，延迟渲染是无法被合批。

除了上面这两种合批技术外，Unity还有一些其他合批技术，这边只做介绍，不进行展开

> **运行时静态合批(Static Batching In Runtime)：**其实就是运行时手动代码合批。
> Unity还提供了一种灵活度很高的运行时静态合批方法。我们可以在运行时调用合并函数：**StaticBatchingUtility.Combine**实现手动将一些模型合并成一个完整模型。

### 三、GPU Instancing 简单介绍

GPU Instancing 没有动态合批那样对网格数量的限制，也没有静态网格那样需要这么大的内存，它很好的弥补了这两者的缺陷，但也有存在着一些限制，我们下面来逐一阐述。

与动态和静态合批不同的是，GPU Instancing 并不通过对网格的合并操作来减少Drawcall，GPU Instancing 的处理过程是**只提交一个模型网格让GPU绘制很多个地方，这些不同地方绘制的网格可以对缩放大小，旋转角度和坐标有不一样的操作，材质球虽然相同但材质球属性可以各自有各自的区别。**

从图形调用接口上来说 GPU Instancing 调用的是 OpenGL 和 DirectX 里的**多实例渲染**接口。我们拿 OpenGL 来说:

```text
第一个是无索引的顶点网格集多实例渲染，
void glDrawArraysInstanced(GLenum mode, GLint first, GLsizei count, Glsizei primCount);
第二个是索引网格的多实例渲染，
void glDrawElementsInstanced(GLenum mode, GLsizei count, GLenum type, const void* indices, GLsizei primCount);
第三个是索引基于偏移的网格多实例渲染。
void glDrawElementsInstancedBaseVertex(GLenum mode, GLsizei count, GLenum type, const void* indices, GLsizei instanceCount, GLuint baseVertex);
```

这三个接口都会向GPU传入渲染数据并开启渲染，与平时渲染多次要多次执行整个渲染管线不同的是，这三个接口会分别将模型渲染多次，并且是在同一个渲染管线中。

如果只是一个坐标上渲染多次模型是没有意义的，我们需要将一个模型渲染到不同的多个地方，并且需要有不同的缩放大小和旋转角度，以及不同的材质球参数，这才是我们真正需要的。

GPU Instancing 正为我们提供这个功能，上面三个渲染接口告知Shader着色器开启一个叫 **InstancingID** 的变量，这个变量可以确定**当前着色计算的是第几个实例。**

有了这个 InstancingID 就能使得我们在多实例渲染中，辨识当前渲染的模型到底使用哪个属性参数。

Shader的顶点着色器和片元着色器可以通过这个变量来获取模型矩阵、颜色等不同变化的参数。我们来看看在**Unity3D的Shader**中我们应该做些什么:

GPU Instancing实操：[Testplus：U3D优化批处理-GPU Instancing了解一下](https://zhuanlan.zhihu.com/p/34499251)

### 四、SRP Batcher 简单介绍

**4.1 SRP Batcher 并不会减少 DrawCall，减少是 DrawCall 之间的 GPU 设置的工作量。**

> 因为 Unity 在发出 DrawCall 之前必须进行很多设置。实际的 CPU 成本便来自这些设置，而不是来自 GPU DrawCall 本身（DrawCall 只是 Unity 需要推送到 GPU 命令缓冲区的少量字节）。

**4.2 SRP Batcher 通过批处理一系列 Bind 和 Draw GPU 命令来减少 DrawCall 之间的 GPU 设置的工作量**。也就是之前一堆绑定和绘制的 GPU 命令，我们可以使用批处理减少绘制调用之间的 GPU 设置。

**4.3 SRP Batcher 兼容性**

- 为了使 SRP Batcher 代码路径能够渲染对象：

- - 渲染的对象必须是网格或蒙皮网格。该对象不能是粒子。
  - 着色器必须与 SRP Batcher 兼容。HDRP 和 URP 中的所有光照和无光照着色器均符合此要求（这些着色器的“粒子”版本除外）。

- 为了使着色器与 SRP Batcher 兼容：

- - 必须在一个名为“UnityPerDraw”的 CBUFFER 中声明所有内置引擎属性。例如：`unity_ObjectToWorld` 或 `unity_SHAr`。
  - 必须在一个名为 `UnityPerMaterial` 的 CBUFFER 中声明所有材质属性。

**4.4 SRPBatcher** **的应用**

- 应用1：

- - 常规优化手段，对于场景中大量存在且表现相同的物体会采用合并 Mesh 减少 DrawCall 的方式（静态批），而对于多种需要不同材质表现则无法合并，因为他们使用的不是同一个材质球。
  - 而 SRPBatcher 则可以批处理这些 Shader （使用的变体也相同）相同的物体。

- 应用2：

- - 直接使用 StaticBatcher 它内存消耗很高的情况下，在内存瓶颈的情况下，可以考虑使用 **SRPBatcher +** StaticBatcher 混用，进行内存优化。（但是要注意，在场景的复杂度很高的情况下，大概率会出现 drawcall 大幅度提升，导致帧率陡降。）