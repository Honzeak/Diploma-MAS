using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATS_Lights : MonoBehaviour
{
    public ATS_VehicleManager VM;
    public AnimationCurve LightState;
    public LightSystem LS;
    public float blinkFrekvence=0.25f;
    public float blinkDuration=0.25f;
    public float blinkTime;
    public float state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(VM.PlayAnimation==true)
        {
            state = LightState.Evaluate(VM.MyPosition);
            if(state==0)
            {
                blinkTime = blinkFrekvence;
                LS.MaterialObject.SetTexture("_EmissionMap", LS.Normal);
                LS.LeftBlinker.SetActive(false);
                LS.RightBlinker.SetActive(false);

            }
            else if(state==1)
                {
                blinkTime += Time.deltaTime;
                LS.MaterialObject.SetTexture("_EmissionMap", LS.Normal);
                LS.LeftBlinker.SetActive(false);

                if (blinkTime>blinkDuration)
                {
                    LS.RightBlinker.SetActive(true);
                    if (blinkTime>blinkDuration+blinkFrekvence)
                    {
                        blinkTime = 0;
                    }
                }
                else
                {
                    LS.RightBlinker.SetActive(false);
                }
            }
            else if (state == 2)
            {
                blinkTime += Time.deltaTime;
                LS.MaterialObject.SetTexture("_EmissionMap", LS.Brake);
                LS.LeftBlinker.SetActive(false);

                if (blinkTime > blinkDuration)
                {
                    LS.RightBlinker.SetActive(true);
                    if (blinkTime > blinkDuration + blinkFrekvence)
                    {
                        blinkTime = 0;
                    }
                }
                else
                {
                    LS.RightBlinker.SetActive(false);
                }
            }
            else if (state == -1)
            {
                blinkTime += Time.deltaTime;
                LS.MaterialObject.SetTexture("_EmissionMap", LS.Normal);
                LS.RightBlinker.SetActive(false);

                if (blinkTime > blinkDuration)
                {
                    LS.LeftBlinker.SetActive(true);
                    if (blinkTime > blinkDuration + blinkFrekvence)
                    {
                        blinkTime = 0;
                    }
                }
                else
                {
                    LS.LeftBlinker.SetActive(false);
                }
            }
            else if (state == -2)
            {
                blinkTime += Time.deltaTime;
                LS.MaterialObject.SetTexture("_EmissionMap", LS.Brake);
                LS.RightBlinker.SetActive(false);

                if (blinkTime > blinkDuration)
                {
                    LS.LeftBlinker.SetActive(true);
                    if (blinkTime > blinkDuration + blinkFrekvence)
                    {
                        blinkTime = 0;
                    }
                }
                else
                {
                    LS.LeftBlinker.SetActive(false);
                }
            }
            else if (state == 5)
            {
                blinkTime = 0;
                LS.MaterialObject.SetTexture("_EmissionMap", LS.Brake);
                LS.RightBlinker.SetActive(false);
                LS.LeftBlinker.SetActive(false);
                
            }

        }
    }
    [System.Serializable]
    public class LightSystem
    {
        public Material MaterialObject;
        public Texture2D Normal;
        public Texture2D Brake;
        public GameObject LeftBlinker;
        public GameObject RightBlinker;
    }

}
