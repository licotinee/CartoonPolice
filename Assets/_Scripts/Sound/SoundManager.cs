
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public List<Sound> BG_Sound, Sfx_Sound;
    public AudioSource BG_Source;
    public AudioSource Sfx_Source;
    public AudioSource Sfx_Soure_Loop;
    public AudioSource Sfx_Soure_PlayOneShot;


    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        this.PlayBGM(SoundTag.Bgm_home);

        

    }


    public void PlaySFX(SoundTag soundTag)
    {

        foreach (Sound s in Sfx_Sound)
        {
            if (s.tag == soundTag)
            {
                Sfx_Source.volume = s.volume;
                Sfx_Source.clip = s.clip;
                Sfx_Source.loop = false;
                Sfx_Source.Play();
                break;
            }
        }
    }

    public void PlaySFXOneShot(SoundTag soundTag)
    {
        foreach (Sound s in Sfx_Sound)
        {
            if (s.tag == soundTag)
            {
                Sfx_Soure_PlayOneShot.PlayOneShot(s.clip);
                break;
            }
        }
    }
    public void PlaySfxLoop(SoundTag soundTag)
    {
        foreach (Sound s in Sfx_Sound)
        {
            if (s.tag == soundTag)
            {
                Sfx_Soure_Loop.volume = s.volume;
                Sfx_Soure_Loop.clip = s.clip;
                Sfx_Soure_Loop.loop = true;
                Sfx_Soure_Loop .Play();
                break;
            }
        }
    }

    public void StopSfxLoop()
    {
        Sfx_Soure_Loop.Stop();
    }


    public void PlayBGM(SoundTag soundTag)
    {

        foreach (Sound s in BG_Sound)
        {
            if (s.tag == soundTag)
            {

                BG_Source.volume = s.volume;
                BG_Source.clip = s.clip;
                BG_Source.loop = true;
                BG_Source.Play();
                break;
            }
        }
    }

    public void StopCurrentBG()
    {
        BG_Source.Pause();
    }
    public void ContinueCurrentBG()
    {
        BG_Source.UnPause();
    }
    public void StopCurrentSFX()
    {
        //foreach (AudioSource audio in Sfx_Source)
        //    audio.Stop();
    }

    //public void PlaySFX(SoundTag soundTag)
    //{
    //    for (int i = 0; i < Sfx_Sound.Count; i++)
    //    {
    //        if (Sfx_Sound[i].tag == soundTag)
    //        {
    //            for (int j = 0; j < Sfx_Source.Count; j++)
    //            {
    //                if (Sfx_Source[j].isPlaying && j != Sfx_Source.Count - 1)
    //                    continue;
    //                else if (Sfx_Source[j].isPlaying && j == Sfx_Source.Count - 1)
    //                {
    //                    GameObject SFX_Source = new GameObject();
    //                    SFX_Source.transform.parent = this.transform;

    //                    AudioSource new_source = SFX_Source.AddComponent<AudioSource>();
    //                    new_source.volume = Sfx_Sound[i].volume;
    //                    new_source.clip = Sfx_Sound[i].clip;
    //                    new_source.Play();
    //                    Sfx_Source.Add(new_source);
    //                    break;
    //                }
    //                else
    //                {
    //                    Sfx_Source[j].volume = Sfx_Sound[i].volume;
    //                    Sfx_Source[j].clip = Sfx_Sound[i].clip;
    //                    Sfx_Source[j].Play();
    //                    return;
    //                }
    //            }
    //        }
    //    }
    //}
}



