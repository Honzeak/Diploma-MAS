using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardSetTrigger : MonoBehaviour
{


    public VW_Dashboard_control Dashboard;
    public bool ChangeZnacku = true;
    public int IDZnackyNavigace;

    public bool ChangeText = false;
    public string TextNavigace;

    public bool ChangeSipky = false;
    public VW_Dashboard_control.Smer Smer;

    public bool ChangeTarget;
    public GameObject Target;

    public bool ChangeSemafor=false;
    public enum SemaforState { On,Off,Cervena,Zelena,Zluta};
    public SemaforState SetSemafor;

    private void OnTriggerEnter(Collider other)
    {
        if(ChangeZnacku==true)
        {
            Dashboard.SetZnacka(IDZnackyNavigace);
        }
        if (ChangeText == true)
        {
            Dashboard.SetText(TextNavigace);
        }
        if (ChangeSipky == true)
        {
            Dashboard.SetNavigace(Smer);
        }

        if (ChangeTarget == true)
        {
            Dashboard.Target=Target;
        }

        if (ChangeSemafor== true)
        {
            if (SetSemafor == SemaforState.On)
                Dashboard.SemaforOn();
            if (SetSemafor == SemaforState.Off)
                Dashboard.SemaforOff();
            if (SetSemafor == SemaforState.Zelena)
                Dashboard.SemaforZelena();
            if (SetSemafor == SemaforState.Zluta)
                Dashboard.SemaforZluta();
            if (SetSemafor == SemaforState.Cervena)
                Dashboard.SemaforCervena();
        }
    }
}
