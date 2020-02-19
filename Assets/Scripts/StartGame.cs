using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private int player1Team, player2Team;
    // Start is called before the first frame update
    void Start()
    {
        player1Team = 1;
        player2Team = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpGame()
    {
        //Debug.Log(player1Team +" "+ player2Team);
        PlayerPrefs.SetInt("Player1Team", player1Team);
        PlayerPrefs.SetInt("Player2Team", player2Team);
        SceneManager.LoadScene("Scenes/SampleScene");
    }

    public void SetPlayer1Team(int team)
    {
        player1Team = team;
    }
    public void RandomPlayer1Team()
    {
        player1Team = Random.Range(1, 4);
    }
    public void SetPlayer2Team(int team)
    {
        player2Team = team;
    }
    public void RandomPlayer2Team()
    {
        player2Team = Random.Range(1, 4);
    }
}
