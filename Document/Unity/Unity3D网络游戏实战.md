![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\000.png)

#### 前言

为什么要写这本书

​		玩到好玩的游戏时，我总希望有朝一日能做出优秀的游戏作品；对生活有感悟时，也总会期待在游戏中表达感想。自Unity引擎流行开来，个人和小团队也能制作精良的游戏，实现梦想不再遥远。

​		使用Unity引擎，游戏开发者再也不用过度关心底层复杂系统的实现，只需关心具体的游戏逻辑。一般来说，游戏引擎都能够很好地处理渲染、物理等通用的底层模块，但对于那些不完全通用的功能，比如本书介绍的网络模块，引擎往往没能提供通用的解决方案。这就要求开发者对网络底层有足够深刻的理解，才能做出优质的网络游戏。

​		如今，游戏联网是一大趋势。几大热门的手机游戏厂商只开发网络游戏，老牌单机游戏也纷纷添加联网功能。作为有志于从事游戏行业、渴望做出顶级产品的我们，更需要深入探讨网络游戏的开发技术。然而市面上的Unity教程，大多是介绍引擎的使用方法和简单的单机游戏的开发过程，就算涉及网络，也只是简单带过。市面上也有不少介绍网络底层的资料，但大部分没有和游戏开发结合起来，更不可能提供完整的游戏示例。想要制作当今热门的网络游戏，特别是开发手机网络游戏，或者想要到网游公司求职，很难找到实用的教程。

​		本书以制作一款完整的多人坦克对战游戏为例，详细介绍网络游戏的开发过程。书中还介绍一套通用的服务端框架和客户端网络模块——它是商业游戏的简化版本。相信通过本书，读者能够掌握Unity网络游戏开发的大部分知识，能够深入了解TCP底层机制，能够亲自搭建一套可重复使用的客户端框架，也能够从框架设计中了解商业游戏的设计思路。本书分为三个部分，分别是“扎基础”“搭框架”和“做游戏”，本书结合实例，循序渐进，深入地讲解网络游戏开发所需的知识。

​		2013年8月，在筹备第一本著作《手把手教你用C#制作RPG游戏》的同时，我也在规划这本介绍网络游戏技术的书籍。2016年11月，《Unity3D网络游戏实战》正式出版。此后一年多的时间里，陆续有热心读者与我交流，探讨网络游戏的开发知识，我也一直在学习和积累。2018年1月，在收集了足够多的反馈，也相信自己的技术水平又上一个层次之后，我便着手本书第2版的写作。第2版的结构与第1版有颇多差异，对网络底层有更详细的介绍，而对场景搭建和单机游戏部分做了必要的精简，代码质量也有了很大提高，可以说全书几乎重写。

​      这本书凝结了我多年的工作经验，也凝结着我对国产游戏的美好愿景。愿与诸位一同努力，造就举世瞩目的游戏。

读者对象

这里将根据用户需求划分出一些可能使用本书的用户。

​	**游戏开发爱好者**：想要自己制作一款游戏的人。书中理论与实践结合，很适合作为自学的参考书。

​	**求职者**：想要谋求游戏公司开发岗位的人。书中对网络底层和商业游戏常遇到的问题都有介绍，覆盖常见的面试内容。

​	**职场新人**：刚入行的程序员。书中所介绍的网络知识和问题，是每个游戏从业人员都会遇到且必须去解决的。本书很适合作为提升技术水平的资料。

​	**游戏公司**：作为新人培训材料，本书能够帮助新人快速提高自身技术水平，同时书中有完整的实践项目，可使新人更快融入实际工作。

​	**学校**：可作为大学或游戏培训机构的教科书。本书结构安排合理，循序渐进，理论实践相结合，适合教学。

如何阅读本书

​		本书给予读者一个明确的学习目标，即制作一款完整的多人对战游戏，然后一步一步去实现它。全书涉及TCP网络底层知识、常见网络问题解决方法、客户端网络框架、客户端界面系统、网络游戏房间系统、坦克游戏战斗系统等多项内容。在涉及相关知识点时，书中会有详细的讲解。本书分为三个部分，阅读时要注意它们之间的递进关系。

​		第一部分“扎基础”主要介绍TCP网络游戏开发的必备知识，包括TCP异步连接、多路复用的处理，以及怎样处理粘包分包、怎样发送完整的网络数据、怎样设置正确的网络参数。第3章介绍了一款简单网络游戏开发的全过程，在后续章节中会逐步完善这个游戏。

​		第二部分“搭框架”主要介绍商业级客户端网络框架的实现方法。这套框架具有较高的通用性，解决了网络游戏开发中常遇到的问题，且达到极致的性能要求，可以运用在多款游戏上。书中还介绍了一套单进程服务端框架的实现，服务端框架使用select多路复用，做到底层与逻辑分离，设有消息分发、事件处理等模块。

​		第三部分“做游戏”通过一个完整的实例讲解网络游戏的设计思路，包括游戏实体的类设计、怎样组织代码、怎样实现游戏大厅（房间系统）、怎样实现角色的同步。这一部分会使用第二部分搭好的框架，一步步地做出完整的游戏项目。

​		由于本书重点在网络部分，因此不会过多着墨于Unity的基础操作和C#语言的基本语法。同时作为实例教程，本书偏重于例子涉及的知识点。读者如果想要深入地了解某些内容，或者了解实现某种功能的更多方法，建议在阅读本书的过程中多多查询相关资料，以做到举一反三。

​		本书提供的所有示例的源码和素材，读者可以在Github或网盘下载。我也会在Github上发表勘误、补充篇等内容，欢迎关注。由于网盘的不稳定性，作者不能保证多年后网盘地址还有效。若读者发现网盘地址失效，可以发送邮件到我的邮箱，我将会把最新的下载地址发给你。

**Github**：https://luopeiyu.github.io/unity_net_book/

**百度网盘**：[https://pan.baidu.com/s/1XhYKHJYjWTtGAqMb3uBYx](https://pan.baidu.com/s/1XhYKHJYjWTtGAqMb3uBYxQ)[Q](https://pan.baidu.com/s/1XhYKHJYjWTtGAqMb3uBYxQ)密码：hxuz

**作者邮箱**：aglab@foxmail.com

​		本书资源中的“Final”文件夹是最终游戏成品，包含服务端程序（Serv）和客户端程序（Client）两大部分。读者可以先按照7.6节的介绍，配置MySQL数据库和两个数据表，然后运行服务端程序，再打开客户端程序的exe文件，体验游戏。

勘误和支持

​		由于作者水平有限，编写的时间也很仓促，书中难免会出现一些错误或者不准确的地方，恳请读者批评指正。如果读者发现书中的错误，或者有更多的宝贵意见，欢迎发送邮件至我的邮箱 aglab@foxmail.com，我很期待能够听到你们的真挚反馈。

致谢

​		若没有身边众多亲朋好友的支持，本书的出版过程不可能一帆风顺。首先要感谢我的父母，他们的努力，让我有了坚实的后盾，我才能义无反顾地前行。

​		感谢机械工业出版社华章公司的杨绣国编辑。在她的帮助下，本书得以顺利出版。

​		感谢邝松恩和张永明，他们是最早接触第2版书稿的同事，给了我很多建议。

​		感谢黄剑基、蒙屿森、周阳鸣、詹俊雄、陆俊壕、沙梓社、吴嘉琪、郑志铭、卢阳飞、许远帆、林文佳、粱浩林、宫文达、葛剑航、罗斌汉、江宇晴、肖聪等人在我编写本书的过程中给予诸多鼓舞。

​		每一款游戏都是梦想与智慧的结晶！

罗培羽

2018年8月于广州





####  第1章 网络游戏的开端：Echo

​		网络通信和电话通信很相似。想象一下打电话的过程，拿起手机拨通号码，等待对方说“喂”，然后开始通话，最后挂断。记住这个过程（如图1-1所示），将有助于理解本章的内容。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\001.png" style="zoom: 50%;" />

​																							图1-1  拨打电话的过程

​		本章会先介绍Socket（套接字）的概念，然后着手开发Echo程序。学完本章，读者能够动手编写基础网络应用程序，还能够编写一套时间查询程序。本章的知识是网络游戏中最基础的。



##### 1.1 藏在幕后的服务端

​		一款网络游戏分为客户端和服务端两个部分，客户端程序运行在用户的电脑或手机上，服务端程序运行在游戏运营商的服务器上。如图1-2所示，多个客户端通过网络与服务端通信。图1-2中间的TCP连接指的是一种游戏中常用的网络通信协议，与之对应的还有UDP协议、KCP协议、HTTP协议等。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\002.png" style="zoom:50%;" />

​																							图1-2  典型的网络游戏架构

客户端和客户端之间通过服务端的消息转发进行通信。例如在一款射击游戏中，玩家1移动，玩家2会在自己的屏幕中看到玩家1的位置变化，这个过程称为“位置同步”，它会涉及表1-1和图1-3所示的5个步骤。

| 步骤 |                说明                |
| :--: | :--------------------------------: |
|  1   |             玩家1移动              |
|  2   |  客户端1向服务端发送新的坐标信息   |
|  3   |           服务端处理消息           |
|  4   | 服务端将玩家1的新坐标转发给客户端2 |
|  5   |  客户端2收到消息并更新玩家1的位置  |

​																							表1-1  位置同步涉及的步骤

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\003.png" style="zoom: 33%;" />

​																							图1-3 	位置同步的5个步骤

​		一款流行的网络游戏，可能有数百万玩家同时在线。为了支撑这么多玩家，游戏服务端通常采取分布式架构。图1-4所示的是一组分区服务端，由2个区组成，每个服务端负责不同区的玩家。

​		服务端与服务端之间通常使用TCP网络通信，如图1-5所示，各个服务端相互连接，形成服务端集群。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\004.png" style="zoom: 67%;" />

​																							图1-4 	服务端分区

​		客户端和服务端之间、服务端和服务端之间都是使用TCP网络通信的。网络编程是开发网络游戏的基础，那么，我们就从最基础的Socket开始吧！

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\005.png" style="zoom: 67%;" />

​																							图1-5  服务端的分布式架构





##### 1.2 网络连接的端点：Socket

###### 1.2.1    Socket

​		网络上的两个程序通过一个双向的通信连接实现数据交换，这个连接的一端称为一个Socket。一个Socket包含了进行网络通信必需的五种信息：**连接使用的协议、本地主机的IP地址、本地的协议端口、远程主机的IP地址和远程协议端口**（如图1-6所示）。如果把Socket理解成一台手机，那么本地主机IP地址和端口相当于自己的手机号码，远程主机IP地址和端口相当于对方的号码。至少需要两台手机才能打电话，同样地，至少需要两个Socket才能进行网络通信。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\006.png" style="zoom: 67%;" />

​																							图1-6 	Socket示意图



###### 1.2.2 	IP地址

​		网络上的计算机都是通过IP地址识别的，应用程序通过通信端口彼此通信。通俗地讲，可以理解为每一个IP地址对应于一台计算机（实际上一台计算机可以有多个IP地址，此处仅作方便理解的解释）。在图1-7中，从计算机1的角度看，192.168.1.5是自己的IP，称为“本地IP”。192.168.1.12是别人的IP，称为“远程IP”。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\007.png" style="zoom: 80%;" />

​																							图1-7  IP地址示意图

> `提示： 在Windows命令提示符中输入ipconfig，便能够查看本机的IP地址。图1-8所示计算机的IP地址为192.168.0.105。`

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\008.png" style="zoom: 80%;" />

​																							图1-8 	查看本机IP地址



###### 1.2.3 	端口

​		“端口”是英文port的意译，是设备与外界通信交流的出口。每台计算机可以分配0到65535共65536个端口。通俗地讲，每个Socket连接都是从一台计算机的一个端口连接到另外一台计算机的某个端口，如图1-9所示。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\009.png" style="zoom: 80%;" />

​																							图1-9	端口示意图

​		端口是个逻辑概念。很久以前，计算机没有“多任务”的概念，也没有“端口”的概念，只需要两台计算机的地址，便能够进行网络通信。就像很久以前，每家每户都住平房，寄信给别人时，只需在信封上写××路××号一样。随着城市的发展，人们都住上了高楼，这时候写信的地址就变成××路××号××层××室。同样的，随着计算机多任务系统的发展，人们定义了“端口”的概念，把不同的网络消息分发给不同的任务。就像写上门牌号能够把信发送到每家每户一样，使用IP和端口也能够把信息发送给对应的任务。

​		图1-10和表1-2展示了Socket、IP和端口之间的关系。**每一个进程（客户端1、客户端2、服务端）可以拥有多个Socket，每个Socket通过不同端口与其他计算机连接。每一条Socket连接代表着本地Socket→本地端口→网络介质→远程端口→远程Socket的链路**，例如在计算机1的Socket A通过1000端口连接到计算机2的888端口。值得注意的是，就像打电话分为“呼叫方”和“接听方”一样，Socket通信分也为“连接方”和“监听方”：连接方使用不同的端口连接，监听方只使用一个端口监听。图1-10中Socket E在Socket A连接后产生，代表着Socket A和服务端的连接，Socket F在Socket B连接后产生，代表着Socket B和服务端的连接。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\010.png" style="zoom: 80%;" />

​																							图1-10 	Socket连接示意图

​																						表1-2 	图1-10中各个Socket的属性

|  Socket  |                             属性                             |
| :------: | :----------------------------------------------------------: |
| Socket A | 协议：TCP<br />本地IP:192.168.1.5<br />本地端口：1000<br />远程IP:192.168.1.12<br />远程端口：888 |
| Socket B | 协议：TCP<br />本地IP:192.168.1.5<br />本地端口：1002<br />远程IP:192.168.1.12<br />远程端口：888 |
| Socket C | 协议：TCP<br />本地IP:192.168.1.5<br />本地端口：1003<br />远程IP:（略）<br />远程端口：（略） |
| Socket D | 协议：TCP<br />本地IP:192.168.1.12<br />本地端口：888<br />远程IP:未知<br />远程端口：未知 |
| Socket E | 协议：TCP<br />本地IP:192.168.1.12<br />本地端口：888<br />远程IP:192.168.1.5<br />远程端口：1000 |
| Socket F | 协议：TCP<br />本地IP:192.168.1.12<br />本地端口：888<br />远程IP:192.168.1.12<br />远程端口：1002 |



###### 1.2.4    Socket通信的流程

​		为了能够理解下一节的程序，请务必认真阅读本节。图1-11展示了一套基本的Socket通信流程。这个过程和手机通话很相似，连接方（客户端）和监听方（服务端）有着不同的流程。图1-11中的Socket、Connect、Bind、Listen等词汇指的是Socket通信过程中所需要调用的API，三次握手、四次挥手等词汇指的是操作系统内部的处理过程。

**1）开启一个连接之前，需要创建一个Socket对象（使用API Socket），然后绑定本地使用的端口（使用API Bind）**。对服务端而言，绑定的步骤相当于给手机插上SIM卡，确定了“手机号”。对客户端而言，连接时（使用API Connect）会由系统分配端口，可以省去绑定步骤。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\011.png" style="zoom: 80%;" />

​																							图1-11 	Socket通信的基本流程

**2）服务端开启监听（使用API Listen），等待客户端接入**。相当于电话开机，等待别人呼叫。

**3）客户端连接服务器（使用API Connect）**，相当于手机拨号。

**4）服务器接受连接（使用API Accept）**，相当于接听电话并说出“喂”。

通过这4个步骤，成功建立连接，可以收发数据。

**5）客户端和服务端通过Send和Receive等API收发数据，操作系统会自动完成数据的确认、重传等步骤，确保传输的数据准确无误**。

**6）某一方关闭连接（使用API Close），操作系统会执行“四次挥手”的步骤，关闭双方连接**，相当于挂断电话。



###### 1.2.5    TCP和UDP协议

​		从概念上讲，**TCP是一种面向连接的、可靠的、基于字节流的传输层通信协议**，与TCP相对应的**UDP协议是无连接的、不可靠的、但传输效率较高的协议**。在本章的语义中，“Socket通信”特指使用TCP协议的Socket通信。

​		也许能够以寄快递的例子解释不同协议的区别。有些快递公司收费低，对快递员的要求也低，丢件的事情频频发生；有些公司收费高，但要求快递员在每个节点都做检查和记录，丢件率很低。不同快递公司有着不同的行为规则，有的奉行低价优先，有的奉行服务至上。TCP、UDP协议对应不同快递公司的行为规则。它们的目的都是将数据发送给接收方，但使用的策略不同：**TCP注重传输的可靠性，确保数据不会丢失，但速度慢；UDP注重传输速度，但不保证所有发送的数据对方都能够收到**。至于孰优孰劣，得看具体的应用场景。游戏开发最常用的是TCP协议，所以本书也以TCP为主。





##### 1.3 开始网络编程：Echo

###### 1.3.1    什么是Echo程序

​		Echo程序是网络编程中最基础的案例。建立网络连接后，客户端向服务端发送一行文本，服务端收到后将文本发送回客户端（见图1-12）。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\012.png" style="zoom: 80%;" />

​																							图1-12  Echo程序示意图

​		Echo程序分为客户端和服务端两个部分，客户端部分使用Unity实现，为了技术的统一，服务端使用C#语言实现。



###### 1.3.2    编写客户端程序

​		由于本书偏重于开发网络游戏，重点讲解网络相关的内容。假定你对Unity的基本操作、UGUI有一定的了解（如果你对此还不是很了解，推荐阅读本书第1版中的入门章节）。

​		打开Unity，新建名为Echo的项目，制作简单的UGUI界面。在场景中添加两个按钮（右击Hierarchy面板，选择UI→Button，分别命名为ConnButton和SendButton。Unity会自动添加名为Canvas的画布和名为EventSystem的事件系统），添加一个输入框（命名为InputField）和一个文本框（命名为Text），如图1-13和表1-3所示。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\013.png"  />

​																							图1-13  添加按钮和文本

​																					表1-3  客户端UGUI界面部件说明

|        部件        |                    内容                    |
| :----------------: | :----------------------------------------: |
|  ConnButton(按钮)  |         连接按钮，用于发起网络连接         |
| InputField(输入框) |    文本输入框，用于输入发给服务端的文本    |
|  SendButton(按钮)  | 发送按钮，用于将玩家输入的文本发送给服务端 |
|    Text(文本框)    |    文本框，用于显示从服务端接收到的文本    |

​		建立界面后，就可以开始写代码了。新建名为Echo.cs的脚本，输入下面的代码。（这段代码的结构和1.2.4节中的客户端流程一样，客户端通过Connect命令连接服务器，然后向服务器发送输入框中的文本；发送后等待服务器回应，并把服务器回应的字符串显示出来；代码中标有底纹的语句表示需要特别注意。）

```C#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.Net.Sockets; 
using UnityEngine.UI; 

public class Echo : MonoBehaviour
{
 	Socket socket; //定义套接字 
 	//UGUI
 	public InputField InputFeld;
 	public Text text;
    
 	public void Connection() //点击连接按钮 
 	{ 
 		//Socket 
 		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
 		//Connect 
 		socket.Connect("127.0.0.1", 8888); 
 	} 
 	
 	public void Send() //点击发送按钮 
 	{ 
 		//Send 
 		string sendStr = InputFeld.text; 
 		byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr); 
 		socket.Send(sendBytes); 
 		//Recv 
 		byte[] readBuff = new byte[1024];  
 		int count = socket.Receive(readBuff); 
 		string recvStr = System.Text.Encoding.Default.GetString(readBuff, 0, count); 
 		text.text = recvStr; 
 		//Close 
 		socket.Close(); 
 	} 
}
```

是否对代码有疑惑？不用怕，一句一句弄懂它。



###### 1.3.3    客户端代码知识点

​		1.3.2节中的代码涉及不少网络编程的知识点，它们的含义如下。

​		**（1）using System.Net.Sockets**

​		Socket编程的API（如Socket、AddressFamily等）位于System.Net.Sockets命名空间中，需要引用它。

​		**（2）创建Socket对象**

​		Socket（AddressFamily.InterNetwork，SocketType.Stream，ProtocolType.Tcp）这一行用于创建一个Socket对象，它的三个参数分别代表地址族、套接字类型和协议。

​																							表1-4  AddressFamily的含义

| AddressFamily的值 | 含义     |
| ----------------- | -------- |
| Inernetwork       | 使用IPv4 |
| InernetworkV6     | 使用IPv6 |

> 地址族指明使用IPv4还是IPv6，其含义如表1-4所示，本例中使用的是IPv4，即InterNetwork。
>
> SocketType是套接字类型，类型如表1-5所示，游戏开发中最常用的是字节流套接字，即Stream。

​																							表1-5  SocketType的含义

| SocketTtpe | 含义                                                         |
| :--------: | ------------------------------------------------------------ |
|   Dgram    | 支持数据报,即最大长度固定(通常很小)的无连接、不可靠消息。消息可能会丢失或重复并可能在到达时不按順序排列。Dgram类型的Socket在发送和接收数据之前不需要任何连接,并且可以与多个对方主机进行通信。Dgram使用数据报协议(UDP)和 InterNetworkAddressFamily |
|    Raw     | 支持对基础传输协议的访问。通过使用SocketTypeRaw，可以使用Internet控制消息协议 (ICMP)和Internet组管理协议(Igmp)这样的协议来进行通信。在发送时,您的应用程序必须提供完整的IP标头。所接收的数据报在返回时会保持其IP标头和选项不变 |
|    RDM     | 支持无连接、面向消息、以可靠方式发送的消息,并保留数据中的消息边界。RDM(以可靠方式发送的消息)消息会依次到达,不会重复。此外,如果消息丢失,将会通知发送方。如果使用RDM初始化Socket,则在发送和接收数据之前无须建立远程主机连接,利用 RDM,可以与多个对方主机进行通信 |
|  Seqpacet  | 在网络上提供排序字节流的面向连接且可靠的双向传输。Seqpacket不重复数据,它在数据流中保留边界。Seqpacket类型的Socket与单个对方主机通信,并且在通信开始之前需要建立远程主机连接 |
|   Stream   | 支持可靠、双向、基于连接的字节流,而不重复数据,也不保留边界。此类型的Socket与单个对方主机通信,井且在通信开始之前需要建立远程主机连接。Stream使用传输控制 协议(TCP)和 InterNetworkAddressFamily |
|  Unknown   | 指定未知的Socket类型                                         |

> ProtocolType指明协议，本例使用的是TCP协议，部分协议类型如表1-6所示。若要使用传输速度更快的UDP协议而不是较为可靠的TCP（回顾1.2.5节的内容），需要更改协议类型Socket（AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp）”。

​																							表1-6  常用的协议

| 常用的协议 | 含义                           | 常用的协议  | 含义             |
| ---------- | ------------------------------ | ----------- | ---------------- |
| GGP        | 网关到网关协议                 | PARC        | 通用数据包协议   |
| ICMP       | 网际消息控制协议               | RAW         | 原始IP数据包协议 |
| ICMPv6     | 用于IPv6的Internet控制消息协议 | TCP         | 传输控制协议     |
| IDP        | Internet数据报协议             | UDP         | 用户数据包协议   |
| IGMP       | 网际组管理协议                 | Unknown     | 未知协议         |
| IP         | 网际协议                       | Unspecified | 未指定的协议     |
| Internet   | 数据包交换协议                 |             |                  |

​	**（3）连接Connect**

​	客户端通过socket.Connect（远程IP地址，远程端口）连接服务端。Connect是一个阻塞方法，程序会卡住直到服务端回应（接收、拒绝或超时）。

​	**（4）发送消息Send**

​	客户端通过socket.Send发送数据，这也是一个阻塞方法。该方法接受一个byte[]类型的参数指明要发送的内容。Send的返回值指明发送数据的长度（例子中没有使用）。程序用
System.Text.Encoding.Default.GetBytes(字符串)把字符串转换成byte[]数组，然后发送给服务端。

​	**（5）接收消息Receive**

​	客户端通过socket.Receive接收服务端数据。Receive也是阻塞方法，没有收到服务端数据时，程序将卡在Receive不会往下执行。Receive带有一个byte[]类型的参数，它存储接收到的数据。Receive的返回值指明接收到数据的长度。之后使用
System.Text.Encoding.Default.GetString(readBuff,0,count)将byte[]数组转换成字符串显示在屏幕上。

​	**（6）关闭连接Close**

​	通过socket.Close关闭连接。



###### 1.3.4    完成客户端

​		编写完代码后，将Echo.cs拖曳到场景中任一物体上，并且给InputField和Test两个属性赋值（将对应游戏物体拖曳到属性右侧的输入框上），如图1-14所示。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\014.png"  />

​																							图1-14  Echo组件

​		在属性面板中给ConnButton添加点击事件，设置为Echo组件的Connection方法。使得玩家点击连接按钮时，调用Echo组件的Connection方法，如图1-15所示（图中的游戏物体显示为“Main Camera”，是因为把Echo组件挂在了相机上，如果挂在其他物体上，需选择对应的物体）。采用同样的方法，给SendButton添加点击事件，设置为Echo组件的Send方法.

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\015.png" style="zoom: 80%;" />

​																							图1-15  设置点击事件

​		由于服务端尚未开启，此时运行客户端，点击连接按钮，会提示无法连接，属于正常现象，如图1-16所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\016.png)

