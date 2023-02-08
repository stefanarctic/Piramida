using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizScript : MonoBehaviour
{

    public PageManager pageManager;

    public int currentAnswer = 0;

    private List<int> answers;
    public List<int> correctAnswers;

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
            print("Bifati o optiune!");
            // afiseaza un text pe ecran sa bifati o optiune
            //pageManager.Init();
        }
        else
        {
            answers.Add(currentAnswer);
            if (pageManager.pageNumber == 10)
            {
                // afiseaza punctajul
                print("Se afiseaza punctajul");
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
}