using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyCaseController : MonoBehaviour
{
    public static MoneyCaseController instance;

    [SerializeField] private List<GameObject> moneyAmount;

    private int levelMoney = 10;

    void Awake()
    {
        instance = this;
        OpenMoneys();
    }


    public void MoneyOpener(int count)
    {

        //count/levelMoney

        StartCoroutine(Opener(count + PlayerPrefs.GetInt("valueBorder")));
    }

    IEnumerator Opener(int count)
    {
        var a = 1;
        var temp = 0;
        var valueBorder = 0;
        DOTween.To(() => a, x => a = x, 0, 3).OnUpdate(() =>
        {
            temp++;
            if (temp % 5 == 0 && valueBorder < count / levelMoney) // moneyAmount.Count)
            {
                if (!moneyAmount[PlayerPrefs.GetInt("valueBorder")].activeInHierarchy && moneyAmount.Count >= valueBorder)
                {
                    moneyAmount[PlayerPrefs.GetInt("valueBorder")].SetActive(true);
                    moneyAmount[PlayerPrefs.GetInt("valueBorder")].transform.DOPunchScale(new Vector3(.15f, .15f, .15f), .25f, 2);
                }
                valueBorder++;
                PlayerPrefs.SetInt("valueBorder", PlayerPrefs.GetInt("valueBorder") + 1);
            }
        });

        yield return new WaitForSeconds(.1f);
    }

    private void OpenMoneys()
    {
        if (moneyAmount.Count >= PlayerPrefs.GetInt("valueBorder"))
        {
            for (int i = 0; i < PlayerPrefs.GetInt("valueBorder"); i++)
            {
                moneyAmount[i].SetActive(true);
            }
        }
        
    }
}