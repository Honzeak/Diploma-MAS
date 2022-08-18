using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATS_TrainSegments : MonoBehaviour
{
    [Header("ATS_Trajektorie")]
    public ATS_Trajektorie Trajektory;
    public Vector3 Offset;

    [Header("TrainSegments")]
    public GameObject[] TrainSegments;
    public int secondNaprava;
    public float offsetSegments;

    [Header("Parametry jizdy")]
    public bool PlayAnimation = true;
    public float speed;
    public bool useSpeedGraf;
    public AnimationCurve speedGraf;
    public bool EndDestroy;
    public float MyPosition;
    private int MyPosInt;
    private float inter;
    private string firstLine;
    private string secondLine;
    private string thirtLine;
    private string forthLine;
    [Header("Position")]
    public Vector3[] MyPosition3D;
    public float X;
    public float Y;
    public float Z;

    [Header("Target Look At")]
    public Vector3[] Target;
    public bool LookForward = true;
    public float tX;
    public float tY;
    public float tZ;
    // Start is called before the first frame update
    private void Start()
    {
        MyPosition3D = new Vector3[TrainSegments.Length];
        Target = new Vector3[TrainSegments.Length];
    }
    private void FixedUpdate()
    {
        if (PlayAnimation == true)
        {
            if (useSpeedGraf == true)
            {
                speed = speedGraf.Evaluate(MyPosition);
            }

            MyPosition = MyPosition + Time.fixedDeltaTime * speed;

            
            int s = 0;
            foreach(GameObject segment in TrainSegments)
            {

                MyPosInt = Convert.ToInt32(Mathf.Floor(MyPosition-(s*offsetSegments)));
                if(s==0)
                {
                    inter = ((MyPosition - (s * offsetSegments)) - (MyPosInt));
                }
              
                if (MyPosInt > Trajektory.lines.Length)
                {
                    if (EndDestroy == true)
                    {
                        Destroy(transform.gameObject);
                    }
                    else
                    {
                        speed = 0;
                    }

                }

                firstLine = Trajektory.lines[MyPosInt];
                secondLine = Trajektory.lines[MyPosInt + 1];
                thirtLine = Trajektory.lines[MyPosInt + secondNaprava];
                forthLine = Trajektory.lines[MyPosInt + secondNaprava+1];

                X = (float.Parse(secondLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
                Y = (float.Parse(secondLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
                Z = (float.Parse(secondLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));

                MyPosition3D[s] = new Vector3(-X, Y, -Z) + Offset;

                tX = (float.Parse(forthLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(thirtLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
                tY = (float.Parse(forthLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(thirtLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
                tZ = (float.Parse(forthLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(thirtLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));

                Target[s] = new Vector3(-tX, tY, -tZ) + Offset;


                segment.transform.position = MyPosition3D[s];
                if (LookForward == true)
                    segment.transform.LookAt(Target[s]);
                else
                    segment.transform.up = Target[s] - MyPosition3D[s];
                s++;
            }
        }
    }
}
