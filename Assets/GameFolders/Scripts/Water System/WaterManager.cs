using UnityEngine;

public class WaterManager : MonoBehaviour
{
    public GameObject middleGlass;

    public static WaterManager instance;
    void Start()
    {
        instance = this;
    }
}
