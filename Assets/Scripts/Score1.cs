using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class Score1 : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _score1;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        _score1.text = _gameManager.Score.ToString();
    }

}
