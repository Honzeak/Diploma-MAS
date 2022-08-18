using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{

    public void SetNames()
    {
        transform.GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = "Axis X";
        transform.GetChild(1).GetChild(0).gameObject.GetComponent<Text>().text = "Axis Y";
        transform.GetChild(2).GetChild(0).gameObject.GetComponent<Text>().text = "Axis 3";
        transform.GetChild(3).GetChild(0).gameObject.GetComponent<Text>().text = "Axis 4";
        transform.GetChild(4).GetChild(0).gameObject.GetComponent<Text>().text = "LastDown : ";
    }

    private void Start()
    {
        SetNames();

    }

    private void Update()
    {
        transform.GetChild(0).GetChild(1).gameObject.GetComponent<Text>().text = Input.GetAxis("Axis1").ToString();
        transform.GetChild(1).GetChild(1).gameObject.GetComponent<Text>().text = Input.GetAxis("Axis2").ToString();
        transform.GetChild(2).GetChild(1).gameObject.GetComponent<Text>().text = Input.GetAxis("Axis3").ToString();
        transform.GetChild(3).GetChild(1).gameObject.GetComponent<Text>().text = Input.GetAxis("Axis4").ToString();
        if (Input.anyKeyDown)

            for (int joystick = 1; joystick < 5; joystick++)
            {
                for (int button = 0; button < 20; button++)
                {
                    if (Input.GetKeyDown("joystick " + joystick + " button " + button))
                    {
                        transform.GetChild(transform.childCount - 1).GetChild(1).gameObject.GetComponent<Text>().text = "joystick = " + joystick + "  button = " + button;
                    }
                    else
                    {
               
                    }
                }
            }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
}
