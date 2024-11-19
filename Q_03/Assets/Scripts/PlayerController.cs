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
        Debug.Log("사망");
        //_audio.Play();
        //gameObject.SetActive(false); 사망하고 바로 오브젝트를 비활성화 하면 오디오가 재생되지 않음 
        StartCoroutine(DieDelay());
    }

    IEnumerator DieDelay() 
    {    _audio.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);

    }
}
