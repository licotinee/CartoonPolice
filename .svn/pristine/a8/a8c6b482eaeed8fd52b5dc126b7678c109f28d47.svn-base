using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSetting : MonoBehaviour
{
    [SerializeField] GameObject car;

    // Update is called once per frame
    void Update()
    {
        // Camera in car
        if (car.transform.position.x >= 0) {
            if(GameScenePoliceCarManager.ins.endPosition && car.transform.position.x <= GameScenePoliceCarManager.ins.endPosition.position.x+2f){
                this.transform.position = new Vector3(car.transform.position.x, transform.position.y, transform.position.z);
            }
        }
            
    }

}
