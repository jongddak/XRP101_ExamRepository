using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private Transform _muzzlePoint;
    [SerializeField] private CustomObjectPool _bulletPool;
    [SerializeField] private float _fireCooltime;
    
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private void Awake()
    {
        Init();
    }

    private void OnTriggerEnter(Collider other)
    {

          // 플레이어나 터렛 둘중의 하나에 리지드 바디가 있어야 하는데 없음(플레이어에 추가함) , 총알에도 리지드 바디 추가 
          // 플레이어가 범위를 벗어났다가 다시 들어오면 코루틴이 중복 실행됨 
        if (other.CompareTag("Player"))
        {
            Debug.Log("범위에 들어옴!");
            Fire(other.transform);
        }
    }
    private void OnTriggerExit(Collider other) // 벗어나면 사격 중지 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("범위에서 벗어남!");
            StopCoroutine(_coroutine);
        }
    }

    private void Init()
    {
        _coroutine = null;
        _wait = new WaitForSeconds(_fireCooltime);
        _bulletPool.CreatePool();
    }

    private IEnumerator FireRoutine(Transform target)
    {
        while (true)
        {
            if (target.gameObject.activeInHierarchy == false)  // 플레이어 사망시 사격 중지 
            {
                
                StopCoroutine(_coroutine);
            }
            yield return _wait;
            
            transform.rotation = Quaternion.LookRotation(new Vector3(
                target.position.x,
                0,
                target.position.z)
            );
            _muzzlePoint.rotation = transform.rotation;

            PooledBehaviour bullet = _bulletPool.TakeFromPool();
            bullet.transform.position = _muzzlePoint.position;
            bullet.OnTaken(target);
            
        }
    }

    private void Fire(Transform target)
    {
        _coroutine = StartCoroutine(FireRoutine(target));
    }
}
