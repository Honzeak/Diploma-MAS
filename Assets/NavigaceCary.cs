using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class NavigaceCary : MonoBehaviour
{
    public RaycastHit hit;
    public LayerMask layerMask;
    public float Distance=50;

    [Header("Navigace")]
    public GameObject NavImage;
    public bool active;
    
    // Start is called before the first frame update


    // Update is called once per frame
    private void FixedUpdate()
    {
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Distance, layerMask))
        {
            active = true;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            NavImage.SetActive(true);
            NavImage.transform.position=hit.point;
        }
        else
        {
            active = false;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * Distance, Color.white);
            NavImage.SetActive(false);
        }
    }

}
