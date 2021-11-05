using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    public Inventory playerInventory;
    public TextMeshProUGUI coinDisplay;

    public void UpdateCoin()
    {
        coinDisplay.text = "" + playerInventory.coins;
    }
}
