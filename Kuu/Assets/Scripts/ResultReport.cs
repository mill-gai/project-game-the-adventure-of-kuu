using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultReport : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI carrotsObtainedReport;

    private void Start() {
        GameSession gameSession = FindObjectOfType<GameSession>();
        carrotsObtainedReport.text = gameSession.GetCarrotNum().ToString() + "/" + gameSession.GetTotalCarrots().ToString();
    }
}
