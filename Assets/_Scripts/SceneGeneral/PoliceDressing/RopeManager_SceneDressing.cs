using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeManager_SceneDressing: MonoBehaviour
{
    [SerializeField] Rope_SceneDressing leftRope;
    [SerializeField] Rope_SceneDressing rightRope;
    public int cntEquipRope;
    public float timeDelayBetween2Rope;
    public delegate void UpdateEquipped();
    public static UpdateEquipped updateEquipped;
    private void OnEnable()
    {
        updateEquipped += UpdateEquippedRope;
    }

    private void OnDestroy()
    {
        updateEquipped -= UpdateEquippedRope;
    }
    public void StartTurn()
    {
        StartCoroutine(StartMoveRope());
    }

    IEnumerator StartMoveRope()
    {
        leftRope.StartTurn();
        yield return new WaitForSeconds(timeDelayBetween2Rope);
        rightRope.StartTurn();
    }

    private void UpdateEquippedRope()
    {
        cntEquipRope++;
        if (cntEquipRope == 2)
        {
            cntEquipRope = 0;
            GameSceneDressingManager.ins.UpdateTurn();
        }
    }
}
