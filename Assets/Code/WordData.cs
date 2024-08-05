using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WordData : MonoBehaviour
{
   [SerializeField] 
    private Text charText;
    [HideInInspector]
    public char charValue;

    private Button nut;
    private void Awake() 
    {
     nut = GetComponent<Button>();
     if (nut)
     {
      nut.onClick.AddListener(() => CharSelected());
     }
    }
    public void SetChar(char value)
    {
     charText.text = value + "";
     charValue = value;
    }
    private void CharSelected()
    {
     gameplay.instance.SelectedOption(this);
    }
}
