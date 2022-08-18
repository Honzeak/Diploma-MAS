using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATS_AnimationManager : MonoBehaviour
{
    public ATS_VehicleManager ATS;

    [Header("Position Trigger")]
    public float triggerPosition;
    public AnimationCurve NewCurve;
    private void Update()
    {
        if(ATS.MyPosition>triggerPosition)
        {
            ATS.PlayAnimation = false;
            ATS.speedGraf = NewCurve;
            triggerPosition = 15000;
            ATS.speed = 0;
        }
    }
}
