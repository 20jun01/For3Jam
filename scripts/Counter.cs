using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    [SerializeField] private Text text;
    
    private int _count = 0;
    
    private static Counter _instance;
    
    public static Counter Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<Counter>();
            return _instance;
        }
    }
    
    public void AddCount(int count)
    {
        text.DOCounter(_count, _count + count, 0.5f, true);
        _count += count;
    }
}
