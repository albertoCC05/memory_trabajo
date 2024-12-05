using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private UiManager uiManager;

    public List<QuestionsSO> posibleQuestions;
    public List<QuestionsSO> questionsInQuiz;
    [SerializeField] private int numberOfQuestions = 3;

    private int currentQuestion;
    private int correctAnswers;
    private int wrongAnswers;

    private int currentCorrect;

   [SerializeField] private TextMeshProUGUI correctNumber;
   [SerializeField] private TextMeshProUGUI wrongNumber;
    [SerializeField] private TextMeshProUGUI currentQuestionText;

    [SerializeField] private GameObject finishQuizPanel;
    [SerializeField] private TextMeshProUGUI respuestasCorrectas;
    [SerializeField] private TextMeshProUGUI respuestasIncorrectas;
    [SerializeField] private TextMeshProUGUI resultado;



    private void Start()
    {
        finishQuizPanel.SetActive(false);

        currentQuestion = 1;
        currentQuestionText.text = $"Pregunta: {currentQuestion}/{numberOfQuestions}";

        uiManager = FindObjectOfType<UiManager>();

        SetQuestionsInLevel();

    }
    private void SetQuestionsInLevel()
    {
        for (int i = 0; i < numberOfQuestions; i++)
        {
            int questionToAdd = Random.Range(0, posibleQuestions.Count);
            questionsInQuiz.Add(posibleQuestions[questionToAdd]);
            posibleQuestions.Remove(posibleQuestions[questionToAdd]);

           

        }
        SetCurrentQuestion();
    }
    private void SetCurrentQuestion()
    {
        
      
   
            
            int correctQuestionPosition = Random.Range(1, 4);

            if (correctQuestionPosition == 1)
            {
                uiManager.SetUi(questionsInQuiz[currentQuestion - 1].question, questionsInQuiz[currentQuestion - 1].correctAnswer, questionsInQuiz[currentQuestion - 1].wrongAnswer1, questionsInQuiz[currentQuestion - 1].wrongAnswer2, questionsInQuiz[currentQuestion - 1].questionImage);
                currentCorrect = correctQuestionPosition;
            }
            if (correctQuestionPosition == 2)
            {

                uiManager.SetUi(questionsInQuiz[currentQuestion - 1].question, questionsInQuiz[currentQuestion - 1].wrongAnswer1, questionsInQuiz[currentQuestion - 1].correctAnswer, questionsInQuiz[currentQuestion - 1].wrongAnswer2, questionsInQuiz[currentQuestion - 1].questionImage);
                currentCorrect = correctQuestionPosition;
            }
            if (correctQuestionPosition == 3)
            {
                uiManager.SetUi(questionsInQuiz[currentQuestion - 1].question, questionsInQuiz[currentQuestion - 1].wrongAnswer2, questionsInQuiz[currentQuestion - 1].wrongAnswer1, questionsInQuiz[currentQuestion - 1].correctAnswer, questionsInQuiz[currentQuestion - 1].questionImage);
                currentCorrect = correctQuestionPosition;
            }
        

        

        
    }
    public void CheckIfCorrectButton(int response )
    {
        if (response == currentCorrect)
        {
            currentQuestion++;
            currentQuestionText.text = $"Pregunta: {currentQuestion}/{numberOfQuestions}";
            correctAnswers++;
            correctNumber.text = $"{correctAnswers}";
            ChechEndQuiz();

            if (currentQuestion <= numberOfQuestions)
            {
                SetCurrentQuestion();
            }

           
        }
        else
        {
            currentQuestion++;
            currentQuestionText.text = $"Pregunta: {currentQuestion}/{numberOfQuestions}";
            wrongAnswers++;
            wrongNumber.text = $"{wrongAnswers}";
            ChechEndQuiz();

            if (currentQuestion <= numberOfQuestions)
            {
                SetCurrentQuestion();
            }

        }
    }
    private void ChechEndQuiz()
    {
        if (currentQuestion > numberOfQuestions)
        {
            FinishQuiz();
        }
    }
    private void FinishQuiz()
    {
        finishQuizPanel.SetActive(true);
        respuestasCorrectas.text = $"Respuestas correctas: {correctAnswers}";
        respuestasIncorrectas.text = $"Respuestas incorrectas: {wrongAnswers}";

        if (wrongAnswers <= 3)
        {
            resultado.text = $"Resultado: Apto";
           
        }
        else 
        {

            resultado.text = $"Resultado: No apto";

        }



        

    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
 



}
