using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image backgroundImage;

    [SerializeField] private GameObject StartImage;
    [SerializeField] private GameObject EndImage;
    //singleton
    private static UIManager _instance;
    private Direction _nowState = Direction.None;
    private Counter _counter;
    private GameState _gameState = GameState.Start;
    private EnemiesManager _enemiesManager;

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
    
    void Start()
    {
        StartImage.SetActive(true);
        EndImage.SetActive(false);
        backgroundImage.color = Colors.DefaultColor;
        _counter = Counter.Instance;
        _enemiesManager = EnemiesManager.Instance;
    }
    
    public async void OnDInput()
    {
        _nowState = Direction.None;
        await backgroundImage.DOColor(Colors.DColor, 3f);
        _nowState = Direction.Right;
    }
    
    public async void OnWInput()
    {
        _nowState = Direction.None;
        await backgroundImage.DOColor(Colors.WColor, 3f);
        _nowState = Direction.Up;
    }
    
    public async void OnAInput()
    {
        _nowState = Direction.None;
        await backgroundImage.DOColor(Colors.AColor, 3f);
        _nowState = Direction.Left;
    }
    
    public async void OnSInput()
    {
        _nowState = Direction.None;
        await backgroundImage.DOColor(Colors.SColor, 3f);
        _nowState = Direction.Down;
    }
    
    public bool SpaceInput()
    {
        if (_gameState == GameState.Start)
        {
            _gameState = GameState.Gaming;
            _enemiesManager.StartGame();
            StartImage.SetActive(false);
            return true;
        }
        else if (_gameState == GameState.End)
        {
            _gameState = GameState.Start;
            _enemiesManager.EndGame();
            EndImage.SetActive(false);
            StartImage.SetActive(true);
            return false;
        }

        return true;
    }
    
    public void Damage()
    {
        _counter.AddCount(-1);
    }

    public void Score()
    {
        _counter.AddCount(1);
    }
}