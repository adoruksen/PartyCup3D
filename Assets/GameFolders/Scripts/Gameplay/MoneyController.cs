using DG.Tweening;
using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class MoneyController : MonoBehaviour
{
    public static MoneyController instance;

    [Header("MoneyParents")]
    [SerializeField] private Transform enemyParent;
    [SerializeField] private Transform playerParent;

    [Header("Prefab")]
    [SerializeField] private GameObject moneyPrefab;

    [Header("Lists")]
    [SerializeField] List<GameObject> playerMoneyList;
    [SerializeField] List<GameObject> enemyMoneyList;

    [Header("Texts")] 
    [SerializeField] private TMP_Text playerMoneyCountText;
    [SerializeField] private TMP_Text enemyMoneyCountText;

    public int PlayerMoneyCount => playerMoneyList.Count;
    public int EnemyMoneyCount => enemyMoneyList.Count;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoneyCaseController.instance.MoneyOpener(150);
        }
    }
    private void Awake()
    {
        instance = this;
    }

    public void AddMoney(int value)
    {
        if (SwitchTurnController.instance.myTurn)
        {
            var a = 1;
            var temp = 0;
            var valueBorder = 0;
            DOTween.To(() => a, x => a = x, 0, 3).OnUpdate(() =>
            {
                temp++;
                if (temp % 5 == 0 && valueBorder < value)
                {
                    //if (PlayerMoneyCount == 0)
                    //{
                    //    Debug.Log("kayýp");
                    //    playerMoneyList
                    //}
                    var newMoney = Instantiate(moneyPrefab, playerParent);

                    var pos = new Vector3(
                        playerMoneyList[PlayerMoneyCount - 1].transform
                            .position.x,
                        playerMoneyList[PlayerMoneyCount - 1].transform
                            .position.y + .03f,
                        playerMoneyList[PlayerMoneyCount - 1].transform
                            .position.z);

                    if (playerMoneyList[PlayerMoneyCount - 1].transform
                            .localPosition.x < +0.25f && PlayerMoneyCount > 124)
                        pos = new Vector3(
                            playerMoneyList[PlayerMoneyCount - 1]
                                .transform.position.x + .5f,
                            playerMoneyList[0].transform.position.y % 125 + .01f,
                            playerMoneyList[PlayerMoneyCount - 1]
                                .transform.position.z);
                    newMoney.transform.position = pos;
                    newMoney.transform.DOPunchScale(new Vector3(.15f, .15f, .15f), .25f, 2);
                    playerMoneyList.Add(newMoney);
                    valueBorder++;
                }
                playerMoneyCountText.text = $"${PlayerMoneyCount}";
            });
        }
        else
        {
            //if (EnemyMoneyCount == 0)
            //{
            //    Debug.Log("kayýp");
            //    return;
            //}
            var a = 1;
            var temp = 0;
            var valueBorder = 0;
            DOTween.To(() => a, x => a = x, 0, 3).OnUpdate(() =>
            {
                temp++;
                if (temp % 5 == 0 && valueBorder < value)
                {
                    var newMoney = Instantiate(moneyPrefab, enemyParent);

                    var pos = new Vector3(
                        enemyMoneyList[EnemyMoneyCount - 1].transform
                            .position.x,
                        enemyMoneyList[EnemyMoneyCount - 1].transform
                            .position.y + .03f,
                        enemyMoneyList[EnemyMoneyCount - 1].transform
                            .position.z);

                    if (enemyMoneyList[EnemyMoneyCount - 1].transform
                            .position.x > +0.6f && EnemyMoneyCount > 124)
                        pos = new Vector3(
                            enemyMoneyList[EnemyMoneyCount - 1]
                                .transform.position.x - .5f,
                            enemyMoneyList[0].transform.position.y + .01f,
                            enemyMoneyList[EnemyMoneyCount - 1]
                                .transform.position.z);
                    newMoney.transform.position = pos;
                    newMoney.transform.DOPunchScale(new Vector3(.15f, .15f, .15f), .25f, 2);
                    enemyMoneyList.Add(newMoney);
                    valueBorder++;
                }
                enemyMoneyCountText.text = $"${EnemyMoneyCount}";

            });
        }
    }


    public void SubtractMoney(int value)
    {
        if (SwitchTurnController.instance.myTurn)
        {
            //if (PlayerMoneyCount == 0)
            //{
            //    Debug.Log("kayýp");
            //    return;
            //}
            var a = 1;
            var temp = 0;
            var valueBorder = 0;
            DOTween.To(() => a, x => a = x, 0, 3).OnUpdate(() =>
            {
                temp++;
                if (temp % 5 == 0 && valueBorder < value)
                {
                    playerMoneyList[PlayerMoneyCount - 1].transform
                        .DOLocalMove(new Vector3(Random.Range(-10, 10), 10, Random.Range(-2, 2)), 1f).OnComplete(() =>
                        {
                            playerMoneyList[PlayerMoneyCount-1].SetActive(false);
                            playerMoneyList.RemoveAt(PlayerMoneyCount - 1);
                        });
                    valueBorder++;
                }
                playerMoneyCountText.text = $"${PlayerMoneyCount}";
            });

        }
        else
        {
            //if (EnemyMoneyCount == 0)
            //{
            //    Debug.Log("kayýp");
            //    return;
            //}

            var a = 1;
            var temp = 0;
            var valueBorder = 0;
            DOTween.To(() => a, x => a = x, 0, 10).OnUpdate(() =>
            {
                temp++;
                if (temp % 5 == 0 && valueBorder < value)
                {
                    enemyMoneyList[EnemyMoneyCount - 1].transform
                        .DOLocalMove(new Vector3(5, 10, Random.Range(-2, 2)), 1f).OnComplete(() =>
                        {
                            enemyMoneyList[EnemyMoneyCount - 1].SetActive(false);
                            enemyMoneyList.RemoveAt(EnemyMoneyCount - 1);

                        });
                    valueBorder++;
                }
                enemyMoneyCountText.text = $"${EnemyMoneyCount}";

            });
        }
    }
}