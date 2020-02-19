using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 1;

    private float health;
    private Slider healthBar;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        healthBar = gameObject.GetComponentInChildren<Slider>();
        //start with full health
        health = maxHealth;
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //update the healthbar with the current health if there is a health bar
        if (healthBar != null)
        {
            healthBar.value = health;
        }
    }

    //function that is called by the object that is doing the damage
    public void TakeDamage(float damage)
    {
        //make sure damage will not increase health
        if (damage > 0)
        {
            health -= damage;

            //Run the death function if health is lowered to 0 or lower
            if(health <= 0 && !isDead)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        isDead = true;
        if (GetComponent<Animator>() != null)
        {
            GetComponent<Animator>().SetTrigger("Dead");
            if(gameObject.tag == "Target")
            {
                GetComponentInParent<CookieController>().TargetDestroyed();
            }
            Destroy(gameObject, 3);
        }
    }
}
