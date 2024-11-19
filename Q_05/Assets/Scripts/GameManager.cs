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
        Debug.Log("��ư�׽�Ʈ");
    }
    public void LoadScene(int buildIndex)
    {
        Debug.Log("������"); // �̺�Ʈ �ý��� �߰�
        SceneManager.LoadScene(buildIndex);
        Time.timeScale = 1f;
    }
}
