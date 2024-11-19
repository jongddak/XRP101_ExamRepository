using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float speed;
    public float MoveSpeed  // �ش� �κп��� �ڽ��� ��� �����ؼ� ���� ������ ���ܼ� ���� , ������ ���� ������ �ʵ� speed ���� 
    {
        get => speed;
        private set => speed = value;
    }

    private void Awake()
    {
        Init();
        Debug.Log(speed);
    }

    private void Init()
    {
        MoveSpeed = 5f;
    }
}
