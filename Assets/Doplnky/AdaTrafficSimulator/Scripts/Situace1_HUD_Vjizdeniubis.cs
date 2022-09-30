using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class Situace1_HUD_Vjizdeniubis : MonoBehaviour
{
    [Header("Player")]
    public GameObject Player;
    public float Distance;
    public bool active = true;
    [Header("Animation")]
    public Animator anim;
    public ATS_VehicleManager ATS;
    public Image HUDImage;
    public Sprite Close;
    public Sprite Far;
    public float closeDistance=15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active==true)
        {
            if (ATS.PlayAnimation == true)
            {
                Distance = Vector3.Distance(transform.position,Player.transform.position);
                if(Distance>closeDistance)
                {
                    HUDImage.sprite = Far;
                    HUDImage.color = new Color32(156, 210, 118, 255);
                }
                else
                {
                    HUDImage.sprite = Close;
                    HUDImage.color = new Color32(255, 100,80, 255);
                }
                if (ATS.MyPosition > 8 && ATS.MyPosition < 10)
                {
                    anim.SetBool("ACC", true);
                }

                if (ATS.MyPosition > 180 && ATS.MyPosition < 182)
                {
                    active = false;
                    anim.SetBool("ACC", false);
                }
            }
        }
        
    }
}
