using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceManager_SceneDressing : MonoBehaviour
{
    [SerializeField] Police_SceneDressing wolfoo;
    [SerializeField] Police_SceneDressing kat;
    
    public void StartScene(float seconds)
    {
        wolfoo.MoveRight(seconds, false);
        kat.MoveRight(seconds, true);
    }

    public void StartTurn()
    {
        wolfoo.StartTurn();
        kat.StartTurn();
    }

    public void EndScene(float seconds)
    {
        wolfoo.EndScene(seconds);
        kat.EndScene(seconds);
    }
}