​																							图1-16  连接服务端失败



###### 1.3.5    创建服务端程序

​		游戏服务端可以使用各种语言开发，为了与客户端统一，本书使用C#编写服务端程序。打开位于Unity安装目录下MonoDevelop（也可以使用Visual Studio等工具），选择File→New→Solution创建一个控制台（Console）程序，如图1-17所示。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\017.png" style="zoom: 67%;" />

​																							图1-17  创建控制台程序

​		MonoDevelop为我们创建了图1-18左侧所示的目录结构。打开Program.cs将能看到使用Console.WriteLine("Hello World!")在屏幕上输出“Hello World!”的代码。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\018.png" style="zoom: 80%;" />

​																							图1-18  默认目录结构

​		选择Run→Restart Without Debugging即可运行程序（如图1-19所示）。如果程序一闪而过，可以在Console.WriteLine后面加上一行“Console.Read();”，让程序等待用户输入。读者还可以在程序目录下的bin\Debug找到对应的exe文件，直接执行。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\019.png" style="zoom: 80%;" />

​																							图1-19 	运行控制台程序



###### 1.3.6 编写服务端程序

​		服务器遵照Socket通信的基本流程，先创建Socket对象，再调用Bind绑定本地IP地址和端口号，之后调用Listen等待客户端连接。最后在while循环中调用Accept应答客户端，回应消息。代码如下：

```c#
using System; 
using System.Net; 
using System.Net.Sockets; 

namespace EchoServer 
{ 
	class MainClass 
 	{ 
 		public static void Main (string[] args)
        { 
 			Console.WriteLine ("Hello World!"); 
 			//Socket 
 			Socket listenfd = new Socket(AddressFamily.InterNetwork, 
                                        SocketType.Stream, 																						ProtocolType.Tcp); 
 			//Bind 
 			IPAddress ipAdr = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEp = new IPEndPoint(ipAdr, 8888); 			
            listenfd.Bind(ipEp); 
 			//Listen 
 			listenfd.Listen(0); 
 			Console.WriteLine("[服务器]启动成功"); 
 			while (true)
            { 
 				//Accept 
 				Socket connfd = listenfd.Accept (); 
 				Console.WriteLine ("[服务器]Accept"); 
				//Receive 
 				byte[] readBuff = new byte[1024]; 
				int count = connfd.Receive (readBuff);
                string readStr = System.Text.Encoding.Default.GetString (readBuff, 0, count); 
 				Console.WriteLine ("[服务器接收]" + readStr);
                //Send 
 				byte[] sendBytes = System.Text.Encoding.Default.GetBytes (readStr); 
 				connfd.Send(sendBytes); 
 			} 
 		} 
 	} 
}
```

​		运行程序，读者将能看到如图1-20所示的界面，此时服务器阻塞

在Accept方法。下面会详细解释这一段代码的含义。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\020.png)

​																							图1-20  运行着的服务端程序



###### 1.3.7    服务端知识点

​		上一节的代码涉及不少网络编程的知识点，它们的含义如下。

**（1）绑定Bind**

​	listenfd.Bind(ipEp)将给listenfd套接字绑定IP和端口。程序中绑定本地地址“127.0.0.1”和8888号端口。127.0.0.1是回送地址，指本地机，一般用于测试。读者也可以设置成真实的IP地址，然后在两台计算机上分别运行客户端和服务端程序。

**（2）监听Listen**

​	服务端通过listenfd.Listen(backlog)开启监听，等待客户端连接。参数backlog指定队列中最多可容纳等待接受的连接数，0表示不限制。

**（3）应答Accept**

​	开启监听后，服务器调用listenfd.Accept()接收客户端连接。本例使用的所有Socket方法都是阻塞方法，也就是说当没有客户端连接时，服务器程序卡在listenfd.Accept()不会往下执行，直到接收了客户端的连接。Accept返回一个新客户端的Socket对象，对于服务器来说，它有一个监听Socket（例子中的listenfd）用来监听（Listen）和应答（Accept）客户端的连接，对每个客户端还有一个专门的Socket（例子中的connfd）用来处理该客户端的数据。

**（4）IPAddress和IPEndPoint**

​	使用IPAddress指定IP地址，使用IPEndPoint指定IP和端口。

**（5）System.Text.Encoding.Default.GetString**

​	Receive方法将接收到的字节流保存到readBuff上，readBuff是byte型数组。GetString方法可以将byte型数组转换成字符串。同理，System.Text.Encoding.Default.GetBytes可以将字符串转换成byte型数组。



###### 1.3.8    测试Echo程序

​		运行服务端和客户端程序，点击客户端的连接按钮。在文本框中输入文本，点击发送按钮后，客户端将会显示服务端的回应信息“Hello Unity”，如图1-21所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\021.png)

​																							图1-21  Echo程序

​		读者可能会觉得Echo程序没太大用处，其实只要稍微修改一下，就能够制作有实际作用的程序，比如制作一个时间查询程序。更改服务端代码，发送服务端当前的时间，如果服务器时间是准确的，客户端便可以获取准确的时间，如图1-22所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\022.png)

​																							图1-22  时间查询程序

```c#
//Send 
string sendStr = System.DateTime.Now.ToString(); 
byte[] sendBytes = System.Text.Encoding.Default.GetBytes (sendStr); 
connfd.Send (sendBytes); 
```

​		思考一个问题：当前的服务端每次只能处理一个客户端的请求，如果我们要做一套聊天系统，它必须同时处理多个客户端请求，那又该怎样实现呢？





##### 1.4 更多API

​																							表1-7  Socket类的一些常用方法

|      方法       |                   说明                   |
| :-------------: | :--------------------------------------: |
|      Bind       |      使Socket与一个本地终结点相关联      |
|     Listen      |           将Socket置于侦听状态           |
|     Connect     |           建立与远程主机的连接           |
|  BeginConnect   |     开始一个对远程主机连接的异步请求     |
|   EndConnect    |          结束挂起的异步连接请求          |
|     Accept      |         为新建连接创建新的Socket         |
|   BeginAccept   | 开始一个异步操作来接受一个传入的连接尝试 |
|    EndAccept    |          异步接受传入的连接尝试          |
|     Receive     |        接收来自绑定的Socket的数据        |
|  BeginReceive   |     开始从连接的Socket中异步接收数据     |
|   EndReceive    |       将数据异步发送到连接的Socket       |
|      Send       |         将数据发送到连接的Socket         |
|    BeginSend    |             开始异步发送数据             |
|     EndSend     |            结束挂起的异步发送            |
|   Disconnect    |      关闭套接字连接并允许重用套接字      |
| DeginDisconnect |     开始异步请求从远程终结点断开连接     |
|  EndDisconnect  |        结束挂起的异步断开连接请求        |
|      Close      |    关闭Socket连接并释放所有关联的资源    |
|    Shutdown     |        禁用某Socket上的发送和接收        |
| GetSocketOption |            返回Socket选项的值            |
| SetSocketOption |              设置Socket选项              |
|      Poll       |             确定Socket的状态             |
|     Select      |        确定一个或多个套接字的状态        |

​																							表1-8  Socket类的一些常用属性

|       属性        | 说明                                                    |
| :---------------: | ------------------------------------------------------- |
|   AddressFamily   | 获取Socket的地址族                                      |
|     Available     | 获取已经从网络接收且可供读取的数据量                    |
|     Blocking      | 获取或设置一个值,该值指示Socket是否处于阻止模式         |
|     Connected     | 获取一个值,该值指示Socket是否连接                       |
|      IsBound      | 指示Sacket是否绑定到特定本地端口                        |
|  OSSupportsIPv6   | 指示操作系统和网络适配器是否支持Internet协议第6版(IPv6) |
|   ProtocolType    | 获取Socket的协议类型                                    |
|  SendBufferSize   | 指定Socket发送缓冲区的大小                              |
|    SendTimeout    | 指定之后同步Send调用将超时的时间长度                    |
| ReceiveBufferSize | 指定Socket接收冲区的大小                                |
|  ReceiveTimeout   | 指定之后同步Receive调用将超时的时间长度                 |
|        Ttl        | 指定Socket发送的Internet协议(IP)数据包的生存时间(TTL)值 |





##### 1.5 公网和局域网

​		本书上一版出版后，有些读者问“这套程序能不能在外网运行”和“怎样写外网能连接的服务端”。其实只要是服务端所在的计算机拥有外网IP，便能够访问。本地程序和外网的程序完全一样。

​		假设读者将服务端连到公网，例如连接宽带，或者购买阿里云、腾讯云等服务器，就可以获得这一台计算机的公网IP（如图1-23所示的123.207.111.220）。客户端只需连接这个公网IP和端口，便能够连接到服务端。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\023.png" style="zoom:75%;" />

​																							图1-23  公网示意图

​		有些读者家里使用了无线路由，或者在校园网的局域网内，那情况就稍有不同。如图1-24所示，一些读者把宽带连接到家里的路由器，再由路由器分发到多台计算机（校园网、公司局域网同理），在这种情况下，路由器会有公网和局域网两个IP。在图1-24中，路由器的公网IP是123.207.111.220，局域网IP为192.168.0.1，连接路由器的计算机只有内网IP，它们分别是192.168.0.10和192.168.0.12。如果将服务端放到连接路由器的某台计算机上，因为它只有局域网IP，所以只有局域网内的计算机可以连接上。如果拥有路由器的控制权，可以使用一种叫“端口映射”的技术，即设置路由器，将路由器IP地址的一个端口映射到内网中的一台计算机，提供相应的服务。当用户访问该IP的这个端口时，路由器自动将请求映射到对应局域网内部的计算机上。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\024.png" style="zoom:75%;" />

​																							图1-23  局域网示意图

​		如果没有路由器的控制权（例如校园网），将服务端程序部署到阿里云、腾讯云等云服务器即可。







#### 第2章 分身有术：异步和多路复用

​		第1章中的程序全部使用阻塞API（Connect、Send、Receive等），可称为同步Socket程序，它简单且容易实现，但时不时卡住程序却成为致命的缺点。客户端一卡一顿、服务端只能一次处理一个客户端的消息，不具有实用性。于是，人们发明了异步和多路复用两种技术，完美地解决了阻塞问题。学完本章，读者能够用Unity制作聊天室程序，聊天室程序涉及的知识是网络游戏同步技术的基础。



##### 2.1 什么样的代码是异步代码

​		假设有一个“实现一个闹钟，5秒后铃响”的功能，Unity中有很多方法可以实现，其中有一个方法是下面这样的。这是个同步方法，会卡住程序。代码中的Sleep方法表示让程序休眠，程序运行到该方法时，会等待5000毫秒（即5秒），再打印出“铃铃铃”。

```c#
void Start ()
{ 
	System.Threading.Thread.Sleep(5000); 
	Debug.Log("铃铃铃"); 
}
```

​		另一个实现方法称为异步程序，代码如下：

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.Threading; 

public class Async : MonoBehaviour
{
	void Start ()
    { 
		//创建定时器 
		Timer timer = new Timer(TimeOut, null, 5000, 0); 
		//其他程序代码 
		//…… 
	} 
 	//回调函数 
 	private void TimeOut(System.Object state)
    {
        Debug.Log("铃铃铃"); 
	}
}
```

​		代码解释：

​		在Start方法中创建一个定时器对象timer（定时器Timer类位于System.Threading命名空间内）。Timer类的构造函数有4个参数：第一个参数TimeOut代表回调函数，即打印“铃铃铃”的方法；第三个参数5000代表5000毫秒，即5秒；另外两个参数暂不需要关心。整个程序的功能就是开启定时器，5秒后回调TimeOut方法，打印“铃铃铃”。

​		这种方法称为异步，它指进程不需要一直等下去，而是继续往下执行，直到满足条件时才调用回调函数，这样可以提高执行的效率。

​		如图2-1所示，异步的实现依赖于多线程技术。在Unity中，执行Start、Update方法的线程是主线程，定时器会把定时任务交给另外的线程去执行，在等待5秒后，“另外的某条线程”调用回调函数。主线程继续往下执行代码，不受影响。

<img src="E:\Gitee\Document\Texture\Unity3D网络游戏实战\025.png" style="zoom:80%;" />

​																							图2-1  闹钟程序示意图



##### 2.2 异步客户端

​		同步模式中，客户端使用API Connect连接服务器，并使用API Send和Receive接收数据。在异步模式下，客户端可以使用BeginConnect和EndConnect等API完成同样的功能。

###### 2.2.1    异步Connect

​		每一个同步API（如Connect）对应着两个异步API，分别是在原名称前面加上Begin和End（如BeginConnect和EndConnect）。客户端发起连接时，如果网络不好或服务端没有回应，客户端会被卡住一段时间。读者可以做一个这样的实验：使用NetLimiter等软件限制网速，然后打开第1章制作的Echo程序。点击连接后，客户端会卡住十几秒，并弹出“由于连接方在一段时间后没有正确答复或连接的主机没有反应，连接尝试败。”的异常信息。而在这卡住的十几秒，用户不能做任何操作，游戏体验很差。

​		若使用异步程序，则可以防止程序卡住，其核心的API BeginConnect的函数原型如下：

```c#
public IAsyncResult BeginConnect( 
	string host, 
	int port, 
	AsyncCallback requestCallback, 
 	object state 
)
```

表2-1中针对BeginConnect的参数进行了说明。

​																							表2-1  BeginConnect的参数

| 参数            | 说明                                                         |
| --------------- | ------------------------------------------------------------ |
| host            | 远程主机的名称(IP),如“127.0.0.1”                             |
| port            | 远程主机的端口号,如“8888”                                    |
| requestCallback | 一个AsyncCallback委托,即回调函数,回调函数的参数必須是这的形式:void ConectCallback(IAsyncResult ar) |
| sate            | 一个用户定义对象,可包含连接操作的相关信息。此对象会被传递给回调函数 |

> 知识点 IAsyncResult是.NET提供的一种异步操作，通过名为Begin×××和End×××的两个方法来实现原同步方法的异步调用。Begin×××方法包含同步方法中所需的参数，此外还包含另外两个参数：一个AsyncCallback委托和一个用户定义的状态对象。委托用来调用回调方法，状态对象用来向回调方法传递状态信息。且Begin×××方法返回一个实现IAsyncResult接口的对象，End×××方法用于结束异步操作并返回结果。End×××方法含有一个IAsyncResult参数，用于获取异步操作是否完成的信息，它的返回值与同步方法相同。

​		EndConnect的函数原型如下。在BeginConnect的回调函数中调用EndConnect，可完成连接。

```c#
public void EndConnect( 
	IAsyncResult asyncResult 
)
```



###### 2.2.2    Show Me The Code

​		“码不出何以论天下”，开始编程吧！使用异步Connect修改Echo客户端程序如下所示。

```c#
using System; 

