using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public HingeJoint2D rightThigh;
    public HingeJoint2D leftThigh;
    public HingeJoint2D rightCalf;
    public HingeJoint2D leftCalf;

    public JointMotor2D rightThighMotorRef;
    public JointMotor2D leftThighMotorRef;
    public JointMotor2D rightCalfMotorRef;
    public JointMotor2D leftCalfMotorRef;

    public float hingeSpeed = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        rightCalfMotorRef = rightCalf.motor;
        leftCalfMotorRef = leftCalf.motor;
        rightThighMotorRef = rightThigh.motor;
        leftThighMotorRef = leftThigh.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;

            rightThighMotorRef.motorSpeed = -hingeSpeed;
            leftThighMotorRef.motorSpeed = hingeSpeed;

            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;

            rightThighMotorRef.motorSpeed = hingeSpeed;
            leftThighMotorRef.motorSpeed = -hingeSpeed;

            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;
        }
        else
        {
            rightThigh.useMotor = false;
            leftThigh.useMotor = false;
        }

        if (Input.GetKey(KeyCode.O))
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;

            rightCalfMotorRef.motorSpeed = -hingeSpeed;
            leftCalfMotorRef.motorSpeed = hingeSpeed;

            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;
        }
        else if (Input.GetKey(KeyCode.P))
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;

            rightCalfMotorRef.motorSpeed = hingeSpeed;
            leftCalfMotorRef.motorSpeed = -hingeSpeed;

            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;
        }
        else
        {
            rightCalf.useMotor = false;
            leftCalf.useMotor = false;
        }
    }
}
