https://www.cnblogs.com/atomy/p/13628376.html

[TOC]



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

```mysql
use mysql
```



## **安装后期设置**

### 修改Root密码

假如需要把Root密码改成"123456"，操作命令如下：

```mysql
use mysql;
ALTER USER 'root'@'localhost' IDENTIFIED BY '123456';
flush privileges;
```
![修改Root密码](Texture/修改Root密码.png)

### 允许Root远程登录

```mysql
use mysql;
？？？
```

### 启动服务

![image-20250107110706751](Texture/服务名称.png)

![image-20250107110706751](Texture/启动服务.png)

## **数据库创建与常见操作**

### 查询数据库

```mysql
show databases; // 查询所有数据库
show databases like 'it%'; // 列出所有数据库名称以 it 开头的数据库
```

![查询数据库](Texture/查询数据库1.png)

![查询数据库](Texture/查询数据库2.png)

### 创建数据库

```mysql
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

```mysql
show create database test; // 没有test
show create database cmdDBTest2；
```

![image-20250107130912379](Texture/查询创建数据库的语句.png)

### 更改数据库选项字符集(生产环境有数据不能这样做，仅适用于新建的数据库)

```mysql
alter database study_db character set gbk;
alter database study_db character set utf8mb3;
```

![image-20250107131517309](Texture/更改数据库选项字符集1.png)

![image-20250107131354264](Texture/更改数据库选项字符集3.png)

![image-20250107131453475](Texture/更改数据库选项字符集2.png)

### 删除数据库

```mysql
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

```mysql
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

```mysql
create table study01 (id01 tinyint,id02 int);
```

![image-20250107133215206](Texture/创建表并设置两个字段.png)

```mysql
desc study01; // 描述数据库中名为 study01 的表的结构
```

![image-20250107133339751](Texture/描述表结构.png)

```mysql
insert into study01 (id01,id02) values (100,101);
```

![image-20250107133613156](Texture/表插入数据1.png)

```
insert into study01 (id01,id02) values (-1,-2);
```

![image-20250107133703575](Texture/表插入数据2.png)

```mysql
//SQL 查询语句，用于从名为 study01 的数据库表中选择并返回所有列的所有数据
select * from study01;
```

![image-20250107133822111](Texture/查询所有列数据.png)

#### 有参数控制1

```mysql
create table study02 (id01 tinyint(3) unsigned zerofill,id02 int(3) unsigned zerofill);
```

![image-20250107134646376](Texture/有参数创建字段.png)

```
desc study02;
```

![image-20250107135407471](Texture/有参数描述表结构.png)

```mysql
insert into study02 (id01,id02) values (1,1);
insert into study02 (id01,id02) values (12,1234);
```

![image-20250107135934350](Texture/有参数插入数据.png)

```mysql
select * from study02;
```

![image-20250107140229731](Texture/打印表数据.png)

#### 有参数控制2

```mysql
create table study03 (id01 tinyint(4) unsigned,id02 int(4) zerofill);
```

![image-20250107140713223](Texture/有参数添加字段1.png)

![image-20250107140722996](Texture/有参数添加字段2.png)

```mysql
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

#### 无参数控制

```mysql
create table studyf1 (f1 float,f2 double);
desc studyf1;
insert into studyf1 (f1,f2) values (-12.123,-1234.5678);
select * from studyf1;
```

![image-20250107142240727](Texture/小数类型无参数控制.png)

![](Texture/小数类型设计.png)

![](Texture/小数类型插入参数.png)

#### 有参数控制1

```mysql
create table studyf2 (f1 float(5,2),f2 double(6,3) zerofill);
desc studyf2;
insert into studyf2 (f1,f2) values (12.34,12.34);
insert into studyf2 (f1,f2) values (1.1,1.2);
insert into studyf2 (f1,f2) values (123.45,123.456);
insert into studyf2 (f1,f2) values (123.456,123.456);
/*科学计数法(E)，小数点移动几位。*/
insert into studyf2 (f1,f2) values (0.1234E2,0.123456E3);
/*插入多了，就会四舍五入。*/
insert into studyf2 (f1,f2) values (12.126,12.34);
select * from studyf2;
```

![](Texture/小数插入.png)

![](Texture/小数类型插入具体.png)

#### 有参数控制2

```mysql
create table studyf3 (f1 float(10,4) unsigned zerofill);
desc studyf3;
insert into studyf3 (f1) values (12.345);
insert into studyf3 (f1) values (12.3456);
insert into studyf3 (f1) values (12.34567);
select * from studyf3;
```

![](Texture/有参数小数.png)

### 日期类型

![](Texture/日期类型.png)

#### datetime(年月日时分秒)

```mysql
create table studyd1 (mydate datetime);
insert into studyd1 (mydate) values ('20200902230130');
insert into studyd1 (mydate) values (20200902230130);
insert into studyd1 (mydate) values ('2020-09-02 23:01:30');
insert into studyd1 (mydate) values (null);
select * from studyd1;
```

![](Texture/插入日期.png)

![](Texture/插入日期2.png)

#### timestamp(年月日时分秒/整数)

```mysql
create table studyd2 (mytime timestamp);
insert into studyd2 (mytime) values ('20200902230130');
insert into studyd2 (mytime) values ('2020-09-02 23:01:30');
select * from studyd2;
/*+0 查看时间戳，显示整数。*/
select mytime+0 from studyd2;
```

![](Texture/时间戳.png)

#### date(年月日)

```mysql
create table studyd3 (mydate date);
insert into studyd3 (mydate) values ('20200902');
insert into studyd3 (mydate) values ('2020-09-02');
select * from studyd3;
```

![](Texture/date.png)

![](Texture/date数据.png)

#### time(时分秒)

```mysql
create table studyd4 (mytime time);
insert into studyd4 (mytime) values ('10:10:10');
/*D HH:MM:SS，D代表天，最大可以是34天，代表过去多少时间。*/
insert into studyd4 (mytime) values ('5 10:10:10');
select * from studyd4;
```

#### year

```
create table studyd5 (myyear year);
insert into studyd5 (myyear) values ('2020');
insert into studyd5 (myyear) values ('2021');
select * from studyd5;
```

### 字符类型

![](Texture/字符类型.png)

#### char(M)

M表示字符固定长度，最大为255字节

```mysql
create table studyz1 (mychar char(255));
insert into studyz1 (mychar) values ('YES');
insert into studyz1 (mychar) values ('NO');
insert into studyz1 (mychar) values ('Y ');
insert into studyz1 (mychar) values (' N');
select * from studyz1;
// 从 studyz1 表中查询 mychar 列的内容，并且使用 LENGTH 函数来计算 mychar 中每个字符串的长度
select mychar,length(mychar) `length` from studyz1;
```

![](Texture/char.png)

![](Texture/char2.png)

#### varchar(M)

M表示字符可变长度，最大65535字节，需要1-2字节来保存信息，超过255的长度就用2个字节来保存。

utf8：一个字符占用3个字节 65535/3=21845 -1 -2=21844/21843

gbk：一个字符占用2个字节 65535/2=32767 -1 -2=32766/32765

最大长度是受最大65535字节和所使用的字符集有关

```mysql
create table studyz2 (myvarchar varchar(21844));
insert into studyz2 (myvarchar) values ('YES');
insert into studyz2 (myvarchar) values ('NO');
insert into studyz2 (myvarchar) values ('Y ');
insert into studyz2 (myvarchar) values (' N');
select * from studyz2;
//从 studyz2 表中选择 myvarchar 列，并计算 myvarchar 列中每个字符串的长度，结果以 length 列的形式返回
select myvarchar,length(myvarchar) `length` from studyz2;
```

![](Texture/Varchar.png)

#### text

**text和blob区别：blob用来保存二进制数据，text保存字符数据。**

**text和char/varchar区别：text不需要指定长度。**

存储长度：1字节-4GB

