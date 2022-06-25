using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int totalCarrots;
    [SerializeField] int obtainedCarrots;
    [SerializeField] int curLevelCarrots; // carrots obtained in current level
                        // after player complete the level, add curLevelCarrots to obtainedCarrots

    private void Awake() 
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;
        if(numGameSession > 1){
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    // ======== reset or quit the game when player click buttons on screen ========
    public void ResetCurLevel()
    {
         int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; 
         curLevelCarrots = 0;
         SceneManager.LoadScene(currentSceneIndex);
    }

     public void QuitGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }



    // ====== update number of carrots throughout the game ======
    public void UpdateCarrotNum()
    {
        curLevelCarrots += 1;
        FindObjectOfType<Levelinfo>().setCarrotInfoToScreen(curLevelCarrots);
    }

    public void UpdateTotalCarrots(int num)
    {
        totalCarrots += num;
    }
 
    public void UpdateCarotEndOfLevel()
    {
        obtainedCarrots += curLevelCarrots;
        curLevelCarrots = 0;
        int curTotalCarrots = FindObjectOfType<Levelinfo>().getCurTotalCarrots();
        UpdateTotalCarrots(curTotalCarrots);
    }

    public int GetCarrotNum()
    {
        return obtainedCarrots;
    }
    
    public int GetTotalCarrots()
    {
        return totalCarrots;
    }
} 
