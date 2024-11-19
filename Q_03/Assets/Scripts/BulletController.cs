using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletController : PooledBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _deactivateTime;
    [SerializeField] private int _damageValue;

    private Rigidbody _rigidbody;
    private WaitForSeconds _wait;
    
    private void Awake()
    {
        Init();
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateRoutine());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�÷��̾�� �΋H��");
            PlayerController player = other.GetComponent<PlayerController>();
                
            player.TakeHit(_damageValue);   // �÷��̾� ��Ʈ�ѷ� ������Ʈ�� ����� ������Ʈ�� �ݶ��̴��� ��� ȣ���� �ȵƾ���
        }
    }

    private void Init()
    {
        _wait = new WaitForSeconds(_deactivateTime);
        _rigidbody = GetComponent<Rigidbody>();
    }
    
    private void Fire(Transform target)
    {
        
        Vector3 direction = (target.position - transform.position).normalized;

       
        _rigidbody.velocity = Vector3.zero; 
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        ReturnPool();
    }

    public override void ReturnPool()
    {
        Pool.Push(this);
        gameObject.SetActive(false);
    }

    public override void OnTaken<T>(T t)
    {
        if (!(t is Transform)) return;
        
        Transform tar = t as Transform;   // ������ ����Ȯ�� 

        Fire(tar);


    }
}
