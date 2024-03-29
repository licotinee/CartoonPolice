using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundTag
{
    Bgm_home,
    Bgm_going,
    Bgm_day_thief,
    Eff_digital,
    Eff_fail_01,
    Eff_object_guide_02, 
    Eff_object_guide_03,
    Eff_object_put_01,
    Eff_object_select_01,
    Eff_report_phone,
    Eff_report_ring,
    Eff_report_siren, 
    Eff_success_01,
    Eff_success_02,
    Eff_twinkkle_01,
    Eff_gunshot_1,
    Eff_gunshot_2,
    Eff_scanning,
    Eff_car_crash,
    Eff_virus_die,
    Eff_water_spray,
    Eff_soap_bubble,
    Eff_dry_car,
    Eff_Wolfoo_jump,
    Eff_Wolfoo_roi,
    Eff_fail_02,
    Eff_grass_broken,
    Eff_dog_bited,
    Eff_enemy_crying_airplane,
    Eff_cheer_smallwin,   
    Eff_close_door,    
    Eff_paper_firework_particle,    
    Eff_reward_star,
    Eff_take_photo
        



}

[System.Serializable]
public class Sound
{
    public SoundTag tag;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
}