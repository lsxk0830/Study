## 二、修改Root密码

假如需要把Root密码改成"123456"，操作命令如下：

```
use mysql;
ALTER USER 'root'@'localhost' IDENTIFIED BY '123456';
flush privileges;
```
![输入图片说明](Texture/%E4%BF%AE%E6%94%B9Root%E5%AF%86%E7%A0%81.png)

