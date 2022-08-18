using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDP_Sender : MonoBehaviour
{
    [Header("SendContinual")]
    public bool SendUpdate;
    [Header("UDP")]
    public int port;
    public string IP;
    public IPEndPoint sender;
    private Thread receiveThread;
    private UdpClient client;
    private byte[] sendData;

    [Header("SendText")]
    public string SendText;

    public void Inicializace()
    {

        sender = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();
    }

    private void SendData()
    {
        try
        {


            byte[] data = Encoding.ASCII.GetBytes(SendText);
            client.Send(data, data.Length, sender);
        }
        catch 
        {
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Inicializace();
    }
    private void Update()
    {
        if(SendUpdate==true)
        {
            SendData();
        }
    }


    private void OnApplicationQuit()
    {
        client.Close();
    }
}
