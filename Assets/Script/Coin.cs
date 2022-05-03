using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    Text _text;
    public static int _coin = 1000;

    private void Start()
    {
        _text = GetComponent<Text>();
        LoadCoin();
    }

    private void Update()
    {
        _text.text = "Coin: " + _coin.ToString();
        SaveCoin();
    }

    public void SaveCoin()
    {
        
        SaveLoad.SaveCoin(this);
    }

    public void LoadCoin()
    {
        CoinData data = SaveLoad.LoadCoin();
        _coin = data.coins;
    }

    public void DeleteCoin()
    {
        SaveLoad.DeleteCoin();
        _coin = 0;
    }
}
