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
            Debug.Log("플레이어랑 부딫힘");
            PlayerController player = other.GetComponent<PlayerController>();
                
            player.TakeHit(_damageValue);   // 플레이어 컨트롤러 컴포넌트가 적용된 오브젝트에 콜라이더가 없어서 호출이 안됐었음
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
        
        Transform tar = t as Transform;   // 방향이 부정확함 

        Fire(tar);


    }
}
