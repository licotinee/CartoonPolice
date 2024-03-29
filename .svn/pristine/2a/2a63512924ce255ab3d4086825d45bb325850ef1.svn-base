using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLight_Scene2_3 : MonoBehaviour
{
    Image light;

    private void OnEnable()
    {
        Train.turnRed += TurnRedLight;
        Train.turnGreen += TurnGreenLight;
    }

    private void Start()
    {
        light = GetComponent<Image>();
    }

    private void OnDestroy()
    {
        Train.turnRed -= TurnRedLight;
        Train.turnGreen -= TurnGreenLight;

    }

    private void TurnRedLight()
    {
        light.color = Color.red;
    }

    private void TurnGreenLight()
    {
        light.color = Color.green;

    }
}
