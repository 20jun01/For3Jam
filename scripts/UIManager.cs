using UnityEngine;

public class UIManager : MonoBehaviour
{
    //singleton
    private static UIManager _instance;

    public static UIManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<UIManager>();
            return _instance;
        }
    }
    
    public void OnDInput()
    {
        Debug.Log("D");
    }
    
    public void OnWInput()
    {
        Debug.Log("W");
    }
    
    public void OnAInput()
    {
        Debug.Log("A");
    }
    
    public void OnSInput()
    {
        Debug.Log("S");
    }
    
    public void OnSpaceInput()
    {
        Debug.Log("Space");
    }
}