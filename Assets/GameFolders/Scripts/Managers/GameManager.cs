using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int firstLevel;
    public static int FirstLevel
    {
        get
        {
            if (!PlayerPrefs.HasKey("firstLevel"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("firstLevel");
        }
        set
        {
            firstLevel = value;
            PlayerPrefs.SetInt("firstLevel", firstLevel);
        }
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("firstLevel"))
        {
            PlayerPrefs.SetInt("firstLevel", 0);
        }
    }
}