//点击连接按钮 
public void Connection() 
{ 
 	//Socket 
 	socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
	//Connect 
	socket.BeginConnect("127.0.0.1", 8888, ConnectCallback, socket); 
} 

//Connect回调 
public void ConnectCallback(IAsyncResult ar)
{
    try
    { 
		Socket socket = (Socket) ar.AsyncState;socket.EndConnect(ar); 
 		Debug.Log("Socket Connect Succ"); 
 	} 
 	catch (SocketException ex)
    { 
		Debug.Log("Socket Connect fail" + ex.ToString());
    } 
}
```

​		说明：

​		1）由BeginConnect最后一个参数传入的socket，可由ar.AsyncState获取到。

​		2）try-catch是C#里处理异常的结构。它允许将任何可能发生异常情形的程序代码放置在try{}中进行监控。异常发生后，catch{}里面的代码将会被执行。catch语句中的参数ex附带了异常信息，可以将它打印出来。如果连接失败，EndConnect会抛出异常，所以将相关的语句放到try-catch结构中。

​		打开Echo服务端，运行程序。点击连接按钮后，客户端不再被卡住。图2-2展示的是在限制网速的情况下，客户端无法连接服务端，弹出异常的情形。但无论如何，客户端不再卡住。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\026.png)

​																			图2-2  限制网速，客户端无法连接服务端，弹出异常



###### 2.2.3    异步Receive

​		Receive是个阻塞方法，会让客户端一直卡着，直至收到服务端的数据为止。如果服务端不回应（试试注释掉Echo服务端的Send方法！），客户端就算等到海枯石烂，也只能继续等着。异步Receive方法BeginReceive和EndReceive正是解决这个问题的关键。

​		与BeginConnect相似，BeginReceive用于实现异步数据的接收，它的原型如下所示。

```c#
public IAsyncResult BeginReceive ( 
	byte[] buffer, 
	int offset, 
	int size, 
	SocketFlags socketFlags, 
	AsyncCallback callback, 
	object state 
)
```

表2-2对BeginReceive的参数进行了说明。

​																							表2-2  BeginReceive的参数说明

| 参数        | 说明                                                         |
| ----------- | ------------------------------------------------------------ |
| buffer      | Byte类型的数组,它存储接收到的数据                            |
| offset      | buffer中存储数据的位置。该位置从0开始计数                    |
| size        | 最多接收的字节数                                             |
| socketFlags | SocketFlags值的按位组合,这里设置为0                          |
| callback    | 回调函数,一个AsyncCalback委托                                |
| state       | 一个用户定义对象,其中包含接收操作的相关信息。当操作完成时,此对象会被传递 给EndReceive委托 |

​		虽然参数比较多，但我们先重点关注buffer、callback和state三个即可。对应的EndReceive的原型如下，它的返回值代表了接收到的字节数。

```c#
public int EndReceive( 
	IAsyncResult asyncResult 
)
```

​		冗谈无用，源码拿来！修改Echo客户端程序如下所示，其中底纹标注的部分为需要特别注意的地方。

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.Net.Sockets; 
using UnityEngine.UI; 
using System; 

public class Echo : MonoBehaviour
{ 
	//定义套接字 
	Socket socket; 
	//UGUI 
	public InputField InputFeld; 
	public Text text; 
	//接收缓冲区 
	byte[] readBuff = new byte[1024]; 
	string recvStr = ""; 
	//点击连接按钮 
	public void Connection() 
	{
    	//Socket 
		socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
		//Connect 
		socket.BeginConnect("127.0.0.1", 8888, ConnectCallback, socket); 
	} 
	//Connect回调 
	public void ConnectCallback(IAsyncResult ar)
    {
        try
        { 
	 		Socket socket = (Socket) ar.AsyncState; socket.EndConnect(ar); 
 			Debug.Log("Socket Connect Succ"); 
 			socket.BeginReceive( readBuff, 0, 1024, 0, ReceiveCallback, socket); 
 		} 
		catch (SocketException ex)
        { 
	 		Debug.Log("Socket Connect fail" + ex.ToString());
        } 
	} 
 	//Receive回调 
 	public void ReceiveCallback(IAsyncResult ar)
    {
        try
        { 
	 		Socket socket = (Socket) ar.AsyncState; 
            int count = socket.EndReceive(ar);
            recvStr = System.Text.Encoding.Default.GetString(readBuff, 0, count); 
 			socket.BeginReceive( readBuff, 0, 1024, 0, ReceiveCallback, socket); 
 		} 
 		catch (SocketException ex)
        { 
	 		Debug.Log("Socket Receive fail" + ex.ToString());
        } 
 	} 
    //点击发送按钮 
    public void Send() 
    { 
        //Send 
        string sendStr = InputFeld.text; 
        byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr); 
        socket.Send(sendBytes); 
        //不需要Receive了 
    } 
    public void Update()
    { 
        text.text = recvStr; 
    } 
}
```

上述代码运行的结果如图2-3所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\027.png)

​																						图2-3  程序运行结果

​		下面对值得注意的地方进行进一步解释。

​	**（1）BeginReceive的参数**

​	上述程序中，BeginReceive的参数为(readBuff,0,1024,0,ReceiveCallback,socket)。第一个参数readBuff表示接收缓冲区；第二个参数0表示从readBuff第0位开始接收数据，这个参数和TCP粘包问题有关，后续章节再详细介绍；第三个参数1024代表每次最多接收1024个字节的数据，假如服务端回应一串长长的数据，那一次也只会收到1024个字节。

​	**（2）BeginReceive的调用位置**

​	程序在两个地方调用了BeginReceive：一个是ConnectCallback，在连接成功后，就开始接收数据，接收到数据后，回调函数
 ReceiveCallback被调用。另一个是BeginReceive内部，接收完一串数据后，等待下一串数据的到来，如图2-4所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\028.png)

​																					图2-4  程序结构图

​	**（3）Update和recvStr**

​	在Unity中，只有主线程可以操作UI组件。由于异步回调是在其他线程执行的，如果在BeginReceive给text.text赋值，Unity会弹出“get_isActiveAndEnabled can only be called from the main thread”的异常信息，所以程序只给变量recvStr赋值，在主线程执行的Update中再给text.text赋值（如图2-5所示）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\029.png)

​																					图2-5 	在主线程中给UI组件赋值



###### 2.2.4  异步Send

​		尽管不容易察觉，Send也是个阻塞方法，可能导致客户端在发送数据的一瞬间卡住。TCP是可靠连接，当接收方没有收到数据时，发送方会重新发送数据，直至确认接收方收到数据为止。

​		在操作系统内部，每个Socket都会有一个发送缓冲区，用于保存那些接收方还没有确认的数据。图2-6指示了一个Socket涉及的属性，它分为“用户层面”和“操作系统层面”两大部分。Socket使用的协议、IP、端口属于用户层面的属性，可以直接修改；操作系统层面拥有“发送”和“接收”两个缓冲区，当调用Send方法时，程序将要发送的字节流写入到发送缓冲区中，再由操作系统完成数据的发送和确认。由于这些步骤是操作系统自动处理的，不对用户开放，因此称为“操作系统层面”上的属性。

​		发送缓冲区的长度是有限的（默认值约为8KB），如果缓冲区满，那么Send就会阻塞，直到缓冲区的数据被确认腾出空间。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\030.png)

​																							图2-6  发送缓冲区示意图

​		可以做一个这样的实验：删去服务端Receive相关的内容，使客户端的Socket缓冲区不能释放，然后发送很多数据（如下代码所示），这时就能够把客户端卡住。

```c#
//点击发送按钮 
public void Send() 
{ 
	//Send 
    string sendStr = InputFeld.text; 
    byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr);
    for(int i=0;i<10000;i++)
    { 
        socket.Send(sendBytes); 
    } 
}
```

​		值得注意的是，Send过程只是把数据写入到发送缓冲区，然后由操作系统负责重传、确认等步骤。Send方法返回只代表成功将数据放到发送缓存区中，对方可能还没有收到数据。

​		异步Send不会卡住程序，当数据成功写入输入缓冲区（或发生错误）时会调用回调函数。异步Send方法BeginSend的原型如下。

```c#
public IAsyncResult BeginSend( 
    byte[] buffer, 
    int offset, 
    int size, 
    SocketFlags socketFlags, 
    AsyncCallback callback, 
    object state 
)
```

​		表2-3对BeginSend的参数进行了说明。

​																							表2-3  BeginSend参数说明

| 参数        | 说明                                                         |
| ----------- | ------------------------------------------------------------ |
| buffer      | Byte类型的数组，包含要发送的数据                             |
| offset      | 从buffer中的offset位置开始发送                               |
| size        | 要发送的字节数                                               |
| socketFlags | SocketFlags值的按位组合,这里设置为0                          |
| callback    | 回调函数,一个AsyncCalback委托                                |
| state       | 一个用户定义对象,其中包含发送操作的相关信息。当操作完成时,此对象会被传递给EndSend委托 |

​		EndSend函数原型如下。它的返回值代表发送的字节数，如果发送失败会抛出异常。

```c#
public int EndSend ( 
	IAsyncResult asyncResult 
)
```

​		又到“Show Me The Code”的时间了，修改客户端程序，使用异步发送。

```c#
//点击发送按钮 
public void Send() 
{ 
	//Send 
	string sendStr = InputFeld.text; 
	byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr); 
	socket.BeginSend(sendBytes, 0, sendBytes.Length, 0, SendCallback, socket); 
} 
 
//Send回调 
public void SendCallback(IAsyncResult ar)
{ 
    try
    { 
        Socket socket = (Socket) ar.AsyncState; 	 
        int count = socket.EndSend(ar); 
        Debug.Log("Socket Send succ" + count); 	
    } 
    catch (SocketException ex)
    { 
        Debug.Log("Socket Send fail" + ex.ToString());
    } 
}
```

​		注意：在上述代码中BeginSend的第二个参数设置为0；第三个参数sendBytes.Length，代表发送sendBytes一整串数据。读者可以将它们分别设置为1、endBytes.Length-1，代表从第2个字符开始发送。

​		一般情况下，EndSend的返回值count与要发送数据的长度相同，代表数据全部发出。但也不绝对，如果EndSend的返回值指示未全部发完，需要再次调用BeginSend方法，以便发送未发送的数据（本章只介绍异步程序，后面章节再详细介绍缓冲区）。

​		使用异步Send时，无论发送多少数据，客户端都不会卡住。测试程序如下所示。

```c#
//点击发送按钮 
public void Send() 
{ 
    //Send 
    string sendStr = InputFeld.text; 
    byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr); 
    for(int i=0;i<10000;i++)
    { 
        socket.BeginSend(sendBytes, 0, sendBytes.Length, 0, SendCallback, socket); 
    } 
}
```

​		图2-7是上述代码的输出结果。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\031.png)

​																							图2-7  代码输出信息





##### 2.3 异步服务端

​		第1章的同步服务端程序同一时间只能处理一个客户端的请求，因为它会一直阻塞，等待某一个客户端的数据，无暇接应其他客户端。使用异步方法，可以让服务端同时处理多个客户端的数据，及时响应。

###### 2.3.1    管理客户端

​		想象一下在聊天室里，某个用户说了一句话后，服务端需要把这句话发送给每一个人。所以服务端需要有个列表，保存所有连接上来的客户端信息。可以定义一个名为ClientState的类，用于保存一个客户端信息。ClientState包含TCP连接所需Socket，以及用于填充BeginReceive参数的读缓冲区readBuff。

```c#
class ClientState 
{
    public Socket socket;  
    public byte[] readBuff = new byte[1024];
}
```

​		C#提供了List和Dictionary等容器类数据结构（System.Collections.Generic命名空间内），其中Dictionary（字典）是一个集合，每个元素都是一个键值对，它是常用于查找和排序的列表。可以通过Add方法给Dictionary添加元素，并通过ContainsKey方法判断Dictionary里面是否包含某个元素。这里假设读者对这些数据结构稍有了解，如果不是很了解，可以先搜索相关的资料。可以在服务端中定义一个Dictionary<Socket,ClientState>类型的Dictionary，以Socket作为Key，以ClientState作为Value。命令如下：

```c#
static Dictionary<Socket, ClientState> clients = new Dictionary<Socket, ClientState>();
```

​		clients的结构如图2-8所示，通过clientState=clients[socket]能够很方便地获取客户端的信息。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\032.png)

​																							图2-8 	clients列表示意图



###### 2.3.2 	异步Accept

​		除了BeginSend、BeginReceive等方法外，异步服务端还会用到异步Accept方法BeginAccept和EndAccept。BeginAccept的函数原型如下。

```c#
public IAsyncResult BeginAccept( 
    AsyncCallback callback, 
    object state 
)
```

​		表2-4对BeginAccept的参数进行了说明。	

​																							表2-4  BeginAccept参数说明

| 参数          | 说明                                          |
| ------------- | --------------------------------------------- |
| AsyncCallback | 回调函数                                      |
| state         | 表示状态信息，必须保证state中包含socket的句柄 |

​		调用BeginAccecpt后，程序继续执行而不是阻塞在该语句上。等到客户端连接上来，回调函数AsyncCallback将被执行。在回调函数中，开发者可以使用EndAccept获取新客户端的套接字（Socket），还可以获取state参数传入的数据。其中EndAccept的原型如下，它会返回一个客户端Socket。

```c#
public Socket EndAccept( 
	IAsyncResult asyncResult 
)
```

​		

###### 2.3.3    程序结构

​		图2-9展示了异步服务端的程序结构，服务器经历Socket、Bind、Listen三个步骤初始化监听Socket，然后调用BeginAccept开始异步处理客户端连接。如果有客户端连接进来，异步Accept的回调函数AcceptCallback被调用，会让客户端开始接收数据，然后继续调用BeginAccept等待下一个客户端的连接。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\033.png)

​																						图2-9 	异步服务端的程序结构



###### 2.3.4 	代码展示

​		“读万卷书不如行万里路”，直接来看看代码吧！服务端程序的主体结构中，定义客户端状态类ClientState，客户端管理列表clients。除了调用BeginAccept外，其大体与同步服务端相似。具体代码如下。

```c#
using System; 
using System.Net; 
using System.Net.Sockets; 
using System.Collections.Generic; 

class ClientState 
{ 
    public Socket socket;  
    public byte[] readBuff = new byte[1024];
} 

class MainClass 
{ 
    //监听Socket 
    static Socket listenfd; 
    //客户端Socket及状态信息 
    static Dictionary<Socket, ClientState> clients = new Dictionary<Socket, ClientState>(); 
    public static void Main (string[] args)
    { 
        Console.WriteLine ("Hello World!"); 
        //Socket 
        listenfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        //Bind 
        IPAddress ipAdr = IPAddress.Parse("127.0.0.1");
        IPEndPoint ipEp = new IPEndPoint(ipAdr, 8888);
        listenfd.Bind(ipEp); 
        //Listen 
        listenfd.Listen(0); 
        Console.WriteLine("[服务器]启动成功"); 
        //Accept 
        listenfd.BeginAccept (AcceptCallback, listenfd); 
        //等待 
        Console.ReadLine();
    }	 
} 	 
```

​		AcceptCallback是BeginAccept的回调函数，它处理了三件事情：

​		1）给新的连接分配ClientState，并把它添加到clients列表中；

​		2）异步接收客户端数据；

​		3）再次调用BeginAccept实现循环。

​		注意BeginReceive的最后一个参数，这里以ClientState代替了原来的Socket。

```c#
//Accept回调 
 public static void AcceptCallback(IAsyncResult ar)
 { 	 
     try
     { 
         Console.WriteLine ("[服务器]Accept"); 
         Socket listenfd = (Socket) ar.AsyncState;  
         Socket clientfd = listenfd.EndAccept(ar); 
         //clients列表 
         ClientState state = new ClientState();  
         state.socket = clientfd; 
         clients.Add(clientfd, state); 
         //接收数据BeginReceive 
         clientfd.BeginReceive(state.readBuff, 0, 1024, 0, 	 ReceiveCallback, state); 
         //继续Accept 
         listenfd.BeginAccept (AcceptCallback, listenfd);  
     } 
     catch (SocketException ex)
     { 
         Console.WriteLine("Socket Accept fail" + ex.ToString()); 
     } 
 }
```

​		ReceiveCallback是BeginReceive的回调函数，它也处理了三件事情：

​		1）服务端收到消息后，回应客户端；

​		2）如果收到客户端关闭连接的信号“if(count==0)”，断开连接；

​		3）继续调用BeginReceive接收下一个数据。

```c#
 //Receive回调 
 public static void ReceiveCallback(IAsyncResult ar)
 { 	 
     try 
     { 
         ClientState state = (ClientState) ar.AsyncState; 	 
         Socket clientfd = state.socket; 
         int count = clientfd.EndReceive(ar); 
         //客户端关闭 
         if(count == 0)
         { 
             clientfd.Close(); 
             clients.Remove(clientfd); 
             Console.WriteLine("Socket Close"); 
             return; 
         } 
         string recvStr = System.Text.Encoding.Default.GetString(state.readBuff, 0, count); 
         byte[] sendBytes = System.Text.Encoding.Default.GetBytes("echo" + recvStr); 
         clientfd.Send(sendBytes);//减少代码量，不用异步 
         clientfd.BeginReceive( state.readBuff, 0, 1024, 0, ReceiveCallback, state); 
     } 
     catch (SocketException ex)
     { 
         Console.WriteLine("Socket Receive fail" + ex.ToString()); 
     } 
 }
```

> 更多知识点
>
> 收到0字节
>
> ​		当Receive返回值小于等于0时，表示Socket连接断开，可以关闭Socket。但也有一种特例，上述程序没有处理，后面章节再做介绍。

​		开始测试程序吧！导出exe文件（如图2-10所示），运行多个客户端，便可以愉快地聊天了。读者可以试着完善这个聊天工具，做一款QQ软件。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\034.png)

​																							图2-10  导出exe文件

程序运行结果如图2-11所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\035.png)

​																							图2-11  Echo程序运行结果





##### 2.4 实践：做个聊天室

​		下面运用前面学到的知识，搭建聊天室。在聊天室中，某个客户端发送聊天消息，所有在线的客户端都会收到这条消息。

###### 2.4.1    服务端

​		聊天室与Echo程序的不同之处在于服务端对消息的处理。服务端会遍历在线的客户端，然后推送消息。代码如下：

```c#
//Receive回调 
public static void ReceiveCallback(IAsyncResult ar)
{ 	
    try
    { 
        …… 
        string recvStr = System.Text.Encoding.Default.GetString(state.readBuff, 0, count); 
        string sendStr = clientfd.RemoteEndPoint.ToString() + ":" + recvStr; 
        byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr); 
        foreach (ClientState s in clients.Values)
        { 	 
            s.socket.Send(sendBytes); 
        } 
        clientfd.BeginReceive( state.readBuff, 0, 1024, 0, ReceiveCallback, state); 
    } 
    catch (SocketException ex)
    { 
        …… 
    } 
}
```



###### 2.4.2    客户端

