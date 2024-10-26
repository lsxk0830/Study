var net = require('net');

var server = net.createServer(function(socket){
    console.log('connected, port:' + socket.remotePort);

    //���յ�����
    socket.on('data', function(data){
        console.log('client send:' + data);
        var ret = "����," + data;
        socket.write(ret);
    });

    //�Ͽ�����
    socket.on('close',function(){
        console.log('closed, port:' + socket.remotePort);
    });
});
server.listen(8001);