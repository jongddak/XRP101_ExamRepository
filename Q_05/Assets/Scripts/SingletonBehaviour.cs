using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Intance 
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

    protected void SingletonInit()
    {
        if (_instance == null)  // 게임매니저가 있으면 재생성 하지않게 코드변경 
        {
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
    }
}
