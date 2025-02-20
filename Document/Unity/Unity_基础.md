#### .Image和RawImage的区别

- Imgae比RawImage更消耗性能

- Image只能使用Sprite属性的图片，但是RawImage什么样的都可以使用

- Image适合放一些有操作的图片，裁剪平铺旋转什么的，针对Image Type属性

- RawImage就放单独展示的图片就可以，性能会比Image好很多




#### Unity3D中的碰撞器和触发器的区别

- 碰撞器是触发器的载体，而触发器只是碰撞器身上的一个属性


当Is Trigger=false时，碰撞器根据物理引擎引发碰撞，产生碰撞的效果，可以调用OnCollisionEnter/Stay/Exit函数；

当Is Trigger=true时，碰撞器被物理引擎所忽略，没有碰撞效果，可以调用OnTriggerEnter/Stay/Exit函数。

如果既要检测到物体的接触又不想让碰撞检测影响物体移动或要检测一个物件是否经过空间中的某个区域这时就可以用到触发器。



#### 物体发生碰撞的必要条件

两个物体都必须带有碰撞器Collider，其中一个物体还必须带有Rigidbody刚体。



#### 简述四元数Quaternion的作用，四元数对欧拉角的优点？

四元数用于表示旋转，相对欧拉角的优点：

- 能进行增量旋转

- 避免万向锁


给定方位的表达方式有两种，互为负（欧拉角有无数种表达方式）



#### 如何安全的在不同工程间安全地迁移asset数据？三种方法

- 将Assets和Library一起迁移

- 导出包package

- 用unity自带的assets Server功能




#### OnEnable、Awake、Start运行时的发生顺序？哪些可能在同一个对象周期中反复的发生？

- Awake–>OnEnable->Start

- OnEnable在同一周期中可以反复地发生




#### MeshRender中material和sharedmaterial的区别？

- 修改sharedMaterial将改变所有物体使用这个材质的外观，并且也改变储存在工程里的材质设置
- 不推荐修改由sharedMaterial返回的材质。如果你想修改渲染器的材质，使用material替代

```c#
private Renderer rend; // 获取渲染器组件
    
    private void SharedMaterialTest()
    {
        // 修改材质颜色（不推荐）
        // 不推荐直接使用 sharedMaterial 进行修改
        rend.sharedMaterial.color = Color.red;
    }

    private void MaterialTest()
    {
        // 修改材质颜色（推荐）
        // 推荐使用 material 进行修改，确保每个对象有自己的材质实例
        rend.material.color = Color.blue;
    }
```



#### Unity提供了几种光源，分别是什么

- 平行光：Directional Light

- 点光源：Point Light

- 聚光灯：Spot Light
- 区域光源：Area Light



#### 简述一下对象池，你觉得在FPS里哪些东西适合使用对象池

对象池就存放需要被反复调用资源的一个空间

比如游戏中要常被大量复制的对象，子弹，敌人，以及任何重复出现的对象。

特点：用内存换取cpu的优化



#### CharacterController和Rigidbody的区别

Rigidbody具有完全真实物理的特性

CharacterController可以说是受限的的Rigidbody，具有一定的物理效果但不是完全真实的。



#### 移动相机动作在哪个函数里，为什么在这个函数里

LateUpdate

在所有的Update结束后才调用，比较适合用于命令脚本的执行。 官网上例子是摄像机的跟随，都是所有的Update操作完才进行摄像机的跟进，不然就有可能出现摄像机已经推进了，但是视角里还未有角色的空帧出现。



#### 简述prefab的用处

- 在游戏运行时实例化

- prefab相当于一个模板，对你已经有的素材、脚本、参数做一个默认的配置，以便于以后的修改

- 同事prefab打包的内容简化了导出的操作，便于团队的交流。




#### GPU的工作原理？

GPU的工作通俗的来说就是完成3D图形的生成,将图形映射到相应的像素点上,对每个像素进行计算确定最终颜色并完成输出

1. **Vertex Shader顶点着色器**：电脑会在内部模拟出一个三维空间，并将这些顶点放置在这一空间内部。接着，投影在同一平面上，也是我们将看到的画面。同时，存下各点距离投影面的垂直距离
2. **primitive processing原始处理**：将相关的点链接在一起，以形成图形
3. **rasterisation光栅化**：显示器实际显示的图像是由像素组成的，我们需要将上面生成的图形上的点和线通过一定的算法转换到相应的像素点。把一个矢量图形转换为一系列像素点的过程就称为光栅化
4. **fragment shader片段着色器**：将格点化后的图形着上颜色
5. **testing and blending测试和混合**：便是将第一步所获得的投影垂直距离取出，和第四步的结果一同做最后处理。在去除被会被其他较近距离的物体挡住的物体后，让剩下的图形放进 GPU 的输出内存。之后，结果便会被送到电脑屏幕显示



#### 什么是渲染管道

是指在显示器上为了显示出图像而经过的一系列必要操作。 渲染管道中的很多步骤，都要将几何物体从一个坐标系中变换到另一个坐标系中去。

主要步骤有： 本地坐标->视图坐标->背面裁剪->光照->裁剪->投影->视图变换->光栅化。



#### 动态加载资源的方式?

- **instantiate**：最简单的一种方式，以实例化的方式动态生成一个物体。
- **Assetsbundle**：即将资源打成 asset bundle 放在服务器或本地磁盘，然后使用WWW模块get 下来，然后从这个bundle中load某个object，unity官方推荐也是绝大多数商业化项目使用的一种方式。
- **Resource.Load**:可以直接load并返回某个类型的Object，前提是要把这个资源放在Resource命名的文件夹下，Unity不管有没有场景引用，都会将其全部打入到安装包中
- **AssetDatabase.loadasset** ：这种方式只在editor范围内有效，游戏运行时没有这个函数，它通常是在开发中调试用的



#### 使用Unity3d实现2d游戏，有几种方式

- 使用本身的GUI、UGUI

- 把摄像机的Projection(投影)值调为Orthographic(正交投影)，不考虑z轴；

- 使用2d插件，如：2DToolKit、NGUI



#### 在物体发生碰撞的整个过程中，有几个阶段，分别列出对应的函数

三个阶段 ；OnCollisionEnter、 OnCollisionStay、 OnCollisionExit



#### Unity3d的物理引擎中，有几种施加力的方式，分别描述出来

rigidbody.AddForce：是一种相对简便的方式，通常用于一般的施加力的场景，作用在刚体的质心

rigidbody.AddForceAtPosition：允许更精确地控制力的作用点，适用于需要在刚体上特定位置施加力的情况，例如模拟碰撞



#### 什么叫做链条关节

Hinge Joint，可以模拟两个物体间用一根链条连接在一起的情况，能保持两个物体在一个固定距离内部相互移动而不产生作用力，但是达到固定距离后就会产生拉力。



#### 物体自身旋转使用的函数？

Transform.Rotate()



#### Unity3d提供了一个用于保存和读取数据的类(PlayerPrefs)，请列出保存和读取整形数据的函数

PlayerPrefs.SetInt()、 PlayerPrefs.GetInt()

官方文档：https://docs.unity3d.com/ScriptReference/PlayerPrefs.html



#### Unity3d脚本从唤醒到销毁有着一套比较完整的生命周期，请列出系统自带的几个重要的方法。

Awake——>Start——>Update——>FixedUpdate——>LateUpdate——>OnGUI——>OnDisable——>OnDestroy

主要执行顺序

1、编辑器->初始化->物理系统->输入事件->游戏逻辑->场景渲染->GUI渲染->物体激活或禁用->销毁物体->应用结束

