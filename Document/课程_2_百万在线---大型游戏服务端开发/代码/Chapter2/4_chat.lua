local skynet = require "skynet"
local socket = require "skynet.socket"

local clients = {}

function connect(fd, addr)
    --��������
    print(fd.." connected addr:"..addr)
    socket.start(fd)
    clients[fd] = {}
    --��Ϣ����
    while true do
        local readdata = socket.read(fd)
        --��������
        if readdata ~= nil then
            print(fd.." recv "..readdata)
            for i, _ in pairs(clients) do --�㲥
                socket.write(i, readdata)
            end
        --�Ͽ�����
        else
            print(fd.." close ")
            socket.close(fd)
            clients[fd] = nil
        end
    end
end
    
skynet.start(function()
    local listenfd = socket.listen("0.0.0.0", 8888)
    socket.start(listenfd ,connect)
end)