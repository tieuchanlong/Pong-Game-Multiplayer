using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class Server 
{
    public static int MaxPlayer { get; private set; }
    public static int Port { get; private set; }

    private static TcpListener tcpListener;

}