```mysql
create table text1 (id int,name tinytext);
create table text2 (id int,name text);
create table text3 (id int,name mediumtext);
/*longtext：最大4GB，4字节开销。*/
create table text4 (id int,name longtext);
```

|    类型    | 说明                                                         |
| :--------: | :----------------------------------------------------------- |
|  tinytext  | 最大256 bytes，1字节开销，少于255个字符的，就比较好，比如：文章摘要 |
|    text    | 最大64k，相当于65535个字符，2字节开销，比如：文章正文        |
| mediumtext | 最大16MB，相当于16777215个字符，3字节开销，存储相对大的文本数据，比如书籍文本，白皮书 |
|  longtext  | 最大4GB，4字节开销                                           |

#### blob

```mysql
create table blob1 (id int,name tinyblob);
create table blob2 (id int,name blob);
create table blob3 (id int,name mediumblob);
create table blob4 (id int,name longblob);
```

|    类型    | 说明          |
| :--------: | :------------ |
|  tinyblob  | 最大256 bytes |
|    blob    | 最大64k       |
| mediumblob | 最大16MB      |
|  longblob  | 最大4GB       |

#### enum相于单项选择题

最多65535个枚举项，2字节开销，相于单项选择题。

```mysql
create table studye1 (myenum enum('Y','N'));
insert into studye1 (myenum) values ('Y');
insert into studye1 (myenum) values ('N');
insert into studye1 (myenum) values ('1');
insert into studye1 (myenum) values ('2');
select * from studye1;
select myenum+0 from studye1;
```

#### set相当于多项选择题。

```mysql
create table studys1 (myset set('A','B','C','D'));
insert into studys1 values ('A');
insert into studys1 values ('A,B');
insert into studys1 values ('C');
insert into studys1 values ('C,D');
select * from studys1;
```

## **表的创建及管理**

### 创建表

需要信息：表名，表字段名，表字段的定义

create table table_name 列定义 选项;

create table table_name like old_table_name; --like:包括旧表的结构+信息+索引

create table table_name select * from old_table_name; --包括旧表的结构+信息

```mysql
create table studyt1
(
    id int(20) unsigned auto_increment not null,
    name varchar(20) not null,
    jobdate date,
    primary key (id)
) engine=innodb default charset=utf8;

show create table studyt1;
```

![](Texture/创建表.png)

### 查询表

```mysql
//列出当前选定数据库中的所有表
show tables;
```

![](Texture/查询表1.png)

```mysql
//列出名为 study_db 的数据库中的所有表
show tables from study_db;
```

![](Texture/查询表2.png)

```mysql
//列出当前选定数据库中所有以 'te' 开头的表名
show tables like 'te%';
```

![](Texture/查询表3.png)

```mysql
//列出 study_db 数据库中所有以 'te' 开头的表名
show tables from study_db like 'te%';
```

![](Texture/查询表4.png)

### 查看表内容

```mysql
select * from study01;
```

![](Texture/查询表内容1.png)

```mysql
//从名为 test 的数据库中的 study01 表中选择所有列的数据
select * from study_db.study01;
```

![](Texture/查询表内容2.png)

```mysql
//从名为 study_db 的数据库中的 study01 表中选择 id01 和 id02 这两列的数据，并限制返回的结果为最多 2 行
select id01,id02 from study_db.study01 limit 2;
```

![](Texture/查询表内容3.png)

### 表的增删改查

#### 查数据库是否是自动commit

```mysql
//用于检查 MySQL 数据库中自动提交设置的有用命令
show variables like '%autocommit%';
```

![](Texture/是否自动commit.png)

表示当前会话的自动提交功能是开启的

#### 测试表和数据

```mysql
create table study11 (id int(3),name varchar(12),sex varchar(6));
create table study12 (id int(3),name varchar(12),age int(5));

insert into study11 (id,name,sex) values 
(1,'study01','男'),
(2,'study02','男'),
(3,'study03','女'),
(4,'study04','女'),
(5,'study05','女');

insert into study12 (id,name,age) values 
(1,'study01',20),
(2,'study02',21),
(3,'study03',18),
(4,'study04',19),
(5,'study05',28);
```

![](Texture/测试表和数据.png)

#### insert

语法：insert into table_name (表字段) values (值列表);

```mysql
/*方法1*/
insert into study11 (id,name,sex) values (6,'study06','男');/*方法2*/
insert into study11 values (7,'study07','男');
/*方法3*/
insert into study11 set id=8,name='study06',sex='男';
/*方法4*/
insert into study1 values (1,'study01',now(),20);/*方法5*/
insert into study1 values (2,'study02',default,20);
/*方法6*/
create table study13 select * from study11; // 创建一个新表 study13，并将 study11 表中的所有数据复制到 study13 中
truncate table study13; // 清空 study13 表中的所有数据
insert into study13 select * from study11; //  将 study11 表中的所有数据再次插入到 study13 表中
```

![](Texture/插入表.png)

#### delete

语法：delete from 表名 [where 条件] [order by] [limit row_count];

![image-20250107172324928](Texture/删除1.png)

```mysql
delete from study13 where id=1;// 从 study13 表中删除 id 列值为 1 的行
```

![](Texture/删除2.png)

```mysql
delete from study13 limit 2;// 用于从 study13 表中删除最多 2 行数据
```

![](Texture/删除3.png)

![](Texture/删除4.png)

#### update

语法：update 表名 set 列名=值 where 条件;

```mysql
update study13 set name='study11',sex='女' where id=1;
```

![](Texture/更新表1.png)

![](Texture/更新表2.png)

#### select

**语法：select 字段/表名 from 表名/视图名 where 查询条件;**

查询条件：

- where 条件
- group by 分组
- having 分组后再聚合
- limit 限制多少行显示
- order by [asc|desc] 排序，升|降

##### 列连接

```mysql
//从 study11 表中选择数据的 SQL 查询语句。它不仅返回 name 列的值，还通过连接 name 和 sex 列生成一个新的列，便于在结果中显示姓名和性别的组合
select name,concat(name,'-',sex) as '姓名+性别' from study11;
```

![](Texture/列连接1.png)

##### 别名 as/也可以省略

```mysql
//条件是 study11 表和 study12 表中的 name 列相匹配。这种查询常用于查找两个表之间的关联数据
select a.* from study11 a,study12 b where a.name=b.name;
```

![](Texture/别名as也可以省略.png)

##### 虚拟表dual

```c#
//从虚拟表 dual 中选择当前的日期和时间。由于 dual 表只有一行一列，因此查询结果将只返回当前的日期和时间
select now() from dual;
```

![](Texture/虚拟表dual.png)

##### SQL语句注释方式

- 语句前注释：#
- \#select now() from dual;
- 语句后注释：--
  select now() from dual; --查当前系统时间
- 多行注释：/**/

```mysql
/*select now() from dual;*/
```

##### 常用的运算符

- =：等于
- \>：大于
- <：小于
- \>=：大于等于
- <=：小于等于
- <>：不等于
- !=：不等于
- is null：为null
- is not null：不为null
- [not]like：模糊查询
- [not]between and：在什么范围内
- [not]in：在什么范围值内

```mysql
select * from study12 where age=20;
select * from study12 where age<>20;
select * from study12 where age>20;
select * from study12 where age>=20;
select * from study12 where age<20;
select * from study12 where age<=20;
//从 study12 表中选择所有列的数据，前提是 age 列的值在 18 到 20 之间（包括 18 和 20）
select * from study12 where age between 18 and 20;
select * from study12 where age not between 18 and 20;
select * from study12 where age>=18 and age<=20;
select * from study12 where age>=18 && age<=20;
//从 study12 表中选择所有列的数据，前提是 age 列的值为 18、19 或 28
select * from study12 where age in (18,19,28);
select * from study12 where age not in (18,19,28);
select * from study12 where name like 'study%';
//从 study12 表中选择所有列的数据，前提是 name 列的值不包含 005 字符串
select * from study12 where name not like '%005%';
```

