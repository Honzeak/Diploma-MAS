using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATS_TriggerStart : MonoBehaviour
{
    [Header("Animations To Start")]
    public ATS_VehicleManager[] Animations;
    public ATS_TrainSegments[] TrainAnimations;
    private void OnTriggerEnter(Collider other)
    {
        foreach(ATS_VehicleManager animation in Animations)
        {
            animation.PlayAnimation = true;
        }
        foreach (ATS_TrainSegments animation in TrainAnimations)
        {
            animation.PlayAnimation = true;
        }
    }
}
