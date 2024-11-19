using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _range;
    [SerializeField] private LayerMask _targetLayer;  // �ν����ͻ󿡼� ���̾� ������ �����־ �߰� 
    
    public void Fire()
    {
        //Ray ray = new(origin.position, Vector3.forward); // fps �� ī�޶� �߾ӿ��� �߻�Ǿ�� �ϴ� ������ �߻� ������ ī�޶��� �������� ���� 
        Ray ray = new(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        
        if (Physics.Raycast(ray, out hit, _range, _targetLayer))
        {
            Debug.Log($"{hit.transform.name} Hit!!");
        }
    }
    
}
