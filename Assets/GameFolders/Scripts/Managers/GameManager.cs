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

    static int level;
    public static int Level
    {
        get
        {
            if (!PlayerPrefs.HasKey("level"))
            {
                return 1;
            }
            return PlayerPrefs.GetInt("level");
        }
        set
        {
            level = value;
            PlayerPrefs.SetInt("level", level);
        }
    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("level"))
        {
            PlayerPrefs.SetInt("level", 1);
        }

        if (!PlayerPrefs.HasKey("firstLevel"))
        {
            PlayerPrefs.SetInt("firstLevel", 1);
        }
    }
}
