using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        Camera.main.GetComponent<Launch>().StopAiming();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        Camera.main.GetComponent<Launch>().ResetTarget();
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
