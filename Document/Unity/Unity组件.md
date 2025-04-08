##### Mesh Filter（网格过滤器）组件

单纯保存了一个网格信息。作为单独组件可以和多个不同的Render进行组合

------

##### Mesh Render（网格渲染）组件

用于渲染Mesh Filter组件中的模型。渲染静态物体，所以不能对模型播放动画

------

##### Skinned Mesh Render（蒙皮网格渲染）组件

- 记录骨骼与模型顶点的权重信息
- 比Mesh Render组件多了一些额外信息，其中Mesh表示模型的网格资源，RootBone表示根节点骨骼
- 绑定根节点骨骼的意思是当播放骨骼动画是从这个节点下开始找对应的骨骼节点

------

##### EventSystem组件

用于监听游戏事件

------

##### CanvasRender组件

UGUI中所有UI单元都需要绑定它才能参与渲染

<img src="..\Texture\Unity\003.png" align="left"/>

- Cull Transparent Mesh：

  表示是否过滤透明像素，原理是使用Shader的Alpha Test功能，在片元着色器上判断当前是不是透明像素，如果已经是透明像素了，就直接把这个像素丢弃

------

##### Text组件

自带的Text比较占内存，无法提供图文混排功能

<img src="..\Texture\Unity\001.png" style="zoom:67%;" align="left" />

- Rich Text：是否支持富文本

  <img src="..\Texture\Unity\002.png" style="zoom:67%;" align="left"/>

- Maskable:表示当前文本是否可以被Mask或者RectMask2D裁掉

- Best Fit:显示文本时忽略设置的字体大小，采用Min Size和Max Size的大小，尽可能将文本装在文本框中

- Raycast Target:表示当前文本是否接受点击事件。不需要点击的UI尽量不要勾选它，否则会带来额外的性能消耗

- Raycast Padding:希望文本的显示区域和点击区域不同，可以通过它上下左右的偏移量来实现

------

##### 描边和阴影

Text会先根据文字对应的Unicode码在TTF字体库中提取字的型号，然后将它绘制在Font纹理位图中。这样每个字形都能确定一个矩形区域，再配合Text中设置的字体大小，就能计算出文字的包围盒。根据包围盒的大小，用两个三角形面就能确定一个字体渲染的Mesh.
Text提取字型号--->绘制在Font位图--->每个字形的矩形区域和字体大小--->计算文字包围盒--->两个三角面确定Mesh

为了得到好的描边结果，UGUI采用的方式是额外生成4个面片，在上下左右四个方向上各绘制1次，再加上原来的1次文字绘制，一个描边需要画5次才能完成。

示例：原本5和汉子只需要10个三角面，因为加了描边，所以多画了4次，一共50个三角面。主摄像机带了4个三角面，所以54个三角面。
<img src="..\Texture\Unity\004.png"  align="left"  />











在描边的基础上继续添加阴影，三角面的数量（不包括主摄像机的数量4个）翻了一倍。原因是**阴影需要对每个文字的面片增加一倍的开销**。所以描边产生的50个三角面就变成了100个三角面。如果只增加阴影，那么5个汉子只需要额外产生10个三角面。所以不要同时使用描边和阴影。

为Text添加描边以后得到的文本容易不清晰，目前的解决办法是将文本的字体调大，在RectTransform组件缩小Scale。缺点是文本会在位图中占用更多的内存。

------

##### 动态字体

UGUI动态字体的原理是根据传入的文字及字体大小将其生成纹理图集，文本网格的顶点上会记录UV信息，然后通过UV信息在字体纹理上采样贴图，文字最终就会显示出来了。
字符生成位图 → **位图打包为纹理图集** → 通过UV从图集采样 → 显示文字

> UV:一个二维坐标系,作用是告诉每个文字的顶点"应该从字体纹理的哪个位置采样颜色”.
>
> 若字符“A”在纹理中占据的区域是 `(x:0.2~0.3, y:0.5~0.6)`，则它的四个顶点UV坐标为：
> 左下角：(0.2, 0.5)
> 右下角：(0.3, 0.5)
> 左上角：(0.2, 0.6)
> 右上角：(0.3, 0.6)

文本最终被保存在位图中，因为是根据文字+字体大小生成的纹理，所以完全相同的文本如果字体大小不同，也会在位图中保存多份。
<img src="..\Texture\Unity\006.png"  align="left" style="zoom:50%;" />

------

##### 字体花屏

纹理位图会根据文字的内容动态扩容。动态扩容时，文字对应的UV一点会发生变化。UGUI底层已经处理过这些了，但在实际开发中，个别设备还是会出现花屏的问题。花屏的原因是：虽然纹理位图已经扩容，但是文本网格顶点数据中的UV并没有更新，导致了采样错误。

------

##### Text Mesh Pro

Text Mesh Pro使用的是SDF字体，并不会像Text一样根据字体大小将结果写入位图。它使用的是矢量图，图中保存的是字体边缘的距离场信息。这样，就是为文字设置不同的字体大小，也不会产生额外的内存开销。【TMP 并非直接使用矢量图，而是将字体的矢量轮廓信息预处理成一种特殊纹理——距离场纹理】

Text Mesh Pro与Text 动态字体区别：它不会在文字数量增多时对SDF图集慢慢扩容

