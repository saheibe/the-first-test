# 记一次RabbitMq 安装和配置坑

## 正常情况下安装
先安装erl ，在安装rabbitmq 这个在windows下的安装没什么技巧，按照默认一路下一步就ok。安装好后可以到cmd测试是否安装好。
+ 测试**erl**： `D:\Program Files\erl3.9\bin>erl`
+ 测试**RabbitMq**：`D:\Program Files\RabbitMQ Server\rabbitmq_server-3.5.6\sbin>rabbitmq-service`

最后看端口开启情况，在cmd输入`netstat -ano|findstr 5672` 。默认rabbmit的服务端口是5672 ，如果是开启状态说明安装好了。

配置文件不在安装目录下面，而是在`C:\Users\Administrator\AppData\Roaming\RabbitMQ`,其实不单单配置文件的默认地址在这里，数据文件，日志文件的地址也在这里。

## 出现异常
### 关键字Unable to register service with service manager. Error: Access is denied.
权限的问题，需要用管理员权限安装运行。
### init terminating in do_boot ({error,previous_upgrade_failed})
碰到这个错误，尝试了很多方法，最后还是通过删除 rabbitmq 数据库解决的 。




1. https://my.oschina.net/ydsakyclguozi/blog/528835
2. https://github.com/rabbitmq/rabbitmq-server/issues/257
3. https://groups.google.com/forum/#!topic/rabbitmq-users/ZH8pzxA_c48
