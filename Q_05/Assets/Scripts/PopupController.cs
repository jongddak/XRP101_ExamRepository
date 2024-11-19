using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupController : MonoBehaviour
{
    [SerializeField] private float _deactiveTime;
    private WaitForSecondsRealtime _wait;   // 타임스케일을 0으로 하면 코루틴이 정지됨 리얼타임으로 바꿔줌 
    private Button _popupButton;

    [SerializeField] private GameObject _popup;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _wait = new WaitForSecondsRealtime(_deactiveTime);
        _popupButton = GetComponent<Button>();
        SubscribeEvent();
    }

    private void SubscribeEvent()
    {
        _popupButton.onClick.AddListener(Activate);
    }

    private void Activate()
    {
        _popup.gameObject.SetActive(true);
        GameManager.Intance.Pause();
        StartCoroutine(DeactivateRoutine());
    }

    private void Deactivate()
    {
        _popup.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    private IEnumerator DeactivateRoutine()
    {
        yield return _wait;
        Deactivate();
    }
}
