using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("==> Singleton doesnt exist!!! <==");
                instance = FindObjectOfType<T>();
            }

            return instance;
        }
    }

    protected virtual void Awake()
    {
        if (instance != null && instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID())
            Destroy(this.gameObject);
        else
            instance = this.GetComponent<T>();
    }


}