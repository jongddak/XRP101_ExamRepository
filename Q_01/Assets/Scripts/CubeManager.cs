using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private CubeController _cubeController;
    private Vector3 _cubeSetPoint;

    private void Awake()
    { // 씬에 큐브 매니저 스크립트가 달린 오브젝트가 없어서 추가 , 큐브 프리팹 넣어줌 
      //  SetCubePosition(3, 0, 3);  큐브가 생성되기 전에 위치를 지정해서 오류 발생(실행 순서awake - start 순이므로)
      //  생성후에 위치를 변경할 수 있도록 코드 위치 변경
    }
     
   
    private void Start()
    {
        CreateCube();
        SetCubePosition(3, 0, 3);
    }

    private void SetCubePosition(float x, float y, float z)
    {
        _cubeSetPoint.x = x;
        _cubeSetPoint.y = y;
        _cubeSetPoint.z = z;
         
        _cubeController.SetPoint = _cubeSetPoint; // 큐브 컨트롤러에 좌표값을 전달해줘야 함 , 프로퍼티를 private을 떼줌
        _cubeController.SetPosition();
    }

    private void CreateCube()
    {
        GameObject cube = Instantiate(_cubePrefab);
        _cubeController = cube.GetComponent<CubeController>();
        _cubeSetPoint = _cubeController.SetPoint;
    }
}
