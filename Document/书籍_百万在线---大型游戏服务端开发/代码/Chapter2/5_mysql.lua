local skynet = require "skynet"
local mysql = require "skynet.db.mysql"

skynet.start(function()
    --����
    local db=mysql.connect({
        host="39.100.116.101",
        port=3306,
        database="message_board",
        user="root",
        password="7a77-788b889aB",
        max_packet_size = 1024 * 1024,
        on_connect = nil
    })
    --����
    local res = db:query("insert into msgs (text) values (\'hehe\')")
    --��ѯ
    res = db:query("select * from msgs")
    --��ӡ
    for i,v in pairs(res) do
        print ( i," ",v.id, " ",v.text)
    end
end)