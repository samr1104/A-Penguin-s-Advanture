using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioSource audioSrc;
    public static AudioClip pushBox;
    public static AudioClip bombExplosion;
    public static AudioClip click;
    public static AudioClip damage;
    public static AudioClip playerDie;
    public static AudioClip EleUp;
    public static AudioClip EleDown;
    public static AudioClip pickupItem;
    public static AudioClip recovery;
    public static AudioClip slide;
    public static AudioClip waterSplash;
    public static AudioClip playerWin;
    public static AudioClip trigger;
    public static AudioClip appear;



    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        pushBox = Resources.Load<AudioClip>("push_box");
        bombExplosion = Resources.Load<AudioClip>("bomb1");
        click = Resources.Load<AudioClip>("Click");
        damage = Resources.Load<AudioClip>("damage");
        playerDie = Resources.Load<AudioClip>("die");
        EleUp = Resources.Load<AudioClip>("elevator_up");
        EleDown = Resources.Load<AudioClip>("elevator_down");
        pickupItem = Resources.Load<AudioClip>("pick_up_item");
        recovery = Resources.Load<AudioClip>("recovery");
        slide = Resources.Load<AudioClip>("slide");
        waterSplash = Resources.Load<AudioClip>("WaterSplash");
        trigger = Resources.Load<AudioClip>("trigger");
        playerWin = Resources.Load<AudioClip>("Victory");
        appear = Resources.Load<AudioClip>("Jump2");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SoundManager.PlayClickClip();

        }
    }

    public static void PlayPushBoxClip()
    {
        audioSrc.PlayOneShot(pushBox);
    }

    public static void PlayBombClip()
    {
        audioSrc.PlayOneShot(bombExplosion);
    }

    public static void PlayClickClip()
    {
        audioSrc.PlayOneShot(click);
    }

    public static void PlayDamageClip()
    {
        audioSrc.PlayOneShot(damage);
    }

    public static void PlayDieClip()
    {
        audioSrc.PlayOneShot(playerDie);
    }

    public static void PlayEleUpClip()
    {
        audioSrc.PlayOneShot(EleUp);
    }

    public static void PlayEleDownClip()
    {
        audioSrc.PlayOneShot(EleDown);
    }

    public static void PlayPickUpItemClip()
    {
        audioSrc.PlayOneShot(pickupItem);
    }

    public static void PlayRecoveryClip()
    {
        audioSrc.PlayOneShot(recovery);
    }

    public static void PlaySlideClip()
    {
        audioSrc.PlayOneShot(slide);
    }

    public static void PlayWaterClip()
    {
        audioSrc.PlayOneShot(waterSplash);
    }

    public static void PlayTriggerClip()
    {
        audioSrc.PlayOneShot(trigger);
    }

    public static void PlayWinClip()
    {
        audioSrc.PlayOneShot(playerWin);
    }

    public static void PlayAppearClip()
    {
        audioSrc.PlayOneShot(appear);
    }
}
