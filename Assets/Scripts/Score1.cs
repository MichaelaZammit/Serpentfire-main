using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class Score1 : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI _score1;

    private GameManager _gameManager;

    public void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void Update()
    {
        _score1.text = _gameManager.Score.ToString();
    }

}
