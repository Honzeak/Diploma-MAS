using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATS_VehicleManager : MonoBehaviour
{
    [Header("ATS_Trajektorie")]
    public ATS_Trajektorie Trajektory;
    public Vector3 Offset;

    [Header("Parametry jizdy")]
    public bool PlayAnimation=true;
    public float speed;
    public bool useSpeedGraf;
    public AnimationCurve speedGraf;
    public bool EndDestroy;
    public bool SetOnStart = false;
    public float MyPosition;
    private int MyPosInt;
    private float inter;
    private string firstLine;
    private string secondLine;
    private string thirtLine;

    [Header("Brzdeni")]
    public bool Stop;
    public float BrakeNormal=2;
    public float BrakeCritic=5;
    public GameObject BrakesLight;




    [Header("Position")]
    public Vector3 MyPosition3D;
    public float X;
    public float Y;
    public float Z;

    [Header("Target Look At")]
    public float LookFar=2;
    public Vector3 Target;
    public bool LookForward=true;
    public float tX;
    public float tY;
    public float tZ;


    private void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (SetOnStart == true)
        {
            MyPosInt = Convert.ToInt32(Mathf.Floor(MyPosition));
            inter = (MyPosition - (MyPosInt));
            try
            {
                firstLine = Trajektory.lines[MyPosInt];
                secondLine = Trajektory.lines[MyPosInt + 1];
                thirtLine = Trajektory.lines[MyPosInt + 2];
                SetOnStart = false;

            }
            catch
            {
                
            }

            X = (float.Parse(secondLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
            Y = (float.Parse(secondLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
            Z = (float.Parse(secondLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));

            MyPosition3D = new Vector3(-X, Y, -Z) + Offset;

            tX = (float.Parse(thirtLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(secondLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
            tY = (float.Parse(thirtLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(secondLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
            tZ = (float.Parse(thirtLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(secondLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));

            Target = new Vector3(-tX, tY, -tZ) + Offset + transform.forward * LookFar / speed;


            transform.position = MyPosition3D;
            if (LookForward == true)
                transform.LookAt(Target);
            else
                transform.up = Target - MyPosition3D;
        }

        if (PlayAnimation==true)
        {
            
            if (Stop == true)
            {
                speed = -BrakeCritic * Time.fixedDeltaTime + speed;
                if (speed < 0)
                {
                    speed = 0;
                }
                try
                {
                    BrakesLight.SetActive(true);
                }
                catch
                {

                }
            }
            else
            {
                if (useSpeedGraf == true)
                {
                    speed = speedGraf.Evaluate(MyPosition);
                }
            }

                MyPosition = MyPosition + Time.fixedDeltaTime * speed;

            MyPosInt = Convert.ToInt32(Mathf.Floor(MyPosition ));
            inter = (MyPosition - (MyPosInt ));
            //Smazani Objektu
            if (MyPosInt >= Trajektory.lines.Length)
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
            try
            {
                firstLine = Trajektory.lines[MyPosInt];
                secondLine = Trajektory.lines[MyPosInt + 1];
                thirtLine = Trajektory.lines[MyPosInt + 2];
            }
            catch
            {
                Destroy(transform.gameObject);
            }

            X = (float.Parse(secondLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
            Y = (float.Parse(secondLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
            Z = (float.Parse(secondLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(firstLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));

            MyPosition3D = new Vector3(-X, Y, -Z) + Offset;

            tX = (float.Parse(thirtLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(secondLine.Split(',')[0], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
            tY = (float.Parse(thirtLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(secondLine.Split(',')[2], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));
            tZ = (float.Parse(thirtLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * inter) + (float.Parse(secondLine.Split(',')[1], System.Globalization.CultureInfo.InvariantCulture) * (1 - inter));

            Target = new Vector3(-tX, tY, -tZ) + Offset+transform.forward*LookFar/speed;


            transform.position = MyPosition3D;
            if (LookForward == true)
                transform.LookAt(Target);
            else
                transform.up = Target - MyPosition3D;

        }
    }
        
}
