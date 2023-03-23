using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;
    //singleton
    private static UIManager _instance;
    private Direction _nowState = Direction.None;

    public Direction NowState
    {
        get => _nowState;
    }

    public static UIManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<UIManager>();
            return _instance;
        }
    }
    
    public async void OnDInput()
    {
        _nowState = Direction.None;
        await backgroundImage.DOColor(Colors.DColor, 3f);
        _nowState = Direction.Right;
    }
    
    public void OnWInput()
    {
        _nowState = Direction.None;
        backgroundImage.DOColor(Colors.WColor, 3f);
        _nowState = Direction.Up;
    }
    
    public void OnAInput()
    {
        _nowState = Direction.None;
        backgroundImage.DOColor(Colors.AColor, 3f);
        _nowState = Direction.Left;
    }
    
    public void OnSInput()
    {
        _nowState = Direction.None;
        backgroundImage.DOColor(Colors.SColor, 3f);
        _nowState = Direction.Down;
    }
    
    public void OnSpaceInput()
    {
        Debug.Log("Space");
    }
}