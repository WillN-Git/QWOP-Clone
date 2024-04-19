public class Data
{
    public float startDist;
    public int alive = 1;

    // Body parts
    public float headAngle;
    public float headPositionX;
    public float headPositionY;
    public float headVelocityX;
    public float headVelocityY;

    public float torsoSpeed;
    public float torsoAngle;

    // Joints
    public float rightThighSpeed;
    public float leftThighSpeed;
    public float rightCalfSpeed;
    public float leftCalfSpeed;
    public float elbowSpeed;

    public float rightThighAngle;
    public float leftThighAngle;
    public float rightCalfAngle;
    public float leftCalfAngle;
    public float elbowAngle;

    public Data()
    {
        startDist = 0;
        torsoSpeed = 0;
        torsoAngle = 0;
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
        torsoSpeed++;
        torsoAngle++;
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
