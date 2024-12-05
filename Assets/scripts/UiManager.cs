using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI question;
    [SerializeField] private TextMeshProUGUI answer1;
    [SerializeField] private TextMeshProUGUI answer2;
    [SerializeField] private TextMeshProUGUI answer3;
    [SerializeField] private Image image;


    public void SetUi(string quest, string ans1, string ans2, string ans3, Sprite sprite)
    {
        question.text = quest;
        answer1.text = ans1;
        answer2.text = ans2;
        answer3.text = ans3;
        image.sprite = sprite;
    }
}
