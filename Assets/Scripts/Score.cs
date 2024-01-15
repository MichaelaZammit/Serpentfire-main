using System.Collections;
using System.Collections.Generic;

using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private int playerIndex;

    private GameManager _gameManager;

    private Scores scoreData = new Scores();

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        _score.text = _gameManager.scores[playerIndex].ToString();

        if (scoreData.score > scoreData.highScore)
        {
            scoreData.highScore = scoreData.score;
        }
    }

    private void Start()
    {
        scoreData = SaveData.Load();
    }

    private void OnDestory()
    {
        SaveData.Save(scoreData);
    }


}