​		聊天客户端与Echo客户端大同小异，不同的是，它会显示以前的聊天信息。示例代码如下：

```c#
//Receive回调 
public void ReceiveCallback(IAsyncResult ar)
{ 	 
    try 
    { 
        Socket socket = (Socket) ar.AsyncState; 	
        int count = socket.EndReceive(ar); 
        string s = System.Text.Encoding.Default.GetString(readBuff, 0, count); 
        recvStr = s + "\n" + recvStr; 
        socket.BeginReceive( readBuff, 0, 1024, 0, ReceiveCallback, socket); 
    } 
    catch (SocketException ex)
    { 
        Debug.Log("Socket Receive fail" + ex.ToString());  
    } 
}
```



###### 2.4.3    测试

​		现在运行多个客户端，如图2-12所示，愉快地聊天吧！

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\036.png)

​																								图2-12  聊天程序





##### 2.5 状态检测Poll

​		使用异步程序，我们已经能够开发一套聊天程序。除了异步，有没有其他技术可以改善聊天室呢？

###### 2.5.1    什么是Poll

​		比起异步程序，同步程序更简单明了，而且不会引发线程问题。智慧的人们经过多年辛勤钻研，终于在某一天灵光一闪，想到一个处理阻塞问题的绝佳方法，那就是：

```c#
if(socket有可读数据)
{ 
    socket.Receive() 
} 
if(socket缓冲区可写)
{ 
    socket.Send() 
} 
if(socket发生程序)
{ 
    错误处理 
}
```

​		只要在阻塞方法前加上一层判断，有数据可读才调用Receive，有数据可写才调用Send，那不就既能够实现功能，又不会卡住程序了么？可能有人会在心里感叹，这样的好方法我怎么就没有想到呢？

​		微软当然很早就想到了这个解决方法，于是给Socket类提供了Poll方法，它的原型如下：

```c#
public bool Poll ( 
	int microSeconds, 
    SelectMode mode 
)
```

表2-5对Poll的参数进行了说明。

​																							表2-5  Poll的参数说明

| 参数         | 说明                                                         |
| ------------ | ------------------------------------------------------------ |
| microSeconds | 等待回应的时间,以微秒为单位,如果该参数为-1,表示一直等待,如果为0,表示非阻塞 |
| mode         | 有3种可选的模式,分别如下:<br/>SeletRead:如果Socket可读(可以接收数据),返回true,否则返回false;<br/>SelectWrite:如果 Socket可写,返回true,否则回 false;<br/>SelectEror:如果连接失败,返true,否则false |

​		Poll方法将会检查Socket的状态。如果指定mode参数为SelectMode.SelectRead，则可确定Socket是否为可读；指定参数为SelectMode.SelectWrite，可确定Socket是否为可写；指定参数为SelectMode.SelectError，可以检测错误条件。Poll将在指定的时段（以微秒为单位）内阻止执行，如果希望无限期地等待响应，可将microSeconds设置为一个负整数；如果希望不阻塞，可将
 microSeconds设置为0。



###### 2.5.2    Poll客户端

​		卡住客户端的最大“罪犯”就是阻塞Receive方法，如果能在Update里面不停地判断有没有数据可读，如果有数据可读才调用Receive，那不就解决问题了么？代码如下：

```c#
//省略各种using 

public class Echo : MonoBehaviour 
{ 
    //定义套接字 
    Socket socket; 
    //UGUI 
    public InputField InputFeld; 
    public Text text; 
    
    //点击连接按钮 
    public void Connection() 
    { 
        //Socket 
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        //Connect 
        socket.Connect("127.0.0.1", 8888); 
    } 
    
    //点击发送按钮 
    public void Send(){……//略} 

    public void Update()
    { 
        if(socket == null)  return; 
        if(socket.Poll(0, SelectMode.SelectRead))
        { 	 
            byte[] readBuff = new byte[1024]; 
            int count = socket.Receive(readBuff); 
            string recvStr = System.Text.Encoding.Default.GetString(readBuff, 0, count); 
            text.text = recvStr; 
        } 
    } 
}
```

​		上述代码调用了socket.Poll，设置为不阻塞模式（microSeconds为0）。比起异步程序，这段代码可谓简洁。程序只处理阻塞
 Receive，阻塞Send就由读者自己实现吧（也是因为涉及后面的缓冲区章节的内容，所以就留到后面再讲解）。



###### 2.5.3    Poll服务端

​		服务端可以不断检测监听Socket和各个客户端Socket的状态，如果收到消息，则分别处理，流程如下所示。

```c#
初始化listenfd 
初始化clients列表 
while(true)
{ 
	if(listenfd可读)  Accept; 
	for(遍历clients列表)
	{ 
		if(这个客户端可读)  消息处理; 
	}	 
} 	
```

​		服务端使用主循环结构while(true){……}，不断重复做两件事情：

​		1）判断监听Socket是否可读，如果监听Socket可读，意味着有客户端连接上来，调用Accept回应客户端，以及把客户端Socket加入客户端信息列表。

 	 2）如果某一个客户端Socket可读，处理它的消息（在聊天室中，服务端把消息广播给各个客户端）。

​		服务端代码如下：

```c#
class MainClass 
{ 
    //监听Socket 
    static Socket listenfd; 
    //客户端Socket及状态信息 
    static Dictionary<Socket, ClientState> clients = new Dictionary<Socket, ClientState>();  
    public static void Main (string[] args) 
    { 
        //Socket 
        listenfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        //Bind 
        IPAddress ipAdr = IPAddress.Parse("127.0.0.1"); 
        IPEndPoint ipEp = new IPEndPoint(ipAdr, 8888);  
        listenfd.Bind(ipEp); 
        //Listen 
        listenfd.Listen(0); 
        Console.WriteLine("[服务器]启动成功"); 
        //主循环 
        while(true)
        { 
            //检查listenfd 
            if(listenfd.Poll(0, SelectMode.SelectRead))	 
                ReadListenfd(listenfd); 
            //检查clientfd 
            foreach (ClientState s in clients.Values)
            { 
                Socket clientfd = s.socket; 
                if(clientfd.Poll(0, SelectMode.SelectRead))
                { 	 
                    if(!ReadClientfd(clientfd))
                        break; 
                } 
            } 
            //防止CPU占用过高 
			System.Threading.Thread.Sleep(1); 
        }	
    } 
}
```

​		这段代码有三个注意点。

​		其一是在主循环最后调用System.Threading.Thread.Sleep(1)，让程序挂起1毫秒，这样做的目的是避免死循环，让CPU有个短暂的喘息时间。

​		其二是ReadClientfd会返回true或false，返回false表示该客户端断开（收到长度为0的数据）。由于客户端断开后，ReadClientfd会删除clients列表中对应的客户端信息，导致clients列表改变，而ReadClientfd又是在foreach（ClientState s in clients.Values） 的循环中被调用的，clients列表变化会导致遍历失败，因此程序在检测到客户端关闭后将退出foreach循环。

​		其三是将Poll的超时时间设置为0，程序不会有任何等待。如果设置较长的超时时间，服务端将无法及时处理多个客户端同时连接的情况。当然，这样设置也会导致程序的CPU占用率很高。

​		下面来看看ReadListenfd和ReadClientfd两个方法的实现。

​		ReadListenfd代码如下。它和异步服务端中AcceptCallback很相似，用于应答（Accept）客户端，添加客户端信息（ClientState）。

```c#
//读取Listenfd 
public static void ReadListenfd(Socket listenfd)
{ 	
    Console.WriteLine("Accept"); 
    Socket clientfd = listenfd.Accept(); 
    ClientState state = new ClientState();  		
    state.socket = clientfd; 
    clients.Add(clientfd, state); 
}
```

​		ReadClientfd代码如下。它和异步服务端中的ReceiveCallback很相似，用于接收客户端消息，并广播给所有的客户端。

```c#
//读取Clientfd 
public static bool ReadClientfd(Socket clientfd)
{ 	 
    ClientState state = clients[clientfd]; 
    //接收 
    int count = 0; 
    try
    { 
        count = clientfd.Receive(state.readBuff);  
    }
    catch(SocketException ex)
    { 
        clientfd.Close(); 
        clients.Remove(clientfd); 
        Console.WriteLine("Receive SocketException " + ex.ToString()); 
        return false; 
    } 

    //客户端关闭 
    if(count == 0)
    { 
        clientfd.Close(); 
        clients.Remove(clientfd); 
        Console.WriteLine("Socket Close"); 
        return false; 
    } 
    //广播 
    string recvStr = System.Text.Encoding.Default.GetString(state.readBuff, 0, count); 
    Console.WriteLine("Receive" + recvStr); 
    string sendStr = clientfd.RemoteEndPoint.ToString() + ":" + recvStr; 
    byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr); 
    foreach (ClientState cs in clients.Values)
    { 	
        cs.socket.Send(sendBytes); 
    } 
    return true; 
}
```

​		尽管逻辑清晰，但Poll服务端的弊端也很明显，若没有收到客户端数据，服务端也一直在循环，浪费了CPU。Poll客户端也是同理，没有数据的时候还总在Update中检测数据，同样是一种浪费。从性能角度考虑，还有不小的改进空间。





##### 2.6 多路复用Select

###### 2.6.1    什么是多路复用

​		此节内容为重点知识，因为后面章节的服务端程序将全部使用Select模式。多路复用，就是同时处理多路信号，比如同时检测多个Socket的状态。

​		又是辛勤的人们，经过没日没夜的加班，终于灵光一闪，想到了解决Poll服务端中CPU占用率过高的方法，那就是：同时检测多个Socket的状态。在设置要监听的Socket列表后，如果有一个（或多个）Socket可读（或可写，或发生错误信息），那就返回这些可读的Socket，如果没有可读的，那就阻塞。

​		Select方法便是实现多路复用的关键，它的原型如下：

```c#
public static void Select( 
    IList checkRead, 
    IList checkWrite, 
    IList checkError, 
    int microSeconds 
)
```

表2-6对Select的参数进行了说明。

​																							表2-6  Select的参数说明

| 参数         | 说明                                                         |
| ------------ | ------------------------------------------------------------ |
| checkRead    | 检测是否有可读的Socket列表                                   |
| checkWrite   | 检测是否有可写的Socket列表                                   |
| checkError   | 检测是否有出错的Socket列表                                   |
| microSeconds | 等待回应的时间,以微秒为单位,如果该参数为-1表示一直等待,如果为0表示非阻塞 |

​		Select可以确定一个或多个Socket对象的状态，如图2-13所示。使用它时，须先将一个或多个套接字放入IList中。通过调用Select（将IList作为checkRead参数），可检查Socket是否具有可读性。若要检查套接字是否具有可写性，可使用checkWrite参数。若要检测错误条件，可使用checkError。在调用Select之后，Select将修改IList列表，仅保留那些满足条件的套接字。如图2-13所示，把包含6个Socket的列表传给Select，Select方法将会阻塞，等到超时或某个（或多个）Socket可读时返回，并且修改checkRead列表，仅保存可读的socket A和socket C。当没有任何可读Socket时，程序将会阻塞，不占用CPU资源。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\037.png)

​																					图2-13  Select示意图	



###### 2.6.2 	Select服务端

​		服务端调用Select，等待可读取的Socket，流程如下。

```C#
初始化listenfd 
初始化clients列表 
while(true) 
{ 
	checkList = 待检测Socket列表 
    Select(checkList ...) 
 	for(遍历可读checkList 列表)
 	{ 
 		if(listenfd可读)  Accept; 
     	if(这个客户端可读)  消息处理; 
	}	
} 	 
```

服务端使用主循环结构while(true){…}，不断地调用Select检测Socket状态，其步骤如下：

- 将监听Socket（listenfd）和客户端Socket（遍历clients列表）添加到待检测Socket可读状态的列表checkList中。
- 调用Select，程序中设置超时时间为1秒，若1秒内没有任何可读信息，Select方法将checkList列表变成空列表，然后返回。
- 对Select处理后的每个Socket做处理，如果监听Socket（listenfd）可读，说明有客户端连接，需调用Accept。如果客户端Socket可读，说明客户端发送了消息（或关闭），将消息广播给所有客户端。

上述过程的示例代码如下：

```c#
using System; 
using System.Net; 
using System.Net.Sockets; 
using System.Collections.Generic; 

class ClientState 
{ 
    public Socket socket;  
    public byte[] readBuff = new byte[1024];  
} 

class MainClass 
{ 
    //监听Socket 
    static Socket listenfd; 
    //客户端Socket及状态信息 
    static Dictionary<Socket, ClientState> clients = new Dictionary<Socket, ClientState>(); 

    public static void Main (string[] args)  
    { 
        //Socket 
        listenfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        //Bind 
        IPAddress ipAdr = IPAddress.Parse("127.0.0.1"); 
        IPEndPoint ipEp = new IPEndPoint(ipAdr, 8888);  
        listenfd.Bind(ipEp); 
        //Listen 
        listenfd.Listen(0); 
        Console.WriteLine("[服务器]启动成功"); 
        //checkRead 
        List<Socket> checkRead = new List<Socket>(); 
        //主循环 
        while(true)
        { 
            //填充checkRead列表 
            checkRead.Clear(); 
            checkRead.Add(listenfd);  
            foreach (ClientState s in clients.Values)
            { 	 
                checkRead.Add(s.socket); 
            } 
            //select 
            Socket.Select(checkRead, null, null, 1000); 
            //检查可读对象 
 			foreach (Socket s in checkRead)
            { 
 				if(s == listenfd)
 					ReadListenfd(s); 
 				else 
 					ReadClientfd(s); 
            } 

        }	 
    } 	
}
```

​		其中ReadListenfd和ReadClientfd与2.5.3节的实现相同，这里不再重复



###### 2.6.3    Select客户端

​		使用Select方法的客户端和使用Poll方法的客户端极其相似，因为只需检测一个Socket的状态，将连接服务端的socket输入checkRead列表即可。为了不卡住客户端，Select的超时时间设置为0，永不阻塞。示例代码如下：

```c#
public void Update()
{ 
    if(socket == null) return; 
    //填充checkRead列表 
    checkRead.Clear(); 
    checkRead.Add(socket); 
    //select 
    Socket.Select(checkRead, null, null, 0);  
    //check 
    foreach (Socket s in checkRead)
    { 
        byte[] readBuff = new byte[1024]; 
        int count = socket.Receive(readBuff); 
        string recvStr =  System.Text.Encoding.Default.GetString(readBuff, 0, count); 
        text.text = recvStr; 
    } 
}
```

​		由于程序在Update中不停地检测数据，性能较差。商业上为了做到性能上的极致，大多使用异步（或使用多线程模拟异步程序）。本书将会使用异步客户端、Select服务端演示程序。

​		如果读者想要了解更多异步服务端的知识，欢迎阅读本书的第一版，第一版内容全程使用了异步服务端程序。

​		实践出真知，尽管还有一些“坑”没有处理，但最基本的知识都掌握了。先动手做一款简单的网络游戏吧！







#### 第3章 实践出真知：大乱斗游戏

​		通过前面两章的学习，读者应该对Socket编程有了一定的了解。那么，开发网络游戏还会涉及哪些概念？怎样将Socket编程和实际游戏项目结合起来？

​		本章将通过完整实例介绍开发网络游戏的过程，以及其中会涉及的概念。尽管它并不完美，没有避开深藏其中的“坑”，但它展示了网络模块的设计思路，以及网络消息的处理方法。

##### 3.1 什么是大乱斗游戏

​		大乱斗是一种常见的游戏模式，所有角色会进入同一个场景，玩家可以控制它们移动，也可以让角色攻击敌人，如图3-1所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\038.png)

​																								图3-1  大乱斗游戏		

游戏说明：
		1）打开客户端即视为进入游戏，在随机出生点刷出角色。

​		2）使用鼠标左键点击场景，角色会自动走到指定位置。

​		3）在站立状态下，点击鼠标右键可使角色发起攻击，角色会向鼠标指向的方向进攻。

​		4）每个角色默认有100滴血（hp），受到攻击会掉血，死亡后从场景消失，提示“game over”。

​		5）若玩家掉线，视为死亡，从场景中消失。

​      以下是游戏开发的步骤，随后将根据这些步骤来介绍这个游戏的开发过程。

- 搭建场景。
- 编写角色类代码，这一步会介绍角色类的继承结构。
- 编写客户端网络模块，这一步会介绍“协议”“消息队列”等几个概念，是本章的重点。
- 编写服务端程序，这一步会介绍一种常用的服务端处理网络消息的方法。
- 各个协议的处理，包括进入游戏协议、移动协议等。





##### 3.2 搭建场景

​		大乱斗游戏需要两个素材：一个平面场景、一个带动作的人物模型。Unity自带的Standard Assets包含了这个示例需要的大部分素材，读者可以导入Standard Assets的Characters和Environment两个库，以获取素材（右击Assets面板，选择Import Package，再分别选择Characters和Environment，如图3-2所示）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\039.png)

​																								图3-2  导入Standard Assets素材

​		导入素材后，可以使用Terrain搭建场景，再在地表上画出好看的纹理，如图3-3所示。为方便后续的制作，可将Terrain的中心点放到原点的位置，再调整摄像机的角度，45°俯视角对准原点，如图3-4所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\040.png)

​																								图3-3  使用Terrain搭建场景

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\041.png)

​																								图3-4  45°俯视的相机

​		然后添加一个名为“Terrain”的Tag，将地形的标签设为Terrain。在制作“玩家通过鼠标左键点击场景，角色会自动走到指定位置”的功能时，会通过该标签判断是否点击到场景，如图3-5所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\042.png)

​																								图3-5  设置标签（Tag）

Standard Assets的Characters库提供了一个人物模型（导入后位于Assets/Standard Assets/Characters/ThirdPersonCharacter/Models，如图3-6和图3-7所示），还提供了行走、站立等动作，可以用来作为游戏中的角色素材。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\043.png)

​																								图3-6  人物模型（一）

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\044.png)

​																								图3-7  人物模型（二）





##### 3.3 角色类Human

###### 3.3.1    类结构设计

​		大乱斗游戏的核心要素之一是玩家所控制的角色，它可以行走，还可以攻击其他角色。玩家可以操控一个角色，又能够看到其他玩家操控的角色，可想而知，这两种角色应有不同的表现。玩家操控的角色是由玩家驱动的（下称“操控角色”），它接受鼠标的控制；其他玩家操控的角色（下称“同步角色”）是由网络数据驱动的，由服务端转发角色的状态信息。这两种角色有很多共同点，比如都可以行走、都可以表现攻击动作等。

​		可以设计图3-8所示的类结构，其基类BaseHuman是基础的角色类，它处理“操控角色”和“同步角色”的一些共有功能；CtrlHuman类代表“操控角色”，它在BaseHuman类的基础上处理鼠标操控功能；SyncHuman类是“同步角色”类，它也继承自BaseHuman，并处理网络同步（如果有必要）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\045.png)

​																								图3-8  Human类结构图



###### 3.3.2    BaseHuman

​		接下来开始编写代码。一句句添加代码，一步步实现功能。首先要实现的是角色在场景中出现、消失和移动，后续再实现角色的攻击和死亡。BaseHuman作为角色类的基类，处理移动、攻击等功能。

