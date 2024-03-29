using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoobBackground : MonoBehaviour
{
    [SerializeField] List<GameObject> ListBgs;
    private List<float> ListSizeBgs = new List<float>();
    [SerializeField] float speedLayer;
    private float oldPosition;

    private void Start()
    {
        oldPosition = Camera.main.transform.position.x;
        for (int i = 0; i < ListBgs.Count; ++i)
        {
            ListSizeBgs.Add(ListBgs[i].GetComponent<SpriteRenderer>().size.x);
        }
    }
    private void LateUpdate()
    {
        LayerTransform();
        LoopLayer();
    }

    private void LayerTransform()
    {
        if(Camera.main.transform.position.x > 0)
        {
            float dist = (Camera.main.transform.position.x - oldPosition) * speedLayer;
            for (int i = 0; i < ListBgs.Count; ++i)
            {
                ListBgs[i].transform.position += new Vector3(dist, 0, 0);
            }
            oldPosition = Camera.main.transform.position.x;
        }
    }

    private void LoopLayer()
    {
        for (int i = 0; i < ListBgs.Count; ++i)
        {
            if (ListBgs[i].transform.position.x + ListSizeBgs[i] / 2 <= Camera.main.transform.position.x - Camera.main.aspect * Camera.main.orthographicSize)
            {
                int nextIndexBg = (i + ListBgs.Count - 1) % (ListBgs.Count);
                ListBgs[i].transform.position = new Vector3(ListBgs[nextIndexBg].transform.position.x + ListSizeBgs[nextIndexBg] / 2 + ListSizeBgs[i] / 2 - 0.05f, ListBgs[i].transform.position.y, 0);
            }
        }
    }
}
