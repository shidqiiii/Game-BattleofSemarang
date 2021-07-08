using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth, maxHealth;

    public float invisibleLength;
    private float invisibleCounter;

    private SpriteRenderer theSR;

    public GameObject deathEffect;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Invincibility();
    }

    public void DealDamage()
    {
        if(invisibleCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
                Instantiate(deathEffect, transform.position, transform.rotation);
                //Jika player mati aktifkan UI
                FailedMenu.instance.SuccessfulUnsuccessful();
            }
            else
            {
                invisibleCounter = invisibleLength;
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, .5f);

                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }
        
    }

    public void Invincibility()
    {
        if (invisibleCounter > 0)
        {
            invisibleCounter -= Time.deltaTime;

            if (invisibleCounter <= 0)
            {
                theSR.color = new Color(theSR.color.r, theSR.color.g, theSR.color.b, 1f);
            }
        }
    }

    public void HealPlayer()
    {
        currentHealth++;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        UIController.instance.UpdateHealthDisplay();
    }
}
