using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterShape : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer waterSkinMesh;
    [SerializeField] private OverflowWater overflowSc;
    public void SetBlendValue(float value)
    {
        var blendVal = waterSkinMesh.GetBlendShapeWeight(0) + value;

        BorderHandlerManager.Instance.MoneyLevel();
        if (blendVal>100)
        {
            Debug.Log(("game over"));
            LevelManager.gameState = GameState.Finish;
            InteractionController.Instance.WinControllerFunction();
            OverflowWater.gameOver = true;
            overflowSc.OverflowStart();

        }

        blendVal = Mathf.Clamp(blendVal, 0, 100);
        waterSkinMesh.SetBlendShapeWeight(0, blendVal);
    }
}
