using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class UDP_Receiver : MonoBehaviour
{
    [Header("UDP")]
    public int port;
    public IPEndPoint sender;
    private Thread receiveThread;
    private UdpClient client;
    private byte[] receivedData;

    [Header("Recieve Mesage")]
    public string RecieveMesage;

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
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref ipep);
                RecieveMesage = Encoding.ASCII.GetString(data);
                //Debug.Log(RecieveMesage);
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
