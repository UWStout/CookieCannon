using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterHit : MonoBehaviour
{
    public float despawnTime = 0.5f;

    private float timer;
    private bool hit;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        hit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hit)
        {
            timer += Time.deltaTime;

            if (timer >= despawnTime)
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
        hit = true;
    }
}
