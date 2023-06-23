using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizScript : MonoBehaviour
{

    public PageManager pageManager;

    public int currentAnswer = 0;

    public int score;

    [HideInInspector]
    public List<int> answers;
    public List<int> correctAnswers;

    public TextMeshProUGUI scoreText;
    public GameObject scorePage;

    public Scrollbar quizAnswersScrollbar;

    public QuizResultsScript quizResultsScript;

    public Animator checkOptionAnimator;

    private void Start()
    {
        answers = new List<int>();
    }

    public void OnValueChangedToggle1(bool b)
    {
        if (b)
            currentAnswer = 1;
        else
            currentAnswer = 0;
    }

    public void OnValueChangedToggle2(bool b)
    {
        if (b)
            currentAnswer = 2;
        else
            currentAnswer = 0;
    }

    public void OnValueChangedToggle3(bool b)
    {
        if (b)
            currentAnswer = 3;
        else
            currentAnswer = 0;

    }

    public void ProceedWithNextPage()
    {
        if(currentAnswer == 0)
        {
            //print("Bifati o optiune!");
            // afiseaza un text pe ecran sa bifati o optiune
            checkOptionAnimator.SetTrigger("TriggerFadeIn");
            //pageManager.Init();
        }
        else
        {
            answers.Add(currentAnswer);
            if (pageManager.pageNumber == 10)
            {
                // afiseaza punctajul
                print("Se afiseaza punctajul");
                pageManager.currentPage.SetActive(false);
                scorePage.SetActive(true);
                CalculateScore();

                quizAnswersScrollbar.value = 0.9999f;
                print("Changed value of scrollbar");
                quizResultsScript.ShowResults(this);
            }
            else
            {
                currentAnswer = 0;
                pageManager.NextPage();
            }
            //switch (pageManager.pageNumber)
            //{
            //    case 1:
            //        {
            //            pageManager.Page1Next();
            //            break;
            //        }
            //    case 2:
            //        {
            //            pageManager.Page2Next();
            //            break;
            //        }
            //    case 3:
            //        {
            //            pageManager.Page3Next();
            //        }
            //}
        }
    }

    public void CalculateScore()
    {
        int score_temp = 0;
        for(int i = 0; i < answers.Count; i++)
        {
            if (answers[i] == correctAnswers[i])
                score_temp += 10;
        }
        score = score_temp;
        scoreText.text = score.ToString();
    }

    public void GoToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
