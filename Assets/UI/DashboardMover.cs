using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashboardMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newpos= transform.GetComponent<RectTransform>().anchoredPosition;
       if(Input.GetKey(KeyCode.Keypad8))
        {
            newpos += new Vector2(0, 20 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            newpos += new Vector2(0, -20 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Keypad6))
        {
            newpos += new Vector2(20 * Time.deltaTime,0);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            newpos += new Vector2(-20 * Time.deltaTime,0);
        }

        transform.GetComponent<RectTransform>().anchoredPosition = newpos;
    }
}
