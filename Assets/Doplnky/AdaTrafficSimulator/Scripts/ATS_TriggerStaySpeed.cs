using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATS_TriggerStaySpeed : MonoBehaviour
{
    [Header("Animations To Start")]
    public ATS_VehicleManager[] Animations;
    public ATS_TrainSegments[] TrainAnimations;

    [Header("SpeedCondition")]
    public bool SpeedCondition;
    public float SpeedLimit;
    public Rigidbody Player;
    public KrizovaatkaDubis KD;
    private void OnTriggerStay(Collider other)
    {
        if(SpeedCondition==true)
        {
            float speed = Player.velocity.magnitude;

            if (speed < SpeedLimit)
            {
                
                foreach (ATS_VehicleManager animation in Animations)
                {
                    animation.PlayAnimation = true;
                }
                foreach (ATS_TrainSegments animation in TrainAnimations)
                {
                    animation.PlayAnimation = true;
                }
                KD.SetAnimation();
                SpeedCondition = false;
            }
        }
        

    }
}
