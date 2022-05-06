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

    //[SerializeField] private WaterShape waterShape;


    public bool LeftMouseClicked => Input.GetMouseButton(0);
    public bool LeftMouseUp => Input.GetMouseButtonUp(0);

    void Start()
    {
        enemyStartPos = enemyHand.transform.position;
        playerStartPos = playerHand.transform.position;
    }

    void Update()
    {
        if (LevelManager.gameState == GameState.Normal)
            if (myTurn)
                if (LeftMouseClicked)
                {
                    playerHand.transform.eulerAngles =
                        Vector3.Lerp(playerHand.transform.eulerAngles, new Vector3(0, 0, 100), .01f);

                    if (playerHand.transform.eulerAngles.z > 10)
                    {
                        particleSystem.emissionRate += .03f;
                        particleSystem.emissionRate = Mathf.Clamp(particleSystem.emissionRate, 0, 15);
                        //waterShapeSc.setBlendValue(-.015f);
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
        //Clear My EnemyTurn Position

        enemyHand.transform.DOMove(enemyStartPos, .5f);
        CinemachineBehaviour(posSetter.Camera3Pos, posSetter.Camera3Rot, 1.5f);
        if (GameManager.FirstLevel == 1) tutorialUI.SetActive(true);

        playerHand.transform.DOLocalMove(posSetter.PlayerTargetPos, 1f);

        yield return new WaitUntil(() => LeftMouseUp);

        particleSystem.emissionRate = 0;
        GameManager.FirstLevel++;
        tutorialUI.SetActive(false);

        playerHand.transform.DOLocalRotateQuaternion(Quaternion.identity, .75f).OnComplete(() =>
            playerHand.transform.DOMove(playerStartPos, 2)).OnStart(() =>
            CinemachineBehaviour(posSetter.Camera2Pos, posSetter.Camera2Rot, 1.5f));

        yield return new WaitForSeconds(1);
        if (LevelManager.gameState == GameState.Normal) EnemyTurn();
    }

    IEnumerator EnemyTurnCo()
    {
        myTurn = false;

        //Clear My Hand Position
        var t = Random.Range(2f, 4.1f);

        enemyHand.transform.DOMove(posSetter.EnemyTargetPos, 1f).OnComplete(() =>
        {
            var f = 1;

            DOTween.To(() => f, x => f = x, 0, t).OnUpdate(() =>
            {
                //handEnemyRotateGlass.RotateFunc(enemyHand.transform);
            }).OnComplete(() =>
            {
                //handEnemyRotateGlass.RotateFunctionFinish(enemyHand.transform);
                enemyHand.transform.DOMove(enemyStartPos, 1);
                if (LevelManager.gameState == GameState.Normal) PlayerTurn();
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
