using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invincibleLenght;
    private float invincibleCounter;

    private SpriteRenderer theSR;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; ;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime;
            if(invincibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b,1f);
            }
        }
    }
    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {
            currentHealth--;

            PlayerController.instance.anim.SetTrigger("Hurt");
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLenght;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                PlayerController.instance.Knockback();
            }
            UIController.instance.UpdateHealthDisplay();
        }

    }
    public void HealPlayer()
    {
        currentHealth++;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
