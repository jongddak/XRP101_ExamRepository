using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    [field: SerializeField]
    [field: Range(0, 100)]
    public int Hp { get; private set; }

    private AudioSource _audio;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audio = GetComponent<AudioSource>();
    }
    
    public void TakeHit(int damage)
    {
        Hp -= damage;

        if (Hp <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("���");
        //_audio.Play();
        //gameObject.SetActive(false); ����ϰ� �ٷ� ������Ʈ�� ��Ȱ��ȭ �ϸ� ������� ������� ���� 
        StartCoroutine(DieDelay());
    }

    IEnumerator DieDelay() 
    {    _audio.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);

    }
}