##### 逻辑运算

- 非：not
- 与：and &&
- 或：or
- 异或：xor

```mysql
在 SQL 中，使用普通的等于运算符 = 进行 NULL 值比较时，结果会返回 NULL，而不是 TRUE 或 FALSE。
例如，NULL = NULL 的结果是 NULL，而 NULL <=> NULL 的结果是 TRUE
select null is not not null,null is null;
select null<=>null,10<=>null;
```

![](Texture/逻辑运算.png)

##### 组合

```mysql
select * from study12 where name='study01' and age=20;
select * from study12 where name='study01' or age=21;
```

![](Texture/组合1.png)

![](Texture/组合2.png)

##### like

从 `study12` 表中选择所有列的数据，前提是 `name` 列的值以 `study` 开头

```mysql
select * from study12 where name like 'study%';
```

![](Texture/like.png)

##### 查询分组与排序

group by 分组

group by 列 {asc升序|desc降序},{with rollup} 组内聚合计算

```mysql
//是一条用于从 study12 表中选择数据的 SQL 查询语句，按 name 列的前 4 个字符进行分组，并将相同组的 name 值连接成一个字符串
select left(name,4),group_concat(name) name from study12 group by left(name,4);
```

![](Texture/查询分组与排序.png)

##### limit:限制返回的行数

```mysql
//从 study12 表中选择所有列的数据，按 age 列降序排序，并只返回年龄最大的那一行
select * from study12 order by age desc limit 1;
```

![](Texture/limit.png)

##### distinct:去除重复记录

```mysql
//从 study12 表中选择 name 列的前 4 个字符，并返回唯一的结果
select distinct left(name,4) name from study12;
```

![](Texture/distinct.png)

##### union:有重并集,把多个结果组合不去重

```mysql
//从 study11 表和 study12 表中分别选择 name 列的值，并将这两个结果集合并在一起，返回所有的 name 值，包括重复的值
select name from study11 union all select name from study12;
```

> 使用 `UNION` 操作符时，两个表的列数和数据类型必须匹配。根据你提供的信息，表1（包含 `id`、`name`、`sex`）和表2（包含 `id`、`name`、`age`）的列数和数据类型不完全相同，因此不能直接使用 `UNION` 来合并这两个表

![](Texture/union.png)

##### unionall:有重并集,把多个结果组合不去重

```mysql
//从 study11 表和 study12 表中分别选择 name 列的值，并将这两个结果集合并在一起，返回所有的 name 值，包括重复的值
select name from study11 union all select name from study12;
```

![](Texture/unionall.png)

##### for update:会锁表(生产环境不要轻易用)

```mysql
//从 study11 表中选择所有行，并对这些行进行锁定，以便在当前事务中进行更新或其他操作
select * from study11 for update;
```

![](Texture/forupdate.png)

## **常用函数**

### 字符串函数

#### concat(str1,str2,...)：拼接

作用：将传入的字符连接成一个字符串，任何字符与null进行连接结果都是null。

```mysql
SELECT CONCAT(`name`,'-',sex) FROM study11;
```

![](Texture/concat.png)

#### insert(str,pos,len,newstr)：插入

作用：将字符串str从pos位置开始len个字符长的子串，替换为指定的字符newstr。

```mysql
SELECT INSERT('ABCDEFG',2,3,'XXX');
```

![](Texture/insert.png)

> 说明：SQL Server中对应的函数是STUFF。

```mysql
SELECT STUFF('ABCDEFG',2,3,'XXX')
```

#### LOWER(str)：小写

作用：将字符串转成小写。

```mysql
SELECT LOWER('ABC');
```

![](Texture/LOWER.png)

#### UPPER(str)：大写

作用：将字符串转成大写。

```mysql
SELECT UPPER('abc');
```

![](Texture/UPPER.png)

#### LEFT(str,len)：左边的len个字符

作用：返回字符串str最左边的len个字符。

```mysql
SELECT LEFT('abc',2);
```

![](Texture/LEFT.png)

#### RIGHT(str,len)：右边的len个字符

作用：返回字符串str最右边的len个字符。

```mysql
SELECT RIGHT('abc',2);
```

![](Texture/RIGHT.png)

#### LPAD(str,len,padstr):在列的左边粘贴字符

作用：用字符串padstr对str最左边进行填充，直到总长度达到len个字符为止。

```mysql
SELECT LPAD('abc',10,'def');
```

![](Texture/LPAD.png)

![](Texture/LPAD2.png)

> 说明：SQL Server中没有对应的函数。

#### RPAD(str,len,padstr):在列的右边粘贴字符

作用：用字符串padstr对str最右边进行填充，直到总长度达到len个字符为止。

```mysql
SELECT RPAD('abc',10,'def')；
```

![](Texture/RPAD.png)

>  说明：SQL Server中没有对应的函数。

#### LTRIM(str):去除字符串当中最左侧的空格

作用：去除字符串当中最左侧的空格。

```mysql
SELECT LTRIM('   abc');
```

![](Texture/LTRIM.png)

#### RTRIM(str):去除字符串当中最右侧的空格

```mysql
SELECT RTRIM('ab c   ');
```

![](Texture/RTRIM.png)

#### TRIM([remstr FROM] str):去除字符

完整格式：TRIM([{BOTH | LEADING | TRAILING} [remstr] FROM] str)

作用：返回字符串str，其中所有remstr前缀和/或后缀都已被去除。若分类符BOTH、LEADIN或TRAILING中没有一个是给定的，则假设为BOTH。remstr为可选项，在未指定情况下，可去除空格。

##### 去除两侧空格

```mysql
SELECT TRIM('   a b c   ');
```

![](Texture/TRIM1.png)

##### 去除两侧'x'字符

```mysql
SELECT TRIM(BOTH 'x' FROM 'xxxbxaxrxxx');
```

![](Texture/TRIM2.png)

##### 去除左侧'x'字符

```mysql
SELECT TRIM(LEADING 'x' FROM 'xxxbarxxx');
```

![](Texture/TRIM3.png)

##### 去除右侧'x'字符

```mysql
SELECT TRIM(TRAILING 'x' FROM 'xxxbarxxx');
```

![](Texture/TRIM4.png)

##### 去除右侧'xyz'字符串

```mysql
SELECT TRIM(TRAILING 'xyz' FROM 'barxyzxyz');
```

![](Texture/TRIM5.png)

![](Texture/TRIM6.png)

> 说明：SQL Server中没有对应的函数。

#### REPEAT(str,count):返回str重复count次的结果

```mysql
SELECT REPEAT('abc',3);
```

![](Texture/REPEAT.png)

>  说明：SQL Server中没有对应的函数

#### REPLACE(str,from_str,to_str):用字符串to_str替换字符串str中所有出现的字符串from_str

```mysql
SELECT REPLACE('mysql','my','hello my');
```

![](Texture/REPLACE2.png)

#### SUBSTRING(str FROM pos FOR len):返回字符串str中第pos位置起len个字符长度的字符

```mysql
SELECT SUBSTRING('abc',2,2);
```

![](Texture/SUBSTRING.png)

### 数值函数

#### ABS(X)：返回X的绝对值

```mysql
SELECT ABS(-1);
```

![](Texture/ABS.png)

#### CEILING(X)

作用：小数不为零部分向上取整，即向上取最近的整数。

```mysql
SELECT CEILING(1.1);
```

![](Texture/CEILING.png)

#### FLOOR(X)

作用：小数不为零部分向下取整，即向下取最近的整数。

```
SELECT FLOOR(2.3);
```

![](Texture/FLOOR.png)

#### MOD(N,M):返回N/M的模，即求余

```
SELECT MOD(5,2);
SELECT 5%2;
```

![](Texture/MOD.png)

> 说明：SQL Server中没有对应的函数，只能通过%求余。

```mysql
SELECT 5%2
```

#### RAND()

作用：返回0-1内容的随机值。

```mysql
SELECT CEILING(RAND()*10);
```

