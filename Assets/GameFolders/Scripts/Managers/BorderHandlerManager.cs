using System.Collections.Generic;
using UnityEngine;

public class BorderHandlerManager : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer blendShape;

    public List<float> borders = new List<float>();

    public List<GameObject> levelsObj;

    int currentLevel = 0;

    public static BorderHandlerManager Instance;
    private void Start()
    {
        Instance = this;
    }
    public void MoneyLevel()
    {
        float f = blendShape.GetBlendShapeWeight(0);

        if (currentLevel<borders.Count)
        {
            if (f > borders[currentLevel])
            {
                Debug.Log("SU SEVIYESINI GECTI");
                levelsObj[currentLevel].GetComponent<SingleBorder>().DoSomeMath(levelsObj[currentLevel].GetComponent<SingleBorder>().operation, levelsObj[currentLevel].GetComponent<SingleBorder>().value);
                currentLevel++;
            }
        }
    }
}
