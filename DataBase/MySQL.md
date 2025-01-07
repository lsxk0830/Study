https://www.cnblogs.com/atomy/p/13628376.html

## 安装MySQL

[MySQL下载链接](https://dev.mysql.com/downloads/installer/)

### 安装验证

#### 1.通过Workbench验证

[MySQL Workbench下载链接](https://dev.mysql.com/downloads/workbench/)

![安装按照1](Texture/安装验证1.png)

输入Root密码，点击"OK"。如果能正常登录，证明安装是成功的

#### 2.通过MySQL 8.0 Command Line Client验证

![安装按照2](Texture/安装验证2.png)

#### 3.Windows下的命令操作符验证

先配置环境变量

登陆MySQL

```
mysql -u root -p
```

![image-20250107113215194](Texture/安装验证3.png)

### 环境变量

此电脑-属性-高级系统设置-环境变量-系统变量-Path-编辑-新建

输入"C:\Program Files\MySQL\MySQL Server 8.0\bin"，然后依次点击"确定"

![image-20250107112917499](Texture/环境变量.png)

选择mysql数据库

```
use mysql
```



## **安装后期设置**

### 修改Root密码

假如需要把Root密码改成"123456"，操作命令如下：

```c#
use mysql;
ALTER USER 'root'@'localhost' IDENTIFIED BY '123456';
flush privileges;
```
![修改Root密码](Texture/修改Root密码.png)

### 允许Root远程登录

```
use mysql;
？？？
```

### 启动服务

![image-20250107110706751](Texture/服务名称.png)

![image-20250107110706751](Texture/启动服务.png)

## **数据库创建与常见操作**

### 查询数据库

```
show databases; // 查询所有数据库
show databases like 'it%'; // 列出所有数据库名称以 it 开头的数据库
```

![查询数据库](Texture/查询数据库1.png)

![查询数据库](Texture/查询数据库2.png)

### 创建数据库

```
/*方法一*/
// 创建一个名为 cmdDBTest 的数据库，并设置默认的字符集和排序规则
create database cmdDBTest default character set UTF8 default collate utf8_general_ci;
/*方法二*/
//创建一个名为 cmdDBTest2 的数据库，但只有在该数据库不存在时才会创建，同时设置该数据库的默认字符集为 UTF-8，默认排序规则为 utf8_general_ci
create database if not exists cmdDBTest2 default character set UTF8 default collate utf8_general_ci; 
```

![image-20250107114836613](Texture/创建数据库1.png)

![image-20250107130604310](Texture/创建数据库1.png)

### 查询创建数据库的语句

```
show create database test; // 没有test
show create database cmdDBTest2；
```

![image-20250107130912379](Texture/查询创建数据库的语句.png)

### 更改数据库选项字符集(生产环境有数据不能这样做，仅适用于新建的数据库)

```
alter database study_db character set gbk;
alter database study_db character set utf8mb3;
```

![image-20250107131517309](Texture/更改数据库选项字符集1.png)

![image-20250107131354264](Texture/更改数据库选项字符集3.png)

![image-20250107131453475](Texture/更改数据库选项字符集2.png)

### 删除数据库

```
/*方法一*/
// 如果数据库 cmddbTest2 存在，它将被删除。如果数据库不存在，MySQL 会抛出一个错误
drop database cmddbTest2;
/*方法二*/
//如果数据库 cmddbTest2 存在，则删除它；如果数据库不存在，则什么也不做
drop database if exists cmddbTest2;
```

![image-20250107131809709](Texture/删除数据库1.png)

![image-20250107132100691](Texture/删除数据库2.png)

![image-20250107132115985](Texture/删除数据库3.png)

### 选择数据库

```
use study_db;
```

![image-20250107132349100](Texture/选择数据库.png)

## **数据类型**

### 整数类型

- tinyint [(M)][unsigned][zerofill]
- smallint [(M)][unsigned][zerofill]
- mediumint [(M)][unsigned][zerofill]
- int [(M)][unsigned][zerofill]
- bigint [(M)][unsigned][zerofill]

参数说明：

- M：取值范围。
- unsigned：无符号，控制是否有正负数。
- zerofill：用来进行前导零填充，如tinyint的值为1，而其最长取值位数是3位，则填充后的结果会变成001。类型后面写了zerofill，默认就是unsigned无符号。

![](Texture/数据类型1.png)

#### 无参数控制

```
create table study01 (id01 tinyint,id02 int);
```

![image-20250107133215206](Texture/创建表并设置两个字段.png)

```
desc study01; // 描述数据库中名为 study01 的表的结构
```

![image-20250107133339751](Texture/描述表结构.png)

```
insert into study01 (id01,id02) values (100,101);
```

![image-20250107133613156](Texture/表插入数据1.png)

```
insert into study01 (id01,id02) values (-1,-2);
```

![image-20250107133703575](Texture/表插入数据2.png)

```
//SQL 查询语句，用于从名为 study01 的数据库表中选择并返回所有列的所有数据
select * from study01;
```

![image-20250107133822111](Texture/查询所有列数据.png)

#### 有参数控制1

```
create table study02 (id01 tinyint(3) unsigned zerofill,id02 int(3) unsigned zerofill);
```

![image-20250107134646376](Texture/有参数创建字段.png)

```
desc study02;
```

![image-20250107135407471](Texture/有参数描述表结构.png)

```
insert into study02 (id01,id02) values (1,1);
insert into study02 (id01,id02) values (12,1234);
```

![image-20250107135934350](Texture/有参数插入数据.png)

```
select * from study02;
```

![image-20250107140229731](Texture/打印表数据.png)

#### 有参数控制2

```
create table study03 (id01 tinyint(4) unsigned,id02 int(4) zerofill);
```

![image-20250107140713223](Texture/有参数添加字段1.png)

![image-20250107140722996](Texture/有参数添加字段2.png)

```
insert into study01 (id01,id02) values (100,101);
insert into study01 (id01,id02) values (0,2);
select * from study01;
```

![image-20250107141154618](Texture/有符号插入数据.png)

如果 `id01` 或 `id02` 列的数据类型是 **无符号（UNSIGNED）** 的整型类型（如 `INT UNSIGNED` 或 `BIGINT UNSIGNED`），则它们不允许存储负数

### 小数类型

- decimal (M,D)
- float (M,D)
- double (M,D)

参数说明：

- zerofill
- unsigned

![](Texture/数据库小数类型.png)