主要函数介绍

1. Reset 是在用户点击检视面板的Reset按钮或者首次添加该组件时被调用。此函数只在编辑模式下被调用。Reset最常用于在检视面板中给定一个最常用的默认值。

2. Awake 用于在游戏开始之前初始化变量或游戏状态。在脚本整个生命周期内它仅被调用一次.Awake在所有对象被初始化之后调用，所以你可以安全的与其他对象对话或用诸如 GameObject.FindWithTag 这样的函数搜索它们。每个游戏物体上的Awke以随机的顺序被调用。因此，你应该用Awake来设置脚本间的引用，并用Start来传递信息 ,Awake总是在Start之前被调用。它不能用来执行协同程序。

3. OnDisable 不能用于协同程序。当对象变为不可用或非激活状态时此函数被调用。

4. Start 在behaviour的生命周期中只被调用一次。它和Awake的不同是Start只在脚本实例被启用时调用。你可以按需调整延迟初始化代码。Awake总是在Start之前执行。这允许你协调初始化顺序。

5. FixedUpdate 当MonoBehaviour启用时，其在每一帧被调用。处理Rigidbody时，需要用FixedUpdate代替Update。例如:给刚体加一个作用力时，你必须应用作用力在FixedUpdate里的固定帧，而不是Update中的帧。(两者帧长不同)。

6. OnTriggerEnter 可以被用作协同程序，在函数中调用yield语句。当Collider(碰撞体)进入trigger(触发器)时调用OnTriggerEnter。

7. OnCollisionEnter 相对于OnTriggerEnter，传递的是Collision类而不是Collider。Collision包含接触点，碰撞速度等细节。如果在函数中不使用碰撞信息，省略collisionInfo参数以避免不必要的运算。注意如果碰撞体附加了一个非动力学刚体，只发送碰撞事件。可以被用作协同程序。 当鼠标在GUIElement(GUI元素)或Collider(碰撞体)上点击时调用OnMouseDown。

8. Update 是实现各种游戏行为最常用的函数。

9. yield 一个协同程序在执行过程中,可以在任意位置使用yield语句。yield的返回值控制何时恢复协同程序向下执行。协同程序在对象自有帧执行过程中堪称优秀。协同程序在性能上没有更多的开销。StartCoroutine函数是立刻返回的,但是yield可以延迟结果。直到协同程序执行完毕。

10. LateUpdate 是在所有Update函数调用后被调用。这可用于调整脚本执行顺序。例如:当物体在Update里移动时，跟随物体的相机可以在LateUpdate里实现。 渲染和处理GUI事件时调用。这意味着你的OnGUI程序将会在每一帧被调用。要得到更多的GUI事件的信息查阅Event手册。如果Monobehaviour的enabled属性设为false，OnGUI()将不会被调用。

11. OnApplicationQuit，当用户停止运行模式时在编辑器中调用。当web被关闭时在网络播放器中被调用。




#### 物理更新一般放在哪个系统函数里？

FixedUpdate，每固定帧绘制时执行一次，和Update不同的是FixedUpdate是渲染帧执行，如果你的渲染效率低下的时候FixedUpdate调用次数就会跟着下降。

FixedUpdate比较适用于物理引擎的计算，因为是跟每帧渲染有关。 Update就比较适合做控制。



#### 在场景中放置多个Camera并同时处于活动状态会发生什么？

游戏界面可以看到很多摄像机的混合。



#### 如何销毁一个UnityEngine.Object及其子类？

Destroy();



#### 请描述游戏动画有哪几种，以及其原理？

主要有关节动画、骨骼动画、关键帧动画

- 关节动画：把角色分成若干独立部分，一个部分对应一个网格模型，部分的动画连接成一个整体的动画，角色比较灵活，Quake2中使用这种动画；多个Mesh

- 骨骼动画，广泛应用的动画方式，集成了以上两个方式的优点，骨骼按角色特点组成一定的层次结构，有关节相连，可做相对运动，皮肤作为单一网格蒙在骨骼之外，决定角色的外观；一个Mesh

- 关键帧动画由一个完整的网格模型构成，在动画序列的关键帧里记录各个顶点的原位置及其改变量，然后插值运算实现动画效果，角色动画较真实。




#### 请描述为什么Unity3d中会发生在组件上出现数据丢失的情况

一般是组件上绑定的物体对象被删除了



#### alpha blend工作原理

Alpha Blend 实现透明效果，不过只能针对某块区域进行alpha操作，透明度可设。



#### 写出光照计算中的diffuse的计算公式？

diffuse = Kd x colorLight x max(N*L,0)；Kd 漫反射系数、colorLight 光的颜色、N 单位法线向量、L 由点指向光源的单位向量、其中N与L点乘，如果结果小于等于0，则漫反射为0。



#### LOD是什么，优缺点是什么？

LOD(Level of detail)多层次细节，是最常用的游戏优化技术。 它按照模型的位置和重要程度决定物体渲染的资源分配，降低非重要物体的面数和细节度，从而获得高效率的渲染运算。

- **作用**：优化GPU
- **缺点**：同一模型要准备多个模型，消耗内存
- **特点**：以内存做消耗来优化GPU

