using System;
using UnityEngine;

public class OnKeyInput : MonoBehaviour
{
    private KeyInputReceiver _keyInputReceiver;
    private UIManager _uiManager;
    
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
        }
        
        if (_keyInputReceiver.DirectionKeyDownInput[(int) Direction.Up])
        {
            _uiManager.OnWInput();
        }
        
        if (_keyInputReceiver.DirectionKeyDownInput[(int) Direction.Left])
        {
            _uiManager.OnAInput();
        }
        
        if (_keyInputReceiver.DirectionKeyDownInput[(int) Direction.Down])
        {
            _uiManager.OnSInput();
        }
        
        if (_keyInputReceiver.AttackKeyDownInput)
        {
            _uiManager.OnSpaceInput(_keyInputReceiver.DirectionKeyDownInput);
        }
    }
}