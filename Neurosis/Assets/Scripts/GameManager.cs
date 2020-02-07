using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
    }

    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }

    public void LoadInstructions(){
        SceneManager.LoadScene("Instructions");
    }
    
    public void BackToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Restart(){
        SceneManager.LoadScene("MainMenu");
    }

    public void GameOver(){
        SceneManager.LoadScene("GameOver");
    }

    public void QuitGame(){
        Application.Quit();
}
}
