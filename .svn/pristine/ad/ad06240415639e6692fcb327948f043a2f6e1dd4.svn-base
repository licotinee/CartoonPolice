using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsacle_Scene3_4 : MonoBehaviour
{
    [SerializeField] private int id;
    /*
        id = 1: hole
        id = 2: ground
        id = 3: water
     */

    public int GetId()
    {
        return id;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CarPolice"))
        {   
            gameObject.GetComponent<Collider2D>().enabled = false;
        }

        if (collision.gameObject.CompareTag("LimitScene"))
        {
            Destroy(gameObject);
        }
    }

}
