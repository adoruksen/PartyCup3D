using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortuneWheelController : MonoBehaviour
{
    public static FortuneWheelController instance;

    [SerializeField] Transform innerWheel;
    [SerializeField] List<GameObject> turnList;
    [SerializeField] List<AnimationCurve> animationCurves;

    [System.NonSerialized] public bool isYou = false;


    bool spinning;
    public static bool isFinished =false;
    float anglePerItem;
    int randomTime;
    int itemNumber;

    private void Awake()
    {
        instance = this;
        spinning = false;
        anglePerItem = 360 / turnList.Count;
    }
    void Start()
    {
        if (transform.GetChild(0).gameObject.activeInHierarchy)
        {
            if (!spinning)
            {
                randomTime = Random.Range(1, 4);
                itemNumber = Random.Range(0, turnList.Count);
                float maxAngle = 360 * randomTime + (itemNumber * anglePerItem);

                StartCoroutine(SpinTheWheel(2 * randomTime, maxAngle));
            }
        }
    }

    IEnumerator SpinTheWheel(float time, float maxAngle)
    {
        spinning = true;

        float timer = 0.0f;
        float startAngle = innerWheel.localEulerAngles.z;
        maxAngle -= startAngle;

        int animationCurveNumber = Random.Range(0, animationCurves.Count);

        while (timer < time)
        {
            float angle = maxAngle * animationCurves[animationCurveNumber].Evaluate(timer / time);
            innerWheel.localEulerAngles = new Vector3(0.0f, 0.0f, angle + startAngle) ;
            timer += Time.deltaTime;
            yield return 0;
        }

        innerWheel.localEulerAngles = new Vector3(0.0f, 0.0f, maxAngle + startAngle);

        spinning = false;

        isFinished = true;
        if (isFinished)
        {
            if (itemNumber == 0)
            {
                isYou = true;
                SwitchTurnController.instance.PlayerTurn();
            }
            else
            {
                SwitchTurnController.instance.EnemyTurn();
            }
        }

        Debug.Log("wheelde " +turnList[itemNumber]);
        transform.GetChild(0).gameObject.SetActive(false);

        LevelManager.gameState = GameState.Normal;
    }
}
