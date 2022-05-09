using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.PlayerLoop;

public class SwitchTurnController : MonoBehaviour
{
    #region Singleton Pattern
    public static SwitchTurnController instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    [Header("GameObjects")] 
    [SerializeField] private GameObject playerHand;
    [SerializeField] private GameObject enemyHand;
    [SerializeField] private GameObject tutorialUI;

    [Header("Position Staff")]
    [SerializeField] private PositionSetter posSetter;
    private Vector3 enemyStartPos;
    private Vector3 playerStartPos;

    [Header("Boolean")]
    public bool myTurn;

    [Header("Water System")] 
    [SerializeField] private ParticleSystem particleSystem;
    [SerializeField] private WaterShape waterShape;
    [SerializeField] private EnemyHandController enemyHandControllerSc;
    private ParticleSystem.EmissionModule emModule;


    public bool LeftMouseClicked => Input.GetMouseButton(0);
    public bool LeftMouseUp => Input.GetMouseButtonUp(0);

    void Start()
    {
        enemyStartPos = enemyHand.transform.parent.localPosition;
        playerStartPos = playerHand.transform.localPosition;
    }

    void Update()
    {
        if (LevelManager.gameState == GameState.Normal)
            if (myTurn)
                if (LeftMouseClicked)
                {
                    tutorialUI.SetActive(false);
                    playerHand.transform.localEulerAngles =
                        Vector3.Lerp(playerHand.transform.localEulerAngles, new Vector3(0, 0, 100), .01f);

                    if (playerHand.transform.localEulerAngles.z > 10)
                    {
                        emModule = particleSystem.emission;
                        emModule.rateOverTimeMultiplier += .2f;
                        emModule.rateOverTimeMultiplier = Mathf.Clamp(emModule.rateOverTimeMultiplier, 0, 20);
                        waterShape.SetBlendValue(-.015f);
                    }
                }
    }


    public void PlayerTurn()
    {
        StartCoroutine(PlayerTurnCo());
    }

    public void EnemyTurn()
    {
        StartCoroutine(EnemyTurnCo());
    }

    IEnumerator PlayerTurnCo()
    {
        myTurn = true;

        CinemachineBehaviour(posSetter.Camera3Pos, posSetter.Camera3Rot, 1.5f);

        playerHand.transform.DOLocalMove(posSetter.PlayerTargetPos, 1f).OnComplete(() =>
        {
            if (GameManager.FirstLevel == 1) tutorialUI.SetActive(true);
        });


        yield return new WaitUntil(() => LeftMouseUp);
        emModule.rateOverTimeMultiplier = 0;
        GameManager.FirstLevel++;
        playerHand.transform.DOLocalRotateQuaternion(Quaternion.identity, .75f).OnComplete(() =>
            playerHand.transform.DOLocalMove(playerStartPos, 2)).OnStart(() =>
            CinemachineBehaviour(posSetter.Camera2Pos, posSetter.Camera2Rot, 1.5f));

        yield return new WaitForSeconds(1);
        myTurn = false;
        if (LevelManager.gameState == GameState.Normal) EnemyTurn();
    }

    IEnumerator EnemyTurnCo()
    {
        var t = Random.Range(2f, 4.1f);

        enemyHand.transform.parent.DOLocalMove(posSetter.EnemyTargetPos, 1f).OnComplete(() =>
        {
            var f = 1;

            DOTween.To(() => f, x => f = x, 0, t).OnUpdate(() =>
            {
                enemyHandControllerSc.RotateFunction(enemyHand.transform);
            }).OnComplete(() =>
            {
                enemyHandControllerSc.RotateFunctionFinish(enemyHand.transform);
                enemyHand.transform.parent.DOLocalMove(enemyStartPos, 1).OnComplete(() =>
                {
                    myTurn = true;
                    if (LevelManager.gameState == GameState.Normal) PlayerTurn();
                });
            });
        });


        yield return new WaitForSeconds(t + .001f);
    }


    private void CinemachineBehaviour(Vector3 pos, Vector3 rot, float time)
    {
        CinemachineController.instance.ChangeCamPosInTime(pos, time, false);
        CinemachineController.instance.ChangeCamRotInTime(rot, time, false);
    }

}
