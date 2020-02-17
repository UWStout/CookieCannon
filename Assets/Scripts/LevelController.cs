using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public GameObject[] cookies;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(cookies[PlayerPrefs.GetInt("Player1Team") - 1],  new Vector3(0,0,0), Quaternion.identity);
        Instantiate(cookies[PlayerPrefs.GetInt("Player2Team") - 1], new Vector3(Random.Range(75f, 90f), 0, 0), Quaternion.identity).transform.Rotate(new Vector3(0, 180, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