​		第一版的BaseHuman代码如下：

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class BaseHuman : MonoBehaviour 
{ 
    //是否正在移动 
    protected bool isMoving = false; 
    //移动目标点 
    private Vector3 targetPosition; 
    //移动速度 
    public float speed = 1.2f; 
    //动画组件 
    private Animator animator; 
    //描述 
    public string desc = "";  
    
    //移动到某处 
    public void MoveTo(Vector3 pos)
    { 
        targetPosition = pos; 
        isMoving = true; 
        animator.SetBool("isMoving", true); 
    } 
    
    //移动Update 
    public void MoveUpdate()
    { 
        if(isMoving == false)  return; 
        Vector3 pos = transform.position; 
        transform.position = Vector3.MoveTowards(pos, targetPosition, speed*Time.deltaTime); 
        transform.LookAt(targetPosition); 
        if(Vector3.Distance(pos, targetPosition) < 0.05f)
        { 	
            isMoving = false; 
            animator.SetBool("isMoving", false); 
        } 
    } 

    protected void Start ()
    { 
        animator = GetComponent<Animator>(); 
    } 

    protected void Update () 
    { 
        MoveUpdate(); 
    } 
}
```

​		以下是上述代码的说明。

​		**（1）继承关系**

​		BaseHuman类继承自MonoBehaviour（如图3-9所示），说明它可以作为组件挂到GameObject身上，也说明它拥有MonoBehaviour的一些性质，比如在唤醒时会执行Awake和Start，每帧会执行一次Update。代码中Start和Update方法使用了protected关键字修饰，意味着只有该类本身和继承类可以调用这两个方法。当然，将它修改为public也无伤大雅。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\046.png)

​																								图3-9  类结构示意图

​		**（2）移动功能**

​		BaseHuman的一大半代码都是在处理移动功能，移动功能会涉及isMoving、targetPosition和speed三个变量，以及MoveTo和
MoveUpdate两个方法。角色移动的流程如图3-10所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\047.png)

​																								图3-10  移动功能流程图

- isMoving是bool型变量，指代角色是否正在移动。
- targetPosition是Vector3类型的坐标，代表角色移动的目的地。在玩家点击鼠标左键（或通过网络同步）获取目的地坐标后，MoveTo方法会把目的地的坐标赋给targetPosition，而后续的MoveUpdate会让玩家一步步往目的地方向移动。
- speed代表移动的速度。
- MoveTo方法是给玩家指定目的地的方法，当玩家单击鼠标时，会调用所控制角色的MoveTo方法，设置目的地坐标（targetPosition）和动画状态。
- MoveUpdate是一个被Update调用的方法，所以它会每帧执行一次。首先通过if(isMoving==false)判断当前是否处于行走状态，如果不是行走状态，就无须往目的地行进了；接着通过Vector3.MoveTowards计算新位置，MoveTowards的作用是计算pos朝targetPosition方向移动一段距离后的位置；之后使用transform.LookAt让角色转向目标点；最后使用Vector3.Distance判断当前位置与目标位置的距离，如果距离足够小，就认为角色到达了目的地，再将角色状态更改为站立状态（isMoving=false）。

​		**（3）动画功能**

​		BaseHuman中定义了Animator型变量animator，它会指代角色身上的动画控制器。动画控制器中设有isMoving参数，程序通过类似“animator.SetBool("isMoving",false);”的语句改变动画控制器的值，从而让角色播放行走和站立两种动画。



###### 3.3.3    角色预设

​		接下来开始制作角色预设。

​		为使角色可以播放不同的动作，需要新建一个动画控制器（如图3-11所示，此处命名为HumanAniCtrl），给动画控制器添加Idle和Run两个状态，如图3-12所示，并设置Idle和Run的转换条件。

​		接着添加每个状态的动画，StandardAsset中包含了站立（HumanoidIdle）和跑步（HumanoidRun）等动作，只需要给Idle和Run两个状态设置相应的动作（Motion）即可，如图3-13所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\048.png)

​																								图3-11  动画控制器

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\049.png)

​																								图3-12  动画编辑器的两个状态

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\050.png)

​																								图3-13  给Idle状态设置动作

​		为了能控制动画的切换状态，可给动画控制器添加一个Bool类型的参数isMoving，如图3-14所示，用来控制角色的动作。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\051.png)

​																								图3-14  添加参数isMoving

​		然后设置两组状态的切换条件，图3-15展示的是从Idle状态切换到Run状态的条件，当参数isMoving为true时，切换状态。为了有更好的动作表现效果，可将Has Exit Time设置为false，并缩短动画混合的时间。从Run切换到Idle状态的条件（Conditions）是isMoving为false，用参数isMoving控制动画状态机。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\052.png)

​																								图3-15  Idle状态切换到Run状态的设置

​		最后，将人物模型做成预设（按Ctrl+D复制Characters库的模型，移动到Assets目录下），并添加Animator组件，设置Animator的动画控制器（Controller）为之前创建的HumanAniCtrl，如图3-16所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\053.png)

​																								图3-16	设置动画控制器



###### 3.3.4 	CtrlHuman

​		完成了Human基类BaseHuman和角色预设，接下来开始设计“操控角色”类CtrlHuman。CtrlHuman继承自BaseHuman，拥有BaseHuman的所有功能。除此之外，CtrlHuman还实现了鼠标操控角色移动的功能。图3-17展示了CtrlHuman的核心功能。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\054.png)

​																								图3-17  CtrlHuman核心功能

​		CtrlHuman类代码如下：

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class CtrlHuman : BaseHuman 
{ 
    new void Start () 
    { 
        base.Start(); 
    } 

    new void Update () 
    { 
        base.Update(); 
        if(Input.GetMouseButtonDown(0))
        { 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit; 
            Physics.Raycast(ray, out hit); 
            if (hit.collider.tag == "Terrain")
                MoveTo(hit.point); 
        } 
    } 
}
```

​		以下是上述代码说明。

​		**（1）base.XXX，new void XXX（）**

​		base指当前类的父类，可调用父类的非私有属性和方法，代码中的base.Start和base.Update指代调用父类BaseHuman的Start和Update方法。

​		new用作修饰符时，new关键字可以显式地隐藏从基类继承的成员。隐藏继承的成员时，该成员的派生版本将替换基类版本。虽然可以在不使用new修饰符的情况下隐藏成员，但会生成警告。

​		**（2）判断鼠标输入**

​		Input.GetMouseButtonDown(0)用于判断鼠标是否被按下：参数为0表示判断鼠标左键是否被按下，参数为1表示判断鼠标右键是否被按下。而Input.mousePosition代表当前鼠标所指的屏幕坐标。

​		**（3）获取点击位置**

​		Unity3D中的Camera.ScreenPointToRay方法能够将屏幕位置转成一条射线，只需填入屏幕坐标点，该方法将返回对应的射线。射线是在三维坐标中一个点向一个方向发射的一条线，Unity3D中可以使用Ray和Physics.Raycast来做射线检测。当射线射向碰撞器时Raycast返回true，否则为false，并且可以通过out hit变量获取碰撞点。如果射线与场景发生碰撞（Tag为Terrain），那么碰撞点就是角色移动的目标点。

​      写好代码，怎能不测试一番？将角色预设拉到场景上，添加CtrlHuman组件，然后运行游戏，如图3-18所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\055.png)

​																								图3-18  运行游戏，看到刚刚创建的角色

​		点击鼠标左键设置目的地，角色朝目的地跑过去，如图3-19所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\056.png)

​																								图3-18  角色朝着目的地跑过去



###### 3.3.5 	SyncHuman

​		同步角色SyncHuman暂无特殊功能，编写一个继承自BaseHuman的类SyncHuman，并处理它的Start和Update方法即可。代码如下：

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class SyncHuman : BaseHuman 
{ 
    new void Start () 
    { 
        base.Start(); 
    } 
    new void Update ()
    { 
        base.Update(); 
    } 
}
```





##### 3.4 如何使用网络模块

​		前两章介绍了异步Socket编程的基础知识，还介绍了Echo、聊天室的例子。但在实际的网络游戏开发中，网络模块往往是作为一个底层模块用的，它应该和具体的游戏逻辑分开，而不应该把处理逻辑的代码（例如之前给recvStr赋值）写到ReceiveCallback里面去，因为ReceiveCallback应当只处理网络数据，不应该去处理游戏功能。一个可行的做法是，给网络管理类添加回调方法，当收到某种消息时就自动调用某个函数，这样便能够将游戏逻辑和底层模块分开。制作网络管理类前，需要先了解委托、协议和消息队列这三个概念。

###### 3.4.1    委托

​		网络管理类会使用委托实现消息分发，可以把委托理解成回调函数的实现方式。委托是一个类，它定义了方法的类型，从而可以将方法当作另一个方法的参数来进行传递，这种将方法动态地赋给参数的做法，可以避免在程序中大量使用if-Else（或Switch）语句，同时使得程序具有更好的可扩展性。

​		delegate（委托）是C#中的一种类型，它能够引用某种类型的方法，它相当于C/C++中的函数指针，使用委托需要：

​		1）声明一个delegate类型，它必须与要传递的方法具有相同的参数和返回值类型；

​		2）创建delegate对象，并将要传递的方法作为参数传入；

​		3）在适当的地方调用它。

​		在如下的代码中，“delegate void DelegateStr(string str)”创建了一个名为“DelegateStr”的delegate类型，它可以引用带有一个string参数、返回值类型为void的方法。接着在Main方法中使用“DelegateStr fun=new DelegateStr(PrintStr)”创建名为“fun”的DelegateStr对象，并将需要调用的方法PrintStr传入其中。最后使用fun("Hello Lpy")调用该方法。

```c#
//声明委托类型 
public delegate void DelegateStr(string str); 
//需要调用的方法 
public static void PrintStr(string str)
{ 
    Console.WriteLine("PrintStr: " + str); } 
//主函数 
public static void Main (string[] args)
{ 
    //创建delegate对象 
    DelegateStr fun = new DelegateStr(PrintStr);
    //调用 
    fun("Hello Lpy"); 
    Console.ReadLine(); 
}
```

​		运行程序，调用fun("Hello Lpy")相当于调用了PrintStr("HelloLpy")。运行结果如图3-20所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\057.png)

​																								图3-20  委托示例程序

​		“+=”和“-=”是委托对象的操作符。例如下面代码中添加新方法PrintStr2，然后使用fun+=PrintStr2传入PrintStr2方法。这时委托对象fun带有PrintStr和PrintStr2这两个方法，调用时两个方法会被依次调用。运行结果如图3-21所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\058.png)

​																								图3-21  程序运行结果

```c#
//需要调用的方法2 
public static void PrintStr2(string str)
{ 
    Console.WriteLine("PrintStr2: " + str); 
} 
DelegateStr fun = new DelegateStr(PrintStr); 
fun += PrintStr2;
```

​		使用“-=”可以删除某个传入的方法，如下面的代码中使用“DelegateStr fun=new DelegateStr（PrintStr）”和 fun+=PrintStr2给fun添加了PrintStr和PrintStr2两个方法，随后又使用fun-=PrintStr删除了PrintStr。这时调用fun，将只有PrintStr2起作用。运行结果如图3-22所示。

```c#
DelegateStr fun = new DelegateStr(PrintStr); 
fun += PrintStr2; 
fun -= PrintStr;
```

​		总而言之，读者可以把委托当作是回调函数的一种实现。由于定义了委托类型，也相当于定义了回调函数的形式，回调函数必须符合委托类型所定义的参数和返回值类型。而且一个委托可以对应多个回调函数；一次调用，多个函数会被回调。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\059.png)

​																								图3-22  传入委托的PrintStr被删除



###### 3.4.2    通信协议

​		通信协议是通信双方对数据传送控制的一种约定，通信双方必须共同遵守，方能“知道对方在说什么”和“让对方听懂我的话”。例如，当有玩家在场景里面走动，就需要将位置信息广播给其他在线玩家，那么该发送什么样的数据给服务端呢？本小节会使用一种最简单的字符串协议来实现。协议格式如下所示，消息名和消息体用“|”隔开，消息体中各个参数用“,”隔开。

> ​		消息名|参数1,参数2,参数3,...

​		如果玩家在场景里面移动，它至少需要告诉其他在线玩家以下信息：		

​		**1）要做什么事情**——由消息名决定，消息名为“Move”表示移动，“Leave”表示离开，“Enter”表示进入场景；

​		**2）谁在移动**——通过参数1表明身份，可以使用客户端的IP和端口表示；

​		**3）目的地是什么**——通过参数2到4说明目的地坐标点。

​		所以该客户端会发送类似下面的字符串给其他客户端。其中：“Move”代表这条协议是移动同步协议，“127.0.0.1:1234”代表了客户端的身份，“10,0,8”三个值代表目的地的坐标。

> Move|127.0.0.1:1234, 10, 0, 8,

​		其他客户端收到服务端转发的字符串后，使用Split('|')和Split(',')便可将协议中各个参数解析出来，进而处理数据。代码如下：

```c#
string str = "Move|127.0.0.1:1234, 10, 0,8,"; 
string[] args = str.Split('|'); 
string msgName = args[0]; //协议名：Move 
string msgBody = args[1]; //协议体：127.0.0.1:1234, 10, 0,8, 
string[] bodyArgs = msgBody.Split(','); 
string desc = bodyArgs [0]; //玩家描述：127.0.0.1:1234 
float x = float.Parse(bodyArgs [1]);    //x坐标：10 
float y = float.Parse(bodyArgs [2]);    //y坐标：0 
float z = float.Parse(bodyArgs [3]);    //z坐标：8
```

​		结合委托的知识，客户端程序提供各种消息类型（通过消息名区分）的处理方法，网络模块解析消息，将不同类型的消息派发给不同的方法去处理。例如：如果收到一条“Move”协议，就交给OnMove方法处理；如果收到一条“Enter”协议，就交给OnEnter方法去处理。



###### 3.4.3    消息队列

​		由于在Unity中，只有主线程才能操作UI组件，所以在第2章的聊天室例子中，定义了变量recvStr作为主线程和回调线程之间的桥梁。多线程消息处理虽然效率较高，但非主线程不能设置Unity3D组件，而且容易造成各种莫名其妙的混乱。由于单线程消息处理足以满足游戏客户端的需要，因此大部分游戏会使用消息队列让主线程去处理异步Socket接收到的消息。

​		C#的异步通信由线程池实现，不同的BeginReceive不一定在同一线程中执行。创建一个消息列表，每当收到消息便在列表末端添加数据，这个列表由主线程读取，它可以作为主线程和异步接收线程之间的桥梁。由于MonoBehaviour的Update方法在主线程中执行，可让Update方法每次从消息列表中读取几条信息并处理，处理后便在消息列表中删除它们。本章例子中，消息队列可以使用List<String>实现。图3-23是消息队列的示意图，图中的“4364”“4365”和“5522”代表玩家的身份。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\060.png)

​																								图3-23 	消息队列示意图



###### 3.4.4  NetManager类

​		又到Show me the code的时间了，结合异步Socket编程、委托回调、消息队列等知识，实现一套通用的网络模块。当然，它是不完美的，有漏洞的，后续章节会逐步完善它。网络模块中最核心的地方是一个称为NetManager的静态类，这个类对外提供了三个最主要的接口。

- Connect方法，调用后发起连接；

- AddListener方法，消息监听。其他模块可以通过AddListener设置某个消息名对应的处理方法，当网络模块接收到这类消息时，就会回调处理方法；

- Send方法，发送消息给服务端。

  无论内部实现有多么复杂，网络模块对外的接口只有图3-24所展示的这几个。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\061.png)

​																								图3-24  NetManager对外示意图

​		下面的代码展示网络模块的使用方法，当收到Enter协议时，NetManager就会调用OnEnter方法。

```c#
void Start ()
{ 
    NetManager.AddListener("Enter", OnEnter); 	 		
    NetManager.Connect("127.0.0.1", 8888); 
} 
void Update()
{ 
    NetManager.Update(); 
} 
void OnEnter (string msg)
{ 
    Debug.Log("OnEnter"); 
}
```

​		对内部而言，NetManager使用了异步Socket接收消息，每次接收到一条消息后，NetManager会把消息存入消息队列中（如图3-25所示）。NetManager有一个供外部调用的Update方法，每当调用它时就会处理消息队列里的第一条消息，然后根据协议名将消息分发给对应的回调函数。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\062.png)

​																								图3-25  NetManager的内部处理流程

​		NetManager的代码如下：

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.Net.Sockets; 
using UnityEngine.UI; 
using System; 

public static class NetManager 
{ 
    //定义套接字 
    static Socket socket; 
    //接收缓冲区 
    static byte[] readBuff = new byte[1024]; 
    //委托类型 
    public delegate void MsgListener(String str); 
    //监听列表 
    private static Dictionary<string, MsgListener> listeners = new Dictionary<string, MsgListener>(); 
    //消息列表 
    static List<String> msgList = new List<string>(); 
    //添加监听 
    public static void AddListener(string msgName, MsgListener listener)
    { 
        listeners[msgName] = listener; 
    } 
    //获取描述 
    public static string GetDesc()
    { 
        if(socket == null) return ""; 
        if(!socket.Connected) return ""; 
        return socket.LocalEndPoint.ToString(); 
    } 
    //连接 
    public static void Connect(string ip, int port) 
    { 
        //Socket 
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
        //Connect （用同步方式简化代码） 
        socket.Connect(ip, port); 
        //BeginReceive 
        socket.BeginReceive( readBuff, 0, 1024, 0, ReceiveCallback, socket); 
    } 


    //Receive回调 
    private static void ReceiveCallback(IAsyncResult ar)
    { 	 
        try 
        { 
            Socket socket = (Socket) ar.AsyncState; 
            int count = socket.EndReceive(ar); 
            string recvStr = System.Text.Encoding.Default.GetString(readBuff, 0, count); 
            msgList.Add(recvStr); 
            socket.BeginReceive( readBuff, 0, 1024, 0, ReceiveCallback, socket); 
        } 
        catch (SocketException ex)
        { 
            Debug.Log("Socket Receive fail" + ex.ToString());  
        } 
    } 
    //发送 
    public static void Send(string sendStr) 
    { 
        if(socket == null) return; 
        if(!socket.Connected)return; 
        byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr); 
        socket.Send(sendBytes); 
    } 
    //Update 
    public static void Update()
    { 
        if(msgList.Count <= 0)  return; 
        String msgStr = msgList[0]; 
        msgList.RemoveAt(0); 
        string[] split = msgStr.Split('|'); 
        string msgName = split[0]; 
        string msgArgs = split[1]; 
        //监听回调; 
        if(listeners.ContainsKey(msgName))
            listeners[msgName](msgArgs); 
    }	
}
```

​		代码说明如下。

​		（1）MsgListener

​		 MsgListener是一个委托类型，它指明了回调函数只有一个string参数。

​		（2）listeners

​		监听列表，它指明了各个消息名所对应的处理方法（如图3-26所示），外部可以通过AddListener方法添加对应消息名的处理函数。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\063.png)

​																								图3-26  监听列表示意图

​		（3）Connect/Send

​		为了减少代码量，使用同步Connect和Send，读者可以自行改为异步方式。

​		（4）漏洞

​		上述代码没有处理粘包分包、线程冲突等问题，后续章节会逐一解决它们。



###### 3.4.5    测试网络模块

​		完成简易的网络模块，编写一小段代码来测试它，从而确保网络模块能够正常工作。新建一个Main组件，并挂到场景中任一物体上。在Start方法中调用NetManager的AddListener方法，分别监听Enter、Move和Leave三个协议，然后调用Connect方法连接服务端。代码如下所示，后续的游戏功能也会在Main中实现。

