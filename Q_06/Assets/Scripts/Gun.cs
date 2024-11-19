using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;  // 인스펙터상에서 레이어 설정이 빠져있어서 추가 
    
    public void Fire()
    {
        //Ray ray = new(origin.position, Vector3.forward); // fps 는 카메라 중앙에서 발사되어야 하니 레이의 발사 지점을 카메라의 메인으로 수정 
        Ray ray = new(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }
    
}
