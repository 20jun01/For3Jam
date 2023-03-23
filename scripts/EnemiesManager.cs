using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    
    [SerializeField] private float minTime;

    [SerializeField] private float maxTime;

    [SerializeField] private float xMinPosition;

    [SerializeField] private float xMaxPosition;

    [SerializeField] private float yMinPosition;

    [SerializeField] private float yMaxPosition;
    
    private float _interval;
    private float _time = 0f;

    void Start()
    {
        _interval = GetRandomTime();
    }

    void Update()
    {
        _time += Time.deltaTime;

        if(_time > _interval)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = GetRandomPosition();
            var (direction, color) = Colors.GetRandomColor();
            enemy.GetComponent<SpriteRenderer>().color = color;
            enemy.GetComponent<EnemyObject>().SetColor(direction);
            var randomDirection = GetRandomDirection();
            randomDirection.x *= xMaxPosition - xMinPosition;
            randomDirection.x *= 2f;
            randomDirection.y *= yMaxPosition - yMinPosition;
            randomDirection.y *= 2f;
            enemy.gameObject.transform.DOMove(randomDirection, 10f).SetRelative();
            _time = 0f;
            _interval = GetRandomTime();
        }
    }
    
    private float GetRandomTime()
    {
        return Random.Range(minTime, maxTime);
    }

    private Vector2 GetRandomPosition()
    {
        float x = Random.Range(xMinPosition, xMaxPosition);
        float y = Random.Range(yMinPosition, yMaxPosition);
        return new Vector2(x, y);
    }
    
    private Vector2 GetRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        float length = Mathf.Sqrt(x * x + y * y);
        return new Vector2(x / length, y / length);
    }
}
