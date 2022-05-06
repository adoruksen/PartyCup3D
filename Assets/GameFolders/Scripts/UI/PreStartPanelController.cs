using System.Collections;
using UnityEngine;

public class PreStartPanelController : MonoBehaviour
{
    [SerializeField] private PositionSetter posSetter;
    public void GameStarterTapping()
    {
        LevelManager.gameState = GameState.Wheel;
        gameObject.SetActive(false);
        CinemachineController.instance.ChangeCamPosInTime(posSetter.Camera2Pos,.5f,false);
        CinemachineController.instance.ChangeCamRotInTime(posSetter.Camera2Rot, .5f, false);
        FortuneWheelController.instance.enabled = true;
        FortuneWheelController.instance.transform.GetChild(0).gameObject.SetActive(true);
        DuringGamePanelController.instance.transform.GetChild(0).gameObject.SetActive((true));
    }

}
