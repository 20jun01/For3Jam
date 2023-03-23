using UnityEngine;

public class KeyInputReceiver : MonoBehaviour
{
    //singleton
    private static KeyInputReceiver _instance;

    public static KeyInputReceiver Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<KeyInputReceiver>();
            return _instance;
        }
    }

    private readonly KeyCode[] _directionKeyCodesWasd =
    {
        KeyCode.D, KeyCode.W, KeyCode.A, KeyCode.S
    }; 
    
    private KeyCode _attackKeyCode = KeyCode.Space;
    
    private KeyCode _enterKeyCode = KeyCode.Return;

    private readonly bool[] _directionKeyDownInput = new bool[4];
    
    private bool _attackKeyDownInput = false;
    
    private bool _enterInput = false;

    public bool[] DirectionKeyDownInput => _directionKeyDownInput;

    public bool AttackKeyDownInput => _attackKeyDownInput;
    
    public bool EnterInput => _enterInput;

    // Update is called once per frame
    void Update()
    {
        _directionKeyDownInput[(int)Direction.Right] = 
                                                       Input.GetKeyDown(_directionKeyCodesWasd[(int)Direction.Right]);
        _directionKeyDownInput[(int)Direction.Up] =
                                                    Input.GetKeyDown(_directionKeyCodesWasd[(int)Direction.Up]);
        _directionKeyDownInput[(int)Direction.Left] = 
                                                      Input.GetKeyDown(_directionKeyCodesWasd[(int)Direction.Left]);
        _directionKeyDownInput[(int)Direction.Down] = 
                                                      Input.GetKeyDown(_directionKeyCodesWasd[(int)Direction.Down]);
        
        _attackKeyDownInput = Input.GetKeyDown(_attackKeyCode);
        
        _enterInput = Input.GetKeyDown(_enterKeyCode);
    }
}
