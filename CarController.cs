using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;    
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float brakeForce = 50f;
    public float presentBrakeForce = 0f;
    public float presentAcceleration = 0f;

    [Header("Car Steering")]
    public float wheelsTorque = 35f;
    public float presentTurnAngle = 0f;

    [Header("Extras")]
    public GameObject headLight;
    public GameObject line;
    public Animator acceAnim;
    public Animator brakeAnim;

    private void Update()
    {
        MoveCar();
        CarSteering();
        HeadLight();
    }


    private void MoveCar()
    {
        presentAcceleration = accelerationForce * SimpleInput.GetAxis("Vertical");

        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollider.motorTorque = presentAcceleration;

        if (presentAcceleration > 0)
        {
            acceAnim.SetBool("Accelerate",true);
            brakeAnim.SetBool("Brake", false);
        }
        else if(presentAcceleration < 0)
        {
            acceAnim.SetBool("Accelerate", false);
            brakeAnim.SetBool("Brake", true);

        }

    }

    private void CarSteering()
    {
        presentTurnAngle = wheelsTorque * SimpleInput.GetAxis("Horizontal");

        frontLeftWheelCollider.steerAngle = presentTurnAngle;
        frontRightWheelCollider.steerAngle = presentTurnAngle;

        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform);
        SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheels(backLeftWheelCollider, backLeftWheelTransform);
        SteeringWheels(backRightWheelCollider, backRightWheelTransform);
    }

    private void SteeringWheels(WheelCollider wc,Transform wt)
    {
        Vector3 position;
        Quaternion rotation;

        wc.GetWorldPose(out position, out rotation);

        wt.position = position;
        wt.rotation = rotation;
    }


    public void ApplyBreak()
    {

        StartCoroutine(CarBrake());
    }

    IEnumerator CarBrake()
    {
        presentBrakeForce = brakeForce;

        frontLeftWheelCollider.brakeTorque = 300 * presentBrakeForce;
        frontRightWheelCollider.brakeTorque = 300 * presentBrakeForce;
        backLeftWheelCollider.brakeTorque = 300 * presentBrakeForce;
        backRightWheelCollider.brakeTorque = 300 * presentBrakeForce;

        line.SetActive(true);
        StartCoroutine(DeactivateLineAfterDelay(2f));
        yield return new WaitForSeconds(1f);

        presentBrakeForce = 0f;
        frontLeftWheelCollider.brakeTorque = 0f;
        frontRightWheelCollider.brakeTorque = 0f;
        backLeftWheelCollider.brakeTorque = 0f;
        backRightWheelCollider.brakeTorque = 0f;

    }

    IEnumerator DeactivateLineAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        line.SetActive(false);
    }

    public void HeadLight()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (headLight.activeInHierarchy)
            {
                headLight.SetActive(false);
            }
            else
            {
                headLight.SetActive(true);
            }
            
        }

    }
}
