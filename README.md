- 常用插件推荐
  - [[UniTask]](https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask)
- 文档
  - C#
    - [C#基础](Document/C#/C#基础.md)
    - [C#进阶_字典原理实现](Document/C#/C# 进阶/字典实现原理.md)
    - [C#进阶_结构体&类](Document/C#/C# 进阶/结构体&类.md)
    - [排序](Document/C#/排序.md)
    - [设计模式](Document/C#/设计模式.md)
    - [数据结构](Document/C#/数据结构.md)
    - [网络同步](Document/C#/网络同步.md)
  - Lua
    - [Lua](Document/Lua/Lua.md)
  - Unity
    - [基础_面试](Document/基础_面试.md)
    - [基础_优化](Document/基础_优化.md)
    - [进阶_TextMeshPro](Document/进阶_TextMeshPro.md)
    - [进阶_合批](Document/进阶_合批.md)
  - 数据库



```mermaid
graph LR
       A[运行时引擎架构] 
       A --> B[游戏循环]
       A --> C[渲染系统]
   
       B --> B1[处理输入]
       B --> B2[更新游戏逻辑]
   
       C --> C1[渲染管道]
       C --> C2[着色器]
   
       D --> D1[碰撞检测]
       D --> D2[刚体动力学]
   
       E --> E1[音频文件加载]
       E --> E2[音频解码]
   
       F --> F1[键盘输入]
       F --> F2[鼠标输入]
       F --> F3[手柄输入]
   
       G --> G1[加载资源]
       G --> G2[管理资源]
       G --> G3[释放资源]
   
       H --> H1[内存池]
       H --> H2[对象池]
       H --> H3[自定义分配器]
   
       I --> I1[任务分配]
       I --> I2[多CPU核心]
   
       J --> J1[性能检测]
       J --> J2[内存泄漏检测]
       J --> J3[问题调试]
```

