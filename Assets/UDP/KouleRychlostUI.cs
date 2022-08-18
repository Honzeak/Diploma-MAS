using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KouleRychlostUI : MonoBehaviour
{
    public UDP_Receiver UDPReceiver;
    public string ReceiveText;
    public float speed;
    public float height;

    [Header("Vizualizace")]
    public Text speedInput;
    public Slider heightInput;

    // Update is called once per frame
    void Update()
    {
        ReceiveText = UDPReceiver.RecieveMesage;
        string[] mesageParts = ReceiveText.Split(';');
        speed = float.Parse(mesageParts[0]);
        height = float.Parse(mesageParts[1]);

        //Vizualizace
        speedInput.text = speed.ToString();
        heightInput.value = height;
    }
}
