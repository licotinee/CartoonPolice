using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Scene3_4 : MonoBehaviour
{
    [SerializeField] GameObject carPolice;
    private float lengthCam;
    private void Start()
    {
        lengthCam = Camera.main.orthographicSize * Camera.main.aspect;
    }
    private void LateUpdate()
    {
        if (GameScene43Manager.ins.isStartGame)
        {
            transform.position = new Vector3(carPolice.transform.position.x + 3f / 5 * lengthCam, transform.position.y, transform.position.z);
        }     
    }
}
