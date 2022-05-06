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
                //parayý kontrol edecegim scriptteki toplama fonk
                break;

            case MathOperation.Multiplication:
                MoneyController.instance.AddMoney(MoneyController.instance.PlayerMoneyCount * value -
                                                    MoneyController.instance.PlayerMoneyCount);
                //parayý kontrol edecegim scriptteki toplama fonk * value
                break;

            case MathOperation.Division:
                MoneyController.instance.SubtractMoney(MoneyController.instance.PlayerMoneyCount -
                                                       MoneyController.instance.PlayerMoneyCount / value);
                //parayý kontrol edecegim scriptteki çýkartma fonk toplam para sayýsý - toplam para sayýsý/value
                break;

            case MathOperation.Subtraction:
                MoneyController.instance.SubtractMoney(value);
                //parayý kontrol edecegim scriptteki cýkarma fonk 
                break;
        }
    }
}