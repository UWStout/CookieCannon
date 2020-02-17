using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 1;

    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInChildren<Slider>() != null)
        {
            gameObject.GetComponentInChildren<Slider>().value = health;
        }
    }

    public void TakeDamage(int damage)
    {
        if(damage > 0)
        {
            health -= damage;

            if(health <= 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {

    }
}
