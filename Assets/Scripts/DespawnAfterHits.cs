using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterHits : MonoBehaviour
{
    public int numOfHits = 3;

    private int hits;
    private float timer, despawnTime = 6;
    // Start is called before the first frame update
    void Start()
    {
        hits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(hits > 0)
        {
            timer += Time.deltaTime;

            if(timer > despawnTime)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnDestroy()
    {
        if (gameObject.tag == "Projectile")
        {
            Camera.main.GetComponent<Launch>().enabled = true;
            Camera.main.GetComponent<CameraFollowProjectile>().SwitchSides();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ++hits;
        if(hits >= numOfHits)
        {
            Destroy(gameObject);
        }
    }
}
