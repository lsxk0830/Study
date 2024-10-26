var net = require('net');

class Role{
    constructor() {
        this.x = 0;
        this.y = 0;
    }
}

var roles = new Map();

var server = net.createServer(function(socket){
    //������
    roles.set(socket, new Role())

    //���յ�����
    socket.on('data', function(data){
        var role = roles.get(socket);
        var cmd = String(data);
        //����λ��
        if(cmd == "left\r\n") role.x--;
        else if(cmd == "right\r\n") role.x++;
        else if(cmd == "up\r\n") role.y--;
        else if(cmd == "down\r\n") role.y++;

        //�㲥
        for (let s of roles.keys()) {
            var id = socket.remotePort;
            var str = id + " move to " + role.x + " " + role.y + "\n";
            s.write(str);
        }
    });

    //�Ͽ�����
    socket.on('close',function(){
        roles.delete(socket)
    });
});

server.listen(8001);