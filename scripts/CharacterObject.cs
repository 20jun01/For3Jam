using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class CharacterObject : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private int moveSpeed;
    private bool _isMoving = false;
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _isMoving = horizontal != 0;
        
        if (_isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;
            if(horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;
        }
        
        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);  
        animator.SetBool(IsMoving, _isMoving);
    }
}
