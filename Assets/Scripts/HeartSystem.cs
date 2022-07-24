using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    public Image[] hearts;
    public int life = 3;
    public bool dead = false;

    private bool invulnerable;
    private float timer;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        foreach (Image img in hearts)
        {
            img.sprite = fullHeart;
        }
        invulnerable = false;
        timer = 0f;
    }

    void Update()
    {
        if(dead)
        {
            // SET DEAD
            gameObject.SetActive(false);
        }

        if(invulnerable)
        {
            // count invulnerable time, then set back to vulnerable
            timer += Time.deltaTime;
            if(timer >= 1f)
            {
                invulnerable = false;
                timer = 0f;
            }
        }

        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }
        for(int i = 0; i < life; i++){
            hearts[i].sprite = fullHeart;
        }
    }

    public void TakeDamage()
    {
        if(life >= 1 && !invulnerable)
        {
            life -= 1;
            // Destroy(hearts[life].gameObject);
            // audio
            SoundManager.PlayDamageClip();

            invulnerable = true;
            if(life < 1)
            {
                dead = true;
                // audio
                SoundManager.PlayDieClip();
            }
        }
    }

    public void GetHeal()
    {
        if(life < 3)
        {
            life += 1;
            // audio
            SoundManager.PlayRecoveryClip();
        }
    }
}
