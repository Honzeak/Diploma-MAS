using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KouleRychlostSend : MonoBehaviour
{
    public UDP_Sender UDPSender;
    public GameObject Koule;
    public float speed;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        speed = Koule.GetComponent<Rigidbody>().velocity.magnitude;
        UDPSender.SendText = speed.ToString()+";"+Koule.transform.position.y.ToString();
    }
}