LOD简单示例：[【100个 Unity踩坑小知识点】| Unity 的 LOD技术（多细节层次）](https://xiaoy.blog.csdn.net/article/details/122425837)



#### 两种阴影判断的方法、工作原理？

本影和半影：

- 本影：景物表面上那些没有被光源直接照射的区域（全黑的轮廓分明的区域）。

- 半影：景物表面上那些被某些特定光源直接照射但并非被所有特定光源直接照射的区域（半明半暗区域） 


工作原理：从光源处向物体的所有可见面投射光线，将这些面投影到场景中得到投影面，再将这些投影面与场景中的其他平面求交得出阴影多边形，保存这些阴影多边形信息，然后再按视点位置对场景进行相应处理得到所要求的视图（利用空间换时间，每次只需依据视点位置进行一次阴影计算即可，省去了一次消隐过程）



#### Vertex Shader是什么，怎么计算？

顶点着色器 是一段执行在GPU上的程序，用来取代fixed pipeline中的transformation和lighting，Vertex Shader主要操作顶点。

计算的主要步骤包括：

1. **坐标变换：** 将模型空间中的顶点坐标转换为世界空间、相机空间，最终转换为屏幕空间的坐标。这通常涉及到模型的平移、旋转和缩放等变换操作。
2. **法线变换：** 与坐标类似，法线是模型表面上的垂直方向。在顶点着色器中，法线通常也需要进行坐标变换，以便在后续的光照计算中使用。
3. **纹理坐标计算：** 如果模型需要贴上纹理，顶点着色器还会计算每个顶点的纹理坐标，用于纹理映射。
4. **颜色计算：** 顶点着色器可以计算顶点的颜色，这些颜色可以在后续的光照模型中使用，或者作为传递给片段着色器的插值颜色



#### MipMap是什么，作用？

MipMapping：在三维计算机图形的贴图渲染中有常用的技术，为加快渲染进度和减少图像锯齿，贴图被处理成由一系列被预先计算和优化过的**`图片组成的文件`**，这样的贴图被称为MipMap。



#### Unity3D是否支持写成多线程程序？如果支持的话需要注意什么

支持：如果同时你要处理很多事情或者与Unity的对象互动小可以用thread,否则使用coroutine。

Unity3d没有多线程的概念，不过unity也给我们提供了StartCoroutine（协同程序）和LoadLevelAsync（异步加载关卡）后台加载场景的方法。

注意：仅能从主线程中访问Unity3D的组件，对象和Unity3D系统调用。C#中有lock这个关键字,以确保只有一个线程可以在特定时间内访问特定的对象



#### 如何让已经存在的GameObject在LoadLevel后不被卸载掉？

```
DontDestroyOnLoad(transform.gameObject);
```



#### U3D中用于记录节点空间几何信息的组件名称，及其父类名称

Transform 父类是 Component



#### 向量的点乘、叉乘以及归一化的意义？

叉乘几何意义：得到一个与这两个向量都垂直的向量，这个向量的模是以两个向量为边的平行四边形的面积

点乘几何意义：可以用来表征或计算两个向量之间的夹角，以及在b向量在a向量方向上的投影

点乘描述了两个向量的相似程度，结果越大两向量越相似，还可表示投影

叉乘得到的向量垂直于原来的两个向量

标准化向量：用在只关系方向，不关心大小的时候



#### 矩阵相乘的意义及注意点？

用于表示线性变换：旋转、缩放、投影、平移、仿射

注意矩阵的蠕变：误差的积累



#### 当一个细小的高速物体撞向另一个较大的物体时，会出现什么情况？如何避免？

穿透（碰撞检测失败）（例如CS射击游戏，可以使用开枪时发射射线，射线碰撞到则掉血击中）

1. **减小时间步长：** 减小物理引擎的时间步长可以增加物体在每一帧内移动的距离，减小 tunneling 的可能性。然而，减小时间步长也可能对性能产生影响，需要谨慎调整。
2. **增加碰撞体精度：** 增加物体的碰撞体的精度和检测方法，例如使用更复杂的碰撞体形状、凸包（Convex Hull）等，可以提高碰撞检测的准确性。
3. **使用连续碰撞检测（CCD）：** 连续碰撞检测是一种高级的碰撞检测技术，可以在两个物体之间进行插值，以便在物体移动的过程中检测到碰撞。Unity 的物理引擎支持连续碰撞检测，可以通过 Rigidbody 的 `Rigidbody.collisionDetectionMode` 属性来设置。
4. **增加物体的质量：** 增加物体的质量可以减缓它的运动，降低碰撞的力度，减小 tunneling 的概率。
5. **手动处理碰撞：** 对于一些特殊情况，可能需要手动处理碰撞，例如在代码中检测碰撞并立即处理，而不依赖于物理引擎的碰撞检测。



#### 为何大家都在移动设备上寻求U3D原生GUI的替代方案

不美观，OnGUI很耗费时间，使用不方便



#### 简述NGUI中Grid和Table的作用

`Grid（网格）`：

- 作用：Grid 是一个简单的网格布局容器，用于将**子元素按行或列排列**，类似于二维数组的布局。每个子元素都位于网格中的一个单元格。
- 使用场景：当你希望以网格形式排列子元素时，可以使用 Grid。例如，游戏中的物品栏、九宫格图标等情况。

`Table（表格）`：

- 作用：Table 是一个更灵活的布局容器，可以根据需要**指定行数和列数**，同时支持**合并单元格和灵活的子元素布局**。
- 使用场景当你需要更复杂的表格布局时，或者希望在表格中进行合并单元格等高级布局操作时，可以使用 Table。例如，制作复杂的UI表格、排行榜等情况。



#### 请简述NGUI中Panel和Anchor的作用

`Panel（面板）`：

- 作用： Panel 是NGUI中最基本的UI容器，用于包裹和管理其他UI元素。它相当于一个矩形区域，用于限制和控制其子元素的显示范围，同时提供渲染和层级管理。
- 使用场景： 在一个Panel中，你可以添加按钮、文本、精灵等各种UI元素，并通过Panel来控制它们的显示和渲染。常见的应用场景包括游戏中的主界面、子界面、弹出窗口等。

`Anchor（锚点）`：

- 作用： Anchor 是用于定义UI元素相对于其父容器（通常是Panel）的位置和尺寸的工具。Anchor决定了UI元素的定位方式，包括左上、左下、右上、右下、中心等。
- 使用场景： 通过设置Anchor，你可以确保UI元素在不同屏幕分辨率和尺寸下保持相对位置和大小的一致性。这在移动设备、不同屏幕比例的设备上尤为重要，以适应各种屏幕。

综合起来，**Panel作为UI元素的容器，负责限制显示区域和管理层级关系，而Anchor用于控制UI元素相对于父容器的位置和尺寸，以适应不同的屏幕布局。这两者的配合使用使得NGUI具有强大的灵活性和适应性**。



#### 请简述如何在不同分辨率下保持UI的一致性

多屏幕分辨率下的UI布局一般考虑两个问题：

1、布局元素的位置，即屏幕分辨率变化的情况下，布局元素的位置可能固定不动，导致布局元素可能超出边界；

2、布局元素的尺寸，即在屏幕分辨率变化的情况下，布局元素的大小尺寸可能会固定不变，导致布局元素之间出现重叠等功能。

为了解决这两个问题，在Unity GUI体系中有两个组件可以来解决问题，分别是布局元素的Rect Transform和Canvas的Canvas Scaler组件。



#### 更新函数

- 第一帧更新前（初始化），Start：当脚本启用实例后，才会在第一帧更新前调用Start。更新顺序，游戏逻辑、交互、动画、摄像机位置，使用不同事件函数，绝大多数逻辑在Update。
- FixedUpdate（物理Physics）：固定更新频率，用作于物理渲染。调用此函数之后会执行物理计算和更新，Fixedupdate里计算运动，无需乘以Time.deltaTime，因为已有独立可靠计时器。调用FixedUpdate频率高于Update。
- Update：每一帧调用一次Update，帧更新主要函数，执行绝大多数逻辑。
- LateUpdate：每一帧在Update调用完毕后，调用LateUpdate。LateUpdate常用用途是跟随第三人称摄像机，保证角色在Update中的移动和旋转，在LateUpdate中执行所有摄像机的移动和旋转计算。确保角色在摄像机跟踪器位置之前已完全移动。



#### ScriptObject的作用和使用方式

ScriptObject类型经常使用于存储一些Unity本身不可以打包的一些object，比如字符串，一些类对象，用这个类型的子类型可以用BuildPipeline打包成assetbundle包共后续使用，非常方便。



#### 使用原生 GUI 创建一个可以拖动的窗口命令是什么

GUI.DragWindow();



#### 请简述OnBecameVisible及OnBecameInvisible的发生时机，以及这一对回调函数的意义

当物体是否可见切换之时。可以用于只需要在物体可见时才进行的计算。



#### 什么叫动态合批？跟静态合批有什么区别

`合批`是一种优化技术，用于减少绘制调用的数量，从而提高渲染性能。合批的主要目标是将多个游戏对象的渲染操作合并成一个，以减少渲染状态的切换和减轻渲染负担

如果动态物体共用着相同的材质，那么Unity会自动对这些物体进行批处理。 动态批处理操作是自动完成的，并不需要你进行额外的操作。

区别：动态批处理一切都是自动的，不需要做任何操作，而且物体是可以移动的，但是限制很多

​			静态批处理：自由度很高，限制很少，缺点可能会占用更多的内存，而且经过静态批处理后的所有物体都不可以再移动了。



#### 什么是LightMap

LightMap：就是指在三维软件里实现`打好光`，然后渲染把场景各表面的光照输出`到贴图上`，最后又通过引擎贴`到场景上`，这样就使物体有了光照的感觉。

光照贴图过程将预先计算场景中表面的亮度，并将结果存储在图表或“光照贴图”中供以后使用



#### Unity3D Shader分哪几种，有什么区别

- 表面着色器的抽象层次比较高，它可以轻松地以简洁方式实现复杂着色。表面着色器可同时在前向渲染及延迟渲染模式下正常工作。

- 顶点片段着色器可以非常灵活地实现需要的效果，但是需要编写更多的代码，并且很难与Unity的渲染管线完美集成。

- 固定功能管线着色器可以作为前两种着色器的备用选择，当硬件无法运行那些酷炫Shader的时，还可以通过固定功能管线着色器来绘制出一些基本的内容



#### 获取、增加、删除组件的命令分别是什么

- 获取：GetComponent

- 增加：AddComponent

- 删除：Destroy



#### Unity中，照相机的Clipping Planes的作用是什么?调整 Near、Far两个值时，应该注意什么

剪裁平面 。从相机到开始渲染和停止渲染之间的 距离。



#### 如何在Unity3D中查看场景的面数，顶点数和Draw Call数？如何降低Draw Call数

在Game视图右上角点击Stats。降低Draw Call 的技术是Draw Call Batching



#### 请问alpha test在何时使用？能达到什么效果

Alpha Test,中文就是透明度测试。 简而言之就是V&F shader中最后fragment函数输出的该点颜色值（即上一讲frag的输出half4）的alpha值与固定值进行比较。Alpha Test语句通常于Pass{}中的起始位置。Alpha Test产生的效果也很极端，要么完全透明，即看不到，要么完全不透明。



#### 四元数有什么作用

对旋转角度进行计算时用到四元数



#### 将Camera组件的ClearFlags选项选成Depth only是什么意思？有何用处

仅深度，该模式用于对象不被裁剪。



#### 在编辑场景时将GameObject设置为Static有何作用？

1、设置游戏对象为Static，当这些部分被静态物体挡住而不可见时将会剔除（或禁用）网格对象。进而在游戏的运行过程中让游戏有更加流畅的运行体验。

2、static下有很多的选项，例如Lightmap Static，指的是使用光照贴图对场景中的静态物体进行优化；Occluder static则是会在遮挡剔除中应用，当一个静态的物体被遮挡后，便不会渲染与之相关的信息。



####  有A和B两组物体，有什么办法能够保证A组物体永远比B组物体先渲染？

把A组物体的渲染对列大于B物体的渲染队列



#### 将图片的TextureType选项分别选为Texture和Sprite有什么区别

Sprite作为UI精灵使用，Texture作用模型贴图使用。



#### 问一个Terrain，分别贴3张，4张，5张地表贴图，渲染速度有什么区别？为什么

没有区别，因为不管几张贴图只渲染一次。



#### 什么是DrawCall？DrawCall高了又什么影响？如何降低DrawCall

Unity中，每次引擎准备数据并通知GPU的过程称为一次Draw Call。DrawCall越高对显卡的消耗就越大。降低DrawCall的方法：

- Dynamic Batching

- Static Batching

- 高级特性Shader降级为统一的低级特性的Shader




#### Addcomponent后哪个生命周期函数会被调用

对于AddComponent添加的脚本，其Awake，Start，OnEnable是在Add的当前帧被调用的，其中Awake，OnEnable与AddComponent处于同一调用链上，Start会在当前帧稍晚一些的时候被调用，Update则是根据Add调用时机决定何时调用：如果Add是在当前帧的Update前调用，那么新脚本的Update也会在当前帧被调用，否则会被延迟到下一帧调用



#### 实时点光源的优缺点是什么

可以有cookies – 带有 alpha通道的立方图(Cubemap )纹理。点光源是最耗费资源的。



#### 层剔除

用layermask ，通过位运算的方式去设置 在代码中使用时如何开启某个Layers？

LayerMask mask = 1 << 你需要开启的Layers层。

LayerMask mask = 0 << 你需要关闭的Layers层。

举几个例子：

```
LayerMask mask = 1 << 2; 表示开启Layer2。
LayerMask mask = 0 << 5;表示关闭Layer5。
LayerMask mask = 1<<2|1<<8;表示开启Layer2和Layer8。
LayerMask mask = 0<<3|0<<7;表示关闭Layer3和Layer7。
```



#### 分别解释顶点着色器和像素着色器是什么

- 顶点着⾊器是⼀段执⾏在GPU上的程序，⽤来取代 fixed pipeline中的transformation和lighting，Vertex Shader主要操作顶点。

- 像素着色器实际上就是对每一个像素进行光栅化【矢量图形转换为一系列像素点的过程】的处理期间，在GPU上运算的一段程序。不同与顶点着色器，像素着色器不会以软件的形式来模拟像素着色器。

- 像素着色器实质上是取代了固定功能流水线中多重纹理的环节，而且赋予了我们访问单个像素以及访问每一个像素纹理坐标的能力




#### 画布的三种模式.缩放模式

1. 屏幕空间-覆盖模式(Screen Space-Overlay)，Canvas创建出来后，默认就是该模式，该模式和摄像机无关，即使场景内没有摄像机，UI游戏物体照样渲染 
   - 屏幕空间：电脑或者手机显示屏的2D空间，只有x轴和y轴
   - 覆盖模式：UI元素永远在3D元素的前面
2. 屏幕空间-摄像机模式(Screen Space-Camera)，设置成该模式后需要指定一个摄像机游戏物体，指定后UGUI就会自动出现在该摄像机的“投射范围”内，和NGUI的默认UI Root效果一致，如果隐藏掉摄像机，UGUI当然就无法渲染

3. 世界空间模式(WorldSpace)，设置成该模式后UGUI就相当于是场景内的一个普通的“Cube 游戏模型”，可以在场景内任意的移动UGUI元素的位置，通常用于怪物血条显示和VR开发


缩放模式：

| Property:              | Function:                                    |
| ---------------------- | -------------------------------------------- |
| UI Scale Mode          | Canvas中UI元素的缩放模式                     |
| Constant Pixel Size    | 使UI保持自己的尺寸，与屏幕尺寸无关。         |
| Scale With Screen Size | 屏幕尺寸越大，UI越大                         |
| Constant Physical Size | 使UI元素保持相同的物理大小，与屏幕尺寸无关。 |

Constant Pixel Size、Constant Physical Size实际上他们本质是一样的，只不过 Constant Pixel Size 通过逻辑像素大小调节来维持缩放，而 Constant Physical Size 通过物理大小调节来维持缩放。



#### FSM有限状态机

FSM是一种数据结构，它由以下几个部分组成：

1. **内在的所有状态（必须是有限个）**

2. **输入条件**

3. **状态之间起到连接性作用的转换函数**


为什么要用FSM？

因为它编程快速简单t，易于调试，性能高，与人类思维相似从而便于梳理，灵活且容易修改

FSM的描述性定义： 一个有限状态机是一个设备，或是一个模型，具有有限数量的状态。它可以在任何给定时间根据输入进行操作，使得系统从一个状态转换到另一个状态，或者是使一个输出或者一种行为的发生，一个有限状态机在任何瞬间只能处于一种状态。

State 状态基类，定义了基本的Enter，Update，Exit三种状态行为，通常在这三种状态行为的方法里会写一些逻辑。每个State都会有StateID（状态id，可以是枚举等），FSMControl（控制该状态的状态控制器的引用），Check方法（用来进行状态判断，并返回StateID，通过FSMControl驱动）

FSMControl，包含了一下FSMMachine，封装层。

FSMMachine，驱动它的State列表，Update方法调用当前State的Check方法来获得StateID，当currentState的Check方法返回的StateID和当前StateID不同，则切换状态。

这是一个简单的FSM状态机系统，根据需要自己写个Control继承FSMControl来驱动状态。因为Check是State的职责，所以每一个不同对象的行为如Human的Idle和Dog的Idel区分肯定也不同。因此需要分别去写HumanIdleState和DogIdleState。如果还有Cat，Fish，可想而知代码量会有多么庞大。

因此我将FSMControl抽象为一个公共基类，把State的Check具体实现作为FSMControl的Virtual方法。这样在IdleState里的Check方法就不用写具体的状态切换判断逻辑，而是调用它FSMControl子类（自己写的继承自FSMControl的Control类）的重写方法

这样每次添加的新对象只要有Idle这个状态，就可以用一个公用的StateIdle，状态切换的逻辑差异放在Control层



#### 什么是状态机，什么是行为树？

1. `有限状态机系统`：是指在不同阶段会呈现出不同的运行状态的系统，这些状态是有限的、不重叠的。这样的系统在某一时刻一定会处于其所有状态中的一个状态，此时它接收一部分允许的输入，产生一部分可能的响应，并且迁移到一部分可能的状态。
   - 基本节点是状态：他包含了一系列运行在该状态的行为以及离开这个状态的条件。
   - 状态可以任意跳转,实现简单,但是对于大的状态机很难维护.状态逻辑的重用性低。
   - 每一个状态的逻辑会随着一些新状态的增加而越来越复杂。维持状态的数量和状态逻辑复杂性是一个很大的难点。需要合理的分割以及重用状态。
   - 状态机状态的复用性很差，一旦一些因素变化导致这个环境发生变化。你只能新增一个状态，并且给这个新状态添加连接他以及其他状态的跳转逻辑。
   - 状态机的跳转条件一旦不满足，就会一直卡在某一个状态。
2. `行为树`：一个流行的AI技术，涵盖了层次状态机，事件调度，事件计划，行为等一系列技术。
   - 高度模块化状态，去掉状态中的跳转逻辑，使得状态变成一个“行为”。
   - “行为”和”行为”之间的跳转是通过父节点的类型来决定的。比如并行处理两个行为，在状态机里面无法同时处理两个状态。
   - 通过增加控制节点的类型，可以达到复用行为的目的。
   - 可视化编辑。



#### 使用过哪些Unity插件

因人而异，可以去简单了解一下要说的插件，没用过也可以，至少你知道这个插件了！

| 插件名                                   | 作用               |
| ---------------------------------------- | ------------------ |
| shader graph                             | 制作shader光影效果 |
| cinemachine+timeline+postprocessingstack | 制作过场动画       |
| nodecanvas                               | 制作怪物ai         |
| easytouch                                | 手游触摸控制       |
| DoTween                                  | 动画插件           |
| Fungus                                   | 对话插件           |
| 3D WebView                               | 浏览器插件         |
| Vectrosity                               | 划线插件           |
| AVPro Video                              | 视频播放插件       |



#### 射线检测碰撞物的原理是？

答：射线是3D世界中一个点向一个方向发射的一条无终点的线，在发射轨迹中与其他物体发生碰撞时，它将停止发射 。



#### UGUI 合批的一些问题

简单来说在一个Canvas下，需要相同的material，相同的纹理以及相同的Z值。例如UI上的字体Texture使用的是字体的图集，往往和我们自己的UI图集不一样，因此无法合批。还有UI的动态更新会影响网格的重绘，因此需要动静分离



#### Avator的作用

**在Unity中是连接动画系统和3D模型的重要中介**。它使得不同的动画资源能够在相同的3D模型上正确播放，支持动画混合和匹配，以及在一些情况下，允许更高级的运动学效果。 Avatar的正确设置对于实现流畅且准确的角色动画至关重要。

用户提供的模型骨架和Unity骨架结构进行适配，是一种骨架映射关系。 方便动画的重定向

AnimationType有三种类型 

Humanoid人型：可以动画重定向，游戏对象挂载animator，子类原始模型+重定向模型，

Generic非人型 

Legacy旧版 

Avator Mask身体遮罩，身体某一部分是否受到动画影响

反向动力学 IK，通过手或脚来控制身体其他部分



#### 反向旋转动画的方法是什么

将动画速度调成-1，animation.speed=-1



#### Animation.CrossFade 是什么

动画淡入淡出



#### 写出 Animation 的五个方法

- AddClip 将 clip 添加到名称为 newName 的动画中

- Blend 在后续 time 秒中将名称为 animation 的动画向 targetWeight 混合

- CrossFade 在后续 time 秒的时间段内，使名称为 animation 的动画淡入，使其他动画淡出

- CrossFadeQueued 使动画在上一个动画播放完成后交叉淡入淡出

- IsPlaying 名称为 name 的动画是否正在播放

- PlayQueued 在先前的动画播放完毕后再播放动画

- RemoveClip 从动画列表中移除剪辑

- Sample 对当前状态的动画进行采样

- Stop 停止所有使用该动画启动的正在播放的动画




#### 简述 SkinnedMesh 的实现原理

SkinnedMesh中文一般称作骨骼蒙皮动画，正如其名，这种动画中包含**骨骼（Bone）**和**蒙皮(Skinned Mesh)**两个部分

Bone的层次结构和关节动画类似；Mesh则和关节动画不同：关节动画中是使用多个分散的Mesh，而Skinned Mesh中**Mesh是一个整体**，也就是说只有一个Mesh。实际上如果没有骨骼让Mesh运动变形，Mesh就和静态模型一样了。

Skinned Mesh技术的**精华在于蒙皮**，所谓的皮并不是模型的贴图，而是Mesh本身，**蒙皮是指将Mesh中的顶点附着（绑定）在骨骼之上，而且每个顶点可以被多个骨骼所控制，这样在关节处的顶点由于同时受到父子骨骼的拉扯而改变位置就消除了裂缝**。所以Skinned Mesh这个词从字面上理解似乎是有皮的模型。

参考文档：http://blog.csdn.net/n5/article/details/3105872



#### 动画层(Animation Layers)的作用是什么？

动画分层

身体部位动画分层，比如我只想动动头，身体其他部分不发生动画，可以方便处理动画区分



#### Coroutine 的作用

协程Coroutine在Unity中一直扮演者重要的角色。 可以实现简单的计时器、将耗时的操作拆分成几个步骤分散在每一帧去运行等等，而尽量不阻塞主线程运行。



#### 什么是协同程序?

在主线程运行时同时开启另一段逻辑处理，来协助当前程序的执行。 换句话说，开启协程就是开启一个线程。可以用来控制运动、序列以及对象的行为。

update 函数返回后将运行正常协程更新。协程是一个可暂停执行 (yield) 直到给定的 YieldInstruction 达到完成状态的函数。

协程的不同用法：

yield 在下一帧上调用所有 Update 函数后，协程将继续。

yield WaitForSeconds 在为帧调用所有 Update 函数后，在指定的时间延迟后继续协程

yield WaitForFixedUpdate 在所有脚本上调用所有 FixedUpdate 后继续协程

yield WWW 在 WWW 下载完成后继续。

yield StartCoroutine 将协程链接起来，并会等待 MyFunc 协程先完成。



#### Unity3D的协程和C#线程 之间的区别是什么?

1. 执行上下文：
   - 协程： 在Unity中，协程是在主线程中运行的。它们允许在一帧之间分割执行，因此适用于处理异步任务、动画、等待一定时间后执行等操作。
   - 线程： 线程是独立于主线程的执行单元，它在自己的执行上下文中运行。在C#中，直接操作Unity的渲染和物理系统等可能导致不可预测的问题。
2. 性能开销：
   - 协程： 协程的开销较小，适用于处理较轻量级的任务。由于在主线程中运行，它们不会引入多线程的复杂性。
   - 线程： 线程的创建和管理会引入较大的性能开销，而且在多线程环境中需要考虑同步和竞态条件等问题。
3. 操作Unity对象：
   - 协程： 协程可以直接操作Unity对象，例如启动协程等待一段时间后执行某操作。
   - 线程： 在C#中，直接在其他线程中操作Unity对象可能导致异常，因为Unity的API通常要求在主线程中调用。
4. 等待操作：
   - 协程： 协程使用`yield return`语句来等待异步操作，例如`yield return new WaitForSeconds(1.0f)`等待一秒钟。
   - 线程： 在线程中通常使用`Thread.Sleep`等方法来等待一段时间，但这会阻塞整个线程。
5. 多线程安全：
   - 协程： 由于在主线程中运行，协程天然是单线程的，不需要考虑多线程安全问题。
   - 线程： 线程可能需要考虑多线程安全问题，如使用锁来保护共享资源，以防止竞态条件等问题。

总体而言，协程适用于处理与Unity主线程交互的轻量级异步任务，而线程则适用于需要并行执行的较重任务。在使用线程时，需要小心处理多线程带来的同步和竞态条件等问题。在Unity中，协程是处理异步任务的一种更常见和推荐的方式



#### 协同程序的执行代码是什么？有何用处，有何缺点? 

- 作用：一个协同程序在执行过程中,可以在任意位置使用yield语句。yield的返回值控制何时恢复协同程序向下执行
- 协同程序在对象自有帧执行过程中堪称优秀。协同程序在性能上没有更多的开销
- 协同程序并非真线程，可能会发生堵塞



#### Unity常用资源路径有哪些

```
//获取的目录路径最后不包含  
//获得的文件路径开头包含 
Application.dataPath; //Asset文件夹的绝对路径
//只读
Application.streamingAssetsPath;  //StreamingAssets文件夹的绝对路径（要先判断是否存在这个文件夹路径）
Application.persistentData ; //可读写
//资源数据库 (AssetDatabase) 是允许您访问工程中的资源的 API
AssetDatabase.GetAllAssetPaths; //获取所有的资源文件（不包含meta文件）
AssetDatabase.GetAssetPath(object) //获取object对象的相对路径
AssetDatabase.Refresh(); //刷新
AssetDatabase.GetDependencies(string); //获取依赖项文件
Directory.Delete(p, true); //删除P路径目录
Directory.Exists(p);  //是否存在P路径目录
Directory.CreateDirectory(p); //创建P路径目录
AssetDatabase //类库，对Asset文件夹下的文件进行操作，获取相对路径，获取所有文件，获取相对依赖项
Directory //类库，相关文件夹路径目录进行操作，是否存在，创建目录，删除等操作
```



#### Unity 特殊的专属文件夹

Editor：编辑器相关的资源可以放入此文件中，包含图片、脚本等文件。

Editor Default Resources：配和Editor使用，不会打包到包中增大包体大小。

Plugins：存放第三方SDK、插件等资源。

StreamingAssets：Assets下根目录，不会压缩资源，属于只读。常见的代码调用：

```csharp
#if UNITY_EDITOR
string filepath = Application.dataPath +"/StreamingAssets"+"/filename";
#elif UNITY_IPHONE
 string filepath = Application.dataPath +"/Raw"+"/filename";
#elif UNITY_ANDROID
 string filepath = "jar:file://" + Application.dataPath + "!/assets/"+"/filename;
#endif
```

应用安装后才会创建可读可写的目录：可读可写，代码访问：Application.persistentDataPath。

官方链接：https://docs.unity3d.com/cn/current/Manual/SpecialFolders.html



#### AssetsBundle 打包

```c#
using UnityEditor;
using System.IO;
public class CreateAssetBundles //进行AssetBundle打包
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
		string dir = "AssetBundles";
        if (Directory.Exists(dir) == false)
        {
            Directory.CreateDirectory(dir);
        }
    	BuildPipeline.BuildAssetBundles(dir, //路径必须创建
   		BuildAssetBundleOptions.ChunkBasedCompression, //压缩类型***
    	BuildTarget.StandaloneWindows64);//平台***
    }
 }
```

| None                    | Build assetBundle   without any special option.（LAMA压缩，压缩率高，解压久） |
| ----------------------- | ------------------------------------------------------------ |
| UncompressedAssetBundle | Don’t compress the  data when creating the asset bundle.（不压缩，解压快） |
| ChunkBasedCompression   | Use chunk-based LZ4  compression when creating the AssetBundle. |

（压缩率比LZMA低，解压速度接近无压缩）|



#### AssetBundle加载

1. LoadFromMemory(LoadFromMemoryAsync)
2. LoadFromFile（LoadFromFileAsync）

3. UnityWebRequest

4. LoadAssetsByWWW(LoadFromCacheOrDownload)

##### 第一种 LoadFromMemory(LoadFromMemoryAsync)

```
IEnumerator Start(){
  string path = "AssetBundles/wall.unity3d";
 
  AssetBundleCreateRequest request =AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path));
 
  yield return request;
  
  AssetBundle ab = request.assetBundle;
  
  GameObject wallPrefab = ab.LoadAsset<GameObject>("Cube");
  
  Instantiate(wallPrefab);}
```

##### 第二种 LoadFromFile（LoadFromFileAsync）

```
IEnumerator Start(){
string path = "AssetBundles/wall.unity3d";
 
  AssetBundleCreateRequest request = AssetBundle.LoadFromFileAsync(path);
 
  yield return request;
 
  AssetBundle ab = request.assetBundle;
 
  GameObject wallPrefab = ab.LoadAsset<GameObject>("Cube");
 
  Instantiate(wallPrefab);}
```

##### 第三种 UnityWebRequest

```c#
private IEnumerator TestUnityWebRequest()
    {
        //string uri = @"http://localhost/AssetBundles/cubewall.unity3d";
        string path = Application.dataPath + "/5.AB打包/AB/cubesphere";
        using (UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path))
        {
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success) // 处理请求的结果
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request); // 获取 AssetBundle
                GameObject wallPrefab = bundle.LoadAsset<GameObject>("CubeSphere_1");
                wallPrefab.name = "UnityWebRequest";
                Instantiate(wallPrefab);
            }
            else
            {
                Debug.LogError("未能下载AssetBundle,错误: " + request.error);
            }
        }
    }
```

##### 第四种WWW（无依赖）

```
private IEnumerator LoadNoDepandenceAsset()
    {
        string path = "";
        
        if (loadLocal)
        {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
            path += "File:///";
#endif
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
            path += "File://";
#endif
            path += assetBundlePath + "/" + assetBundleName;
            
            //www对象
            WWW www = new WWW(path);
 
            //等待下载【到内存】
            yield return www;
 
            //获取到AssetBundle
            AssetBundle bundle = www.assetBundle;
 
            //加载资源
            GameObject prefab = bundle.LoadAsset<GameObject>(assetRealName);
 
            //Test:实例化
            Instantiate(prefab);
        }
```

##### 第四种WWW（有依赖）

```c#
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
 public class LoadAssetsDemo : MonoBehaviour{
    [Header("版本号")]
    public int version = 1;
    
    [Header("加载本地资源")]
    public bool loadLocal = true;
    [Header("资源的bundle名称")]
    public string assetBundleName;
    [Header("资源的真正的文件名称")]
    public string assetRealName;
    
    //bundle所在的路径
    private string assetBundlePath;
    //bundle所在的文件夹名称
    private string assetBundleRootName;
 
    private void Awake()
    {
        assetBundlePath = Application.dataPath + "/OutputAssetBundle";
        assetBundleRootName = assetBundlePath.Substring(assetBundlePath.LastIndexOf("/") + 1);
        
        Debug.Log(assetBundleRootName);
    }
 
IEnumerator LoadAssetsByWWW()
 {
   string path="";//判断是不是本地加载
   if(loadLocal)// loadLocal=true为本地资源
   {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
        path+="File:///";
#endif
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
        path+="File://";
#edif
   }
   path+=assetBundle+"/"+assetBundleRootName; //获取要加载的资源路径【bundle的总说明文件】
  
   WWW www=WWW.LoadFromCacheOrDownload(path,version);  //加载
   yield return www;
   AssetBundle manifestBundle=www.assetsBundle; //拿到其中的bundle
   //获取到说明文件
   AssetBundleManifest manifest=manifest.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
   //获取资源的所有依赖
   string[] dependencies=manifest.GetAllDependencies(assetBundleName);
   //卸载Bubdle和解压出来的manifest对象
   manifestBundle.Unload(true);
   //获取到相对路径
   path =path.Remove(path.LastIndexOf("/")+1);
   //声明依赖的Bundle数组
   AssetBundle[] depAssetBundle=new AssetBundle[dependencies.Length];
   
   for(int i=0;i<dependencies.Length;i++) //遍历加载所有的依赖
   {  
		string depPath=path+ dependencies[i]; //获取到依赖Bundle的路径
		www=WWW.LoadFromCacheOrDownload(depPath,version); //获取新的路径进行加载
		yield return www;
		depAssetBundles[i]=www.assetsBundle; //将依赖临时保存
 }
   //获取路径
   path+=assBundleName;
   //加载最终资源
   www=WWW.LoadFromCacheOrDownload(path,version);
   //等待下载
   yield return www;
   //获取到真正的AssetBundle
   AssetBundle realAssetBundle=www.assBunle;
   //加载真正的资源
   GameObject prefab=realAssetBundle.LoadAsset<GameObject>(assetBundle);
   //生成
   Instantiate(prefab);
 
   //卸载依赖
   for(int i-0;i<depAssetBundle.Length;i++){
   depAssetBundle[i].Unload(true);}
   realAssetBundle.Unload(true);}
 }
```

 

#### AssetBundle卸载流程

AssetBundle.Unload(bool)

T true卸载所有资源

false只卸载没使用的资源，而正在使用的资源与AssetBundle依赖关系会丢失，调用Resources.UnloadUnusedAssets可以卸载。

或者等场景切换的时候自动调用Resources.UnloadUnusedAssets。



#### 客户端与服务器交互方式有几种？

长连接模式（Socket）与短链接模式（Http）

- socket通常也称作"套接字",实现服务器和客户端之间的物理连接，并进行数据传输，主要有UDP和TCP两个协议。Socket处于网络协议的传输层。

- 协议传输的主要有http协议 和基于http协议的Soap协议（web service）,常见的方式是 http 的post 和get 请求，web 服务。 




#### 概述序列化

简单理解成把对象转换为容易传输的格式的过程。 ⽐如，可以序列化⼀个对象，然后使⽤HTTP通过Internet在客户端和服务器端之间传输该对象



#### UDP/TCP含义，区别

UDP协议全称是用户数据报协议

- 面向无连接

- 面向报文

- 不可靠性

- 有单播，多播，广播的功能

- 头部开销小，传输数据报文时是很高效的

TCP协议全称是传输控制协议是一种面向连接的、可靠的、基于字节流的传输层通信协议。三次握手、四次挥手

-  面向连接
-  仅支持单播传输
-  面向字节流
-  可靠传输
-  提供拥塞控制
- TCP提供全双工通信
-  三次握手【1-2-1】
   - 客户端发送同步包告诉服务器想连接并进入等待
   -  服务器收到同步包后回复同步包+ack包并进入等待
   -  客户端收到同步包和ack包后，发送ack包确认并修改状态，服务器收到ack包修改连接状态
-  四次挥手【1-2-2-1】
   - 客户端 向服务器发送一个 **FIN**（结束）包，还可以接收
   - 服务器收到结束包，发送ack包确认
   - 服务器发送完ack后如果没有数据则发送**FIN**（结束）包
   - 客户端收到服务器的 **FIN** 包后，回复一个 **ACK** 包，确认断开连接并等待一会。服务器收到连接关闭






#### TCP/IP协议栈各个层次及分别的功能？

- 接口层：这是协议栈的最低层，对应OSI的物理层和数据链路层，主要完成数据帧的实际发送和接收

- 网络层：处理分组在网络中的活动，例如路由选择和转发等，这一层主要包括IP协议、ARP、ICMP协议等。

- 传输层：主要功能是提供应用程序之间的通信，这一层主要是TCP/UDP协议

- 应用层：用来处理特定的应用，针对不同的应用提供了不同的协议，例如进行文件传输时用到的FTP协议，发送email用到的SMTP等



#### 写出WWW的几个方法

1、WWW.LoadFromCacheOrDownload：可被用于将Assets Bundles自动缓存到本地磁盘

2、WWW.Dispose ：释放现有的 WWW 对象。

3、WWW.isDone：是否完成下载？（只读）

4、WWW.progress：下载进度（只读）。



#### Socket粘包

**粘包**：就是多个独立的数据包连到一块儿。

什么情况下需要考虑粘包？ 答：实际情况如下：

- 如果利用tcp每次发送数据，就与对方建立连接，然后双方发送完一段数据后，就关闭连接，这样就不会出现粘包问题。

- 如果发送的数据无结构，比如文件传输，这样发送方只管发送，接收方只管接收存储就ok，也不用考虑粘包。

- 如果双方建立连接，需要在连接后一段时间内发送不同结构数据，如连接后，有好几种结构： 1)”good good study” 2)”day day up” 那这样的话，如果发送方连续发送这个两个包出去，接收方一次接收可能会是”good good studyday day up” 这样接收方就傻了，因为协议没有规定这么奇怪的字符串，所以要把它分包处理，至于怎么分也需要双方组织一个比较好的包结构，所以一般可能会在头加一个数据长度之类的包，以确保接收。


