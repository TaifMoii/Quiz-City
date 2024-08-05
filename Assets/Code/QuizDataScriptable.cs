using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static gameplay;

[CreateAssetMenu(fileName = "QustionData", menuName = "QuestionData", order = 1)]
public class QuizDataScriptable : ScriptableObject
{
    public List<QuestionData> data;
    }
