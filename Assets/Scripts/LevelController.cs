using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public GameObject[] cookies;
    GameObject cookie1, cookie2;

    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        cookie1 = Instantiate(cookies[PlayerPrefs.GetInt("Player1Team") - 1],  new Vector3(0,0,0), Quaternion.identity);
        cookie2 = Instantiate(cookies[PlayerPrefs.GetInt("Player2Team") - 1], new Vector3(Random.Range(75f, 90f), 0, 0), Quaternion.identity);
        cookie2.transform.Rotate(new Vector3(0, 180, 0));

        cookie1.GetComponent<CookieController>().team = 1;
        cookie2.GetComponent<CookieController>().team = 2;

        Camera.main.GetComponent<CameraFollowProjectile>().cookies.Add(cookie1);
        Camera.main.GetComponent<CameraFollowProjectile>().cookies.Add(cookie2);
        Camera.main.GetComponent<Launch>().cookies.Add(cookie1);
        Camera.main.GetComponent<Launch>().cookies.Add(cookie2);
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver && Input.anyKey)
        {
            SceneManager.LoadScene("Scenes/MainMenu");
        }
    }

    public void Victory(int defeatedTeam)
    {
        isGameOver = true;

        Component[] animators;
        if (defeatedTeam == 1)
        {
            animators = cookie2.GetComponentsInChildren<Animator>();
            GetComponentInChildren<Text>().text = "Player 1 Wins!";
        }
        else
        {
            animators = cookie1.GetComponentsInChildren<Animator>();
            GetComponentInChildren<Text>().text = "Player 2 Wins!";
        }

        foreach(Animator anim in animators)
        {
            anim.SetTrigger("Win");
        }

        
    }
}
