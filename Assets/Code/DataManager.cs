using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    [Header("data")]
    private int Heart;
    private int Coin;
    

    private void Awake() 
    {
     if (instance == null )
     instance = this;
     else 
     Destroy(gameObject);
     LoadData();
    }
    void Start()
    {
        
    }


    void Update()
    {
        
    }
    public void AddCoins(int amount)
    {
     Coin += amount;
     SaveData();
    }
    public void RemoveCoins(int amount)
    {
    Coin -= amount;
    Coin = Mathf.Max(Coin, 0);
    SaveData();
    }
    public int GetCoin()
    {
     return Coin;
    }
    public int GetHeart()
    {
     return Heart;
    }
    private void LoadData()
    {
     Coin = PlayerPrefs.GetInt("Coin", 1000);
    }
    private void SaveData()
    {
     PlayerPrefs.SetInt("Coin", Coin);
    }

}
