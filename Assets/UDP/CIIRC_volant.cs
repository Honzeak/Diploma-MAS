using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class CIIRC_volant: MonoBehaviour
{
    [Header("UDP")]
    public int port;
    public IPEndPoint sender;
    private Thread receiveThread;
    private UdpClient client;
    private byte[] receivedData;
    public byte[] bytes;
    [Header("Receive Mesage")]
    public float steer;
    public string ReceiveMesage;

    public void Start()
    {
        
        Inicializace();

    }

    public void Inicializace()
    {
        receiveThread = new Thread(new ThreadStart(ReceiveDataUDP));
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    public void ReceiveDataUDP()
    {
        
        client = new UdpClient(6501);
        while (true)
        {
            try
            {

                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 6501);
                steer = BitConverter.ToSingle(client.Receive(ref ipep), 5);
                //byte data = client.Receive(ref ipep)[0];
                Debug.Log("SUPER");
            }
            catch
            {
                Debug.Log("ErrorToReceive");
            }
        }
    }


    private void OnApplicationQuit()
    {
        receiveThread.Abort();
        client.Close();
    }


}
