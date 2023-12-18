using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using System.Linq;

public class GameManager : MonoBehaviour
{
    
    private List<Transform> _screenObjects = new List<Transform>();
    private GameState _currentState = GameState.GameInProgress;

    public int Score = 0;

    public GameState CurrentState { get { return _currentState;} }

    private void Awake()
    {
        SetGameState(GameState.GameInProgress);
    }

    public void SetGameState(GameState gameState)
    {
        _currentState = gameState;

        switch (gameState)
        {
            case GameState.GameInProgress:
                Score = 0;
                break;
                case GameState.GameOver:

                break;

                default: break;
        }
    }

    public void AddScreenObject(Transform transform)
    {
        _screenObjects.Add(transform);
    }

    public void RemoveScreenObject(Transform transform)
    {
        _screenObjects.Remove(transform);
    }

    public bool FindScreenObject( float posx, float posy)
    {
        Transform objtransform = _screenObjects.Where(x => x.position.x == posx && x.position.y == posy).FirstOrDefault();
        if(objtransform)
        return true;

        return false;
    }
}
