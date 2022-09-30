using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATS_VehicleBehavior : MonoBehaviour
{
    public ATS_VehicleManager VehicleManager;

    [Header("Wheel Rotation")]
    public GameObject[] LWheels;
    public GameObject[] RWheels;
    public float rd=0.35f;
    private float speed;
    // Start is called before the first frame update


    // Update is called once per frame
    void FixedUpdate()
    {
        speed = VehicleManager.speed;
        foreach(GameObject wheel in LWheels)
        {
            wheel.transform.Rotate((speed * Time.fixedDeltaTime / rd)* Mathf.Rad2Deg, 0,0);
        }

        foreach (GameObject wheel in RWheels)
        {
            wheel.transform.Rotate(-(speed * Time.fixedDeltaTime / rd) * Mathf.Rad2Deg, 0, 0);
        }
    }
}