<img src="..\Texture\Unity\005.png"  align="left" style="zoom:50%;" />

- Sampling Point Size：采样大小
- Packing Method：打包方法，通常在开发阶段选择Fast（/ fɑːst 快速的）、在发布阶段选择Optimum（ / ˈɒptɪməm 最佳的），后者打包慢但是质量高
- Atlas Resolution：SDF字体图的分辨率
- Character Set：字符格式，主要用于静态字体的预先生成

<img src="..\Texture\Unity\007.png"  align="left" style="zoom:50%;" />

- 要预先确认SDF图集的大小，如2048*2048像素。
- Multi Altas Textures表示开启多SDF图集，即当2048✖️2048像素大小的贴图装不下文字后系统会再创建一张2048✖️2048像素的图集
- Atlas Population Mode选择为Dynamic表示动态字体
- Clear Dynamic Data On Build勾选后会在打包前清空动态产生的字体信息，一定要勾选，不然编辑模式下产生的结果也会被打进游戏包中

<img src="..\Texture\Unity\008.png"  align="left" style="zoom:50%;" />

- Text Style:用于强制设备标签，如大小、颜色、下划线等
- Color Gradient(/ ˈɡreɪdiənt)：文本上下渐变效果
- Text Wrapping Mode：是否自动换行

------

##### SDF字体

Signed(/ saɪnd 有符号的) Distance Field(/ fiːld 场、地).有向距离场。保存的是文本每个点相对于文字边缘的距离。SDF采用Alpha8格式的贴图，表示每个像素由8位组成，取值范围为0~255，那么1024✖️1024像素就占用1.0MB内存。

<img src="..\Texture\Unity\009.png"  align="left" style="zoom: 80%;" />

- TTF字体先将“王”字的信息提取出来，接着并不是直接为了方便写入位图，而是将与每个像素距离字体最近的边缘到该像素的距离写入位图。为了方便理解，将“王”字的“一”的笔画提取出来。如下所示，距离场的信息最中间是距离边缘最远的，所以它的数据趋向于1.0，靠近边缘的信息趋向于0.0。
  0.0 0.0 0.0 0.0 0.0 0.0 0.0 0.0

  0.3 0.3 0.3 0.3 0.3 0.3 0.3 0.3

  1.0 1.0 1.0 1.0 1.0 1.0 1.0 1.0

  0.3 0.3 0.3 0.3 0.3 0.3 0.3 0.3

  0.0 0.0 0.0 0.0 0.0 0.0 0.0 0.0

  字体的放大和缩小其实就是改变Mesh的顶点信息，在执行片元着色器时，显卡会差值计算出每个像素到边缘的距离，在Shader里做个采样就能最终渲染出文本了。

- 优点：不会因为字体的大小额外占用内存。对于描边和阴影，因为每个像素记录的已经是到边缘的距离，所以只需要检测当前渲染的像素是否处于接近0也就是边缘的位置，然后开始在Shader里对它进行描边就行.
  两个三角形面就能确定一个字体渲染的Mesh，五个字10个三角面。整个描边只需要6个三角面就可以绘制结束。

  <img src="..\Texture\Unity\010.png"  align="left" style="zoom: 80%;" />

------

##### 图文混排

- 鼠标选中图片精灵--->Create--->TextMeshPro--->SpriteAsset，创建SpriteAsset文件。
- 将Sprite Asset拖入TextMeshPro中
- <img src="..\Texture\Unity\012.png"  align="left" style="zoom: 33%;" />
- 直接输入“图文<sprite name=EmojiOne_0>混排”
- <img src="..\Texture\Unity\011.png"  align="left" style="zoom: 80%;" />
- 图片位置奇怪原因是精灵的锚点对齐方式和文本不同。打开Sprite编辑器，修改Sprite的对齐方式，删除原来的SpriteAsset，创建新的

------

##### Image

默认情况下Image是由两个三角面拼成一个矩形片来渲染。

启动User Sprite Mesh后，将使用Sprite自身形状的三角片来渲染UI(Image Type为Simple)

如果使用两个三角形拼成的矩形片，当UI大面积是透明的时候，会白白的浪费渲染性能；而使用Sprite自身形状的三角片来渲染UI虽然增加了顶点的数量，但是能提升UI的填充效率。Image支持Sprite Mesh的另一个前提是Sprite必须支持Mesh Type，Mesh Type = Tight（紧密的）

Image组件只能显示Sprite,原因是Sprite在Texture的基础上又记录了一层额外的信息，比如Sprite与Altas(图集)之间的引用关系，Mesh Type保存为Tight模式等。可以使用Altas减少Draw Call,配合Sprite Mesh可以优化渲染填充率。

------

RawImage

RawImage只能显示Texture,虽然RawImage也可以使用Sprite,但它其实使用的是Sprite对应的Texture文件。

<img src="..\Texture\Unity\013.png"  align="left" style="zoom: 80%;" />

UV Rect可以指定UV的矩形区域，这样可以只显示图片的一部分或者平铺图片。如果图片较大又需要裁剪，使用UV Rect从性能的角度来说要比使用Mask高效很多，但UV Rect只能设置单独的一张图，而Mask可以将整个节点下单所有贴图都裁剪。