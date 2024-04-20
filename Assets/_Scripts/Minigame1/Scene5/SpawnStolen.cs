using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStolen : MonoBehaviour
{
    [SerializeField] List<StolenThing> ListStolens;

    public void Spawn(Vector3 start, Vector3 end)
    {
        int ran = Random.Range(0, ListStolens.Count);
        SoundManager.Instance.PlaySFXOneShot(SoundTag.Eff_object_put_01);
        StolenThing thing = Instantiate(ListStolens[ran], start, Quaternion.identity);

        thing.Move(end.y);
    }

  
  
}
