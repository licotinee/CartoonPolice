using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Police_Scene4_1 : MonoBehaviour
{
    [SerializeField] SkeletonAnimation wolfoo;
    [SerializeField] SkeletonAnimation kat;

   private void Awake()
   {
        wolfoo.transform.position = wolfoo.transform.position - new Vector3(0, Camera.main.orthographicSize, 0);
        kat.transform.position = kat.transform.position - new Vector3(0, Camera.main.orthographicSize, 0);
        wolfoo.AnimationState.SetAnimation(0, "Idle", true);
        kat.AnimationState.SetAnimation(0, "Idle", true);
   }


    public void MoveUp()
    {
        StartCoroutine(StartMoveUp(wolfoo.gameObject, kat.gameObject));
    }

    IEnumerator StartMoveUp(GameObject ob1, GameObject ob2)
    {
        float start = ob1.transform.position.y;
        float end = start + Camera.main.orthographicSize;

        float eslapsed = 0;
        float seconds = 0.5f;

        float posY;

        while (eslapsed <= seconds) 
        {
            eslapsed += Time.deltaTime;
            posY = start + (end - start) * (eslapsed/seconds);
            ob1.transform.position = new Vector3(ob1.transform.position.x, posY, ob1.transform.position.z);
            ob2.transform.position = new Vector3(ob2.transform.position.x, posY, ob2.transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        
        ob1.transform.position = new Vector3(ob1.transform.position.x, end, ob1.transform.position.z);
        ob2.transform.position = new Vector3(ob2.transform.position.x, end, ob2.transform.position.z);

        PoliceCheer();
    }

    private void PoliceCheer()
    {

        wolfoo.AnimationState.SetAnimation(0, "Cheer", true);
        kat.AnimationState.SetAnimation(0, "Cheer", true);
    }
}