​		客户端测试代码：

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Main : MonoBehaviour 
{ 
    void Start () 
    { 
        NetManager.AddListener("Enter", OnEnter);
        NetManager.AddListener("Move", OnMove);
        NetManager.AddListener("Leave", OnLeave);
        NetManager.Connect("127.0.0.1", 8888);  
    } 
    void OnEnter (string msg) 
    { 
        Debug.Log("OnEnter" + msg); 
    } 
    void OnMove (string msg)
    { 
        Debug.Log("OnMove" + msg); 
    } 
    void OnLeave (string msg)
    { 
        Debug.Log("OnLeave" + msg); 
    } 
}
```

​		做个最简单的测试，角色移动时给服务端发送Enter协议，服务端原封不动地转发数据，客户端收到消息后，理应回调OnEnter方法，打印出消息内容。

​		在客户端的CtrlHuman类中添加发送协议的代码，如下所示：

```c#
public class CtrlHuman : BaseHuman
{ 
    new void Update ()
    { 
        …… 
        if(Input.GetMouseButtonDown(0))
        { 
        	…… 
            if (hit.collider.tag == "Terrain")
            { 
            	MoveTo(hit.point); 
                NetManager.Send("Enter|127.1.1.1,100,200,300,45"); 
            }	
        } 	 
    } 	
}  
```

​		本书会使用Select来演示服务端程序。参照上一章的Select服务端程序，将收到的消息原封不动地广播给所有客户端。

​		服务端部分代码如下：

```c#
//读取Clientfd 
public static bool ReadClientfd(Socket clientfd)
{ 	 
    …… 
    //广播 
    string recvStr =  System.Text.Encoding.Default.GetString(state.readBuff, 0, count); 
    Console.WriteLine("Receive" + recvStr); 
    string sendStr = recvStr; 
    byte[] sendBytes = System.Text.Encoding.Default.GetBytes(sendStr); 
    foreach (ClientState cs in clients.Values)
    { 	
        cs.socket.Send(sendBytes); 
    } 
    return true; 
}  
```

​		运行服务端和客户端，点击鼠标让小人移动，可以看到客户端和服务端都输出了消息内容，如图3-27a和图3-27b所示，表示网络模块正常工作。接下来便可以编写具体的网络协议了。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\064.png)

​																										图   3-27





##### 3.5 进入游戏：Enter协议

​		当玩家打开游戏，客户端程序会生成一个操控角色（CtrlHuman），并把它放到场景中的一个随机位置。然后发送一条Enter协议给服务端，包含了对玩家的描述、位置等信息。服务端将Enter协议广播出去，其他客户端收到Enter协议后，创建一个同步角色（SyncHuman），如图3-28所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\065.png)

​																								图3-28 	Enter协议流程图

###### 3.5.1 	创建角色

​		玩家进入场景便会创建角色，使用Main组件的Start编写相关功能最为合适（由于只有单一功能，所有代码都写到了Main类里面，读者也可以根据需要划分模块）。修改后的Main代码如下所示。

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class Main : MonoBehaviour
{ 
    //人物模型预设 
    public GameObject humanPrefab; 
    //人物列表 
    public BaseHuman myHuman; 
    public Dictionary<string, BaseHuman> otherHumans; 

    void Start () 
    { 
        //网络模块 
        NetManager.AddListener("Enter", OnEnter); 
        NetManager.AddListener("Move", OnMove); 
        NetManager.AddListener("Leave", OnLeave); 
        NetManager.Connect("127.0.0.1", 8888); 
        //添加一个角色 
        GameObject obj = (GameObject)Instantiate(humanPrefab); 
        float x = Random.Range(-5, 5); 
        float z = Random.Range(-5, 5); 
        obj.transform.position = new Vector3(x, 0, z);  
        myHuman = obj.AddComponent<CtrlHuman>(); 
        myHuman.desc = NetManager.GetDesc(); 
        //发送协议 
        Vector3 pos = myHuman.transform.position;  
        Vector3 eul = myHuman.transform.eulerAngles; 
        string sendStr = "Enter|"; 
        sendStr += NetManager.GetDesc()+ ","; 
        sendStr += pos.x + ","; 
        sendStr += pos.y + ","; 
        sendStr += pos.z + ","; 
        sendStr += eul.y; 
        NetManager.Send(sendStr); 
    } 
    void OnEnter (string msgArgs)
    { 
        Debug.Log("OnEnter" + msgArgs); 
    } 
    void OnMove (string msgArgs)
    { 
        Debug.Log("OnMove" + msgArgs); 
    } 
    void OnLeave (string msgArgs)
    { 
        Debug.Log("OnLeave" + msgArgs); 
    } 
}
```

​		这里完成了创建角色和发送Enter协议两项功能，Enter协议包含了角色描述和坐标信息，如图3-29所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\066.png)

​																								图3-29  Enter协议

​		以下是上述代码的说明。

​		（1）玩家操控角色

​		游戏中的角色都由代码生成，定义humanPrefab代表角色预设。角色预设只是一个带动画控制器的模型，不带任何Human类组件（如图3-30所示）。程序会按需给角色添加CtrlHuman或SyncHuman组件。将角色预设拉入Main的humanPrefab属性，如图3-31所示，即可完成预设的设置。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\067.png)

​																								图3-30  角色预设属性

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\068.png)

​																								图3-31  设置角色预设

​		定义BaseHuman类型的myHuman代表生成出来的操控角色，即玩家自己的角色。程序使用Instantiate(humanPrefab)在场景中生成角色GameObject，再生成随机位置，最后通过AddComponent<CtrlHuman>()给GameObject添加CtrlHuman组件。

​		（2）其他同步角色

​		程序中定义了Dictionary<string,BaseHuman>类型的成员otherHumans，otherHumans列表将会保存所有同步角色的信息（后续会用到）。

​		（3）发送协议

​		调用NetManager的Send方法发送Enter协议，Enter协议包含了角色描述、位置坐标（pos.x,pos.y,pos.z）和旋转角度（eul.y）。



###### 3.5.2    接收Enter协议

​		客户端收到服务端转发的Enter协议后，需要解析Enter协议的各个参数，包括角色描述（desc）、三个坐标信息（x、y、z）以及旋转角度（eulY），然后添加一个同步角色，把它记录到otherHumans列表中。

​		Main代码修改如下。

```c#
void OnEnter (string msgArgs) 
{ 
    Debug.Log("OnEnter" + msgArgs); 
    //解析参数 
    string[] split = msgArgs.Split(','); 
    string desc = split[0]; 
    float x = float.Parse(split[1]); 
    float y = float.Parse(split[2]); 
    float z = float.Parse(split[3]); 
    float eulY = float.Parse(split[4]); 
    //是自己 
    if(desc == NetManager.GetDesc())  return; 
    //添加一个角色 
    GameObject obj = (GameObject)Instantiate(humanPrefab);
    obj.transform.position = new Vector3(x, y, z); 
    obj.transform.eulerAngles = new Vector3(0, eulY, 0); 
    BaseHuman h = obj.AddComponent<SyncHuman>(); 
    h.desc = desc;  
    otherHumans.Add(desc, h); 
}
```



###### 3.5.3    测试Enter协议

​		为了测试多个客户端的同步状态，可以打开Unity中 PlayerSettings中的Run In Background（如图3-32所示），客户端方能在后台运行。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\069.png)

​																								图3-32  打开PlayerSettings中的Run In Background

​		打开只有转发功能的服务端程序，然后按先后顺序运行客户端A和客户端B。可以看到，当客户端B打开时，客户端A出现了客户端B的角色，如图3-33所示。可能有读者会问，客户端B为什么没有出现在客户端A上呢？因为客户端B没有收到任何关于其他玩家的消息。后续的List协议将会解决这个问题。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\070.png)

​																								图3-33  测试Enter协议





##### 3.6 服务端如何处理消息

​		既然客户端可以通过AddListener把网络协议和具体的处理函数对应起来，那服务端能不能有类似的机制，把底层网络模块和具体的消息处理函数分开呢？答案必须是肯定的。

###### 3.6.1    反射机制

​		设想在服务端程序里面也定义了一堆如下的方法：

```c#
public static void MsgEnter(ClientState c, string msgArgs)
{ 	 
    …… 
} 
public static void MsgList(ClientState c, string msgArgs)
{ 
    …… 
}
```

​		如果网络模块能在解析协议名后，自动调用名为“Msg+协议名”的方法，那便大功告成（如图3-34所示），而这其中，C#的反射机制是实现该功能的关键。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\071.png)

​																								图3-34  服务端消息处理示意图

​		修改Select服务端接收消息部分的代码，如下所示，完成消息处理函数的自动调用。

```c#
using System.Reflection; 
using System.Linq; 
//读取Clientfd 
public static bool ReadClientfd(Socket clientfd)
{ 	 
	ClientState state = clients[clientfd]; 
    //接收消息 
    …… 
    //客户端关闭（count==0） 
    …… 
    //消息处理 
    string recvStr = System.Text.Encoding.Default.GetString(state.readBuff, 0, count); 
	string[] split = recvStr.Split('|'); 
    Console.WriteLine("Recv" + recvStr); 
    string msgName = split[0]; 
    string msgArgs = split[1]; 
    string funName = "Msg" + msgName; 
    MethodInfo mi = typeof(MsgHandler).GetMethod(funName);  
    object[] o = {state, msgArgs}; 
    mi.Invoke(null, o); 
    return true; 
}
```

​		以下是上述代码中关于反射的说明。

​		MethodInfo类对象mi包含它所指代的方法的所有信息，通过这个类可以得到方法的名称、参数、返回值等，并且可以调用它。假设所有的消息处理方法都定义在MsgHandler类中，且都是静态方法，通过typeof(MsgHandler).GetMethod(funName)便能够获取MsgHandler类中名为funName的静态方法。由于MethodInfo定义于System.Reflection命名空间下，因此需要引用（using）该命名空间。

​		mi.Invoke(null,o)代表调用mi所包含的方法。第一个参数null代表this指针，由于消息处理方法都是静态方法，因此此处要填null。第二个参数o代表的是参数列表。这里定义的消息处理函数都有两个参数，第一个参数是客户端状态state，第二个参数是消息的内容msgArgs。



###### 3.6.2    消息处理函数

​		接下来在服务端创建一个名为MsgHandler.cs的文件，用它来定义存放所有消息处理函数的MsgHandler类（如图3-35所示）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\072.png)

​																								图3-35  添加MsgHandler类

​		MsgHandler类的代码如下所示，后续再根据需要添加消息处理内容。

```c#
using System; 
using System.Collections.Generic; 

class MsgHandler 
{ 
    public static void MsgEnter(ClientState c, string msgArgs)
    { 	 
        Console.WriteLine("MsgEnter" + msgArgs); 
    } 
    public static void MsgList(ClientState c, string msgArgs)
    { 	 
        Console.WriteLine ("MsgList" + msgArgs); 
    } 
}
```

​		图3-36展示了服务端的消息处理流程。诸如在MsgEnter等消息处理函数中，第一个参数c指代了这条消息是哪个客户端发来的，参数msgArgs代表具体的消息内容。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\073.png)

​																								图3-36 	消息处理示意图



###### 3.6.3 	事件处理

​		有时候服务端需要对玩家上线、玩家下线等事件做出反应。比如在大乱斗游戏中，如果游戏玩家下线，服务端就需要通知其他客户端该玩家下线，从而使客户端删除角色。对此，可以使用类似于消息处理的方法来处理事件，添加一个处理事件的类EventHandler（如图3-37所示），在里面定义一些消息处理函数（目前只有处理玩家下线的OnDisconnect）就可实现该功能。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\074.png)

​																								图3-37  添加EventHandler类

​		EventHandler的代码如下：

```c#
using System; 
public class EventHandler 
{ 
    public static void OnDisconnect(ClientState c)
    { 	 
        Console.WriteLine ("OnDisconnect"); 
    } 
}
```

​		修改服务端接收消息的代码ReadClientfd，当玩家下线时，调用EventHandler.OnDisconnect，代码如下所示。同理可以在Accept处添加接受客户端连接的事件。

```c#
//读取Clientfd 
public static bool ReadClientfd(Socket clientfd)
{ 
    ClientState state = clients[clientfd]; 
    //接收 
    int count = 0; 
    try
    { 
        count = clientfd.Receive(state.readBuff); 
    }
    catch(SocketException ex)
    { 
        MethodInfo mei =  typeof(EventHandler).GetMethod("OnDisconnect"); 
        object[] ob = {state}; 
        mei.Invoke(null, ob); 
        clientfd.Close(); 
        clients.Remove(clientfd); 
        Console.WriteLine("Receive SocketException" + ex.ToString()); 
        return false; 
    } 
    //客户端关闭 
    if(count <= 0)
    { 
        MethodInfo mei = typeof(EventHandler).GetMethod("OnDisconnect"); 
        object[] ob = {state}; 
        mei.Invoke(null, ob); 
        clientfd.Close(); 
        clients.Remove(clientfd); 
        Console.WriteLine("Socket Close"); 
        return false; 
    } 
    //消息处理 
    …… 
}
```

​		图3-38展示了服务端消息处理和事件处理的流程。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\075.png)

​																								图3-38  事件处理示意图

​		使用这套带有消息处理机制和事件处理机制的Select服务端，继续完成大乱斗游戏吧！



###### 3.6.4    玩家数据

​		现在，回过头来看看3.5.3节留下的问题——进入游戏场景的玩家没有收到任何关于其他玩家的消息。一个常规的解决办法就是：当玩家进入场景时，向服务端请求List协议，服务端收到后，将场景中的人物信息返回给客户端。要达成这个功能，服务端必须要记录各个玩家的坐标信息。最直接的就是在客户端状态结构ClientState中添加一些变量，代码如下所示。

```c#
public class ClientState 
{ 
    public Socket socket;  
    public byte[] readBuff = new byte[1024];   
    public int hp = -100; 
    public float x = 0; 
    public float y = 0; 
    public float z = 0; 
    public float eulY = 0; 
}
```

上述代码添加的状态信息包括角色的生命值（hp）、位置信息（x、y、z）和旋转角度（eulY）。



###### 3.6.5    处理Enter协议

​		服务端接收到Enter协议（以及后续的Move协议）后，需要把玩家的坐标信息记录下来，再广播出去。可通过修改处理消息的MsgHandler.MsgEnter方法来实现。它先解析客户端发来的协议参数，然后给代表该客户端的ClientState赋值，最后将协议广播给所有的客户端。代码如下：

```c#
public static void MsgEnter(ClientState c, string msgArgs) 
{ 
    //解析参数 
    string[] split = msgArgs.Split(','); 
    string desc = split[0]; 
    float x = float.Parse(split[1]); 
    float y = float.Parse(split[2]); 
    float z = float.Parse(split[3]); 
    float eulY = float.Parse(split[4]); 
    //赋值 
    c.hp = 100; 
    c.x = x; 
    c.y = y; 
    c.z = z; 
    c.eulY = eulY; 
    //广播 
    string sendStr = "Enter|" + msgArgs; 
    foreach (ClientState cs in MainClass.clients.Values)
    { 	 
        MainClass.Send(cs, sendStr); 
    } 
}
```





##### 3.7 玩家列表：List协议

​		当玩家进入场景后，调用NetManager.Send发送List协议。服务端收到后回应各个客户端的信息。请求和回应的字符串协议如图3-39所示。请求的协议不必带任何参数，回应协议的参数依次为角色A描述、角色A坐标X、角色A坐标Y、角色A坐标Z、角色A旋转角度、角色A生命值、角色B描述、角色B坐标X、角色B坐标Y、角色B坐标Z、角色B旋转角度、角色B生命值。以此类推，每个角色带有6个参数，发送所有角色的消息。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\076.png)

​																								图3-39 	List协议的请求和回应形式



###### 3.7.1  客户端处理

​		客户端发送和接收List协议的代码如下所示，它解析参数后，生成一个同步角色。

```c#
public class Main : MonoBehaviour 
{ 
    …… 
    void Start () 
    { 
        //网络模块 
        NetManager.AddListener("Enter", OnEnter);  			
        NetManager.AddListener("List", OnList);  			
        NetManager.AddListener("Move", OnMove);  			
        NetManager.AddListener("Leave", OnLeave);  			
        NetManager.Connect("127.0.0.1", 8888);  //添加角色，发送Enter协议 
        …… 
        //请求玩家列表 
        NetManager.Send("List|"); 
    } 

    void OnList (string msgArgs)
    { 
        Debug.Log("OnList" + msgArgs); 
        //解析参数 
        string[] split = msgArgs.Split(','); 
        int count = (split.Length-1)/6; 
        for(int i = 0; i < count; i++)
        { 
            string desc = split[i*6+0]; 
            float x = float.Parse(split[i*6+1]); 
            float y = float.Parse(split[i*6+2]); 
            float z = float.Parse(split[i*6+3]);  
            float eulY = float.Parse(split[i*6+4]);  
            int hp = int.Parse(split[i*6+5]); 
            //是自己 
            if(desc == NetManager.GetDesc()) 
                continue; 
            //添加一个角色 
            GameObject obj = (GameObject)Instantiate(humanPrefab); 
            obj.transform.position = new Vector3(x, y, z); 
            obj.transform.eulerAngles = new Vector3(0, eulY, 0); 
            BaseHuman h = obj.AddComponent<SyncHuman>(); 
            h.desc = desc;  
            otherHumans.Add(desc, h); 
        }
        …… 
    }
}
```

​		以下是上述代码的说明。

​		（1）count

​		假设服务端回应的角色数量为N，每个角色有6个参数（描述、x、y、z、eulY、hp）。因为协议最后还带有个逗号，所以msgArgs.Split(',')返回的数量为6*N+1，反推得到count=(split.Length-1)/6。

​		（2）hp

​		hp是角色的生命值，后面制作击打功能时会用到。



###### 3.7.2    服务端处理

​		服务端代码如下所示，它会组装List协议，将字符串发送出去。

```c#
public static void MsgList(ClientState c, string msgArgs)
{ 	 
    string sendStr = "List|"; 
    foreach (ClientState cs in MainClass.clients.Values)
    { 	
        sendStr+=cs.socket.RemoteEndPoint.ToString() + ","; 	
        sendStr+=cs.x.ToString() + ","; 
        sendStr+=cs.y.ToString() + ","; 
        sendStr+=cs.z.ToString() + ","; 
        sendStr+=cs.eulY.ToString() + ","; 
        sendStr+=cs.hp.ToString() + ","; 
    } 
    MainClass.Send(c, sendStr); 
}
```



###### 3.7.3    测试

​		运行服务端和多个客户端，后进入场景的客户端也能看到已在线的玩家，虽然他们只会站立不会移动，如图3-40所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\077.png)

​																								图3-40  List协议测试结果





##### 3.8 移动同步：Move协议

​		当玩家用鼠标点击场景，角色移动时，客户端应把目的地位置发送给服务端。服务端一方面记录位置信息，另一方面将目的地位置信息广播给其他客户端。其他客户端收到协议后，解析目的地位置信息，然后控制SyncHuman走到对应的位置去。Move协议如图3-41所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\078.png)

​																								图3-41  Move协议

###### 3.8.1    客户端处理

​		修改Ctrlhuman类中控制角色移动的代码，当角色移动时，将目的地信息发送给服务端。代码如下：

```c#
new void Update () 
{ 
    base.Update(); 
    if(Input.GetMouseButtonDown(0))
    { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit; 
        Physics.Raycast(ray, out hit); 
        if (hit.collider.tag == "Terrain")
        { 
            MoveTo(hit.point); 
            //发送协议  
            string sendStr = "Move|"; 
            sendStr += NetManager.GetDesc()+ ","; 
            sendStr += hit.point.x + ","; 
            sendStr += hit.point.y + ","; 
            sendStr += hit.point.z + ","; 
            NetManager.Send(sendStr); 
        } 	
    } 	
}
```

​		修改Main的协议处理函数OnMove（记得添加对该协议的监听），解析协议参数，然后找到对应的同步角色，调用MoveTo方法让同步角色走到目的地。

