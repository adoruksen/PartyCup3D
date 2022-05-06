using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] SwitchTurnController switchTurnController;

    public static InteractionController Instance;
    private void Start()
    {
        Instance = this;
    }

    public void winControllerFunction()
    {
        if (switchTurnController.myTurn)
        {

            Debug.Log("KAYBETTIK");
        }
        else
        {
            Debug.Log("KAZANDIK");
        }
    }


    
}
