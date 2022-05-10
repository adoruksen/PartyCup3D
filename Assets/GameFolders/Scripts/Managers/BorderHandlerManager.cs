using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BorderHandlerManager : MonoBehaviour
{
    [SerializeField] SkinnedMeshRenderer blendShape;

    public List<float> borders = new List<float>();

    public List<GameObject> levelsObj;

    int currentLevel = 0;

    public static BorderHandlerManager Instance;
    private void Awake()
    {
        Instance = this;
    }

   
    public void MoneyLevel()
    {
        float blendShapeWeight = blendShape.GetBlendShapeWeight(0);

        if (currentLevel<borders.Count)
        {
            if (blendShapeWeight > borders[currentLevel])
            {
                Debug.Log("SU SEVIYESINI GECTI");
                levelsObj[currentLevel].transform.DOScale(new Vector3(.25f, .25f, .25f), .5f);
                levelsObj[currentLevel].GetComponent<SingleBorder>().DoSomeMath(levelsObj[currentLevel].GetComponent<SingleBorder>().operation, levelsObj[currentLevel].GetComponent<SingleBorder>().value);
                currentLevel++;
            }
        }
    }
}
