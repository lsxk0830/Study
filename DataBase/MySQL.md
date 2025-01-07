## 二、修改Root密码

假如需要把Root密码改成"123456"，操作命令如下：

```c#
use mysql;
ALTER USER 'root'@'localhost' IDENTIFIED BY '123456';
flush privileges;
```
![修改Root密码](Texture/修改Root密码.png)

