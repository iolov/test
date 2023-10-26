
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FInScenCont : MonoBehaviour
{
    private void Start()
    {
        DataHolder.Score=PlayerPrefs.GetInt("score");
    }

    [SerializeField] TextMeshProUGUI textMeshProUGUI;
    private void Update()
    {
        textMeshProUGUI.text = DataHolder.Score.ToString();
        if (DataHolder.ScenScore > DataHolder.Score) { DataHolder.Score = DataHolder.ScenScore;}
        DataHolder.ScenScore = 0;
        PlayerPrefs.SetInt("score",DataHolder.Score);
    }
}