所以说：Tcp连续发送消息的时候，会出现消息一起发送过来的问题，这时候需要考虑粘包的问题。

**粘包出现的原因** (在流传输中，UDP不会出现粘包，因为它有消息边界。)

- 发送端需要等缓冲区满才发送出去，造成粘包 (发送端出现粘包)

- 接收端没有及时接收缓冲区包数据，造成一次性接收多个包，出现粘包 (接收端出现粘包)


**解决粘包**

- 缓冲区过大造成了粘包，所以在发送/接收消息时先将消息的长度作为消息的一部分发出去，这样接收方就可以根据接收到的消息长度来动态定义缓冲区的大小。（这种方法就是所谓的自定义协议，这种方法是最常用的）

- 对发送的数据进行处理，每条消息的首尾加上特殊字符，然后再把要发送的所有消息放入一个字符串中，最后将这个字符串发送出去，接收方接收到这个字符串之后，再通过特殊标记操作字符串，把每条消息截出来。(这种方法只适合数据量较小的情况)


注：要记住这一点：TCP对上层来说是一个流协议，所谓流,就是没有界限的一串数据.大家可以想想河里的流水,是连成一片的,其间是没有分界线的，也就是没有包的概念。所以我们必须自己定义包长或者分隔符来区分每一条消息。



