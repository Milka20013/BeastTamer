using System;
using TMPro;
using UnityEngine;

public class CurrencyDisplayer : MonoBehaviour
{
    [SerializeField] private DropContainer dropContainer;
    [SerializeField] private Inventory inventory;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI diamondText;

    public void OnDropGained(object dropObj)
    {
        Drop drop = (Drop)dropObj;
        inventory.TryGetDropValue(drop, out float amount);
        if (drop == dropContainer.moneyDrop)
        {
            moneyText.text = Math.Round(amount, 1).ToString();
        }
        if (drop == dropContainer.diamondDrop)
        {
            diamondText.text = Math.Round(amount, 1).ToString();
        }
    }
}
