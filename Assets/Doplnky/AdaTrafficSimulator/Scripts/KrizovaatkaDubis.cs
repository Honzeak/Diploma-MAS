using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class KrizovaatkaDubis : MonoBehaviour
{
    public GameObject[] SemaforHlavni;
    public GameObject[] SemaforPesi;
    public ATS_VehicleManager ATS;
    public bool PlayAnimation=false;
    public VW_Dashboard_control Dashboard;

    [Header("Stav Semafor")]
    public bool cervena=true;
    public bool zluta=false;
    public bool zelena=false;
    public float waitTime;
    public float offsetrozjezd=3;
    public float helptime;

    private void Start()
    {
        SetCervena();
    }
    public void SetAnimation()
    {
        PlayAnimation = true;
        waitTime = 5 + Random.Range(1, 15);
    }
    public void SetCervena()
    {
        cervena = true;
        zluta = false;
        zelena = false;
        foreach (GameObject go in SemaforHlavni)
        {
            go.transform.GetChild(0).gameObject.SetActive(true);
            go.transform.GetChild(1).gameObject.SetActive(false);
            go.transform.GetChild(2).gameObject.SetActive(false);
        }
        foreach (GameObject go in SemaforPesi)
        {
            go.transform.GetChild(0).gameObject.SetActive(true);
            go.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void SetZluta()
    {
        cervena = false;
        zluta = true;
        zelena = false;
        foreach (GameObject go in SemaforHlavni)
        {
            go.transform.GetChild(0).gameObject.SetActive(false);
            go.transform.GetChild(1).gameObject.SetActive(true);
            go.transform.GetChild(2).gameObject.SetActive(false);
        }
        Dashboard.SemaforZluta();
    }

    public void SetZelena()
    {
        cervena = false;
        zluta = false;
        zelena = true;
        foreach (GameObject go in SemaforHlavni)
        {
            go.transform.GetChild(0).gameObject.SetActive(false);
            go.transform.GetChild(1).gameObject.SetActive(false);
            go.transform.GetChild(2).gameObject.SetActive(true);
        }
        foreach (GameObject go in SemaforPesi)
        {
            go.transform.GetChild(0).gameObject.SetActive(false);
            go.transform.GetChild(1).gameObject.SetActive(true);
        }
        Dashboard.SemaforZelena();
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayAnimation==true)
        {
            helptime += Time.deltaTime;
            if(helptime>waitTime)
            {
                if(zluta==false)
                {
                    SetZluta();
                }
                if(helptime>waitTime+2)
                {
                    if (zelena == false)
                    {
                        SetZelena();
                    }
                    if (helptime>waitTime+2+offsetrozjezd)
                    {
                        ATS.PlayAnimation = true;
                        PlayAnimation = false;
                    }
                }
            }
           
        }
        
    }
}
