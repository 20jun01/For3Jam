using UnityEngine;

public class AttackObject : MonoBehaviour
{
    private Direction _thisColor;
    private UIManager _uiManager;
    
    private void Start()
    {
        _uiManager = UIManager.Instance;
    }
    
    public void SetColor(Direction direction)
    {
        _thisColor = direction;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_thisColor == _uiManager.NowState) return;
        if (other.CompareTag("Enemy"))
        {
            _uiManager.Score();
            Destroy(gameObject);
        }
    }
}