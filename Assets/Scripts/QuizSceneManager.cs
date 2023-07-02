using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizSceneManager : MonoBehaviour
{

    public GameObject page0;

    public AudioSource audioSource;
    public AudioClip quizMusicClip;

    private void Start()
    {
        page0.SetActive(true);
        audioSource.Stop();
        audioSource.clip = quizMusicClip;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }

}
