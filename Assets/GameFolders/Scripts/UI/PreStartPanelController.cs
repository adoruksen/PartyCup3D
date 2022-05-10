using System.Collections;
using UnityEngine;

public class PreStartPanelController : MonoBehaviour
{
    [SerializeField] private PositionSetter posSetter;

    void Start()
    {
        if (GameManager.Level !=1)
        {
            CinemachineController.instance.NotFirstLevel(posSetter.Camera2Pos,posSetter.Camera2Rot);
            LevelManager.gameState = GameState.Wheel;
            FortuneWheelController.instance.enabled = true;
            FortuneWheelController.instance.transform.GetChild(0).gameObject.SetActive(true);
            DuringGamePanelController.instance.transform.GetChild(0).gameObject.SetActive((true));
            gameObject.SetActive(false);


        }
    }
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
