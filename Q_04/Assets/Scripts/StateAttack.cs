using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateAttack : PlayerState
{
    private float _delay = 2;
    private WaitForSeconds _wait;
    
    public StateAttack(PlayerController controller) : base(controller)
    {
        
    }

    public override void Init()
    {
        _wait = new WaitForSeconds(_delay);
        ThisType = StateType.Attack;
    }

    public override void Enter()
    {
        Controller.StartCoroutine(DelayRoutine(Attack));
    }

    public override void OnUpdate()
    {
        Debug.Log("Attack On Update");
    }

    public override void Exit()
    {
        Machine.ChangeState(StateType.Idle);
    }

    private void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(
            Controller.transform.position,
            Controller.AttackRadius
            );

        IDamagable damagable;
        foreach (Collider col in cols)   // 데미지를 입힌 후 idle로 안돌아옴 
        {

            damagable = col.GetComponent<IDamagable>();

            if (damagable != null)  // null 체크 추가
            {
                damagable.TakeHit(Controller.AttackValue);
            }
            else 
            {
                
            }
            

        }
    }

    public IEnumerator DelayRoutine(Action action)
    {
        yield return _wait;

        Attack();
        Exit();
    }

}
