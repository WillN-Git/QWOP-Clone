using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public HingeJoint2D rightThigh;
    public HingeJoint2D leftThigh;
    public HingeJoint2D rightCalf;
    public HingeJoint2D leftCalf;
    
    public HingeJoint2D rightShoulder;
    public HingeJoint2D leftShoulder;
    public HingeJoint2D rightElbow;
    public HingeJoint2D leftElbow;

    public JointMotor2D rightThighMotorRef;
    public JointMotor2D leftThighMotorRef;
    public JointMotor2D rightCalfMotorRef;
    public JointMotor2D leftCalfMotorRef;
    
    public JointMotor2D rightShoulderMotorRef;
    public JointMotor2D leftShoulderMotorRef;
    public JointMotor2D rightElbowMotorRef;
    public JointMotor2D leftElbowMotorRef;

    

    [Header("Gameplay")]
    public float scaleFactor = 0.8f;
    public float jointSpeed = 40.0f;

    public GameObject touchQ;
    public GameObject touchW;
    public GameObject touchO;
    public GameObject touchP;

    private ScoreController _scoreController;

    [Header("Debug")]
    [SerializeField, Range(0, 1)]
    private float inputReceiveRate = 0.5f;

    private IInputActionSender runner;

    private int[] input = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        runner = DummyRunner.instance;

        _scoreController = FindFirstObjectByType<ScoreController>();

        rightThighMotorRef = rightThigh.motor;
        leftThighMotorRef = leftThigh.motor;
        rightCalfMotorRef = rightCalf.motor;
        leftCalfMotorRef = leftCalf.motor;
        
        rightShoulderMotorRef = rightShoulder.motor;
        leftShoulderMotorRef = leftShoulder.motor;
        rightElbowMotorRef = rightElbow.motor;
        leftElbowMotorRef = leftElbow.motor;

        _SendOutputData();
        _ReceiveInputConstantly();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) || input[0] == 1)
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;

            rightThighMotorRef.motorSpeed = -jointSpeed;
            leftThighMotorRef.motorSpeed = jointSpeed;

            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;

            rightShoulder.useMotor = true;
            leftShoulder.useMotor = true;
            
            rightThighMotorRef.motorSpeed = -jointSpeed;
            leftThighMotorRef.motorSpeed = jointSpeed;
            
        }
        else if (Input.GetKey(KeyCode.W) || input[1] == 1)
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;

            rightThighMotorRef.motorSpeed = jointSpeed;
            leftThighMotorRef.motorSpeed = -jointSpeed;

            rightThigh.motor = rightThighMotorRef;
            leftThigh.motor = leftThighMotorRef;

            rightShoulder.useMotor = true;
            leftShoulder.useMotor = true;
            
            rightShoulderMotorRef.motorSpeed = jointSpeed;
            leftShoulderMotorRef.motorSpeed = -jointSpeed;

            rightShoulder.motor = rightShoulderMotorRef;
            leftShoulder.motor = leftShoulderMotorRef;
            
        }
        else
        {
            rightThigh.useMotor = false;
            leftThigh.useMotor = false;

            rightShoulder.useMotor = false;
            leftShoulder.useMotor = false;
        }

        if (Input.GetKey(KeyCode.O) || input[2] == 1)
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;

            rightCalfMotorRef.motorSpeed = -jointSpeed;
            leftCalfMotorRef.motorSpeed = jointSpeed;

            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;

            
            rightElbow.useMotor = true;
            leftElbow.useMotor = true;

            rightElbowMotorRef.motorSpeed = -jointSpeed;
            leftElbowMotorRef.motorSpeed = jointSpeed;

            rightElbow.motor = rightElbowMotorRef;
            leftElbow.motor = leftElbowMotorRef;
        }
        else if (Input.GetKey(KeyCode.P) || input[3] == 1)
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;

            rightCalfMotorRef.motorSpeed = jointSpeed;
            leftCalfMotorRef.motorSpeed = -jointSpeed;

            rightCalf.motor = rightCalfMotorRef;
            leftCalf.motor = leftCalfMotorRef;

            rightElbow.useMotor = true;
            leftElbow.useMotor = true;

            rightElbowMotorRef.motorSpeed = jointSpeed;
            leftElbowMotorRef.motorSpeed = -jointSpeed;

            rightElbow.motor = rightElbowMotorRef;
            leftElbow.motor = leftElbowMotorRef;
        }
        else
        {
            rightCalf.useMotor = false;
            leftCalf.useMotor = false;
            
            rightElbow.useMotor = false;
            leftElbow.useMotor = false;
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

    private void _SendOutputData()
    {
        StartCoroutine(_SendOutputDataCO());
    }

    private IEnumerator _SendOutputDataCO()
    {
        Data.rightThighSpeed = rightThigh.jointSpeed;
        Data.leftThighSpeed = leftThigh.jointSpeed;
        Data.rightCalfSpeed = rightCalf.jointSpeed;
        Data.leftCalfSpeed = leftCalf.jointSpeed;
        Data.rightElbowSpeed = rightElbow.jointSpeed;
        Data.leftElbowSpeed = leftElbow.jointSpeed;
        Data.rightShoulderSpeed = rightShoulder.jointSpeed;
        Data.leftShoulderSpeed = leftShoulder.jointSpeed;

        Data.rightThighAngle = rightThigh.jointAngle;
        Data.leftThighAngle = leftThigh.jointAngle;
        Data.rightCalfAngle = rightCalf.jointAngle;
        Data.leftCalfAngle = leftCalf.jointAngle;
        Data.rightElbowAngle = rightElbow.jointAngle;
        Data.leftElbowAngle = leftElbow.jointAngle;
        Data.rightShoulderAngle = rightShoulder.jointAngle;
        Data.leftShoulderAngle = leftShoulder.jointAngle;

        Data.a = input[0];
        Data.z = input[1];
        Data.o = input[2];
        Data.p = input[3];

        yield return new WaitForSeconds(inputReceiveRate);

        StartCoroutine(_SendOutputDataCO());
    }

    private void _ReceiveInputConstantly()
    {
        StartCoroutine(_ReceiveInputCO());
    }

    private IEnumerator _ReceiveInputCO()
    {
        input = runner.SendAction();

        yield return new WaitForSeconds(inputReceiveRate);

        yield return _ReceiveInputCO();
    }
}
