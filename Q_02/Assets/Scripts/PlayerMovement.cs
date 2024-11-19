using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStatus _status;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _status = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        MovePosition();
    }

    private void MovePosition()
    {  // 1.4 배는 nomalized 안해서 생김
       // 해당 코드는 좌표를 일정 시간에 따라 이동해야 하는데 대각선이 1.4 배 길어서 동일 시간내에 목표지점에 도달하려면
       // 대각선으로 이동시에 더 빨리 이동하게 됨

        Vector3 direction = Vector3.zero;
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.z = Input.GetAxisRaw("Vertical");
        
        if (direction == Vector3.zero) return;
        
        transform.Translate(_status.MoveSpeed * Time.deltaTime * direction.normalized); // normalized 추가
    }
}
