using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI Score_text;
    [SerializeField] TextMeshProUGUI Lives_text;
    [SerializeField] ScoreHandler scoreHandler;
    [SerializeField] DeathHandler deathHandler;

    void Update()
    {
        Score_text.text = scoreHandler.score.ToString("00");
        Lives_text.text = deathHandler.Lives.ToString("00");
        
    }
}
