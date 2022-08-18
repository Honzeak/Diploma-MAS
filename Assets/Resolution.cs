using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{
    public int width;
    public int height;
    public bool fullScreen;

    void Start()
    {
        Screen.SetResolution(width, height, fullScreen); 
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
