using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private float speed;
    public float MoveSpeed  // 해당 부분에서 자신을 계속 참조해서 무한 루프가 생겨서 터짐 , 실제로 값을 저장할 필드 speed 생성 
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
