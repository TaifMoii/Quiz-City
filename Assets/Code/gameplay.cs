using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class gameplay : MonoBehaviour
{
 
    public static gameplay instance;
    
    [SerializeField]
    private QuizDataScriptable QSdata;
    [SerializeField]
    private Image QsImage;
    [SerializeField]
    private WordData[] checkLetter;
    [SerializeField]
    private WordData[] letter;
    private bool check = true;
    private List<int> wordselected;
    private int currentIndex = 0;
    private GameStatus gamestatus= GameStatus.playing;
    private string answerW;

    public int radNum = 0;
    

    private char[] charArray = new char[12];
    private int answerWord = 0;

    private void Awake()
    {
     if (instance == null) instance = this;
     else
      Destroy(gameObject);

      wordselected = new List<int>();
    }
    private void Start()
    {
     SetQuestion();
     UIManager.instance.GiamHeart();
    }
    void Update()
    {
     
     Debug.Log("" + radNum);
    } 
    private void SetQuestion()
    {
      answerWord = 0;
      wordselected.Clear();
     

      QsImage.sprite = QSdata.data[currentIndex].anh;

      answerW = QSdata.data[currentIndex].answer;
      resetQuetion();
     for (int i = 0;i < answerW.Length; i++) 
      {
       charArray[i] = char.ToUpper(answerW[i]);
      } 
      for (int i = answerW.Length; i < letter.Length ; i++)
      {
       charArray[i] = (char)UnityEngine.Random.Range(65,91);
      }
      charArray = ShuffleList.ShuffleListItems<char>(charArray.ToList()).ToArray();
      for (int i = 0;i < letter.Length ; i++)
      {
       letter[i].SetChar(charArray[i]);
      }
      currentIndex++;
      gamestatus= GameStatus.playing;
    } 
    public void SelectedOption(WordData wordData)
    {
     if (gamestatus == GameStatus.Next || answerWord >= answerW.Length) return;

     wordselected.Add(wordData.transform.GetSiblingIndex()); 
     checkLetter[answerWord].SetChar(wordData.charValue);
     wordData.gameObject.SetActive(false);
     answerWord++;
     if (answerWord >= answerW.Length) 
     {
       check = true;
       for (int i = 0;i < answerW.Length;i++)
       {
        if (char.ToUpper(answerW[i]) != char.ToUpper(checkLetter[i].charValue))
        {
         check = false;
         break;
        }
       }
       if (check)
       {
        radNum = Random.Range(5, 15);
        UIManager.instance.TangCoin();
        UIManager.instance.TangScore();
        gamestatus= GameStatus.Next;
        if (currentIndex < QSdata.data.Count){
        Invoke("SetQuestion",0.5f);
       }
       }
       else if (!check)
       {
        Debug.Log("UnCorrect");
        UIManager.instance.GiamHeart();
       }
     }
    }
    
    private void resetQuetion()
    {
     for(int i = 0;i < checkLetter.Length;i++)
     {
      checkLetter[i].gameObject.SetActive(true);
      checkLetter[i].SetChar('_');
     }
     for(int i = answerW.Length;i < checkLetter.Length;i++)
     {
      checkLetter[i].gameObject.SetActive(false);
      checkLetter[i].SetChar('_');
     }
     for (int i = 0;i < letter.Length; i++)
     {
      letter[i].gameObject.SetActive(true);
     }
    }
    public void resetWord()
    {
      if (wordselected.Count > 0)
      {
       int index = wordselected[wordselected.Count - 1];
       letter[index].gameObject.SetActive(true);
       wordselected.RemoveAt(wordselected.Count - 1);
     answerWord--;
     checkLetter[answerWord].SetChar('_');
     }
    }

    [System.Serializable]
    public class QuestionData
    {
     public Sprite anh;
     public string answer;
    }
    public enum GameStatus
    {
     playing,
     Next
    }
    
}
