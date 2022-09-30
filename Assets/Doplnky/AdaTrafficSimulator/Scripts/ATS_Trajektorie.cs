using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATS_Trajektorie : MonoBehaviour
{
    public TextAsset Trajektorie;
    public string[] lines;
    // Start is called before the first frame update
    void Start()
    {
        lines = Trajektorie.text.Split('\n');
    }

}
