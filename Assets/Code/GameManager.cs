using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Menu, Game ,LVComplete, Gameover, Idle}
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Setting")]
    private GameState gameState;

    [Header("Events")]
    public static Action<GameState> onGameStateChanged;
    private void Awake()
    {
     if (instance == null)
      instance = this;
      else 
        Destroy(gameObject);
    }
    public void SetGameState(GameState gameState)
     {
      this.gameState = gameState;
      onGameStateChanged?.Invoke(gameState);
     }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
