using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionFinger_8 : MonoBehaviour
{
    [SerializeField] MicroScope_SessionFinger_8 scope;
    [SerializeField] Broom_SessionFinger_8 broom;

    private void OnEnable()
    {
        scope.ScaleUp(0.5f);
        broom.MoveUp(0.5f);
    }


}
