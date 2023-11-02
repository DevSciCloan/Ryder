using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadOnRKey : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene(); // Reloads the active scene when R is pressed
        }
    }

    public void ReloadScene()
    {
        StartCoroutine(ReloadSceneAsync());
    }


    IEnumerator ReloadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        while(!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
