using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    List<Transform> CarsInRadar = new List<Transform>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            CarsInRadar.Add(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            CarsInRadar.Remove(collision.gameObject.transform);
        }
    }

    public List<Transform> GetCarsInRadar()
    {
        return CarsInRadar;
    }


}
