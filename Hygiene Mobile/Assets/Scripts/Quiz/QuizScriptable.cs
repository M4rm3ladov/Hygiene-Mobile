using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionData", menuName = "QuestionDate")]
public class QuizScriptable : ScriptableObject
{
    public List<Question> questions;
}