![](Texture/RAND1.png)

![](Texture/RAND2.png)

### 日期和时间函数

#### CURDATE()

作用：返回当前日期，只包含年月日。

```mysql
SELECT CURDATE();
```

![](Texture/CURDATE.png)

> 说明：SQL Server中没有对应的函数。

#### CURTIME()

作用：返回当前时间，只包含时分秒。

```mysql
SELECT CURTIME();
```

![](Texture/CURTIME.png)

说明：SQL Server中没有对应的函数。

#### NOW()

作用：返回当前日期和时间，年月日时分秒都包含。

```mysql
SELECT NOW();
```

![](Texture/NOW1.png)

> 说明：SQL Server中对应的函数是GETDATE。

```mysql
SELECT GETDATE()
```

#### UNIX_TIMESTAMP()

```mysql
//是一条用于获取当前 Unix 时间戳的 SQL 查询语句，返回自 1970 年 1 月 1 日以来经过的秒数，常用于时间记录和计算
SELECT UNIX_TIMESTAMP();
```

![](Texture/UNIX_TIMESTAMP.png)

#### FROM_UNIXTIME(unix_timestamp)

```mysql
//用于将给定的 Unix 时间戳转换为可读的日期和时间格式
SELECT FROM_UNIXTIME(1599560172);
```

![](Texture/FROM_UNIXTIME.png)

> 说明：SQL Server中没有对应的函数

#### WEEK(date):返回当前是一年中的第几周

```mysql
SELECT WEEK(NOW());
```

![](Texture/WEEK.png)

> 说明：SQL Server中对应的函数是DATEPART

```mysql
SELECT DATEPART(WEEK,GETDATE())
```

#### YEAR(date):返回所给日期是哪一年

```
SELECT YEAR(NOW());
```

![](Texture/YEAR.png)

#### HOUR(time):返回当前时间的小时

```mysql
SELECT HOUR(NOW());
```

![](Texture/HOUR.png)

> 说明：SQL Server中对应的函数是DATEPART。

```mysql
SELECT DATEPART(HOUR,GETDATE())
```

#### MINUTE(time):返回当前时间的分钟

```mysql
SELECT MINUTE(NOW());
```

> 说明：SQL Server中对应的函数是DATEPART。

```mysql
SELECT DATEPART(MINUTE,GETDATE())
```

![](Texture/MINUTE.png)

#### DATE_FORMAT(date,format)

作用：用于以不同的格式显示日期/时间数据。

![](Texture/DATE_FORMAT1.png)

```mysql
SELECT DATE_FORMAT(NOW(),'%Y-%m-%d');
```

![](Texture/DATE_FORMAT2.png)

```mysql
SELECT DATE_FORMAT(NOW(),'%Y%m%d');
```

![](Texture/DATE_FORMAT3.png)

```mysql
SELECT DATE_FORMAT(NOW(),'%y%m%d');
```

![](Texture/DATE_FORMAT4.png)

> 说明：SQL Server中对应的函数是CONVERT。

```mysql
SELECT CONVERT(VARCHAR(10),GETDATE(),120)
SELECT CONVERT(VARCHAR(10),GETDATE(),112)
SELECT CONVERT(VARCHAR(10),GETDATE(),12)
```

#### DATE_ADD(date,INTERVAL expr unit)

作用：向日期添加指定的时间间隔。

![](Texture/DATE_ADD1.png)

```mysql
SELECT DATE_ADD(NOW(),INTERVAL 3 DAY);
```

![](Texture/DATE_ADD2.png)

```mysql
SELECT DATE_ADD(NOW(),INTERVAL 1 MONTH);
```

![](Texture/DATE_ADD3.png)

> 说明：SQL Server中对应的函数是DATEADD。

```mysql
SELECT DATEADD(DAY,3,GETDATE())
SELECT DATEADD(MONTH,1,GETDATE())
```

#### DATEDIFF(expr1,expr2)：返回两个日期之间的天数

```mysql
SELECT DATEDIFF('2020-06-06',NOW());
```

![](Texture/DATEDIFF.png)

说明：SQL Server中对应的函数是DATEDIFF，不过结果是相反的。

```mysql
SELECT DATEDIFF(DAY,'2020-06-06',GETDATE())
```

### 流程函数

#### IF(expr1,expr2,expr3)

作用：如果expr1是真，返回expr2，否则返回expr3。

```mysql
SELECT IF(2>3,TRUE,FALSE);
```

![](Texture/IF.png)

> 说明：SQL Server中对应的函数是IIF。

```mysql
SELECT IIF(2>3,1,0)
```

#### IFNULL(expr1,expr2)

作用：如果expr1不为空，返回expr1，否则返回expr2。

```mysql
SELECT IFNULL('abc','def');
```

![](Texture/IFNULL1.png)

```mysql
SELECT IFNULL(NULL,'def');
```

![](Texture/IFNULL2.png)

> 说明：SQL Server中对应的函数是ISNULL。

```mysql
SELECT ISNULL('abc','def')
SELECT ISNULL(NULL,'def')
```

#### CASE WHEN THEN END

作用：查询满足多种条件的情况。

```mysql
/*写法一*/
#用户变量，需使用@符号，也可以定义为SELECT @sex:='male';
SET @sex='male';
SELECT CASE @sex
    WHEN 'male' THEN
        '男'
    ELSE
        '女'
END AS '性别';

/*写法二*/
SET @score=90;
SELECT 
    CASE 
        WHEN @score BETWEEN 90 AND 100 THEN 'A+'
        WHEN @score BETWEEN 80 AND 89 THEN 'A'
        WHEN @score BETWEEN 60 AND 79 THEN 'B'
        ELSE 'C'
    END AS '评级';
```

![](Texture/CASE1.png)

![](Texture/CASE2.png)

![](Texture/CASE3.png)

![](Texture/CASE4.png)

### 其它常用函数

#### DATABASE():返回当前数据库名

```mysql
SELECT DATABASE();
```

说明：SQL Server中对应的函数是DB_NAME。

```mysql
--方法一
SELECT DB_NAME()
--方法二
SELECT NAME FROM MASTER..SYSDATABASES WHERE DBID=(SELECT DBID FROM MASTER..SYSPROCESSES WHERE SPID = @@SPID)
```

![](Texture/DATABASE.png)

#### VERSION():返回当前数据库版本

```mysql
SELECT VERSION();
```

![](Texture/VERSION.png)

#### USER():返回当前登录用户名

```mysql
SELECT USER();
```

![](Texture/USER.png)

> 说明：SQL Server中对应的函数是SUSER_NAME。

```mysql
SELECT SUSER_NAME()
```

#### hashed_password:返回str的PASSWORD加密值

```mysql
SHA-224: 使用 SHA2('abc', 224)，生成 224 位的哈希值。
SHA-384: 使用 SHA2('abc', 384)，生成 384 位的哈希值。
SHA-512: 使用 SHA2('abc', 512)，生成 512 位的哈希值。
SELECT SHA2('abc', 256) AS hashed_password;
```

![](Texture/hashed_password.png)

#### MD5(str):返回str的MD5值

```mysql
SELECT MD5('abc');
```

说明：SQL Server中对应的函数是HASHBYTES。

```mysql
SELECT HASHBYTES('MD5','abc')
```

![](Texture/MD5.png)

## 存储过程与自定义函数 

### 存储过程

#### delimiter

MySQL 中有一个命令是delimiter，作用是设置命令段的结束符号，即遇到这个所设置的结束符号后，按回车，则命令段就可以执行了。通常默认情况下，命令的结束符号是分号（;），但是在存储过程中，过程体内可能会包含分号（;），因此需要将命令结束符号替换成其他的字符，如$$、//等，存储过程创建完成后，可以将命令段的结束符号重新设为分号。

语法：delimiter 命令结束符

![](Texture/delimiter.png)

#### 存储过程示例

##### 创建

