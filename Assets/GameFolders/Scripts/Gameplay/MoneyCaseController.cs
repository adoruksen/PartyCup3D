using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoneyCaseController : MonoBehaviour
{
    public static MoneyCaseController instance;

    [SerializeField] private List<GameObject> moneyAmount;

    private int levelMoney=10;

    void Awake()
    {
        instance = this;
        OpenMoneys();
    }
    
 
    public void MoneyOpener(int count)
    {
        //açýk deðilse aç, açýksa i yi arttýr

        //count/levelMoney

        StartCoroutine(Opener(count));



    }

    IEnumerator Opener(int count)
    {
        var a = 1;
        var temp = 0;
        var valueBorder = PlayerPrefs.GetInt("valueBorder");
        DOTween.To(() => a, x => a = x, 0, 3).OnUpdate(() =>
        {
            temp++;
            if (temp % 5 == 0 && valueBorder < count/levelMoney/*moneyAmount.Count*/)
            {
                if (!moneyAmount[valueBorder].activeInHierarchy)
                {
                    moneyAmount[valueBorder].SetActive(true);
                }
                valueBorder++;
                PlayerPrefs.SetInt("valueBorder",PlayerPrefs.GetInt("valueBorder")+1);
            }
        });
      

        yield return new WaitForSeconds(.1f);
    }

    private void OpenMoneys()
    {
        for (int i = 0; i < PlayerPrefs.GetInt("valueBorder"); i++)
        {
            moneyAmount[i].SetActive(true);
        }
    }
}