#### Socket的封包、拆包

**为什么基于TCP的通信程序需要封包、拆包?**

- TCP是流协议，所谓流，就是没有界限的一串数据。但是程序中却有多种不同的数据包，那就很可能会出现如上所说的粘包问题，所以就需要在发送端封包，在接收端拆包。

**如何封包、拆包？**

- 封包就是给一段数据加上包头或者包尾。比如说我们上面为解决粘包所使用的两种方法，其实就是封包与拆包的具体实现。



#### Socket 客户端 队列 的问题

项目中采用了socket通信，通过TCP发送数据给服务器端，因为项目需要，要同时开启大量的线程去发送不同的数据给服务器端，然后服务器端返回不同的数据。由于操作频繁，经常会阻塞，或没有接收到服务器端返回的数据；

因此考虑到使用一个队列：将同一ip下的数据存入一个队列中，通过队列协调发送；当第一条数据发送出去没有收到服务器端返回的数据时，让第二条数据插入队列中排队，当第三条数据也发送出来后，继续排队，以此类推；

如果当第四条数据发出来的时候，存入队列中，第一条数据收服务器端返回数据后，队列中的第二条第三条数据就扔掉，直接发送第四条数据



#### 如何处理网络异常下的可玩性

- 为游戏增加单机模式：比如故事模块，网络异常时可以阅读游戏的故事；丰富的技能或卡牌，网络异常时可以了解技能和卡牌；提供单机玩法，玩家可以与AI进行游戏等。