```c#
void OnMove (string msgArgs) 
{ 
    Debug.Log("OnMove" + msgArgs); 
    //解析参数 
    string[] split = msgArgs.Split(','); 
    string desc = split[0]; 
    float x = float.Parse(split[1]); 
    float y = float.Parse(split[2]); 
    float z = float.Parse(split[3]); 
    //移动 
    if(!otherHumans.ContainsKey(desc)) 
        return; 
    BaseHuman h = otherHumans[desc]; 
    Vector3 targetPos = new Vector3(x, y, z);  
    h.MoveTo(targetPos);   
}
```



###### 3.8.2    服务端处理

​		服务端收到Move协议后，解析参数，记录坐标信息，然后广播Move协议。代码如下：

```c#
public static void MsgMove(ClientState c, string msgArgs)
{ 
    //解析参数 
    string[] split = msgArgs.Split(','); 
    string desc = split[0]; 
    float x = float.Parse(split[1]); 
    float y = float.Parse(split[2]); 
    float z = float.Parse(split[3]); 
    //赋值 
    c.x = x; 
    c.y = y; 
    c.z = z; 
    //广播 
    string sendStr = "Move|" + msgArgs; 
    foreach (ClientState cs in MainClass.clients.Values)
    { 	 
        MainClass.Send(cs, sendStr); 
    } 
}
```



###### 3.8.3    测试

​		运行服务端和多个客户端，移动角色，其他客户端也能看到该角色向目的地走去（如图3-42所示）。值得注意的是，由于网络延迟等原因，这种同步方式可能会有些误差，几个客户端的表现并不会完全一致。但这并不妨碍大乱斗游戏的功能，现在的网络游戏也很难保证所有客户端的表现是完全一样的，只要误差在可接受范围内即可。后面的章节还会继续探讨移动同步算法，更好地处理移动同步问题。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\079.png)

​																								图3-42    通过Move协议同步位置





##### 3.9 玩家离开：Leave协议

​		当某个客户端掉线，服务端会广播Leave协议，客户端收到后删除对应的角色。Leave协议格式如图3-43所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\080.png)

​																								图3-43  Leave协议

###### 3.9.1    客户端处理

​		当客户端收到Leave协议后，调用监听函数OnLeave，删除对应的同步角色，同时把它从同步角色列表otherHumans中删掉。代码如下：

```c#
void OnLeave (string msgArgs) 
{ 
    Debug.Log("OnLeave" + msgArgs); 
    //解析参数 
    string[] split = msgArgs.Split(','); 
    string desc = split[0]; 
    //删除 
    if(!otherHumans.ContainsKey(desc)) 
        return; 
    BaseHuman h = otherHumans[desc]; 
    Destroy(h.gameObject); 
    otherHumans.Remove(desc); 
}
```



###### 3.9.2    服务端处理

​		当客户端掉线时，会触发服务端的Disconnect事件，只要在Disconnect事件的处理函数OnDisconnect中编写发送Leave协议的代码即可。

```c#
using System;

public class EventHandler 
{ 
    public static void OnDisconnect(ClientState c)
    { 
        string desc = c.socket.RemoteEndPoint.ToString(); 	 
        string sendStr = "Leave|" + desc + ","; 
        foreach (ClientState cs in MainClass.clients.Values)
        { 	
            MainClass.Send(cs, sendStr); 
        } 
    } 
}
```



###### 3.9.3    测试

​		运行服务端和多个客户端，然后关掉其中一个客户端，这个客户端的角色也会在其他客户端的场景中消失。到目前为止，已经完成了大乱斗游戏的角色移动部分，那么角色战斗部分又该如何实现呢？



##### 3.10 攻击动作：Attack协议

​		既是大乱斗，自然少不了攻击敌人。在角色站立状态下，玩家右击鼠标，角色就会发出攻击动作（Attack协议）。如果打到敌人（Hit协议），敌人会扣血，直至死亡（Die协议）。Attack、Hit和Die三个协议是处理大乱斗游戏战斗部分的关键。

###### 3.10.1    播放攻击动作

​		由于Unity的Standard Asset中并没有附带攻击动作，读者可以在本书附带的素材或者Asset Store上找到通用的攻击动作文件，把它导入到项目中，如图3-44所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\081.png)

​																								图3-44  导入攻击动作

​		然后修改动画控制器，添加Attack状态和isAttacking参数。由于只有在站立状态下可以攻击，因此Attack状态也只能与Idle状态相互切换，如图3-45所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\082.png)

​																								图3-45    修改动画控制器，添加Attack状态

​		然后编辑Attack状态的切换条件：如果角色处于Idle状态，等到参数isAttacking变为true时，切换为Attack状态，如图3-46所示；如果角色处于Attack状态，等到参数isAttacking变为false时，切换为Idle状态，如图3-47所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\083.png)

​																								图3-46  Idle到Attack的切换条件

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\084.png)

​																								图3-47  Attack到Idle的切换条件

​		操控角色和同步角色都会播放攻击动作，可以在Human的基类BaseHuman添加播放攻击动作的功能。添加变量isAttacking指示角色当前是否处于攻击状态，添加变量attackTime记录上一次发动攻击的时间，假设攻击动作的冷却时间为1.2秒，在冷却时间内不能再次发起进攻。BaseHuman修改的代码如下：

```c#
//是否正在攻击 
internal bool isAttacking = false; 
internal float attackTime = float.MinValue; 
//攻击动作 
public void Attack()
{ 
    isAttacking = true; 
    attackTime = Time.time; 
    animator.SetBool("isAttacking", true); 
} 
//攻击Update 
public void AttackUpdate()
{ 
    if(!isAttacking) return; 
    if(Time.time - attackTime < 1.2f) return; 	 isAttacking = false; 
    animator.SetBool("isAttacking", false);
} 

internal void Update () 
{ 
    MoveUpdate(); 
    AttackUpdate(); 
}
```

​		至此，角色已经具备了播放攻击动作的功能。只需在合适的地方调用Attack方法，角色便会发起攻击。对于操控角色，只要玩家在合适的时间右击鼠标，角色就会转到鼠标所指的方向，然后发起攻击。修改操控角色类CtrlHuman，添加发起攻击功能的代码。程序会判断当前能否发起攻击（不处于攻击状态、不处于移动状态），然后使用LookAt方法让角色转向，最后调用BaseHuman的Attack方法播放攻击动作。

```c#
new void Update () 
{ 
	base.Update(); 
    //移动 
    …… 
	//攻击 
    if(Input.GetMouseButtonDown(1))
    { 
    	if(isAttacking) return; 
        if(isMoving) return; 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
        RaycastHit hit; 
        Physics.Raycast(ray, out hit); 
        transform.LookAt(hit.point); 
        Attack(); 
     } 
}
```

​		上述代码中的hit.point代表右击时鼠标对应到场景的位置，也就是攻击的方向。角色转到该方向（transform.LookAt），然后播放攻击动作。

​      测试游戏，右击鼠标，角色会转到鼠标指示的方向，然后挥动左手，向前方打下去，如图3-48和图3-49所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\085.png)

​																								图3-48  发起攻击

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\086.png)

​																								图3-49  转向并发起攻击

​		当客户端收到播放攻击动作的Attack协议时，同步角色要做出处理，播放攻击动作。可在SyncHuman类中添加一个播放同步攻击动作的SyncAttack方法，它接受一个参数eulY，代表角色的旋转角度。调用SyncAttack方法后，同步角色会转向，然后播放攻击动作。代码如下：

```c#
public class SyncHuman : BaseHuman 
{ 
    …… 
    public void SyncAttack(float eulY)
    { 
        transform.eulerAngles = new Vector3(0, eulY, 0);  Attack(); 
    } 
}
```



###### 3.10.2    客户端处理

​		Attack协议设计如图3-50所示。它带有两个参数，第一个参数为角色描述，第二个参数为攻击的方向。在CtrlHuman发起攻击动作后，将Attack协议发送给服务端，代码如下。

```c#
if(Input.GetMouseButtonDown(1))
{ 
    if(isAttacking) return; 
    if(isMoving) return; 
    …… 
    //发送协议 
    string sendStr = "Attack|"; 
    sendStr += NetManager.GetDesc()+ ",";  
    sendStr += transform.eulerAngles.y + ",";  
    NetManager.Send(sendStr); 
} 
```

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\087.png)

​																								图3-50  Attack协议示意图

​		当客户端接收到服务端转发的Attack协议时，它会解析协议参数，然后调用对应同步角色的SyncAttack方法。修改的Main代码如下：

```c#
NetManager.AddListener("Attack", OnAttack); 
void OnAttack (string msgArgs)
{ 
    Debug.Log("OnAttack" + msgArgs); 
    //解析参数 
    string[] split = msgArgs.Split(','); 
    string desc = split[0]; 
    float eulY = float.Parse(split[1]); 
    //攻击动作 
    if(!otherHumans.ContainsKey(desc)) 
        return; 
    SyncHuman h = (SyncHuman)otherHumans[desc]; 
    h.SyncAttack(eulY); 
}
```



###### 3.10.3    服务端处理

​		服务端只需转发Attack协议，代码如下：

```C#
public static void MsgAttack(ClientState c, string msgArgs)
{ 
    //广播 
    string sendStr = "Attack|" + msgArgs; 
    foreach (ClientState cs in MainClass.clients.Values)
    { 	 
        MainClass.Send(cs, sendStr); 
    } 
}
```



###### 3.10.4    测试

​		运行游戏，然后右击鼠标，可以看到角色发出攻击的动作。在其他客户端上，也能够看到该角色的攻击动作（如图3-51和图3-52所示）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\088.png)

​																								图3-51  测试Attack协议

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\089.png)

​																								图3-52  移动到敌人面前，攻击他



##### 3.11 攻击伤害：Hit协议

​		当玩家发起进攻，且打击到敌人时，敌人会受到伤害。假设不会有玩家作弊，服务端完全信任客户端，一种可能的实现方式是，当攻击到敌人时，攻击方发送Hit协议，如图3-53所示，协议中带有被攻击者的信息。服务端收到协议后，扣除被攻击角色的血量。



![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\090.png)

​																								图3-53  Hit协议示意图

###### 3.11.1    客户端处理

​		假设玩家发动攻击时刚好有角色位于玩家的正前方，便判断该玩家受到攻击。可以在攻击角色正前方做一条有方向的线段，如图3-54和图3-55所示，线段从lineStart延伸到lineEnd，如果有角色被线段射穿，说明该角色位于攻击者的正前方，会受到伤害（更准确的做法是在角色挥动手臂、拳头刚好位于前方时去做判断，这部分和网络功能无关，就留给读者自己实现）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\091.png)

​																								图3-54  使用有向线段判断是否攻击到敌人

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\092.png)

​																								图3-55  攻击到敌人      

​		Unity中的Physics.Linecast（线性投射）恰好能实现上述功能。该方法会从开始位置（lineStart）到结束位置（lineEnd）做一个光线投射，如果碰到碰撞体，返回true。为了实现碰撞检测，还需要给角色预设添加Collider组件，一般会给人形角色添加Capsule Collider，如图3-56所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\093.png)

​																								图3-56  给角色添加Capsule Collider

​		修改CtrlHuman，添加攻击判断的代码，如下所示。先做一条有向线段，如果线段碰到了带有SyncHuman组件的角色，表示角色被击中，客户端发送Hit协议通知服务端谁被击中了。

```C#
//攻击 
if(Input.GetMouseButtonDown(1))
{ 
    …… 
	//发送协议 
    …… 
	//攻击判定 
    Vector3 lineEnd = transform.position + 0.5f*Vector3.up;  
    Vector3 lineStart = lineEnd + 20*transform.forward;  
    if(Physics.Linecast(lineStart, lineEnd, out hit))
    { 	 
        GameObject hitObj = hit.collider.gameObject; 
	 	if(hitObj == gameObject) return; 
 		SyncHuman h = hitObj.GetComponent<SyncHuman>();  
        if(h == null) return; 
 		sendStr = "Hit|"; 
 		sendStr += NetManager.GetDesc()+ ","; 
 		sendStr += h.desc + ","; 
 		NetManager.Send(sendStr); 
 	} 
}
```



###### 3.11.2    服务端处理

​		当服务端收到Hit协议后，它会找出受到攻击的角色，然后扣血（此处固定扣除25滴血）。当被攻击的角色血量小于0，代表角色死亡，服务端会广播Die协议，通知客户端删除该角色。

```C#
public static void MsgHit(ClientState c, string msgArgs)
{ 
    //解析参数 
    string[] split = msgArgs.Split(','); 
    string attDesc = split[0]; 
    string hitDesc = split[1]; 
    //找出被攻击的角色 
    ClientState hitCS = null; 
    foreach (ClientState cs in MainClass.clients.Values)
    { 	 
        if(cs.socket.RemoteEndPoint.ToString() == hitDesc) 	
            hitCS = cs; 
    } 
    if(hitCS == null)  
        return; 
    //扣血 
    hitCS.hp -= 25; 
    //死亡 
    if(hitCS.hp <= 0)
    { 
        string sendStr = "Die|" + hitCS.socket.RemoteEndPoint.ToString(); 
        foreach (ClientState cs in MainClass.clients.Values)
        { 
            MainClss.Send(cs,sendStr);
        }	 
    } 	
}
```



##### 3.12 角色死亡：Die协议

​		当角色死亡时，服务端会广播Die协议（图3-57），客户端收到协议后删除该角色。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\094.png)

​																								图3-57  Die协议示意图



###### 3.12.1    客户端处理

​		客户端处理函数如下，如果是玩家操控的角色死亡，打印出“GameOver”，如果是其他玩家死亡，删掉他［通过SetActive(false)实现］。

```C#
void OnDie (string msgArgs) 
{ 
    Debug.Log("OnDie" + msgArgs); 
    //解析参数 
    string[] split = msgArgs.Split(','); 
    string attDesc = split[0]; 
    string hitDesc = split[0]; 
    //自己死了 
    if(hitDesc == myHuman.desc)
    { 
        Debug.Log("Game Over"); 
        return; 
    } 
    //死了 
    if(!otherHumans.ContainsKey(hitDesc)) 
        return; 
    SyncHuman h = (SyncHuman)otherHumans[hitDesc]; 
    h.gameObject.SetActive(false); 
}
```



###### 3.12.2    测试

​		现在打开多个客户端，攻击对方角色，在攻击一定次数后，敌方死亡，从屏幕上消失（见图3-58、图3-59和图3-60）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\095.png)

​																								图3-58  攻击敌方，敌方受到伤害

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\096.png)

​																								图3-59  服务端显示收到Hit协议

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\097.png)

​																								图3-60 客户端A（左）杀死客户端B（右）角色

​		还记得本章开头说的吗？虽然已经搭建了网络游戏开发的基本框架，但并不完美。如果读者在测试的过程中莫名其妙地断线，或者莫名其妙地收不到协议（在本机测试很少出现，但如果放到网络很差的环境，出现概率比较大）也纯属正常。因为TCP协议是基于数据流的协议，并不保证每次接收的数据都是完整的。制作商业级游戏，必须解决各种隐患。









####  第4章 正确收发数据流

​		TCP协议是一种基于数据流的协议。想象一下看网络直播的过程：直播平台不断把最新画面推送给观众；观众的播放器程序会读出网络数据，播放最新画面，然后丢弃播放过的数据。在图4-1中，在t1时刻，直播平台（服务端）向观众（客户端）依次推送第1帧、第2帧、第3帧数据……到了t2时刻，客户端已经播放了第1帧画面，于是数据向前移动，变成了第2帧、第3帧……整个数据的处理过程就像流水一般，因此称为数据流。本章将介绍怎样正确和高效地处理TCP数据。

​		本章和第5章会涉及TCP的底层机制，有一定难度。但读者不必担心，第6章的“客户端网络模块”会封装这两章介绍的功能，只要对TCP机制稍有了解，能够调用几个函数就好。等做成了游戏，再回头继续探求TCP机制，也是个好办法。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\098.png)

​																								图4-1  数据流示意图

##### 4.1 TCP数据流

###### 4.1.1    系统缓冲区

​		图4-2展示的是接收缓冲区存有数据的TCP Socket示意图。当收到对端数据时，操作系统会将数据存入到Socket的接收缓冲区中，图4-2中接收缓冲区有4个字节数据，分别是1、2、3、4。操作系统层面上的缓冲区完全由操作系统操作，程序并不能直接操作它们，只能通过socket.Receive、socket.Send等方法来间接操作。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\099.png)

​																								图4-2  TCP缓冲区示意图

​		Socket的Receive方法只是把接收缓冲区的数据提取出来，比如调用Receive(readBuff,0,2)（API的参数说明详见第1章），接收2个字节的数据到readbuff。在图4-2所示的例子中，调用后操作系统接收缓冲区只剩下了2个字节数据，用户缓冲区readBuff保存了接收到的2字节数据，形成图4-3所示的缓冲区。当系统的接收缓冲区为空，Receive方法会被阻塞，直到里面有数据。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\100.png)

​																								图4-3  Receive示意图

​		同样地，Socket的Send方法只是把数据写入到发送缓冲区里，具体的发送过程由操作系统负责。当操作系统的发送缓冲区满了，Send方法将会阻塞。



###### 4.1.2    粘包半包现象

​		如果发送端快速发送多条数据，接收端没有及时调用Receive，那么数据便会在接收端的缓冲区中累积。如图4-4所示，客户端先发送“1、2、3、4”四个字节的数据，紧接着又发送“5、6、7、8”四个字节的数据。等到服务端调用Receive时，服务端操作系统已经将接收到的数据全部写入缓冲区，共接收到8个数据。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\101.png)

​																								图4-4  客户端两次发送数据，服务端只响应一次接收

​		这一现象有时与功能需求不符，比如在聊天软件中，客户端依次发送“Lpy”和“_is_handsome”，期望其他客户端也展示出“Lpy”和“_is_handsome”两条信息，但由于Receive可能把两条信息当作一条信息处理，有可能只展示“Lpy_is_handsome”一条信息（如图4-5所示）。Receive方法返回多少个数据，取决于操作系统接收缓冲区中存放的内容。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\102.png)

​																								图4-5  聊天程序可能出现的粘包现象

​		发送端发送的数据还有可能被拆分，如发送“HelloWorld”（如图4-6所示），但在接收端调用Receive时，操作系统只接收到了部分数据，如“Hel”，在等待一小段时间后再次调用Receive才接收到另一部分数据“loWorld”。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\103.png)

​																								图4-6  半包现象		

​		由于TCP是基于流的数据，粘包现象本身是很正常的现象。但它与直觉不符，直觉告诉我们，“一次发送多少数据，一次也接收多少数据”才正常。



###### 4.1.3    人工重现粘包现象

​		一种人工重现粘包现象的方法是，在Accept后让服务端等待一段时间（如30秒，代码如下所示），在此期间让客户端多次发送数据，比如分别发送“hello”和“unity”，那么服务端最终会输出“[服务器接收]hellounity”。

​		同步服务端程序：

```c#
public static void Main (string[] args)
{ 
    //Socket Bind  Listen （略） 
    //Accept 
    Socket connfd = listenfd.Accept (); 
    //等待 
    System.Threading.Thread.Sleep(30*1000);  //Receive 
    byte[] readBuff = new byte[1024]; 
    int count = connfd.Receive (readBuff); 
    string readStr = System.Text.Encoding.UTF8.GetString (readBuff, 0, count); 
    Console.WriteLine ("[服务器接收]" + readStr); 
}
```



##### 4.2 解决粘包问题的方法

​		一般有三种方法可以解决粘包和半包问题，分别是长度信息法、固定长度法和结束符号法。一般的游戏开发会在每个数据包前面加上长度字节，以方便解析，后续也将详细介绍这种方法。

###### 4.2.1    长度信息法

