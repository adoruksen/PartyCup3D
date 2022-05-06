using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderHandlerManager : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer blendShape;

    public List<float> borders = new List<float>();

    public List<GameObject> levelssObj;

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
                levelssObj[currentLevel].GetComponent<SingleBorder>().DoSomeMath(levelssObj[currentLevel].GetComponent<SingleBorder>().operation, levelssObj[currentLevel].GetComponent<SingleBorder>().value);
                currentLevel++;
            }
        }
    }
}