```mysql
DELIMITER $$

-- 创建一个存储过程
CREATE PROCEDURE SHOW_EMP02()
BEGIN
    SELECT * FROM STUDY11;
END$$

-- 恢复分隔符为默认的分号
DELIMITER ;
```

![](Texture/delimiter2.png)

##### 调用

```mysql
CALL SHOW_EMP02();
```

![](Texture/delimiter3.png)

#### 查看存储过程

##### 查看所有存储过程

```mysql
SHOW PROCEDURE STATUS;
```

![](Texture/STATUS1.png)

##### 查看指定数据库的存储过程

```mysql
SHOW PROCEDURE STATUS WHERE DB='study_db';
```

![](Texture/STATUS2.png)

##### 查看指定存储过程源代码

```mysql
SHOW CREATE PROCEDURE SHOW_EMP02;
```

![](Texture/STATUS3.png)

#### 删除存储过程

```mysql
DROP PROCEDURE SHOW_EMP01;
```

![](Texture/DROPPROCEDURE1.png)

![](Texture/DROPPROCEDURE2.png)

#### 声明变量

```mysql
DELIMITER $$
CREATE PROCEDURE SHOW_EMP03()
BEGIN
    #定义一个名为ROWS的整型变量，并将其默认值设置为 0
    DECLARE row_count  INT DEFAULT 0;    
    #计算STUDY11表中的行数，并将结果赋值给变量 ROWS。
    #COUNT(*)函数用于计算表中的总行数
    SELECT COUNT(*) INTO row_count  FROM STUDY11;
    #结果返回
    SELECT row_count  AS TotalRows;
END$$
DELIMITER ;
```

![](Texture/DECLARE.png)

![](Texture/DECLARE2.png)

#### 参数

##### IN：输入参数

```mysql
DELIMITER $$
#IN PNAME VARCHAR(12) 表示 PNAME 是一个输入参数，类型为 VARCHAR(12)。这表示该参数可以接收长度最多为 12 的字符串。
CREATE PROCEDURE GETSEX (IN PNAME VARCHAR(12))
BEGIN
    SELECT SEX FROM STUDY11 WHERE NAME=PNAME;
END$$
DELIMITER ;
```

![](Texture/IN1.png)

![](Texture/IN2.png)

![](Texture/IN3.png)

![](Texture/IN4.png)

##### OUT：输出参数

```mysql
DELIMITER $$
CREATE PROCEDURE GETID (IN PNAME VARCHAR(12),OUT PID INT)
BEGIN
    SELECT ID INTO PID FROM STUDY11 WHERE NAME=PNAME;
END$$
DELIMITER ;
```

![](Texture/OUT1.png)

```mysql
#使用 @ 符号来表示会话变量，这些变量可以在当前会话中被多个 SQL 语句访问和修改
CALL GETID ('study01',@PID);
```

![](Texture/OUT2.png)

##### INOUT：输入输出参数

在 MySQL 中，`INOUT` 是存储过程参数的一种类型，它允许参数在存储过程内被修改，并且这些修改会反映到调用存储过程的上下文中。具体来说，`INOUT` 参数既可以作为输入参数接收值，也可以作为输出参数返回修改后的值

```mysql
DELIMITER $$
CREATE PROCEDURE ADDINT (INOUT PNUM INT,IN PINC INT)
BEGIN
    SET PNUM=PNUM+PINC;
END$$
DELIMITER ;
```

![](Texture/INOUT.png)

### 自定义函数

```mysql
DROP FUNCTION IF EXISTS RAND_STR;
#如果开启了BIN-LOG，需要加上以下这句。
#在创建存储过程或函数时，如果 MySQL 的二进制日志（bin-log）功能开启，可能需要设置 LOG_BIN_TRUST_FUNCTION_CREATORS 为TRUE，以允许没有UPER权限的用户创建函数
SET GLOBAL LOG_BIN_TRUST_FUNCTION_CREATORS=TRUE;
#随机生成一个指定个数的字符串
DELIMITER $$
#创建一个名为RAND_STR的函数，该函数接受一个整数参数 PLEN，表示要生成的随机字符串的长度,返回字符串
CREATE FUNCTION RAND_STR (PLEN INT) RETURNS VARCHAR(255)
BEGIN
    #声明一个包含所有小写和大写字母的字符PSTR，用于生成随机字符
    DECLARE PSTR VARCHAR(100) DEFAULT 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    #声明一个计数器变量 I，用于记录已生成的字符数量
    DECLARE I INT DEFAULT 0;
    #生成结果
    DECLARE PRESULT VARCHAR(255) DEFAULT '';
    WHILE I<PLEN DO
        SET PRESULT=CONCAT(PRESULT,SUBSTRING(PSTR,CEILING(RAND()*52),1));
        SET I=I+1;
    END WHILE;
    #返回结果
    RETURN PRESULT;
END$$
DELIMITER ;
```

> 可以看出，自定义函数的参数，不像存储过程那样需要IN了。

!![](Texture/FUNCTION.png)

> 说明：MySQL的自定义函数，相当于SQL Server中的标量函数，当前版本尚未支持表值函数，这也是一大功能缺陷吧。当然，想返回一个表，可以使用存储过程的方式来实现

### 存储过程构建千万条数据

#### 创建表

```mysql
CREATE TABLE EMP (ID INT,NAME VARCHAR(50),AGE INT);
```

#### 通过存储过程调用自定义函数RAND_STR构建千万条数据：

```mysql
-- 删除存储过程
DROP PROCEDURE IF EXISTS INSERT_EMP;
#show PROCEDURE STATUS WHERE DB='study_db';
-- 创建存储过程
DELIMITER $$

CREATE PROCEDURE INSERT_EMP (IN startNum INT, IN maxNum INT)
BEGIN
    SET AUTOCOMMIT=0;  -- 关闭自动提交

    SET @i = startNum;  -- 初始化计数器为 startNum
    REPEAT
        SET @i = @i + 1;  -- 增加计数器
        INSERT INTO EMP (ID, `NAME`, AGE) VALUES (@i, RAND_STR(6), CEILING(18 + RAND() * 30));
    UNTIL @i >= maxNum  -- 设定循环结束条件
    END REPEAT;

    COMMIT;  -- 提交所有插入
END$$

DELIMITER ;  -- 恢复默认分隔符

-- 调用存储过程
CALL INSERT_EMP(0, 10);
```
![](Texture/构建千万条数据.png)

## 索引

### 索引分类

1. 单值索引：即一个索引只包含单个列，一个表可以有多个单列索引。
2. 唯一索引：索引列的值必须唯一，但允许有空值。
3. 复合索引：一个索引包含多个列，如INDEX MultiIdx(id,name,age)
4. 全文索引：只有在MyISAM引擎上才能使用，只能在CHAR、VARCHAR、TEXT类型字段上使用全文索引。
5. 空间索引：空间索引是对空间数据类型的字段建立的索引。

### 索引操作

#### 创建索引

语法：CREATE INDEX 索引名称 ON table (column[,column]...);

```mysql
CREATE INDEX ID_INDEX ON emp (ID);
CREATE INDEX NAME_INDEX ON emp (NAME);
```

#### 查看索引

语法：SHOW INDEX FROM 表名;

```mysql
SHOW INDEX FROM emp;
```

#### 删除索引

语法：DROP INDEX 索引名称 ON 表名;

```mysql
DROP INDEX NAME_INDEX ON emp;
```



![](Texture/CREATEINDEX1.png)

![](Texture/CREATEINDEX2.png)

![](Texture/CREATEINDEX3.png)

#### 自动创建索引

1. 在表上定义了主键时，会自动创建一个对应的唯一索引。
2. 在表上定义了一个外键时，会自动创建一个普通索引。

```mysql
CREATE TABLE emp (
    ID INT PRIMARY KEY,  -- 自动创建主键索引
    NAME VARCHAR(255),
    AGE INT,
    UNIQUE (NAME)  -- 自动创建唯一索引
);
```

