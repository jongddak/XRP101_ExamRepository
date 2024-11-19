using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBehaviour<GameManager>
{
    public float Score { get; set; }

    private void Awake()
    {
        SingletonInit();
        Score = 70f;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Test() 
    {
        Debug.Log("버튼테스트");
    }
    public void LoadScene(int buildIndex)
    {
        Debug.Log("씬변경"); // 이벤트 시스템 추가
        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1f;
    }
}
