local skynet = require "skynet"
local socket = require "skynet.socket"

function connect(fd, addr)
    --��������
    print(fd.." connected addr:"..addr)
    socket.start(fd)
    --��Ϣ����
    while true do
        local readdata = socket.read(fd)
        --��������
        if readdata ~= nil then
            print(fd.." recv "..readdata)
            socket.write(fd, readdata)
        --�Ͽ�����
        else
            print(fd.." close ")
            socket.close(fd)
        end
    end
end
    
skynet.start(function()
    local listenfd = socket.listen("0.0.0.0", 8888)
    socket.start(listenfd ,connect)
end)