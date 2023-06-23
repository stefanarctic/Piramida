using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizResultsScript : MonoBehaviour
{

    public Answer[] answers;

    public Sprite correctSprite;
    public Sprite wrongSprite;

    public void ShowResults(QuizScript quizScript)
    {

        int score = quizScript.score;

        for(int i = 0; i < quizScript.answers.Count; i++)
        {

            Toggle currentToggle = answers[i].GetAtIndex(quizScript.correctAnswers[i]);
            Image currentImage = (Image) currentToggle.graphic;
            currentImage.sprite = correctSprite;
            currentToggle.isOn = true;

            if (quizScript.answers[i] == quizScript.correctAnswers[i])
            {
                answers[i].checkMark.sprite = correctSprite;
            }
            else
            {
                answers[i].checkMark.sprite = wrongSprite;

                currentToggle = answers[i].GetAtIndex(quizScript.answers[i]);
                currentImage = (Image) currentToggle.graphic;
                currentImage.sprite = wrongSprite;
                currentToggle.isOn = true;
            }
        }

    }

}
