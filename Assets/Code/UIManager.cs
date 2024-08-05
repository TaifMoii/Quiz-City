using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private int score = 1 ;
    private int coin = 0 ; 
    public TextMeshProUGUI ScoreTXT;
    public TextMeshProUGUI heartTXT;
    public TextMeshProUGUI coinTXT;
    public int radNum = 0;
    public int heart = 0;
    
  public void SetScore(int SCvalue)
    {
      score = SCvalue;
    }
    public int Getscore()
    {
     return score;
    }
    public void TangScore()
    {
     score++;
     SetScoreTXT("" + score);
    }
    public void SetScoreTXT(string txt)
    {
     if (ScoreTXT)
        ScoreTXT.text = txt;
    }
    public void SetHeart(int HeartValue)
    {
     heart = HeartValue;
    }
    public int GetHeart()
    {
     return heart;
    }
    public void GiamHeart()
    {
     heart--;
     SetHeartTXT("" + heart);
    }
    public void SetHeartTXT(string txt)
    {
     if (heartTXT)
     heartTXT.text = txt;
    }
    public void setCoin(int CoinValue)
    {
     coin = CoinValue;    
    }
    public int GetCoin()
    {
      return coin;
    }
    public void TangCoin()
    {
     coin += radNum;
     setCoinTXT("" + coin);
    }
    public void setCoinTXT(string txt)
    {
     if (coinTXT)
     coinTXT.text = txt;
    }
    
    public void Fb()
    {
     Application.OpenURL("https://www.facebook.com/phthetai");
     }
    
}
