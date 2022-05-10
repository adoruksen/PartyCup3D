using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DuringGamePanelController : MonoBehaviour
{
    public static DuringGamePanelController instance;
    [SerializeField] private TMP_Text levelText;

    void Awake()
    {
        instance = this;
        levelText.text = $"LEVEL {GameManager.Level}";
    }

    public void RetryButtonHandle()
    {
        LevelManager.gameState = GameState.Finish;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