```mysql
// dept_id 列作为外键会自动创建一个索引
CREATE TABLE department (
    dept_id INT PRIMARY KEY,
    dept_name VARCHAR(255)
);

CREATE TABLE emp (
    ID INT PRIMARY KEY,
    NAME VARCHAR(255),
    AGE INT,
    dept_id INT,
    FOREIGN KEY (dept_id) REFERENCES department(dept_id)  -- 自动创建外键索引
);
```

```mysql
#如果你已经有了一个表，并希望在某些列上自动创建索引，可以使用 ALTER TABLE 语句来添加索引
ALTER TABLE emp ADD INDEX idx_name (NAME);
```

### EXPLAIN

#### 关于EXPLAIN

作用：用来查看索引是否正在被使用，并且输出其使用的索引的信息。

#### EXPLAIN使用示例

```mysql
EXPLAIN SELECT * FROM emp WHERE ID = 5;
```

#### EXPLAIN输出信息

id：select查询的序列号，包含一组数字，表示查询中执行select子句或操作表的顺序。

select_type：所使用的SELECT查询类型。

![](Texture/EXPLAIN1.png)

![](Texture/EXPLAIN2.png)

- **table**：显示这一行的数据是关于哪张表的。
- **type**：type显示的是访问类型，是较为重要的一个指标，结果值从最好到最差依次是：system>const>eq_ref>ref<range>index>all（倒序）一般来说，保证查询至少达到range级别，最好能达到ref。
- **key**：实际使用的索引，若为null，则没有使用到索引。（两种可能，①没建立索引。②建立索引，但索引失效）。查询中若使用了覆盖索引，则该索引仅出现在key列表中。
- **possible_keys**：显示可能应用在这张表中的索引，一个或多个。查询涉及到的字段上若存在索引，则该索引将被列出，但不一定被查询实际使用。
- **key_len**：表示索引中使用的字节数，可通过该列计算查询中使用的索引的长度。在不损失精确型的情况下，长度越短越好，key_len显示的值为索引字段的最大可能长度，并非实际使用长度，即key_len是根据定义计算而得，不是通过表内检索出的。
- **ref**：显示索引的哪一列被使用了，如果可能的话，是一个常数，哪些列或者常量被用于查找索引列上的值。只有当type为ref的时候，ref这列才会有值。
- **rows**：根据表统计信息以及索引选用情况，大致估算出找到所需的记录所需要读取的行数，所以越小越好。可以用来查询sql的读取行数。
- **extra**：包含不适合在其它列中显示但十分重要的额外信息。

#### 哪些情况适合/需要创建索引

- 主键（自动建立唯一索引）
- 外键
- 查询中与其它表关联的字段
- 频繁作为查询条件的字段
- 查询中统计或者分组的字段
- 查询中排序的字段

#### 哪些情况不适合创建索引

- 频繁更新的字段，因为每次更新不单单更新了记录还会更新索引。
- WHERE条件里用不到的字段
- 表记录太少
- 经常增删改的表
- 如果某个数据列包含太多重复的内容（如性别，为它建立索引就没有太大的实际效果)。

## **游标/动态SQL/临时表/事务**

### 游标

#### 越界标志

在MySQL游标中，可以声明DECLARE CONTINUE HANDLER(declare continue handler)来操作1个越界标志。

语法：DECLARE CONTINUE HANDLER FOR NOT FOUND STATEMENT;

#### REPEAT方式

```mysql
DROP PROCEDURE if EXISTS CHANGESEX;
DELIMITER $$
CREATE PROCEDURE CHANGESEX() #创建应用程序
BEGIN
    DECLARE HAVE INT DEFAULT 1;#声明 int 类型Have，默认值是1
    DECLARE PID INT;#声明 int 类型 PID1
    
    DECLARE CURT CURSOR FOR SELECT ID FROM STUDY11;#声明一个名为 CURT 的游标，用于选择 STUDY11 表中的 ID 列
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET HAVE=0;#声明一个继续处理程序，当未找到结果时，将变量 HAVE 设置为 0
    OPEN CURT;
    FETCH CURT INTO PID;#将游标 CURT 当前行的值赋给变量 PID, 用于初始化 PID
    REPEAT
    	#在 STUDY11 表中，查找 ID 列等于 PID 的行，并根据 SEX 列的当前值进行更新。如果 SEX 是 '男'，则将其更新为 'MALE'；如果不是，则将其更新为 'FEMALE'
		SELECT PID;  -- 查看当前的 PID 值
        UPDATE STUDY11
        SET SEX= CASE SEX # CASE 根据不同的条件返回不同的值
        			WHEN '男' THEN 'MALE' 
        			ELSE 'FEMALE' 
        		END 
        WHERE ID=PID;
        FETCH CURT INTO PID; #用于在每次更新后获取下一行的 ID 值
    	UNTIL HAVE=0 
    END REPEAT;
    CLOSE CURT;
END$$
DELIMITER ;
CALL CHANGESEX();  -- 调用存储过程
```

![](Texture/REPEAT方式.png)

> 需要注意的是：MySQL不能像SQL Server那样，使用DEALLOCATE的方式释放游标资源

#### WHILE方式

```mysql
DELIMITER $$ #设置语句分隔符为 $$
CREATE PROCEDURE CHANGESEX1 () #创建存储过程 CHANGESEX1
BEGIN
    DECLARE HAVE INT DEFAULT 1;#声明一个int变量 HAVE，默认值为 1
    DECLARE PID INT;
    
    DECLARE CURT CURSOR FOR SELECT ID FROM STUDY11; #声明一个名为 CURT 的游标，用于选择 STUDY11 表中的 ID 列
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET HAVE=0;#声明一个继续处理程序，当未找到结果时，将变量 HAVE 设置为 0
    OPEN CURT;#打开游标
    FETCH CURT INTO PID;#初始化 PID给CURT赋值
    WHILE HAVE=1 DO #当 HAVE 的值为 1 时，进入循环，（默认值为1，能够正确处理每一行数据）
    	#ID 列等于 PID时，根据 SEX 列的当前值更新性别
        UPDATE STUDY11 SET SEX=CASE SEX WHEN '男' THEN 'MALE' ELSE 'FEMALE' END WHERE ID=PID;
        FETCH CURT INTO PID;
    END WHILE;#结束循环
    CLOSE CURT;#关闭游标
END$$ # 结束存储过程
DELIMITER ;#恢复默认的语句分隔符

CALL CHANGESEX1();
```

![](Texture/WHILE方式.png)

### 动态SQL

#### 动态SQL格式

```mysql
SET SQL= (预处理的SQL语句，可以使用CONCAT拼接的语句，参数用 ？代替 。);
SET @SQL=SQL;
PREPARE STMT_NAME FROM @SQL;
SET @VAR_NAME=XXX;
EXECUTE STMT_NAME [USING @VAR_NAME[,@VAR_NAME]...];
{DEALLOCATE | DROP} PREPARE STMT_NAME;
```

#### 动态SQL示例

```mysql
DELIMITER $$
CREATE PROCEDURE GETNAME (IN PID INT)
BEGIN
    #定义预处理SQL语句
    DECLARE STRSQL VARCHAR(1000);
    #拼接SQL语句
    SET STRSQL="SELECT NAME FROM EMP WHERE ID=?";
    #将自定义变量赋值给用户变量.
    SET @SQL=STRSQL;
    #预处理动态SQL语句.将存储在用户变量 @SQL 中的 SQL 查询字符串编译成一个可执行的预处理语句，并将其命名为 STMT
    PREPARE STMT FROM @SQL;
    #传递动态SQL参数
    SET @PARAM1=PID;    
    #执行动态SQL语句
    EXECUTE STMT USING @PARAM1;
    #释放PREPARE
    DEALLOCATE PREPARE STMT;
END$$
DELIMITER ;

CALL GETNAME(5);
```

![](Texture/动态SQL示例.png)

可以看出，MySQL动态SQL支持""。

