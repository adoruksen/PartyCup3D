using UnityEngine;
using DG.Tweening;

public class EnemyHandController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private WaterShape waterShape;

    public void RotateFunction(Transform hand)
    {
        hand.transform.localEulerAngles = Vector3.Lerp(hand.transform.localEulerAngles, new Vector3(0, 0, 100), .01f);
        if (!(hand.transform.localEulerAngles.z < 340)) return;
        particleSystem.emissionRate += .2f;
        particleSystem.emissionRate = Mathf.Clamp(particleSystem.emissionRate, 0, 20);
        waterShape.SetBlendValue(-.015f);
    }

    public void RotateFunctionFinish(Transform hand)
    {
        particleSystem.emissionRate = 0;
        //hand.transform.localEulerAngles = Vector3.zero;
        hand.transform.DOLocalRotateQuaternion(Quaternion.identity, .75f);

    }
}