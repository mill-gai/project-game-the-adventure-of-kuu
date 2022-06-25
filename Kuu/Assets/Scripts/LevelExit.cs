using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
     [SerializeField] float levelLoadDelay = 1f;
     private bool hasEnter = false;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !hasEnter){
            hasEnter = true;
            FindObjectOfType<GameSession>().UpdateCarotEndOfLevel();
            StartCoroutine(LoadNextLevel()); 
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; //Build index in File->Build Setting
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){ 
            // check if it is the last scene
            // if so, reset to first level
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
    
}
