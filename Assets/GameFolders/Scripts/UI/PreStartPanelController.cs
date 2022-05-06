using UnityEngine;

public class PreStartPanelController : MonoBehaviour
{
    [SerializeField] private PositionSetter posSetter;
    public void GameStarterTapping()
    {
        LevelManager.gameState = GameState.Normal;
        gameObject.SetActive(false);
        CinemachineController.instance.ChangeCamPosInTime(posSetter.Camera2Pos,.5f,false);
        CinemachineController.instance.ChangeCamRotInTime(posSetter.Camera2Rot, .5f, false);
        DuringGamePanelController.instance.transform.GetChild(0).gameObject.SetActive((true));
    }

}
