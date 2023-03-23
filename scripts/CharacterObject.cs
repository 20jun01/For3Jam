using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class CharacterObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private int moveSpeed;
    [SerializeField] private GameObject attackPrefab;
    private bool _isMoving = false;
    private bool _isFalling = false;
    private bool _isJumping = false;
    private static readonly int IsMoving = Animator.StringToHash("IsMoving");
    private static readonly int IsFalling = Animator.StringToHash("IsFalling");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private Direction _nowState;
    private bool _isGaming = false;
    //singleton
    private static CharacterObject _instance;

    public static CharacterObject Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<CharacterObject>();
            return _instance;
        }
    }

    void Start()
    {
        animator.SetBool(IsFalling, _isFalling);
        animator.SetBool(IsJumping, _isJumping);
        _nowState = Direction.Right;
    }
    
    public void SetDirection(Direction direction)
    {
        _nowState = direction;
    }
    
    public void SetGaming(bool isGaming)
    {
        _isGaming = isGaming;
        if (!_isGaming)
        {
            rb.velocity = Vector2.zero;
        }
    }
    
    void Update()
    {
        if (!_isGaming)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _isMoving = horizontal != 0 || vertical != 0;

        if (_isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;
            if(horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;
        }
        
        rb.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.5f, 8.5f), Mathf.Clamp(transform.position.y, -4.6f, 4.6f), transform.position.z);
        animator.SetBool(IsMoving, _isMoving);
    }

    public void Attack(bool[] directionKeyDownInput)
    {
        if (!_isGaming)
        {
            return;
        }
        // Charaから攻撃を出す
        var attack = Instantiate(attackPrefab);
        attack.transform.position = transform.position;
        attack.transform.localScale = transform.localScale;
        // nowStateでColorを決める
        var color = Colors.GetColor(_nowState);
        attack.GetComponent<SpriteRenderer>().color = color;
        attack.GetComponent<AttackObject>().SetColor(_nowState);
        
        var direction = ConvertDirection(directionKeyDownInput);

        direction.x *= 20f;
        direction.y *= 20f;

        attack.gameObject.transform.DOMove(direction, 10f).SetRelative();
    }
    
    private Vector2 ConvertDirection(bool[] directionKeyDownInput)
    {
        var direction = new Vector2(0, 0);
        if (directionKeyDownInput[(int)Direction.Up])
        {
            direction.y += 1;
        }
        if (directionKeyDownInput[(int)Direction.Right])
        {
            direction.x += 1;
        }
        if (directionKeyDownInput[(int)Direction.Down])
        {
            direction.y -= 1;
        }
        if (directionKeyDownInput[(int)Direction.Left])
        {
            direction.x -= 1;
        }
        
        if (direction.x == 0 && direction.y == 0)
        {
            direction.x = 1;
        }
        
        return direction;
    }
}
