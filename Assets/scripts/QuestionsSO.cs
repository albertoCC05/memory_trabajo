using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Object/Question")]

public class QuestionsSO : ScriptableObject
{
    public string question;
    public string wrongAnswer1;
    public string wrongAnswer2;
    public string correctAnswer;
    public Sprite questionImage;
}
