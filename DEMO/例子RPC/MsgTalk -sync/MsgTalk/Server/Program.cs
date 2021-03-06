﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZYSocket.RPCX.Service;
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            LogAction.LogOut += LogAction_LogOut;
            RPCServer server = new RPCServer("127.0.0.1", 3000, 4000, 1024 * 64,1024*1024);
            server.RegServiceModule(new TalkService());         
            server.IsUseTask = true; //如果不搞 client call-->Server call(not return)--->client， 并且是同步访问的 就不要设置为TRUE 否则会浪费CPU
            server.IsCallReturn = true; //服务器是否允许调用客户端同步等待函数
            server.Start();
            Console.ReadLine();


        }

        private static void LogAction_LogOut(string msg, LogType type)
        {
            Console.WriteLine(msg);
        }
    }
}
