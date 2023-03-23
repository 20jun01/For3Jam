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

    void Start()
    {
        
        animator.SetBool(IsFalling, _isFalling);
        animator.SetBool(IsJumping, _isJumping);
    }
    
    void Update()
    {
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

    public void Attack(Direction nowState, bool[] directionKeyDownInput)
    {
        // Charaから攻撃を出す
        var attack = Instantiate(attackPrefab);
        attack.transform.position = transform.position;
        attack.transform.localScale = transform.localScale;
        // nowStateでColorを決める
        var color = Colors.GetColor(nowState);
        attack.GetComponent<SpriteRenderer>().color = color;
        attack.GetComponent<AttackObject>().SetColor(nowState);
        
        var direction = ConvertDirection(directionKeyDownInput);
        
        attack.gameObject.transform.DOMove(direction, 10f).SetRelative().SetLoops(-1, LoopType.Incremental);
    }
    
    private Vector2 ConvertDirection(bool[] directionKeyDownInput)
    {
        var direction = new Vector2(0, 0);
        if (directionKeyDownInput[0])
        {
            direction.y += 1;
        }
        if (directionKeyDownInput[1])
        {
            direction.x += 1;
        }
        if (directionKeyDownInput[2])
        {
            direction.y -= 1;
        }
        if (directionKeyDownInput[3])
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
