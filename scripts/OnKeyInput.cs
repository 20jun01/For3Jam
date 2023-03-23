using System;
using UnityEngine;

public class OnKeyInput : MonoBehaviour
{
    private KeyInputReceiver _keyInputReceiver;
    private UIManager _uiManager;
    [SerializeField] private CharacterObject characterObject;
    [SerializeField] private float timeLimits;
    private static OnKeyInput _instance;

    private GameState _gameState = GameState.Start;
    private float _time = 0f;
    
    public static OnKeyInput Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<OnKeyInput>();
            return _instance;
        }
    }
    
    private void Start()
    {
        _keyInputReceiver = KeyInputReceiver.Instance;
        _uiManager = UIManager.Instance;
    }

    private void Update()
    {
        if (_gameState == GameState.Start)
        {
            if (_keyInputReceiver.AttackKeyDownInput)
            {
                _gameState = GameState.Gaming;
                _uiManager.GameStart();
                characterObject.SetGaming(true);
            }
        }

        if (_gameState == GameState.End)
        {
            if (_keyInputReceiver.EnterInput)
            {
                _gameState = GameState.Start;
                _uiManager.GameTitle();
                characterObject.SetGaming(false);
            }
        }
        
        if (_gameState != GameState.Gaming) return;

        _time += Time.deltaTime;
        
        if (_time > timeLimits)
        {
            _gameState = GameState.End;
            _time = 0f;
            characterObject.SetGaming(false);
            _uiManager.GameEnd();
        }

        if (_keyInputReceiver.DirectionKeyDownInput[(int) Direction.Right])
        {
            _uiManager.OnDInput();
            characterObject.SetDirection(Direction.Right);
        }
        
        if (_keyInputReceiver.DirectionKeyDownInput[(int) Direction.Up])
        {
            _uiManager.OnWInput();
            characterObject.SetDirection(Direction.Up);
        }
        
        if (_keyInputReceiver.DirectionKeyDownInput[(int) Direction.Left])
        {
            _uiManager.OnAInput();
            characterObject.SetDirection(Direction.Left);
        }
        
        if (_keyInputReceiver.DirectionKeyDownInput[(int) Direction.Down])
        {
            _uiManager.OnSInput();
            characterObject.SetDirection(Direction.Down);
        }
        
        if (_keyInputReceiver.AttackKeyDownInput)
        {
            characterObject.Attack(_keyInputReceiver.DirectionKeyDownInput);
        }
    }
}