​		长度信息法是指在每个数据包前面加上长度信息。每次接收到数据后，先读取表示长度的字节，如果缓冲区的数据长度大于要取的字节数，则取出相应的字节，否则等待下一次数据接收。

​		在图4-7所示的例子中，客户端要发送“hellounity”和“love”两个字符串（为了方便解释，并不严格按照字节流绘图，对应图4-7的客户端Send①和②），它在每个包前面加上一个代表字符串长度的字符。按照TCP机制，接收端收到的字节顺序一定和发送顺序一致。

​		1）假设第一次接收到的是“10hel”，服务端程序将接收到的数据存入缓冲区（特指用户缓冲区readBuff，下同），然后读取第一个字节“10”，此时缓冲区长度只有4（见图4-7，服务端Buff①），服务端不处理，等待下一次接收。

​		2）假设第二次接收到了9个字节“lounity4l”（见图4-7，服务端Buff②），此时缓冲区便有了13个字节，超出第一个包所需的11个字节（10个数据字节加上1个长度字节）。于是程序读取缓冲区前11个字节的数据并处理。之后缓冲区便只剩下“4l”两个字节。

​		3）假设服务端第三次接收到“ove”三个字节（见图4-7，服务端Buff③），这时缓冲区便有了“4love”5个字节。程序读取缓冲区的这5个字节并作出处理。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\104.png)

​																								图4-7  使用程度信息法处理粘包半包问题

​		前面的例子使用一个字节表示长度，最大值为255。游戏程序一般会使用16位整型数或32位整型数来存放长度信息（如图4-8和图4-9所示），16位整型数的取值范围是0～65535，32位整型数的取值范围是0～4294967295。对于大部分游戏，网络消息的长度很难超过65535字节，使用16位整型数来存放长度信息较合适。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\105.png)

​																								图4-8  16位消息长度的格式

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\106.png)

​																								图4-9  32位消息长度的格式



###### 4.2.2    固定长度法

​		每次都以相同的长度发送数据，假设规定每条信息的长度都为10个字符，那么发送“Hello”“Unity”两条信息可以发送成
 “Hello...”“Unity...”，其中的“.”表示填充字符，是为凑数，没有实际意义，只为了每次发送的数据都有固定长度。接收方每次读取10个字符，作为一条消息去处理。如果读到的字符数大于10，比如第1次读到“Hello...Un”，那它只要把前10个字节“Hello...”抽取出来，再把后面的两个字节“Un”存起来，等到再次接收数据，拼接第二条信息。



###### 4.2.3    结束符号法

​		规定一个结束符号，作为消息间的分隔符。假设规定结束符号为“$”，那么发送“Hello”“Unity”两条信息可以发送成“Hello$”“Unity$”。接收方每次读取数据，直到“$”出现为止，并且使用“$”去分割消息。比如接收方第一次读到“Hello$Un”，那它把结束符前面的Hello提取出来，作为第一条消息去处理，再把“Un”保存起来。待后续读到“ity$”，再把“Un”和“ity”拼成第二条消息。





##### 4.3 解决粘包的代码实现

​		本节会展示在异步客户端上，实现带有16字节长度信息的协议，来解决粘包问题。

###### 4.3.1    发送数据

​		假设要发送一条字符串消息“HelloWorld”。由于要解决粘包问题，发送的数据需要包含长度信息，实际发送的数据变成了“0AHelloWorld”（0A表示数字10）。下面用Send方法实现了该功能。

```C#
//点击发送按钮 
public void Send(string sendStr) 
{ 
    //组装协议 
    byte[] bodyBytes =  System.Text.Encoding.Default.GetBytes(sendStr); 
    Int16 len = (Int16)bodyBytes.Length; 
    byte[] lenBytes = BitConverter.GetBytes(len); 
    byte[] sendBytes = lenBytes.Concat(bodyBytes).ToArray(); //为了精简代码：使用同步Send 
    //不考虑抛出异常 
    socket.Send(sendBytes); 
}
```

​		图4-10展示了以上程序各个变量的取值。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\107.png)

​																								图4-10  Send程序中各个变量取值示意图

​		其中的Concat方法位于Linq命名空间，使用前需要加上“using System.Linq;”，它的功能是拼接数组。

​		“lenBytes.Concat(bodyBytes).ToArray();”一句的含义是生成一个lenBytes后接bodyBytes的byte数组。



###### 4.3.2    接收数据

​		游戏程序一般会使用“长度信息法”处理粘包问题，核心思想是定义一个缓冲区（readBuff）和一个指示缓冲区有效数据长度变量（buffCount）。

```C#
//接收缓冲区 
byte[] readBuff = new byte[1024]; 
//接收缓冲区的数据长度 
int buffCount = 0;
```

​		比如，readBuff中有5个字节的数据“world”（其余为byte的默认值0），那么buffCount的值应是5，如图4-11所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\108.png)

​																								图4-11  接收缓冲区示意图

​		因为存在粘包现象，缓冲区里面会保存尚未处理的数据。所以接收数据时不再从缓冲区开头的位置写入，而是把新数据放在有效数据之后。比如在图4-11所示的缓冲区中增加两个字节的数据“hi”，缓冲区将会变成图4-12所示的样式，同时让buffCount增加2。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\109.png)

​																								图4-12  新增两字节数据的缓冲区

​		如果使用异步Socket，BeginReceive的参数应填成下面的样子：

```c#
socket.BeginReceive(readBuff,       	//缓冲区 
                    buffCount,        	//开始位置 
                    1024-buffCount,     //最多读取多少数据  
                    0,        			//标志位，设成0即可 
                    ReceiveCallback,    //回调函数 
                    socket);        	// 状态
```

​		图4-13所展示的是，BeginReceive从缓冲区buffCount的位置开始写入，因为缓冲区的索引从0开始，所以第6个位置的索引为5，正好等于buffCount。假设缓冲区长度为9，那么剩余量是“总长度-
 buffCount”。图4-13缓冲区还剩余4个字节，所以下一次接收数据最多只能接收4个字节。对于长度为1024的缓冲区，剩余量便是“1024-buffCount”。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\110.png)

​																								图4-13  BeginReceive参数示意图

​		在收到数据后，程序需要更新buffCount，以使下一次接收数据时，写入到缓冲区有效数据的末尾（如图4-14所示）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\111.png)

​																								图4-14  更新buffCount

```C#
public void ReceiveCallback(IAsyncResult ar)
{ 	 
    Socket socket = (Socket) ar.AsyncState; 
    //获取接收数据长度 
    int count = socket.EndReceive(ar); 
    buffCount+=count; 
    …… 
}
```



###### 4.3.3 	处理数据

​		收到数据后，如果缓冲区的数据足够长，超过1条消息的长度，就把消息提取出来处理。如果数据长度不够，不去处理它，等待下一次接收数据。对于缓冲区数据长度，会有以下几种情况。

1. 缓冲区长度小于等于2

   ​		由于消息长度是16位（2字节），缓冲区至少要有2个字节数据才能把长度信息解析出来（这里假设长度值一定要大于0）。如果缓冲区长度小于2（如图4-15所示），不去处理它，等待下一次接收。

   ![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\112.png)

   ​																								图4-15  缓冲区数据长度小于2的情况

   ​		假设OnReceiveData是处理缓冲区消息的方法，对应的代码如下：

   ```c#
   public void OnReceiveData()
   { 
       if(buffCount <= 2)  
           return; 
       //如果是完整的消息，就处理它 
   }
   ```

2. 缓冲区长度大于2，但还不足以组成一条消息

   ​		在图4-16中，缓冲区有6个有效字节“05hell”。取出前2个字节“05”，解析后会得到这条消息总共有5个字节。加上表示长度的2个字节，这条消息总共有7个字节。显然，缓冲区里的数据不足以组成一条完整的消息。也不去处理它，等待下一次接收。

   ![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\113.png)

   ​																					图4-16  缓冲区长度大于2，但还不足以组成一条消息

   对应的代码如下：

   ```c#
   public void OnReceiveData()
   { 
       if(buffCount <= 2)  
           return; 
       Int16 bodyLength = BitConverter.ToInt16(readBuff, 0);  //消息体长度 
       if(buffCount < 2+bodyLength) 
           return; 
       //如果是完整的消息，就处理它 
   }
   ```

   ​		其中的BitConverter.ToInt16表示取缓冲区readBuff某个字节开始（这里是0，表示从第1个字节开始）的2个字节（因为Int16需要用2个字节表示）数据，再把它转换成数字。

3. 缓冲区长度大于等于一条完整信息

   ​		如果缓冲区长度大于等于一条完整的消息，那应该解析出这一条消息，然后更新缓冲区。如图4-17所示，缓冲区的内容为
    “05hello03cat”，前两个字节“05”代表第一条消息有5个字节，那么将缓冲区第3到第7个字节给解析出来，形成第一条消息。下面的代码使用System.Text.Encoding.UTF8.GetString(缓冲区,开始位置,长度)将缓冲区的指定数据转换为字符串，读取消息内容。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\114.png)

​																				图4-17  缓冲区数据长度大于一条完整信息

```c#
public void OnReceiveData()
{ 
    //消息体长度判断 （略） 
    string s = System.Text.Encoding.UTF8.GetString(readBuff, 2, buffCount); 
    //如果有更多消息，就处理它 
}
```

​		读取出的缓冲区数据已经没有用了，需要删除它。一个直观的办法是将缓冲区后面的数据向前移位，在图4-17所示的例子中，第一条消息共有7位，读取完后，可将缓冲区的第8位移动至缓冲区的第1位，将缓冲区的第9位移动至缓冲区的第2位，以此类推，最终缓冲区将只保留第二条之后的数据“03cat”。

​		移动缓冲区数据可使用Array.Copy方法，它的原型如下：

```c#
public static void Copy( 
 Array sourceArray, 
 long sourceIndex, 
 Array destinationArray, 
 long destinationIndex, 
 long length 
)
```

​		sourceArray代表源数组，destinationArray代表目标数据，sourceIndex代表源数组的起始位置，destinationIndex代表目标数组的起始位置，length代表要复制的消息的长度。在图4-17所示的例子中，需要把缓冲区的第8位（索引为7）到第12位数据“03cat”复制到缓冲区最前面，也就是从源数据的第8位到第12位（索引7到11），复制到目标数据的第1位到第5位（索引0到4），共复制5字节数据。代码如下所示：

```c#
public void OnReceiveData()
{ 
    //处理一条消息 （略） 
    //更新缓冲区 
    int start = 2 + bodyLength; 
    int count = buffCount - start; 
    Array.Copy(readBuff, start, readBuff, 0, count); 
    buffCount -= start; 
    //如果有更多消息，就处理它 
}
```

​		上述代码中，代表起始位置的start指向第一条消息的末尾，在例子中取值为2+5=7。长度count取值为缓冲区有效数据的长度，即12-7=5，最后更新代表缓冲区有效数据长度的buffCount，取值为12-7=5。

​		如果缓冲区数据足够长，还可以继续处理下一条消息。处理消息方法OnReceiveData的完整代码如下：

```c#
public void OnReceiveData()
{ 
    //消息长度 
    if(buffCount <= 2) 
        return; 
    Int16 bodyLength = BitConverter.ToInt16(readBuff, 0); 
    //消息体 
    if(buffCount < 2+bodyLength) 
        return; 
    string s = System.Text.Encoding.UTF8.GetString(readBuff, 2, buffCount); 
    //s是消息内容 
    //更新缓冲区 
    int start = 2 + bodyLength; 
    int count = buffCount - start; 
    Array.Copy(readBuff, start, readBuff, 0, count);  buffCount -= start; 
    //继续读取消息 
    if(readBuff.length > 2)
    { 
        OnReceiveData(); 
    } 
}
```



###### 4.3.4    完整的示例

​		下面以第2章的聊天客户端为例，给出粘包分包处理的完整代码。

比起上一章的程序，它有以下几处改进。

​		1）使用buffCount记录缓冲区的数据长度，使缓冲区可以保存多条数据；

​		2）接收数据（BeginReceive）的起点改为buffCount，由于缓冲区总长度为1024，所以最大能接收的数据长度变成了1024-buffCount；

​		3）通过OnReceiveData处理消息，OnReceiveData每一行代码的具体功能前几节已有详细介绍。这里还增加一些打印内容，以便测试；

​		4）给发送的消息添加长度信息。

代码如下：

```c#
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.Net.Sockets; 
using UnityEngine.UI; 
using System; 
using System.Linq;

public class Echo : MonoBehaviour 
{ 
    //定义套接字 
    Socket socket; 
    //UGUI 
    public InputField InputFeld; 
    public Text text; 
    //接收缓冲区 
    byte[] readBuff = new byte[1024]; 
    //接收缓冲区的数据长度 
    int buffCount = 0; 
    //显示文字 
    string recvStr = ""; 
    //点击连接按钮 
    public void Connection() 
    { 
        //Socket 
        socket = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp); 
        //为了精简代码：使用同步Connect 
        //不考虑抛出异常 
        socket.Connect("127.0.0.1", 8888); 
        socket.BeginReceive( readBuff, buffCount, 1024-buffCount, 0,  ReceiveCallback, socket); 
    } 
    //Receive回调 
    public void ReceiveCallback(IAsyncResult ar)
    { 	 
        try 
        { 
            Socket socket = (Socket) ar.AsyncState; 
            //获取接收数据长度 
            int count = socket.EndReceive(ar); 
            buffCount+=count; 
            //处理二进制消息 
            OnReceiveData(); 
            //继续接收数据 
            socket.BeginReceive( readBuff, buffCount, 1024-
                                buffCount, 0, 
                                ReceiveCallback, socket); 
        } 
        catch (SocketException ex)
        { 
            Debug.Log("Socket Receive fail" + ex.ToString());  } 
    } 
    public void OnReceiveData()
    { 
        Debug.Log("[Recv 1] buffCount=" +buffCount);  
        Debug.Log("[Recv 2] readbuff=" + BitConverter.ToString(readBuff)); 
        //消息长度 
        if(buffCount <= 2) 
            return; 
        Int16 bodyLength = BitConverter.ToInt16(readBuff, 0); 
        Debug.Log("[Recv 3] bodyLength=" +bodyLength); 
        //消息体 
        if(buffCount < 2+bodyLength) 
            return; 
        string s = System.Text.Encoding.UTF8.GetString(readBuff,  2, buffCount); 
        Debug.Log("[Recv 4] s=" +s); 
        //更新缓冲区 
        int start = 2 + bodyLength; 
        int count = buffCount - start; 
        Array.Copy(readBuff, start, readBuff, 0, count);  
        buffCount -= start; 
        Debug.Log("[Recv 5] buffCount=" +buffCount); 
        //消息处理 
        recvStr = s + "\n" + recvStr; 
        //继续读取消息 
        OnReceiveData(); 
    } 
    //点击发送按钮 
    public void Send() 
    { 
        string sendStr = InputFeld.text; 
        //组装协议 
        byte[] bodyBytes =  System.Text.Encoding.Default.GetBytes(sendStr); 
        Int16 len = (Int16)bodyBytes.Length; 
        byte[] lenBytes = BitConverter.GetBytes(len); 
        byte[] sendBytes = lenBytes.Concat(bodyBytes).ToArray(); 
        //为了精简代码：使用同步Send 
        //不考虑抛出异常 
        socket.Send(sendBytes); 
        Debug.Log("[Send]" + BitConverter.ToString(sendBytes)); 
    } 
    public void Update(){ 
        text.text = recvStr; 
    } 
}
```



###### 4.3.5 	测试程序

1.正常的流程

​		现在修改第2章的Select服务端程序，让服务端仅做转发。读者也可以仿照本节的代码，让服务端拥有处理粘包分包的能力。后续章节会详细介绍服务端的实现，这里的测试程序仅作观察客户端数据是否正确之用。

​		服务端程序修改如下：

```c#
//读取Clientfd 
public static bool ReadClientfd(Socket clientfd)
{ 	 
    ClientState state = clients[clientfd]; 
    int count = clientfd.Receive(state.readBuff); 
    //客户端关闭 
    if(count == 0)
    { 
        //略 
    } 
    //显示 
    string recvStr = System.Text.Encoding.Default.GetString(state.readBuff, 2, count-2); 
    Console.WriteLine("Receive" + recvStr); 
    //广播 
    byte[] sendBytes = new byte[count]; 
    Array.Copy(state.readBuff, 0, sendBytes, 0, count);  
    foreach (ClientState cs in clients.Values)
    { 
        cs.socket.Send(sendBytes); 
    } 
    return true; 
}
```

​		运行服务端和客户端程序，在客户端的窗口输入一些数据，然后发送，如图4-18所示。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\115.png)

​																								图4-18  客户端发送和接收“hello”

​		图4-19展示了客户端收到服务端转发的数据。客户端收到的数据为“05hello”，转换为16进制即是“05-00-68-65-6C-6C-6F”，长度为7个字节。取出前两个字节“05-00”，解析得到数据的长度是5。从第三个字节开始读取5个字节“68-65-6C-6C-6F”，解析出来得到文字“hello”（如图4-20所示）。读取完成后，更新缓冲区，缓冲区长度变为0（buffCount为0，至于缓冲区内的数据已经无关紧要了，它们会在下一次Receive被覆盖掉）。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\116.png)

​																								图4-19 	客户端解析数据打印的日志

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\117.png)

​																								图4-20 	服务端打印的日志

2.手动模拟粘包

​		修改客户端ReceiveCallback方法，在接收一次数据后，强制等待30秒，然后再开启下一次接收。因为ReceiveCallback是在子线程中执行，调用Sleep不会卡住主线程，客户端不会被卡住。只要在这30秒内多次发送数据，经由服务端转发，再次调用BeginReceive时，缓冲区已经有足够多的数据，产生粘包现象。客户端代码如下：

```c#
//Receive回调 
public void ReceiveCallback(IAsyncResult ar)
{ 	
    try
    { 
        Socket socket = (Socket) ar.AsyncState; 
        //获取接收数据长度 
        int count = socket.EndReceive(ar); 
        buffCount+=count; 
        //处理二进制消息 
        OnReceiveData(); 
        //等待 
        System.Threading.Thread.Sleep(1000*30); 
        //继续接收数据 
        socket.BeginReceive( readBuff, buffCount, 
                            1024-buffCount, 0, ReceiveCallback, 
                            socket); 
    } 
    catch (SocketException ex)
    { 
        Debug.Log("Socket Receive fail" + ex.ToString()); 
    } 
}
```

​		现在开启服务端和客户端，连接后，迅速让客户端发送“hi”“hello”“unity”三条数据。如图4-21和图4-22所示，客户端收到“hi”之后，进入30秒的等待，唤醒之后，客户端再次调用BeginReceive接收消息，此时缓冲区已存了“hello”和“unity”两条数据，OnReceiveData将会解析它们，并打印日志。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\118.png)

​																								图4-21  服务端打印的日志

​		在图4-22中，收到“hi”时，缓冲区共有4个字节数据“02-00-68-69”，前两字节表示长度，后两字节表示内容。处理过程和“正常的流程”一致。

​		如图4-23所示，在第二次收到消息后，缓冲区共有14字节的数据“05-00-68-65-6C-6C-6F-05-00-75-6E-69-74-79”（图中Recv 1），解析得到第一条消息长度是5（图中Recv 3），得到字符串字节“68-65-6C-6C-6F”，解析字符串得到hello（图中Recv 4）。更新缓冲区后，缓冲区还剩下7个字节，于是程序继续解析它，最终得到“75-6E-69-74-79”，即“unity”。

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\119.png)

​																								图4-22  收到“hi”时客户端打印的日志

![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\120.png)

​																								图4-23  收到“hello”“unity”时客户端打印的日志







![](E:\Gitee\Document\Texture\Unity3D网络游戏实战\1.png)