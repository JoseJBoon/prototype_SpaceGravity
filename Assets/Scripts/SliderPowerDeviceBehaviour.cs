using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SliderJoint2D))]
public class SliderPowerDeviceBehaviour : PowerDeviceBehaviour
{
    SliderJoint2D sliderJoint;
    float motorSpeed;

    void Awake() 
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        motorSpeed = sliderJoint.motor.motorSpeed;
    }

    void OnEnable() 
    {
        SetMotor(-motorSpeed);
    }

    void OnDisable() 
    {
        SetMotor(motorSpeed);
    }

    void SetMotor(float newMotorSpeed)
    {
        JointMotor2D motor = sliderJoint.motor;
        motor.motorSpeed = newMotorSpeed;
        sliderJoint.motor = motor;
    }
}
