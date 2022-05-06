using UnityEngine;
using UnityEngine.SceneManagement;

public class DuringGamePanelController : MonoBehaviour
{
    public static DuringGamePanelController instance;

    void Awake()
    {
        instance = this;
    }

    public void RetryButtonHandle()
    {
        LevelManager.gameState = GameState.Finish;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
