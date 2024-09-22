####  认识Lua

- Lua是一个小巧的脚本语言，由标准C编写而成，在所有操作系统和平台上均可以编译与运行
- Lua没有提供强大的库
- Lua有一个同时进行的JIT项目，提供在特定平台上的及时编译功能



#### 下载Lua

- 官方下载地址：[Lua官网](http://www.lua.org/)
- GitHub下载地址：[Lua for Windows](https://github.com/rjpcomputing/luaforwindows/releases)



#### Lua文本格式

后缀名严格要求：`.lua`



#### 关键字

|  1   |   2   |  3   |  4   |   5    |   6    |   7    |  8   |    9     |  10   |
| :--: | :---: | :--: | :--: | :----: | :----: | :----: | :--: | :------: | :---: |
| and  | break |  do  | else | elseif |  end   | false  | for  | function |  if   |
|  in  | local | nil  | not  |   or   | repeat | return | then |   true   | until |



#### 行注释

单行注释：–

```lua
--这是一个注释演示
```

多行注释：–[[ ]]--

```lua
--[[
多行注释
]]--
```

PS：快捷 使用/取消 注释：`Ctrl+Q`



#### 运算符

##### 算术运算符

| 操作符 | 描述                 | 实例                |
| :----- | :------------------- | :------------------ |
| +      | 加法                 | A + B 输出结果 30   |
| -      | 减法                 | A - B 输出结果 -10  |
| *      | 乘法                 | A * B 输出结果 200  |
| /      | 除法                 | B / A 输出结果 2    |
| %      | 取余                 | B % A 输出结果 0    |
| ^      | 乘幂                 | A^2 输出结果 100    |
| -      | 负号                 | -A 输出结果 -10     |
| //     | 整除运算符(>=lua5.3) | **5//2** 输出结果 2 |

##### **关系运算符**

| 操作符 | 描述                                                         | 实例                  |
| :----- | :----------------------------------------------------------- | :-------------------- |
| ==     | 等于，检测两个值是否相等，相等返回 true，否则返回 false      | (A == B) 为 false。   |
| ~=     | 不等于，检测两个值是否相等，不相等返回 true，否则返回 false  | (A ~= B) 为 true。    |
| >      | 大于，如果左边的值大于右边的值，返回 true，否则返回 false    | (A > B) 为 false。    |
| <      | 小于，如果左边的值大于右边的值，返回 false，否则返回 true    | (A < B) 为 true。     |
| >=     | 大于等于，如果左边的值大于等于右边的值，返回 true，否则返回 false | (A >= B) 返回 false。 |
| <=     | 小于等于， 如果左边的值小于等于右边的值，返回 true，否则返回 false | (A <= B) 返回 true。  |

##### 逻辑运算符

| 操作符 | 描述                                                         | 实例                   |
| :----- | :----------------------------------------------------------- | :--------------------- |
| and    | 逻辑与操作符。 若 A 为 false，则返回 A，否则返回 B。         | (A and B) 为 false。   |
| or     | 逻辑或操作符。 若 A 为 true，则返回 A，否则返回 B。          | (A or B) 为 true。     |
| not    | 逻辑非操作符。与逻辑运算结果相反，如果条件为 true，逻辑非为 false。 | not(A and B) 为 true。 |

##### 其他运算符

| 操作符 | 描述                               | 实例                                                         |
| :----- | :--------------------------------- | :----------------------------------------------------------- |
| ..     | 连接两个字符串                     | a..b ，其中 a 为 "Hello " ， b 为 "World", 输出结果为 "Hello World"。 |
| #      | 一元运算符，返回字符串或表的长度。 | #"Hello" 返回 5                                              |

##### 运算符优先级

```
^
not    - (unary)
*      /       %
+      -
..
<      >      <=     >=     ~=     ==
and
or
```

除了 **^** 和 **..** 外所有的二元运算符都是左连接的。

```
a+i < b/2+1          <-->       (a+i) < ((b/2)+1)
5+x^2*8              <-->       5+((x^2)*8)
a < y and y <= z     <-->       (a < y) and (y <= z)
-x^2                 <-->       -(x^2)
x^y^z                <-->       x^(y^z)
```



#### 数据类型

Lua是动态类型语言，变量不需要类型定义

| **数据类型** | **描述**                                                     |
| :----------: | :----------------------------------------------------------- |
|     nil      | 无效值，形同于C#中的null（在条件表达式中相当于false）        |
|   boolean    | 包含两个值：true 和 false（只有false和nil为假，其余均为真）  |
|    number    | 表示双精度类型的实浮点数                                     |
|    string    | 字符串，由一对双引号或单引号来表示（不可修改）               |
|   function   | 由C或Lua编写的函数                                           |
|   userdata   | 便是任意存储在变量中的C数据结构                              |
|    thread    | 表示执行的独立线路，用于执行协同程序（协程）                 |
|    table     | Lua中的表（table）其实是一个"关联数组"，数组的索引可以是数字或字符串，在Lua中，table的创建是通过"构造表达式"来完成，最简单构造表达式“｛｝”，用来创建一个空表 |



#####  字符串替换：gsub()

Lua中的`string`不可以修改。

```lua
--string
a = "one string"
--gsub() 替换字符串,将对象a中的one替换为another
b = string.gsub(a, "one", "another") --another string
```



##### 连接字符串：..

```lua
-- ".." 相当于C#语言中的"+"
a=1
b='12345'
c = a .. "," .. b
print(c) --1,12345
```



##### C#与Lua的加法

C#中 `"10" + 2`的结果为102，即转换为字符串相加。
Lua中`"10" + 2`的结果为12，即转换为number。

```lua
print(10 + 2) --12
print("10" + 2) --12
```



##### ==比较

```lua
print(10 == "10") --false
print(tostring(10) == "10") --true
print(10 .. "" == "10") --true
```

 注意：Lua中`..`写在number后，需要加空格告诉Lua这是一个连接字符串



##### 条件判断语句

```lua
if exp then
	block
elseif exp then 
	block
else
	block
End
```

`exp`：判断条件
`block`：内容

Lua认为false、nil为假；true/非nil为真。特别注意的是Lua中的0为true。



##### For循环语句

Lua没有`switch-case`语句

```lua
for i=1, 10, 1 do
	pirnt(i)
end

for i=10, 1, -1 do
	pirnt(i)
end
--1 2 3 4 5 6 7 8 9 10
--10 9 8 7 6 5 4 3 2 1

for i=1, 10, 3 do
	print(i)
end
--1 4 7 10
```

注意：Lua中的**for**循环包含10



##### While循环语句

```lua
a = 1
while(a < 5) do
	print(a)
	a = a + 1
end
-- 1 2 3 4
```



##### repeat until（do while）

```lua
num = 3
repeat
	print(num) --3 5 7 9
	num = num+2
until(num>10) --满足 until 退出循环
```



##### Function 函数

```lua
local function add(a, b) -- local相当于局部变量
	return a + b
end
print(add(2 ,3)) --5

function Add()
	print("Hello World")
end
Add() --Hello World

add = function()
	print("==")
end
add() --==
```

###### 函数作为参数

```lua
function Test(tab,func)
	for key , value in pairs(tab) do
		func(key,value)
	end
end

function TestFunc1(key,value)
	print(key..":"..value)
end
function TestFunc2(key,value)
	print(key.."+"..value)
end
tab={name1="ZhangSan",name2="LiSi",age =18}

Test(tab,TestFunc1)
Test(tab,TestFunc2)
输出：
name1:ZhangSan
age:18
name2:LiSi
name1+ZhangSan
age+18
name2+LiSi
```

注意：使用某一模块或函数，须先加载这个模块和函数，在后面调用



##### 数据输入：--io.read()获取输入值

```lua
local a = io.read()
local b = io.read()

function add(a, b)
	return a + b
end

print(a .. "+" .. b .. "=" .. add(a,b))
```



##### 参数

```lua
function test(n)
--~	if n == nil then
--~		n=0
--~	end
	n = n or 0
	print(n)
end

test(3) --3
test()  --0
test(3, 4) --3
```

注意：对于未输入确切值，C#会报错，但Lua会输出结果 `nil`



##### 可变参数

```lua
local function Test(...)
	local tab = {...} --数组
	print("参数个数："..#tab)
	for key,value in ipairs(tab) do
		print(key,value)
	end
    --	for i=1, #tab, 1 do
    --		print(tab[i])
	--	end
end
Test(1,2) 
Test(true)

输出：
参数个数：2
1	1
2	2
参数个数：1
1	true
```

Lua中数组：`local arr = {...}`
数组长度：`#arr`
迭代数组方法： `ipairs()`



##### 返回值

```lua
local function init()
	return 1, "hi"
end

local a,b = init()
print(a, b) -- a  b  对应  1  hi

local a,b,c = init(),"c"
print(a, b, c) -- a b c 对应 1 c nil

local a,b,c = "c",init()
print(a, b, c) -- a b c 对应 c 1 hi
```



#### Table表

##### 初始化方式

```lua
local tab = {name='BlueSky',["like"]="Game",Age=18,Ok=false}
print(tab.name,tab.like,tab.Age,tab.Ok,#tab) --BlueSky	Game	18	false	0
tab["name"]='Blue'
tab.like = "Study"
tab.Age=28
print(tab.name,tab.like,tab.Age,tab.Ok,#tab) --Blue	Study	28	false	0

local tab = {name='BlueSky',"like","Game",false}
for key,value in pairs(tab) do
	print(key,value,#tab)
end
输出：
1	like	3
2	Game	3
3	false	3
name	BlueSky	3
```

初始化：["color"] = "red" 等价于 t["Name"] = "Apple"

local arr = {"a", "b", "c"}实质上是table表。等价于 arr = { [1] = “a”, [2] = “b”, [3] = “c”}

Lua中无数组



##### ipairs( )与pairs( )

```lua
arr = {
	[1] = "a",
	[2] = "b",
	[4] = "c"
}

for key,value in ipairs(arr) do --仅能读出表 [1]
	print("ipairs",key,value)
end

for key,value in pairs(arr) do
	print("pairs",key,value)
end
输出：
ipairs	1	a
ipairs	2	b
pairs	1	a
pairs	2	b
pairs	4	c
```

- `ipairs()`：适用于有顺序的数据表，遇到无序表将无法读出
- `pairs()`：无论是否有序，均能读出



##### index

```lua
father = { house="四合院"}
son = {car="BMW"}

print(son.car, son.house)  --BMW, nil
```

###### 子表读取父表 

我们需要在father与son之间添加下列表，表示连接表，特别注意`.__index`为双`_`

```lua
grandfather = { house="四合院"}
father = {car="BMW"}
son = {car="BMM二手"}

print(father.car, father.house,son.car, son.house)  --BMW	nil	BMM二手	nil

father.__index=father
setmetatable(son,father)

print("Son:",son.car, son.house) --BMM二手	nil

-- t :自己  key：属性
grandfather.__index = function(t, key)
	return grandfather[key]
end

setmetatable(father, grandfather)  --设置father的源表是grandfather,使得father与grandfather有关系

print("father:",father.car, father.house)  --BMW	四合院
print("Son:",son.car, son.house) --BMM二手	四合院
```

简化写法：`father.__index=father`

###### 父表读祖父表

```lua
grandfather = { boat="豪华游轮"}
father = { house="四合院"}
son = {car="BMW"}

grandfather.__index = grandfather
father.__index = father

setmetatable(father, grandfather)
setmetatable(son, father)

print(son.boat, father.boat) --豪华游轮 豪华游轮
```

Lua不存在面向对象思想，与类说法

###### opp（不懂）

```lua
Fruit = { price = 5}
Fruit.__index = Fruit

--创建实例 Fruit类
function Fruit : new(price)
	local t = {}
	t.price = price
	setmetatable(t, Fruit)
	return t
end

function Fruit : printPrice()
	print("Fruit price :" .. self.price)
end

local f = Fruit : new(10)

print(f.price) --10
f : printPrice() --Fruit price: 10
```

###### 封装

封装Fruit给Apple使用

```lua
--Fruit
Fruit = { price = 5 }
Fruit.__index = Fruit

function Fruit : new(price)
	local t = {}
	t.price = price
	setmetatable(t, Fruit)
	return t
end

function Fruit : printPricr()
	print("Fruit Price：" .. self.price)
end
```

Apple封装

```lua
require "Fruit"  --加载模块

Apple = Friut : new()
Apple.__index = Apple

function Apple : new(price, color)
	local t = {}
	t.price = price
	t.color = color or "red"
	setmetatable(t, Apple)
	return t
end
--输出价格
function Apple : printPrice()
	print("Apple Price：" .. self.price)
end
--输出颜色
function Apple : printColor()
	print("Apple Color：" .. self.color)
end

local a = Apple : new(10, "yellow")
a : printPrice() --Apple Price：10
a : printColor() --Apple Color：yellow

```

#### 其他问题

```lua
require "Fruit"
local f = Fruit : new(10)
f : printPrice() --Fruit Price：10

Fruit.printPrice = function(t) 
	t.price = 0
	print("Fruit Price：" .. t.price) --Fruit Price：0
end

f : printPrice() --Fruit Price：0
f = Fruit : new(8)
f : printPrice() --Fruit Price：0 由于上代码将全局变量都改了

--解决方法
require "Fruit"
f = Fruit : new(8)
f : printPrice() --Fruit Price：8
```



#### 协同程序(coroutine)

```lua
function foo (a)
    print("foo 函数输出", a)
    return coroutine.yield(2 * a) -- 返回  2*a 的值
end
 
co = coroutine.create(function (a , b)
    print("第一次协同程序执行输出", a, b) -- co-body 1 10
    local r = foo(a + 1)
     
    print("第二次协同程序执行输出", r)
    local r, s = coroutine.yield(a + b, a - b)  -- a，b的值为第一次调用协同程序时传入
     
    print("第三次协同程序执行输出", r, s)
    return b, "结束协同程序"                   -- b的值为第二次调用协同程序时传入
end)
       
print("main", coroutine.resume(co, 1, 10)) -- true, 4
print("--分割线----")
print("main", coroutine.resume(co, "r")) -- true 11 -9
print("---分割线---")
print("main", coroutine.resume(co, "x", "y")) -- true 10 end
print("---分割线---")
print("main", coroutine.resume(co, "x", "y")) -- cannot resume dead coroutine
print("---分割线---")
```

以上实例接下如下：

- 调用resume，将协同程序唤醒,resume操作成功返回true，否则返回false；
- 协同程序运行；
- 运行到yield语句；
- yield挂起协同程序，第一次resume返回；（注意：此处yield返回，参数是resume的参数）
- 第二次resume，再次唤醒协同程序；（注意：**此处resume的参数中，除了第一个参数，剩下的参数将作为yield的参数**）
- yield返回；
- 协同程序继续运行；
- 如果使用的协同程序继续运行完成后继续调用 resume方法则输出：cannot resume dead coroutine

**resume和yield的配合强大之处在于，resume处于主程中，它将外部状态（数据）传入到协同程序内部；而yield则将内部的状态（数据）返回到主程中**



#### **练习**

##### 判断年份是闰年或平年

**提示：`~=`：不等于 `not`：非 `and`：和 `or`：或**

```lua
year = 2020
if (year % 4 == 0 and year % 100 ~=0) or year % 400 == 0 then
	print(year .. "是闰年")
else
	print(year .. "是平年")
end
--2020是闰年
```



##### 输出矩阵｛[1,2,3,4,5],[2,4,6,8,10],[3,6,9,12,15],[4,8,12,16,20]｝

```lua
str = ''
temp = ''
num =0
offset =0
for i=1 ,4 do
	for j  =1,5 do
		num = offset+i
		offset= offset+i
		str=str..num .." "
	end
	temp=temp..''..str
	str=''
	offset=0
end
print(temp)
```

```lua
str = ""
for j=1, 4 do
	for i=1, 5 do
		str = str .. i*j .. " "
	end
end
print(str) -- 1 2 3 4 5 2 4 6 8 10 3 6 9 12 15 4 8 12 16 20 
```



##### 实现简单的两个数的加减乘除

```lua
function add(a ,b) return a + b end
function subtract(a ,b) return a - b end
function multiply(a ,b) return a * b end
function divide(a ,b) return a / b end

function calculate(a, b, operator)
	if operator == "+" then
		return add(a,b)
	elseif operator == "-" then
		return subtract(a, b)
	elseif operator == "*" then
		return multiply(a, b)
	elseif operator == "/" then
		return divide(a, b)
	else
		return "非法运算符"
	end
end

local a = io.read()
local operator = io.read()
local b = io.read()

print(a .. operator .. b .. "=" ..calculate(a, b, operator)) --3/2.3=1.3043478260
```

**代码改进**

```lua
function add(a ,b) return a + b end
function subtract(a ,b) return a - b end
function multiply(a ,b) return a * b end
function divide(a ,b) return a / b end
function default(a ,b) return "非法运算符" end

function calculate(a, b, operator)
	if operator == "+" then return add
	elseif operator = "-" then return subtract
	elseif operator = "*" then return multiply
	elseif operator = "/" then return divide
	else
		return dafault
	end
end

local a = io.read()
local operator = io.read()
local b = io.read()
local function = calculate(operator)

print(a .. operator .. b .. "=" ..calculate(a, b, operator))
```



##### 1/1! + 1/2! + 1/3! + … + 1/20! = ?

```lua
local function Multiply(n)
	if(n==1) then
		return  1
	else
		return n * Multiply(n-1)
	end
end

local function Divide(num)
	local sum =0
	for i=1,num do
		sum=sum+1/Multiply(i)
	end
	return sum
end

print(Divide(20)) --1.718281828459
```







### [热更新](https://so.csdn.net/so/search?q=热更新&spm=1001.2101.3001.7020)原理

Unity的热更新需要涉及到3个目录：

<img src="E:\Gitee\Lua\Assets\Lua\Texture\1.png" style="zoom:50%;" />

流程：

- 操作①仅第一次操作出现，是将游戏包资源文件拷贝至数据目录（后续将不再执行）
- 操作②请求网络资源，检查是否更新资源
- 操作③启动游戏程序

#### 游戏资源目录

包含Unity工程中StreamingAssets文件夹下的文件。安装游戏之后，这些文件将被复制到目标机器上特定的文件夹内。
注意：不同平台下的目录路径不一。

| 平台            | 路径                                               |
| --------------- | -------------------------------------------------- |
| Mac OS或Windows | Application.dataPath + "/StreamingAssets"          |
| IOS             | Application.dataPath + "/Raw"                      |
| Android         | "jar:file://" + Application.dataPath + "!/assets/" |

####  数据目录

“游戏资源目录”在Andriod、IOS上只读，无法将下载更新的资源放置其中。需建立一个“数据目录”，该目录可读写。
在第一次启动游戏后，程序会将“游戏资源目录”的内容复制到“数据目录中”。操作①
游戏过程中的资源加载，都将从“数据目录”中获取、解包。操作③
注意：不同平台下的目录路径不一

| 平台            | 路径                                              |
| --------------- | ------------------------------------------------- |
| Mac OS或Windows | C:/LuaFramework/"                                 |
| Android或IOS    | Application.persistendDataPath + "/LuaFramework"" |
| 调试模式下      | Application.dataPath + “/StreamingAssets/”        |

#### 网络资源地址

存放游戏资源的网址，游戏开始后，程序会从网络资源地址下载一些更新的文件到数据目录。

此目录下包含不同版本的资源文件，以及用于版本控制的files.txt。程序会优先下载此文件，然后与“数据目录”中文件的MD5码作比较，更新有变化的文件。操作②

LuaFramework的热更新代码定义在Assets\LuaFramework\Scripts\Manager\GameManager.cs【根据实际情况配置路径】	

##### 释放资源

```C#
//释放资源
void CheckExtractResource()
{
	bool isExists = Dictionary.Exists(Util.DataPath) 
		&& Dictionary.Exists(Util.DataPath + "lua/") 
		&& Dictionary.Exists(Util.DataPath + "lua/")；
	if (isExists || AppConst.DebugMode) 
	{
		StartCoroutine(OnUpdateResource());
		return;
	}
	StartCoroutine(OnExtractResource());  //启用释放协议
}

IEnumerator OnExtractResource()
{
	string dataPath = Util.DataPath; //数据目录
	string resPath = Util.AppContentPath(); //游戏包资源目录
	
	if(Directory.Exists(dataPath) && Directory.Delet(dataPath, true))
	{
		Directory.CreateDirectory(dataPath);
	}
}
```

##### 启用更新资源

```c#
IEnumerator OnUpdateMode()
{
	if(!AppConst.UpdateMode)
	{
		OnResourceInited();
		yield break;
	}
	string dataPath = Util.DataPath;  //数据目录
	string url = AppConst.WebUrl;
	string message = string.Empty;
	string random = DateTime.Now.ToString("yyyymmddhhmmss");
	string listUrl = url + "files.txt?v=" + random;
	Debug.LogWarning("LoadUpdate ——> " + listUrl);

	WWW www = new WWW(listUrl);
	yield return www;
	if(www.error != null)
	{
		OnUpdateFaild(string.Empty);
		yield break;
	}
}
```

