using UnityEngine;

public class GameManager : MonoBehaviour
{
    private OnKeyInput _onKeyInput;
    private UIManager _uiManager;
    
    private void Start()
    {
        _onKeyInput = OnKeyInput.Instance;
        _uiManager = UIManager.Instance;
    }
    
    
}