#### 动态SQL注意事项

1. 存储动态SQL的值的变量不能是自定义变量，必须是用户变量或者全局变量 。如：SET SQL='XXX';PREPARE STMT FROM SQL;都是错误的写法，正确的写法为：SET @SQL='XXX';PREPARE STMT FROM @SQL; 
2. 即使PREPARABLE_STMT语句中的 ? 所代表的是一个字符串，也不需要用引号将 ? 两边包起来。
3. 如果动态语句中用到了 IN ，则SQL语句可以写成：SET STRSQL="SELECT NAME FROM EMP WHERE ID IN (?,?,?)";

```mysql
-- 错误的写法
SET SQL = 'SELECT NAME FROM EMP WHERE ID = ?';  -- 这是错误的，因为 SQL 是自定义变量
PREPARE STMT FROM SQL;  -- 这也会出错

-- 正确的写法
SET @SQL = 'SELECT NAME FROM EMP WHERE ID = ?';  -- 使用用户变量 @SQL
PREPARE STMT FROM @SQL;  -- 这是正确的
```

```mysql
SET @SQL = 'SELECT NAME FROM EMP WHERE ID = ?';  -- 正确的写法
PREPARE STMT FROM @SQL;  -- 预处理语句

SET @PARAM1 = 5;  -- 假设我们要查询 ID 为 5 的员工
EXECUTE STMT USING @PARAM1;  -- 执行预处理语句，使用 @PARAM1 作为参数

#如果你写成 SET @SQL = 'SELECT NAME FROM EMP WHERE ID = '?'，这将导致 SQL 语法错误，因为 ? 被视为字符串，而不是占位符
```

```mysql
SET @SQL = 'SELECT NAME FROM EMP WHERE ID IN (?, ?, ?)';  -- 使用 IN 子句，包含多个占位符
PREPARE STMT FROM @SQL;  -- 预处理语句

-- 假设我们要查询 ID 为 1, 2, 3 的员工
SET @PARAM1 = 1;
SET @PARAM2 = 2;
SET @PARAM3 = 3;

EXECUTE STMT USING @PARAM1, @PARAM2, @PARAM3;  -- 执行预处理语句，传递多个参数
```

### 临时表

#### 临时表创建

```mysql
CREATE TEMPORARY TABLE `emp_t1` (
    `ID` int(11) DEFAULT NULL,
    `NAME` varchar(50) DEFAULT NULL,
    `AGE` int(11) DEFAULT NULL,
    KEY `ID_INDEX` (`ID`)
)
ENGINE=InnoDB DEFAULT CHARSET=utf8 #ENGINE=InnoDB 使用 InnoDB 存储引擎
```

```mysql
#创建了一个临时表 emp_t2，并将 EMP 表中 ID 小于或等于 10 的所有行复制到这个临时表中
CREATE TEMPORARY TABLE emp_t2 SELECT * FROM EMP WHERE ID<=10;
```

> 可以看出，MySQL并不支持像SQL Server那样使用SELECT * INTO #EMP FROM EMP的方式来创建临时表。

#### 临时表删除

```mysql
DROP TABLE EMP_T1,EMP_T2;
```

#### 临时表测试（存储过程）

```mysql
DROP PROCEDURE IF EXISTS TempTest1;

DELIMITER $$
CREATE PROCEDURE TempTest1 ()
BEGIN
    #临时表创建方式一测试
    CREATE TEMPORARY TABLE `emp_t1` (
        `ID` int(11) DEFAULT NULL,
        `NAME` varchar(50) DEFAULT NULL,
        `AGE` int(11) DEFAULT NULL,
        KEY `ID_INDEX` (`ID`)
    ) ENGINE=InnoDB DEFAULT CHARSET=utf8;
    
    INSERT INTO EMP_T1 SELECT * FROM EMP LIMIT 10;
    
    #临时表创建方式二测试
    CREATE TEMPORARY TABLE emp_t2 SELECT * FROM EMP WHERE ID<=10;
    
    #结果返回
    #UNION 操作符用于合并两个或多个 SELECT 查询的结果集
    #从两个表 EMP_T1 和 EMP_T2 中选择所有行，并将它们合并成一个结果集
    SELECT * FROM EMP_T1 UNION SELECT * FROM EMP_T2;
    
    #临时表删除
    DROP TABLE EMP_T1,EMP_T2;
END$$
DELIMITER ;

CALL TempTest1 ();
```

![](Texture/临时表测试.png)

#### 自定义函数能使用临时表吗

不可以！自定义函数不支持创建表，不管是正常表还是临时表。（SQL Server自定义函数，也不支持临时表，但是支持表变量。）

### 事务

#### 基础概念

事务（Transaction）是访问和更新数据库的程序执行单元；事务中可能包含一个或多个sql语句，这些语句要么都执行，要么都不执行。

#### MySQL逻辑架构与存储引擎

![](Texture/MySQL逻辑架构与存储引擎.png)

如上图所示，MySQL逻辑架构从上往下可以分为三层：

- 第一层：处理客户端连接、授权认证等。
- 第二层：服务器层，负责查询语句的解析、优化、缓存以及内置函数的实现、存储过程等。
- 第三层：存储引擎，负责MySQL中数据的存储和提取。

说明1：MySQL中服务器层不管理事务，事务是由存储引擎实现的。

说明2：MySQL支持事务的存储引擎有InnoDB、NDB Cluster等，其中InnoDB的使用最为广泛；其他存储引擎不支持事务，如MyIsam、Memory等。

#### 事务控制语句

1. BEGIN 或 START TRANSACTION 显式地开启一个事务；
2. COMMIT 也可以使用 COMMIT WORK，不过二者是等价的。COMMIT 会提交事务，并使已对数据库进行的所有修改成为永久性的；
3. ROLLBACK 也可以使用 ROLLBACK WORK，不过二者是等价的。回滚会结束用户的事务，并撤销正在进行的所有未提交的修改；
4. SAVEPOINT identifier，SAVEPOINT 允许在事务中创建一个保存点，一个事务中可以有多个 SAVEPOINT；
5. RELEASE SAVEPOINT identifier 删除一个事务的保存点，当没有指定的保存点时，执行该语句会抛出一个异常；
6. ROLLBACK TO identifier 把事务回滚到标记点；
7. SET TRANSACTION 用来设置事务的隔离级别。InnoDB 存储引擎提供事务的隔离级别有READ UNCOMMITTED、READ COMMITTED、REPEATABLE READ 和 SERIALIZABLE。

#### 事务提交模式

SET AUTOCOMMIT=1 开启自动提交

SET AUTOCOMMIT=0 禁止自动提交

默认是开启自动提交，可以使用以下命令查询：

```mysql
SHOW VARIABLES LIKE 'AUTOCOMMIT';
```

#### 事务示例

##### 无判断语句事务

```mysql
SHOW PROCEDURE STATUS WHERE Name = 'TranTest1';
DROP PROCEDURE IF EXISTS TranTest1;

DELIMITER $$
CREATE PROCEDURE TranTest1()
BEGIN
    #创建一个名为 EMP_T1 的临时表，并从 EMP 表中选择数据。
    #具体来说，WHERE 1=2 是一个永远为假的条件，
    #因此这条语句将创建一个结构与 EMP 表相同但不包含任何数据的临时表
    CREATE TEMPORARY TABLE EMP_T1 SELECT * FROM EMP WHERE 1=2;
    #开启事务
    START TRANSACTION;
    
    #数据插入
    INSERT INTO EMP_T1 VALUES (1,'HELLO',18);
    INSERT INTO EMP_T1 VALUES (2,'WORLD',19);
    
    #提交事务
    COMMIT;
    
    #结果返回
    SELECT * FROM EMP_T1;
    
    #临时表删除
    DROP TABLE EMP_T1;
END$$
DELIMITER ;

CALL TranTest1();
```

![](Texture/TranTest1.png)

##### 有判断语句事务（推荐）

