using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPyramidScript : MonoBehaviour
{

    public string mainSceneName = "MainScene";

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.gameObject.name);
        if(collision.collider.gameObject.CompareTag("Door"))
        {
            // transition into the main scene
            TransitionIntoNextScene();
        }
    }

    public void TransitionIntoNextScene()
    {
        Debug.Log("Transitioned into the main scene");
        //SceneManager.instance.ChangeScene(mainSceneName);
        //SceneManager.instance.NextScene();
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
