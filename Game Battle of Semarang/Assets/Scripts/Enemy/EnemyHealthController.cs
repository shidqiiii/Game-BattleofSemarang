using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public static EnemyHealthController instance;

    public GameObject deathEffect, collectible;
    public int currentHealth, maxHealth;

    public float damageTime;
    private float countTimeDamage;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Invincibility();
    }

    public void DealDamage()
    {
        currentHealth--;
        EnemyController.instance.theSR.color = new Color(EnemyController.instance.theSR.color.r, EnemyController.instance.theSR.color.g, EnemyController.instance.theSR.color.b, .5f);
        countTimeDamage = damageTime;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            Instantiate(collectible, transform.position, transform.rotation);
        }

    }

    public void Invincibility()
    {
        if (countTimeDamage > 0)
        {
            countTimeDamage -= Time.deltaTime;

            if (countTimeDamage <= 0)
            {
                EnemyController.instance.theSR.color = new Color(EnemyController.instance.theSR.color.r, EnemyController.instance.theSR.color.g, EnemyController.instance.theSR.color.b, 1f);
            }
        }
    }
}
