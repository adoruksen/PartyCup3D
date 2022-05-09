using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] SwitchTurnController switchTurnController;

    public static InteractionController Instance;
    private void Start()
    {
        Instance = this;
    }

    public void WinControllerFunction()
    {
        if (switchTurnController.myTurn)
        {

            Debug.Log("KAYBETTIK");
        }
        else
        {
            Debug.Log("KAZANDIK");
            MoneyCaseController.instance.MoneyOpener(MoneyController.instance.PlayerMoneyCount);

        }
    }


    
}
