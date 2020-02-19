using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public float damage = 1;
    public float team;

    private bool firstHit;
    // Start is called before the first frame update
    void Start()
    {
        firstHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Health>() != null && collision.gameObject.GetComponent<Health>().enabled && team != collision.gameObject.GetComponentInParent<CookieController>().team)
        {
            if (firstHit)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
            }
            else
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage/2f);
            }
        }

        firstHit = false;
    }
}
