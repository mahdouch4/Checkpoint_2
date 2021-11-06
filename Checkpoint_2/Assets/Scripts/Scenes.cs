using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class Scenes : MonoBehaviour
{
    public Text HighestScore;
    public Text CurrentScore;
    public string High;
    public string Current;
    public Scene Game;
    public void Scene0() {  
        SceneManager.LoadScene("Game");
    }  
    void Start()
    {

    }
    void Update()
    {
        High = PlayerPrefs.GetString("HighScore");
        HighestScore.text = High;
        Current = PlayerPrefs.GetString("Current");
        CurrentScore.text = Current;
    }
}
