using System;
using UnityEngine;

public class OnKeyInput : MonoBehaviour
{
    private KeyInputReceiver _keyInputReceiver;
    private UIManager _uiManager;
    [SerializeField] private CharacterObject characterObject;
    
    private void Start()
    {
        _keyInputReceiver = KeyInputReceiver.Instance;
        _uiManager = UIManager.Instance;
    }

    private void Update()
    {
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