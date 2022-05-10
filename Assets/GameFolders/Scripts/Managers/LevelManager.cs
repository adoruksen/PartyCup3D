using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static GameState gameState;
    public LevelAsset levelAsset;

    private void Start()
    {
        //SceneLoadLayer.instance.SceneLoadAnimation();
        CreateLevel();

    }
    void CreateLevel()
    {
        if (GameManager.Level <= levelAsset.levels.Length)
        {
            GameObject levelBorder = Instantiate(levelAsset.levels[GameManager.Level - 1]);

            BorderHandlerManager.Instance.levelsObj.Clear();

            for (int i = 0; i < levelBorder.transform.childCount; i++)
            {
                BorderHandlerManager.Instance.levelsObj.Add(levelBorder.transform.GetChild(i).gameObject);

            }


        }
        else
        {
            GameObject levelBorder = Instantiate(levelAsset.levels[Random.Range(0, levelAsset.levels.Length)]);
            BorderHandlerManager.Instance.levelsObj.Clear();

            for (int i = 0; i < levelBorder.transform.childCount; i++)
            {
                BorderHandlerManager.Instance.levelsObj.Add(levelBorder.transform.GetChild(i).gameObject);

            }
        }
    }

}



