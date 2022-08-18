using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigaceSipkySmer : MonoBehaviour
{
    public GameObject Car;
    public GameObject Sipky;

    private void OnTriggerEnter(Collider other)
    {

            Sipky.SetActive(true);
        
    }

    private void OnTriggerExit(Collider other)
    {
 
            Sipky.SetActive(false);
      
    }

    private void Start()
    {
        Sipky.SetActive(false);
    }

}
