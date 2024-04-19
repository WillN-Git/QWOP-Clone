using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public float startDist;

    // The whole player
    public float speed;
    public float inclination;

    // Joint 
    public float rightThighSpeed;
    public float leftThighSpeed;
    public float rightCalfSpeed;
    public float leftCalfSpeed;

    public float rightThighAngle;
    public float leftThighAngle;
    public float rightCalfAngle;
    public float leftCalfAngle;

    public int alive = 1;

    public Data()
    {
        startDist = 0;
        speed = 0;
        inclination = 0;
        rightThighSpeed = 0;
        leftThighSpeed = 0;
        rightCalfSpeed = 0;
        leftCalfSpeed = 0;
        rightThighAngle = 0;
        leftThighAngle = 0;
        rightCalfAngle = 0;
        leftCalfAngle = 0;
    }

    public void GenerateNewDataCO()
    {
        startDist++;
        speed++;
        inclination++;
        rightThighSpeed++;
        leftThighSpeed++;
        rightCalfSpeed++;
        leftCalfSpeed++;
        rightThighAngle++;
        leftThighAngle++;
        rightCalfAngle++;
        leftCalfAngle++;
    }
}
