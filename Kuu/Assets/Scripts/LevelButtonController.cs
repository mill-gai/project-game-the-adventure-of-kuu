using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelButtonController : MonoBehaviour
{
    public void OnClickResetLevel()
    {
        FindObjectOfType<GameSession>().ResetCurLevel();
    }
    public void OnClickQuitLevel()
    {
        FindObjectOfType<GameSession>().QuitGame();
    }

}