- 为游戏提供教程模块，网络异常时可以学习游戏技巧。



#### 怎样反外挂？ 对外挂的看法？

游戏外挂的原理：外挂分为多种，比如模拟键盘的，鼠标的；修改数据包的；修改本地内存的。

a. 对于模拟用户的鼠标键盘输入的外挂，我们可以用网页上常用的验证码的方式来对付。模拟键盘鼠标的外挂对游戏的影响比加速、修改封包、修改内存、脱机等要小得多，因此被一些人称为绿色外挂。

b. 让服务器不把在正常情况下玩家看不到的东西的数据传送给客户端。

c. 把玩家操作记录发到服务器进行模拟，如果和客户端的计算结果偏差较大可以认为作弊。



#### 简述水面倒影的渲染原理？

原理就是对水面的贴图纹理进行扰动，以产生波光玲玲的效果



#### Unity的Shader中，Blend SrcAlpha OneMinusSrcAlpha这句话是什么意思？

作用就是Alpha混合。公式：最终颜色 = 源颜色源透明值 + 目标颜色（1 - 源透明值）



#### 贴图透明通道分离，压缩格式设为ETC/PVRTC

最初我们使用了DXT5作为贴图压缩格式，希望能减小贴图的内存占用，但很快发现移动平台的显卡是不支持的。因此对于一张1024x1024大小的RGBA32贴图，虽然DXT5可将它从4MB压缩到1MB，但系统将它送进显卡之前，会先用CPU在内存里将它解压成4MB的RGBA32格式（软件解压），然后再将这4MB送进显存。于是在这段时间里，这张贴图就占用了5MB内存和4MB显存；而移动平台往往没有独立显存，需要从内存里抠一块作为显存，于是原以为只占1MB内存的贴图实际却占了9MB！

