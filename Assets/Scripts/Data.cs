public class Data
{
    public static float startDist;
    public static int alive = 1;

    // Body parts
    public static float headAngle;
    public static float headPositionX;
    public static float headPositionY;
    public static float headVelocityX;
    public static float headVelocityY;

    public static float torsoSpeed;
    public static float torsoAngle;

    // Joints
    public static float rightThighSpeed;
    public static float leftThighSpeed;
    public static float rightCalfSpeed;
    public static float leftCalfSpeed;
    public static float leftElbowSpeed;
    public static float rightElbowSpeed;
    public static float rightShoulderSpeed;
    public static float leftShoulderSpeed;

    public static float rightThighAngle;
    public static float leftThighAngle;
    public static float rightCalfAngle;
    public static float leftCalfAngle;
    public static float leftElbowAngle;
    public static float rightElbowAngle;
    public static float leftShoulderAngle;
    public static float rightShoulderAngle;

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
}
