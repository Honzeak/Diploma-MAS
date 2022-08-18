using NWH.VehiclePhysics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDP_Budiky_CIIRC : MonoBehaviour
{
    public UDP_Sender UDP;
    public VehicleController VC;
    public string Message;


    // Update is called once per frame
    void Update()
    {
        Message=VC.SpeedKPH.ToString() + ";" + VC.engine.RPM.ToString() + ";" + (VC.fuel.amount/VC.fuel.capacity).ToString() +";87" ;
        UDP.SendText = Message;
    }
}
