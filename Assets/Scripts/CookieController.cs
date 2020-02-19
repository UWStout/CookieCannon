using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
    public int numOfTargets = 5;
    public int team;
    public float sinkSpeed = 2;

    private int destroyedTargets;
    private bool destroyed;
    // Start is called before the first frame update
    void Start()
    {
        destroyedTargets = 0;
        destroyed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyed)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -100, 0), Time.deltaTime * sinkSpeed);
        }
    }

    public void TargetDestroyed()
    {
        ++destroyedTargets;
        if(destroyedTargets == numOfTargets-1)
        {
            transform.Find("Shop").GetComponent<Health>().enabled = true;
        }
        else if(destroyedTargets >= numOfTargets)
        {
            DestroyCookie();
        }
    }

    public void DestroyCookie()
    {
        Component[] entities = GetComponentsInChildren<Health>();

        foreach (Health entity in entities)
        {
            entity.Death();
        }

        GameObject.Find("LevelController").GetComponent<LevelController>().Victory(team);

        Destroy(gameObject, 5);
        destroyed = true;
    }
}
