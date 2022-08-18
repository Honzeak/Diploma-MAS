using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UDP_Budiky_Modern : MonoBehaviour
{
    public UDP_Receiver UDP;
    public string Message;
    [Header("Dashboard")]
    public GameObject Dashboard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Translate()
    {
        try
        {
            Message = UDP.RecieveMesage;
        }
        catch
        {
            Debug.Log("Error with translate message");
        }
    }

    public void Vizualizate()
    {
        Dashboard.transform.GetChild(0).GetComponent<Text>().text = Mathf.Round(float.Parse(UDP.RecieveMesage.Split(';')[0])).ToString();
        Dashboard.transform.GetChild(1).GetComponent<Text>().text = (Mathf.Round(float.Parse(UDP.RecieveMesage.Split(';')[2])*500)).ToString()+" km";
        Dashboard.transform.GetChild(2).GetComponent<Text>().text = System.DateTime.Now.ToString("HH:mm");


    }
    // Update is called once per frame
    void Update()
    {
        Translate();
        Vizualizate();
    }
}
