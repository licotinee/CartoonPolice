using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Table_Scene1_3 : MonoBehaviour
{
    Animator animator;
    [SerializeField] List<Image> ListToys;
    [SerializeField] float timeDelayHint;
    [SerializeField] Image fingerScanner;
    [SerializeField] Image dish;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        SetValueToys();
        RandomHint();
        
    }

    private void OnEnable()
    {
        DragToys.startDrag += StopHint;
        DragToys.endDrag += RandomHint;
        DragToys.trueDragToy += RemoveToyFromList;
    }

    private void OnDestroy()
    {
        DragToys.startDrag -= StopHint;
        DragToys.endDrag -= RandomHint;
        DragToys.trueDragToy -= RemoveToyFromList;
    }

    private void SetValueToys()
    {
        // id = 1: TeddyBear
        // id = 2: cake
        // id = 3: Milk
        for (int i = 0; i < ListToys.Count; ++i)
        {
            ListToys[i].GetComponent<DragToys>().SetId(i+1);
            ListToys[i].GetComponent<DragToys>().SetStartPos();
        }
    }

    public void RandomHint()
    {
        StartCoroutine(nameof(StartRandomHint));   
    }

    IEnumerator StartRandomHint()
    {
        while (ListToys.Count != 0)
        {
            yield return new WaitForSeconds(timeDelayHint);
            int ran = Random.Range(0, ListToys.Count);
            if (ListToys.Count != 0)
            {
                ListToys[ran].GetComponent<DragToys>().Hint();
            }
        }
    }

    public void StopHint()
    {
        StopCoroutine(nameof(StartRandomHint));
    }

    public void RemoveToyFromList(int idToy)
    {
        for (int i = 0; i < ListToys.Count; ++i)
        {
            if (ListToys[i].GetComponent<DragToys>().GetId() == idToy)
            {
                ListToys.Remove(ListToys[i]);
                break;
            }
        }
    }

    public void EnableScaning()
    {
        StartCoroutine(nameof(StartEnableScaning));
    }

    IEnumerator StartEnableScaning()
    {
        yield return new WaitForSeconds(2f);
        animator.Play("Table_MoveDown");
        var animController = animator.runtimeAnimatorController;
        var clip = animController.animationClips.First(a => a.name == "Table_MoveDown");
        float timePlayAnimMoveDown = clip.length;
        yield return new WaitForSeconds(timePlayAnimMoveDown);
        Destroy(dish.gameObject);
        fingerScanner.gameObject.SetActive(true);
        animator.Play("Table_MoveUp");
        
    }


}