所有不支持硬件解压的压缩格式都有这个问题。经过一番调研，我们发现安卓上硬件支持最广泛的格式是ETC，苹果上则是PVRTC。但这两种格式都是不带透明（Alpha）通道的。因此我们将每张原始贴图的透明通道都分离了出来，写进另一张贴图的红色通道里。这两张贴图都采用ETC/PVRTC压缩。渲染的时候，将两张贴图都送进显存。同时我们修改了NGUI的shader，在渲染时将第二张贴图的红色通道写到第一张贴图的透明通道里，恢复原来的颜色：

```
fixed4 frag (v2f i) : COLOR  
 
    fixed4 col;  
 
    col.rgb = tex2D(_MainTex, i.texcoord).rgb;  
 
    col.a = tex2D(_AlphaTex, i.texcoord).r;  
 
    return col * i.color;  
 
fixed4 frag (v2f i) : COLOR
 {
 
    fixed4 col;
 
    col.rgb = tex2D(_MainTex, i.texcoord).rgb;
 
    col.a = tex2D(_AlphaTex, i.texcoord).r;
 
    return col * i.color;
 }
```

 

#### 关闭贴图的读写选项

Unity中导入的每张贴图都有一个启用可读可写（Read/Write Enabled）的开关，对应的程序参数是TextureImporter.isReadable。

