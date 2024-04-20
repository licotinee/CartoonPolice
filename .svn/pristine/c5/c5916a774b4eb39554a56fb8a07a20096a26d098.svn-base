using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] GameObject button;
    [SerializeField] GameObject tube;
    [SerializeField] Light_Scene6_8 light;
    [SerializeField] Transform posSpawnLight;
    [SerializeField] ShadeBg shadeBg;
    [SerializeField] ListPhoto_Scene6_8 listPhotos;
    bool isTaking;
    private void OnMouseDown()
    {
        if (!isTaking && !GameScene86Manager.ins.isEndGame && GameScene86Manager.ins.isStartGame)
        {
            TakePhoto();
        }
    }

    void TakePhoto()
    {
        StartCoroutine(StartTakePhoto());
    }

    IEnumerator StartTakePhoto()
    {
        // Instantiate Light
        Light_Scene6_8 newLight = Instantiate(light, posSpawnLight.position, Quaternion.identity);
        newLight.ScaleUp(0.25f + 0.3f); // Time from click to take photo


        isTaking = true;
        float eslapsed = 0;
        float seconds = 0.25f;

        float startScaleYTube = tube.transform.localScale.y;
        float endScaleYTube = 0.95f * startScaleYTube;

        Vector3 start, end;
        start = button.transform.position;
        end = start - new Vector3(0, 0.5f, 0);



        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            button.transform.position = Vector3.Lerp(start, end, eslapsed/seconds);
            tube.transform.localScale = new Vector3(tube.transform.localScale.x, startScaleYTube + (endScaleYTube - startScaleYTube) * (eslapsed / seconds), tube.transform.localScale.z);
            yield return new WaitForEndOfFrame();                 
        }
        button.transform.position = end;
        tube.transform.localScale = new Vector3(tube.transform.localScale.x, endScaleYTube, tube.transform.localScale.z);



        eslapsed = 0;
        seconds = 0.3f;
        start = button.transform.position;
        end = start + new Vector3(0, 0.25f, 0);

        endScaleYTube = startScaleYTube;
        startScaleYTube = tube.transform.localScale.y;

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            button.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            tube.transform.localScale = new Vector3(tube.transform.localScale.x, startScaleYTube + (endScaleYTube - startScaleYTube) * ( eslapsed / seconds), tube.transform.localScale.z);
            yield return new WaitForEndOfFrame();
        }
        button.transform.position = end;
        tube.transform.localScale = new Vector3(tube.transform.localScale.x, endScaleYTube, tube.transform.localScale.z);

        Instantiate(shadeBg, Vector3.zero, Quaternion.identity);

        eslapsed = 0;
        seconds = 0.2f;
        start = button.transform.position;
        end = start + new Vector3(0, 0.25f, 0);

        while (eslapsed <= seconds)
        {
            eslapsed += Time.deltaTime;
            button.transform.position = Vector3.Lerp(start, end, eslapsed / seconds);
            yield return new WaitForEndOfFrame();
        }
        button.transform.position = end;

        yield return new WaitForSeconds(0.25f);
        listPhotos.GetPhoto(0.25f);
        yield return new WaitForSeconds(0.25f);
        //
        isTaking = false;
    }
}
