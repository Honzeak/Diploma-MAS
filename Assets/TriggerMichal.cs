using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMichal : MonoBehaviour
{
    public GameObject Sipka;

    // Start is called before the first frame update
    void Start()
    {
        Sipka.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Sipka.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Sipka.SetActive(false);
    }

}
