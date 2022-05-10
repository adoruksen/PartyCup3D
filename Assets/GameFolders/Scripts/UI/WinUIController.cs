using UnityEngine;
using UnityEngine.SceneManagement;



public class WinUIController : MonoBehaviour
{
    public static WinUIController instance;

    void Awake()
    {
        instance = this;
    }


    public void NextButtonHandle()
    {
        LevelManager.gameState = GameState.Finish;
        GameManager.Level++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
