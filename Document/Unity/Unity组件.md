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



------

