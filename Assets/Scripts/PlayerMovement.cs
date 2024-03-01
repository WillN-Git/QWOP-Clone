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

    [Header("Gameplay")]
    public float scaleFactor = 0.8f;
    public float jointSpeed = 40.0f;

    public GameObject touchQ;
    public GameObject touchW;
    public GameObject touchO;
    public GameObject touchP;

    private ScoreController _scoreController;

    // Start is called before the first frame update
    void Start()
    {
        _scoreController = FindFirstObjectByType<ScoreController>();

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

            rightThighMotorRef.motorSpeed = -jointSpeed;
            leftThighMotorRef.motorSpeed = jointSpeed;

            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;

        }
        else if (Input.GetKey(KeyCode.W))
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;

            rightThighMotorRef.motorSpeed = jointSpeed;
            leftThighMotorRef.motorSpeed = -jointSpeed;

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

            rightCalfMotorRef.motorSpeed = -jointSpeed;
            leftCalfMotorRef.motorSpeed = jointSpeed;

            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;

        }
        else if (Input.GetKey(KeyCode.P))
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;

            rightCalfMotorRef.motorSpeed = jointSpeed;
            leftCalfMotorRef.motorSpeed = -jointSpeed;

            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;

        }
        else
        {
            rightCalf.useMotor = false;
            leftCalf.useMotor = false;
        }

        // _scoreController.AddScore();

        touchQ.transform.localScale = new Vector3(1f, 1f, 1f);
        touchW.transform.localScale = new Vector3(1f, 1f, 1f);
        touchO.transform.localScale = new Vector3(1f, 1f, 1f);
        touchP.transform.localScale = new Vector3(1f, 1f, 1f);

        if (Input.GetKey(KeyCode.Q))
        {
            touchQ.transform.localScale = new Vector3(scaleFactor, scaleFactor);

        }
        if (Input.GetKey(KeyCode.W))
        {
            touchW.transform.localScale = new Vector3(scaleFactor, scaleFactor);
        }
        if (Input.GetKey(KeyCode.O))
        {
            touchO.transform.localScale = new Vector3(scaleFactor, scaleFactor);
        }
        if (Input.GetKey(KeyCode.P))
        {
            touchP.transform.localScale = new Vector3(scaleFactor, scaleFactor);
        }
    }
}
