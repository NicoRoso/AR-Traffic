using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.MixedReality.Toolkit.Boundary;
using Microsoft.MixedReality.Toolkit.Utilities;
using Unity.VisualScripting;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int _moneyAmount;
    [SerializeField] private TextMeshPro _textPrice;

    [SerializeField] private Item _item;
    private void Update()
    {
        _textPrice.text = "Money: " + _moneyAmount.ToString() + "руб.";
    }

    public void ProcessBuy(int money)
    {
        if (_moneyAmount - money < 0)
        {
            return;
        }

        _moneyAmount -= money;
    }

    public bool CanBuy(int price)
    {
        return _moneyAmount - price >= 0;
    }
}
