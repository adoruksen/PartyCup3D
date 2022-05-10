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
            StartCoroutine(LoseStatusCo());
        }
        else
        {
            Debug.Log("KAZANDIK");
            StartCoroutine(WinStatusCo());

        }
    }

    IEnumerator WinStatusCo()
    {
        yield return new WaitForSeconds(2);
        CinemachineController.instance.FinishScene();
        CinemachineController.instance.ChangeCamPosInTime(posSetter.Camera4Pos, 1.5f, false);
        CinemachineController.instance.ChangeCamRotInTime(posSetter.Camera4Rot, 1.5f, false);
        yield return new WaitForSeconds(2);
        MoneyCaseController.instance.MoneyOpener(MoneyController.instance.PlayerMoneyCount);
        DuringGamePanelController.instance.transform.GetChild(0).gameObject.SetActive(false);
        WinUIController.instance.transform.GetChild(0).gameObject.SetActive(true);
    }

    IEnumerator LoseStatusCo()
    {
        yield return new WaitForSeconds(2);
        DuringGamePanelController.instance.transform.GetChild(0).gameObject.SetActive(false);
        LoseStatusController.instance.transform.GetChild(0).gameObject.SetActive(true);
    }
}
