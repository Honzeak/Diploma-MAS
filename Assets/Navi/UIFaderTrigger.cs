﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFaderTrigger : MonoBehaviour
{
    public UIFader first;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        first.FadeOut();
    }

    private void OnTriggerExit(Collider other)
    {
        first.FadeIn();
    }
}
