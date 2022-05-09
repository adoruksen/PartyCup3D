using System.Collections;
using UnityEditor;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    [SerializeField] SwitchTurnController switchTurnController;
    [SerializeField] private PositionSetter posSetter;

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
            StartCoroutine(WinStatusCo());

        }
    }

    IEnumerator WinStatusCo()
    {
        CinemachineController.instance.FinishScene();
        CinemachineController.instance.ChangeCamPosInTime(posSetter.Camera4Pos, .75f, false);
        CinemachineController.instance.ChangeCamRotInTime(posSetter.Camera4Rot, .75f, false);
        yield return new WaitForSeconds(1);
        MoneyCaseController.instance.MoneyOpener(MoneyController.instance.PlayerMoneyCount);
    }


    
}
