using TMPro;
using UnityEngine;

public abstract class BorderBase : MonoBehaviour
{
    public enum MathOperation
    {
        Addition,
        Multiplication,
        Division,
        Subtraction
    }

    public virtual void TextSetter(MathOperation operation, int value, TMP_Text textHolder, GameObject border)
    {
        switch (operation)
        {
            case MathOperation.Addition:
                textHolder.text = $"+{value}";
                break;

            case MathOperation.Multiplication:
                textHolder.text = $"x{value}";
                break;

            case MathOperation.Division:
                textHolder.text = $"/{value}";
                break;

            case MathOperation.Subtraction:
                textHolder.text = $"-{value}";
                break;
        }
    }

    public virtual void DoSomeMath(MathOperation operation, int value)
    {
        switch (operation)
        {
            case MathOperation.Addition:
                MoneyController.instance.AddMoney(value);
                //paray� kontrol edecegim scriptteki toplama fonk
                break;

            //case MathOperation.Multiplication:
            //    MoneyController.instance.AddMoney(MoneyController.PlayerMoneyCount * value -
            //                                        MoneyController.PlayerMoneyCount);
            //    //paray� kontrol edecegim scriptteki toplama fonk * value
            //    break;

            //case MathOperation.Division:
            //    MoneyController.instance.SubtractMoney(MoneyController.PlayerMoneyCount -
            //                                           MoneyController.PlayerMoneyCount / value);
            //    //paray� kontrol edecegim scriptteki ��kartma fonk toplam para say�s� - toplam para say�s�/value
            //    break;

            case MathOperation.Subtraction:
                MoneyController.instance.SubtractMoney(value);
                //paray� kontrol edecegim scriptteki c�karma fonk 
                break;
        }
    }
}