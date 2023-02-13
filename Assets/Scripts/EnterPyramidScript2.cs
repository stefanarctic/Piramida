using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPyramidScript2 : MonoBehaviour
{

    public string playerTag = "Player";

    private BoxCollider col;

    private void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag(playerTag))
        {
            print($"Collision with {collision.gameObject.name}");
            //Destroy(col); 
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
            MenuScript.instance.ShowMenu();
        }
    }
}
