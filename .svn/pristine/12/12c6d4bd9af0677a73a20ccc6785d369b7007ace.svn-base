using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCar : MonoBehaviour
{
    [SerializeField] public float speedRotate;
    [SerializeField] GameObject car;


    public void RotateWheel(float rate)
    {   
        transform.eulerAngles -= new Vector3(0, 0, rate * speedRotate * Time.deltaTime);
    }

}
