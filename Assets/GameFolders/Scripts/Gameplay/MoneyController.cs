using System.Collections;
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
    [SerializeField] private Transform enemySubtractPos;
    [SerializeField] private Transform playerSubtractPos;

    [Header("Money Prefab")]
    [SerializeField] private GameObject moneyPrefab;
    private Rigidbody moneyRigidbody;

    [Header("Lists")]
    [SerializeField] List<GameObject> playerMoneyList;
    [SerializeField] List<GameObject> enemyMoneyList;

    [Header("Texts")] 
    [SerializeField] private TMP_Text playerMoneyCountText;
    [SerializeField] private TMP_Text enemyMoneyCountText;

    public int PlayerMoneyCount => playerMoneyList.Count;
    public int EnemyMoneyCount => enemyMoneyList.Count;


    private void Awake()
    {
        instance = this;
    }

    public void AddMoney(int value)
    {
        if (SwitchTurnController.instance.myTurn)
        {
            StartCoroutine(PlayerMoneyAdder(value));
        }
        else
        {
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
            StartCoroutine(PlayerMoneySubtracter(value));
        }
        else
        {
            var a = 1;
            var temp = 0;
            var valueBorder = 0;
            DOTween.To(() => a, x => a = x, 0, 3).OnUpdate(() =>
            {
                temp++;
                if (temp % 5 == 0 && valueBorder < value)
                {

                    moneyRigidbody =enemyMoneyList[EnemyMoneyCount - 1].GetComponent<Rigidbody>();
                    moneyRigidbody.isKinematic = false;
                    moneyRigidbody.AddForce(60f, 350f, enemyMoneyList[EnemyMoneyCount - 1].transform.position.z);
                    //enemyMoneyList[EnemyMoneyCount - 1].transform.DORotate(new Vector3(0, 0, -180), 1f);
                    //enemyMoneyList[EnemyMoneyCount - 1].SetActive(false);
                    enemyMoneyList.RemoveAt(EnemyMoneyCount - 1);

                    valueBorder++;
                }

                enemyMoneyCountText.text = $"${EnemyMoneyCount}";

            });
        }
    }

    IEnumerator PlayerMoneyAdder(int value)
    {
        yield return new WaitUntil(() => SwitchTurnController.instance.cameraMoveFinished);

        var a = 1;
        var temp = 0;
        var valueBorder = 0;
        DOTween.To(() => a, x => a = x, 0, 3).OnUpdate(() =>
        {
            temp++;
            if (temp % 5 == 0 && valueBorder < value)
            {
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

    IEnumerator PlayerMoneySubtracter(int value)
    {
        yield return new WaitUntil(() => SwitchTurnController.instance.cameraMoveFinished);

        var a = 1;
        var temp = 0;
        var valueBorder = 0;
        DOTween.To(() => a, x => a = x, 0, 3).OnUpdate(() =>
        {
            temp++;
            if (temp % 5 == 0 && valueBorder < value)
            {
                moneyRigidbody = playerMoneyList[PlayerMoneyCount - 1].GetComponent<Rigidbody>();
                moneyRigidbody.isKinematic = false;
                moneyRigidbody.AddForce(-60f, 350f, playerMoneyList[PlayerMoneyCount - 1].transform.position.z);
                //playerMoneyList[PlayerMoneyCount - 1].transform.DORotate(new Vector3(0, 0, 180), 1f);
                playerMoneyList.RemoveAt(PlayerMoneyCount - 1);

                //playerMoneyList[PlayerMoneyCount - 1].GetComponent<Animator>().enabled = true;
                valueBorder++;

                //playerMoneyList[PlayerMoneyCount - 1].SetActive(false);
            }
            playerMoneyCountText.text = $"${PlayerMoneyCount}";
        });
    }
}