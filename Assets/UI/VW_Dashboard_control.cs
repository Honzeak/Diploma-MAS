using NWH.VehiclePhysics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VW_Dashboard_control : MonoBehaviour
{
    public  enum Smer {None, Yrovne, Yodbocka, YLrovne, YLodbocka, Vrovne, Vodbocka,DalniceV}
    public Smer NavSmer = new Smer();

    public VehicleController VC;
    public GameObject Dashboard;
    public Sprite[] Znacky;
    public Sprite[] NavigaceBackground;
    public Sprite[] NavigaceSmer;

    [Header("Target")]
    public float Distance;
    public GameObject Target;
    public string NavText;

    [Header("Semafor")]
    public GameObject Semafor;

    public void SemaforOn()
    {
        Semafor.SetActive(true);

    }

    public void SemaforOff()
    {
        Semafor.SetActive(false);
    }

    public void SemaforCervena()
    {
        Semafor.transform.GetChild(0).gameObject.SetActive(true);
        Semafor.transform.GetChild(1).gameObject.SetActive(false);
        Semafor.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void SemaforZluta()
    {
        Semafor.transform.GetChild(0).gameObject.SetActive(true);
        Semafor.transform.GetChild(1).gameObject.SetActive(true);
        Semafor.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void SemaforZelena()
    {
        Semafor.transform.GetChild(0).gameObject.SetActive(false);
        Semafor.transform.GetChild(1).gameObject.SetActive(false);
        Semafor.transform.GetChild(2).gameObject.SetActive(true);
    }
    private void Start()
    {
        SetNavigace(Smer.None);
        SetText(NavText
            );
    }
    public void SetText(string text)
    {
        Dashboard.transform.GetChild(1).GetChild(2).GetComponent<Text>().text = text;

    }
    public void SetNavigace(Smer smer)
    {
        if(smer==Smer.None)
        {
            Dashboard.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            Dashboard.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
        }
        else if(smer==Smer.Vodbocka)
        {
            Dashboard.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite=NavigaceBackground[0];
            Dashboard.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = NavigaceSmer[1];
        }
        else if (smer == Smer.Vrovne)
        {
            Dashboard.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = NavigaceBackground[0];
            Dashboard.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = NavigaceSmer[0];
        }
        else if (smer == Smer.Yodbocka)
        {
            Dashboard.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = NavigaceBackground[1];
            Dashboard.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = NavigaceSmer[2];
        }
        else if (smer == Smer.Yrovne)
        {
            Dashboard.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = NavigaceBackground[1];
            Dashboard.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = NavigaceSmer[0];
        }
        else if (smer == Smer.YLrovne)
        {
            Dashboard.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = NavigaceBackground[2];
            Dashboard.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = NavigaceSmer[0];
        }
        else if (smer == Smer.YLodbocka)
        {
            Dashboard.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = NavigaceBackground[2];
            Dashboard.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = NavigaceSmer[3];
        }
        else if (smer == Smer.DalniceV)
        {
            Dashboard.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = NavigaceBackground[3];
            Dashboard.transform.GetChild(1).GetChild(1).GetComponent<Image>().sprite = NavigaceSmer[4];
        }
    }
    public void SetZnacka(int ID)
    {


        if (ID==0)
            {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        }
        else if(ID==1)//Zruseni
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(false);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite=Znacky[0];
        }
        else if (ID == 2)//Kolona
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(false);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = Znacky[1];
        }
        else if (ID == 3)//Semafor
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(false);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = Znacky[2];
            SemaforOn();
        }
        else if (ID == 50)//Semafor
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = Znacky[3];
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text="50";
        }
        else if (ID == 70)//Semafor
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = Znacky[3];
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = "70";
        }
        else if (ID == 80)//Semafor
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = Znacky[3];
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = "80";
        }
        else if (ID == 100)//Semafor
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = Znacky[3];
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = "100";
        }
        else if (ID == 130)//Semafor
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = Znacky[3];
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = "130";
        }
        else if (ID == 90)//Semafor
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).gameObject.SetActive(true);
            Dashboard.transform.GetChild(2).GetChild(1).GetComponent<Image>().sprite = Znacky[3];
            Dashboard.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<Text>().text = "90";
        }
        else
        {
            Dashboard.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Dashboard.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = Mathf.Round(VC.SpeedKPH).ToString();
        Distance = Vector3.Distance(VC.transform.position, Target.transform.position);
        if(Distance>1000)
        {
            NavText = (Math.Round(Distance / 1000,1)).ToString() + " km";
        }
        else if(Distance>100)
        {
            NavText = ((Mathf.Floor(Distance/100))*100).ToString() + " m";
        }
        else
        {
            NavText = ((Mathf.Floor(Distance / 10)) * 10).ToString()+" m";
        }
        Dashboard.transform.GetChild(1).GetChild(3).GetComponent<Text>().text = NavText;
    }
}
