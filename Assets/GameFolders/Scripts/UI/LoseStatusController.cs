using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseStatusController : MonoBehaviour
{
    public static LoseStatusController instance;

    void Awake()
    {
        instance = this;
    }


    public void TryAgainButtonHandle()
    {
        LevelManager.gameState = GameState.Finish;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
