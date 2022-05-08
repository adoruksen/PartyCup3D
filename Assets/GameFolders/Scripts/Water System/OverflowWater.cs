using UnityEngine;
using DG.Tweening;

public class OverflowWater : MonoBehaviour
{
    float fullBlendValue = 100;

    float particleRate = 100;

    [SerializeField] SkinnedMeshRenderer glassMesh;
    [SerializeField] ParticleSystem particleSystem;

    public static bool gameOver = false;


    void Start()
    {
        particleSystem.emissionRate = 0;
    }

    public void OverflowStart()
    {
        gameOver = true;

        DOTween.To(() => fullBlendValue, x => fullBlendValue = x, 0, 3).OnUpdate(() =>
        {
            glassMesh.SetBlendShapeWeight(0, fullBlendValue);
        });

        DOTween.To(() => particleRate, x => particleRate = x, 0, 3).OnUpdate(() =>
        {
            particleSystem.emissionRate = particleRate;
        });

    }
}