```mysql
Drop PROCEDURE IF EXISTS TranTest2;
DELIMITER $$
CREATE PROCEDURE TranTest2()
BEGIN
    #判断事务是否异常的错误变量
    DECLARE PERROR INT DEFAULT 0;
		#声明一个异常处理程序。当发生 SQL 异常时（如插入失败），将执行 SET PERROR=1;，
		#将 PERROR 设置为 1，表示发生了错误。使用 CONTINUE 表示即使发生异常，存储过程仍将继续执行后续语句
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION SET PERROR=1;

    #临时表创建
    CREATE TEMPORARY TABLE EMP_T1 SELECT * FROM EMP WHERE 1=2;
    
    #开启事务
    START TRANSACTION;

    #数据插入
    INSERT INTO EMP_T1 VALUES (1,'HELLO',18);
    INSERT INTO EMP_T1 VALUES (2,'WORLD',19);
    
    #提交事务
    IF (PERROR=0) THEN #如果 PERROR 为 0（表示没有发生错误），则执行 COMMIT;，提交事务，保存对 EMP_T1 的更改。
        COMMIT;
    ELSE #如果 PERROR 不为 0（表示发生了错误），则执行 ROLLBACK;，回滚事务，撤销对 EMP_T1 的更改
        ROLLBACK;
    END IF;
    
    #结果返回
    SELECT * FROM EMP_T1;
    
    #临时表删除
    DROP TABLE EMP_T1;
END$$
DELIMITER ;

CALL TranTest2();
```

![](Texture/TranTest2_1.png)

![](Texture/TranTest2_2.png)

> 说明：SQL Server中事务执行是否有报错，可以使用@@ERROR来判断，@@ERROR=0代表无报错

## **触发器**

### 触发器概念

触发器是与表有关的数据库对象，在满足定义条件时触发，并执行触发器中定义的语句集合。

### 触发器创建

#### 创建语法

```mysql
CREATE [DEFINER = { 'user' | CURRENT_USER }]　
TRIGGER trigger_name
trigger_time trigger_event
ON table_name
FOR EACH ROW
[trigger_order]
trigger_body
```

#### 创建语法关键词解释

![](Texture/TRIGGER.png)

#### 触发执行内容OLD与NEW

OLD：表示将要删除的旧行（类似于SQL Server中的DELETED表，只不过前者是行记录，后者是表）。

NEW：表示将要插入的新行（类似于SQL Server中的INSERTED表，只不过前者是行记录，后者是表）。

注：因为是单行记录，可以将它们理解为面向对象语言中的对象，直接通过`OLD.字段名`和`NEW.字段名`来使用。

事件与OLD、NEW的对应关系：

|  事件  | OLD  | NEW  |
| :----: | :--: | :--: |
| INSERT |  ×   |  √   |
| DELETE |  √   |  ×   |
| UPDATE |  √   |  √   |

由上可见，更新一条记录，实际上是先将原记录删除（临时保存在OLD中），再插入一条新的记录（临时保存在NEW中）。

### 触发器示例

#### 触发自身表

1. 需求描述：假设有个员工表，如果新入职人员（INSERT）的年龄小于18岁时，自动将其更新为18岁。

2. 测试表创建：

   ```mysql
   DROP TABLE IF EXISTS EMP1;
   CREATE TABLE `emp1` (
       `ID` int(11) DEFAULT NULL,
       `NAME` varchar(50) DEFAULT NULL,
       `AGE` int(11) DEFAULT NULL,
       KEY `ID_INDEX` (`ID`)
   ) ENGINE=InnoDB DEFAULT CHARSET=utf8
   ```

3. 触发器创建：

   ```mysql
   #当年龄小于18岁时自动更新为18岁
   DELIMITER $$
   DROP TRIGGER IF EXISTS triEmp1ForInsert$$
   #定义一个名为 triEmp1ForInsert 的触发器
   #触发时机: BEFORE INSERT 表示该触发器在向 EMP1 表插入新记录之前触发
   #作用范围: FOR EACH ROW 表示触发器会对每一行插入操作执行一次。
   CREATE TRIGGER triEmp1ForInsert BEFORE INSERT ON EMP1 FOR EACH ROW
   BEGIN
       IF (NEW.AGE<18) THEN
           SET NEW.AGE=18;
       END IF;
   END$$
   DELIMITER ;
   ```

4. 数据插入：

   ```mysql
   INSERT INTO EMP1 VALUES (1,'HELLO',17);
   ```

5. 结果查询：

   ```mysql
   SELECT * FROM EMP1;
   ```

   ![](Texture/触发自身表.png)

6. 注意事项：

   需要注意的是，MySQL触发器不允许对自身表进行更新，但是允许更新NEW。

   因此，上面的需求假如想通过AFTER INSERT来更改EMP1表，是行不通的。

   下面进行错误的演示：

   ```mysql
   #错误的演示
   DELIMITER $$
   DROP TRIGGER IF EXISTS triEmp1ForInsert$$
   CREATE TRIGGER triEmp1ForInsert AFTER INSERT ON EMP1 FOR EACH ROW
   BEGIN
       IF (NEW.AGE<18) THEN
           UPDATE EMP1 SET AGE=18 WHERE ID=NEW.ID;
       END IF;
   END$$
   DELIMITER ;
   ```

#### 触发其它表

1. 需求描述

   假设有两个表结构一样的表EMP1和EMP2，如果EMP1有新记录插入时而EMP2还没有，则将新记录也插入到EMP2中。

2. 测试表创建

   ```mysql
   DROP TABLE IF EXISTS EMP1;
   CREATE TABLE `emp1` (
       `ID` int(11) DEFAULT NULL,
       `NAME` varchar(50) DEFAULT NULL,
       `AGE` int(11) DEFAULT NULL,
       KEY `ID_INDEX` (`ID`)
   ) ENGINE=InnoDB DEFAULT CHARSET=utf8
   #上下分开执行
   DROP TABLE IF EXISTS EMP2;
   CREATE TABLE `emp2` (
       `ID` int(11) DEFAULT NULL,
       `NAME` varchar(50) DEFAULT NULL,
       `AGE` int(11) DEFAULT NULL,
       KEY `ID_INDEX` (`ID`)
   ) ENGINE=InnoDB DEFAULT CHARSET=utf8
   ```

3. 触发器创建

   ```mysql
   #EMP1插入新记录而EMP2没有时，将新记录也插入到EMP2中。
   DELIMITER $$
   DROP TRIGGER IF EXISTS triEmp1ForInsert$$
   CREATE TRIGGER triEmp1ForInsert AFTER INSERT ON EMP1 FOR EACH ROW
   BEGIN
   	#检查 EMP2 表中是否存在与新插入记录相同的 ID
       IF NOT EXISTS (SELECT * FROM EMP2 WHERE ID=NEW.ID) THEN
           INSERT INTO EMP2 (ID,`NAME`,AGE) VALUES (NEW.ID,NEW.NAME,NEW.AGE);
       END IF;
   END$$
   DELIMITER ;
   ```

4. 数据插入

   ```mysql
   INSERT INTO EMP1 VALUES (1,'HELLO',18);
   ```

5. 结果查询

   ```mysql
   SELECT * FROM EMP2;
   ```

   ![](Texture/触发其他表.png)

### 触发器查看

```mysql
#查看当前数据库所有触发器
SHOW TRIGGERS;
 
#查看指定数据库所有触发器
SHOW TRIGGERS FROM TEST;

#查看指定数据库指定表所有触发器
SELECT * FROM INFORMATION_SCHEMA.TRIGGERS WHERE EVENT_OBJECT_SCHEMA='study_db' AND EVENT_OBJECT_TABLE='EMP1';
```

### 触发器删除

```mysql
#直接删除触发器
DROP TRIGGER triEmp1ForInsert;

#先检查再删除触发器
DROP TRIGGER IF EXISTS triEmp1ForInsert;
```



![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)

![](Texture/.png)