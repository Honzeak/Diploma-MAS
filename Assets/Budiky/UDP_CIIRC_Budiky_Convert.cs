using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class UDP_CIIRC_Budiky_Convert : MonoBehaviour
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
        Dashboard.transform.GetChild(0).GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -60 - float.Parse(UDP.RecieveMesage.Split(';')[0]));
        Dashboard.transform.GetChild(1).GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -60 - float.Parse(UDP.RecieveMesage.Split(';')[1])/3000*120);
        Dashboard.transform.GetChild(2).GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -60 - float.Parse(UDP.RecieveMesage.Split(';')[2])  * 240);
        Dashboard.transform.GetChild(3).GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, -60 - float.Parse(UDP.RecieveMesage.Split(';')[3]) /3*4);
    }
    // Update is called once per frame
    void Update()
    {
        Translate();
        Vizualizate();
    }
}
