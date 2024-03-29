using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateVirrus : MonoBehaviour
{

    [SerializeField] List<Transform> PosInstantiateVirrus;

    [SerializeField] List<Virrus> ListVirrus;
    List<Vector3> NewPosInstantiateVirrus = new List<Vector3>();
    private int cntDiedVirrus;
    int[] maxDie;

    [SerializeField] int maxDieOfOneVirus;

    private void OnEnable()
    {
        Virrus.eVirrusDie += InstaneAtNewPos;
    }

    private void OnDestroy()
    {
        Virrus.eVirrusDie -= InstaneAtNewPos;
    }

    private void Start()
    {
        maxDie = new int[ListVirrus.Count];
        for (int i = 0; i < ListVirrus.Count; ++i)
        {
            Virrus newVirrus = Instantiate(ListVirrus[i], PosInstantiateVirrus[i].position, Quaternion.identity);
            newVirrus.SetIndex(i);
            maxDie[i] = maxDieOfOneVirus;
        }

        for(int i = ListVirrus.Count; i < PosInstantiateVirrus.Count; ++i)
        {
            NewPosInstantiateVirrus.Add(PosInstantiateVirrus[i].position);
        }
    }

    private void InstaneAtNewPos(Vector3 oldPos, int index)
    {
        maxDie[index] -= 1;
        NewPosInstantiateVirrus.Add(oldPos);
        if (maxDie[index] > 0)
        {
            Virrus newVirrus = Instantiate(ListVirrus[index], NewPosInstantiateVirrus[0], Quaternion.identity);
            newVirrus.SetIndex(index);
            NewPosInstantiateVirrus.RemoveAt(0);
        }
        else
        {
            UpdateDiedVirrus();
        }
    }

    private void UpdateDiedVirrus()
    {
        cntDiedVirrus += 1;
        if(cntDiedVirrus == ListVirrus.Count)
        {
            ToolManager.ins.StartBubble();
            GameScene51Manager.ins.car.ActiveListSoapBalls();
        }
    }
}
