using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonetaryManager : MonoBehaviour
{
    [Header("Coins Earned")]
    public Text TotalCoins;
    private float coinsAmount;
    // Start is called before the first frame update
    void Start()
    {
        TotalCoins.text = Player.GoldCoins.ToString();
        coinsAmount = float.Parse(TotalCoins.text);
    }
    public void ComputeBoughtItem(float itemPrice)
    {
        coinsAmount = coinsAmount - itemPrice;
        Player.GoldCoins = coinsAmount;
        TotalCoins.text = coinsAmount.ToString();
    }
}