选中贴图后可在Import Setting选项卡中看到这个开关。只有打开这个开关，才可以对贴图使用Texture2D.GetPixel，读取或改写贴图资源的像素，但这就需要系统在内存里保留一份贴图的拷贝，以供CPU访问。 

一般游戏运行时不会有这样的需求，因此我们对所有贴图都关闭了这个开关，只在编辑中做贴图导入后处理（比如对原始贴图分离透明通道）时打开它。 这样，上文提到的1024x1024大小的贴图，其运行时的2MB内存占用又可以少一半，减小到1MB。



#### **ugui合批的计算方式**

是通过将使用相同材质的UI元素合并为一个渲染批次，从而减少渲染调用，提高性能



#### UGUI中mask和rectmask2d是怎么实现遮罩的

1. Mask会赋予Image一个特殊的材质，这个材质会给Image的每个像素点进行标记，将标记结果存放在一个缓存内（这个缓存叫做 **Stencil Buffer**）。当子级UI进行渲染的时候会去检查这个 Stencil Buffer内的标记，如果当前覆盖的区域存在标记（即该区域在Image的覆盖范围内），进行渲染，否则不渲染
2. C#层：找出父物体中所有RectMask2D覆盖区域的交集（FindCullAndClipWorldRect）
   C#层：所有继承MaskGraphic的子物体组件调用方法设置剪裁区域（SetClipRect）传递给Shader
   Shader层：接收到矩形区域_ClipRect，片元着色器中判断像素是否在矩形区域内，不在则透明度设置为0（UnityGet2DClipping ）
   Shader层：丢弃掉alpha小于0.001的元素（clip (color.a - 0.001)）内部用到的算法



#### UGUI中如何让粒子特效在UI中实现排序，遮挡，裁剪等等

1. Render Mode（渲染模式）：确保粒子系统的 Render Mode 设置为 World Space（世界空间）。这样可以将粒子特效从屏幕空间移动到世界空间，使其可以与UI元素进行更自由的交互。
2. Sorting Layer 和 Order in Layer（排序层和排序顺序）：使用 Sorting Layer 和 Order in Layer 来调整粒子特效的渲染顺序。你可以将粒子特效设置在UI元素之上或之下，以实现遮挡和排序效果。在 Particle System 组件的 Renderer 模块中找到 Sorting Layer 和 Order in Layer 设置。
3. 使用Canvas组件：如果你想要更细粒度地控制粒子特效与UI的交互，可以考虑将粒子特效嵌套在Canvas组件内。Canvas的 Render Mode 设置为 World Space，确保 Canvas 的 Sorting Layer 和 Order in Layer 设置适当，以影响其子对象（包括粒子特效）的渲染顺序。
4. Camera设置：在使用世界空间的粒子特效时，你可能需要在场景中添加一个Camera用于渲染3D物体。这个Camera的设置可能需要调整，例如，确保它不会渲染到UI的Camera上，或者通过调整Culling Mask来限定它的渲染范围。
5. 裁剪效果：如果希望粒子特效在UI元素内部进行裁剪，可以使用 RectMask2D 或者将粒子特效放在裁剪区域内的遮罩中。这可以通过在UI中创建相应的遮罩元素，然后将粒子特效放置在遮罩内来实现。


