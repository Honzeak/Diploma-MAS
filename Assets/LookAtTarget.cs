using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform, Vector3.up);
        if(Vector3.Distance(target.transform.position,transform.position)<5)
        {
            transform.gameObject.SetActive(false);
        }
    }
}
