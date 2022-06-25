using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Levelinfo : MonoBehaviour
{
    int curTotalCarrots; 
    [SerializeField] private TextMeshProUGUI carrotInfo;

    private void Start()
    {
        curTotalCarrots = FindObjectsOfType<Carrot>().Length;
        carrotInfo.text = "0/" + curTotalCarrots.ToString();
    }
    public int getCurTotalCarrots()
    {
        // return number of total carrots in the scene(current level)
        return curTotalCarrots;
    }
    public void setCarrotInfoToScreen(int curLevelCarrots)
    {
        carrotInfo.text = curLevelCarrots.ToString() + "/" + curTotalCarrots.ToString();
      
    }
}
