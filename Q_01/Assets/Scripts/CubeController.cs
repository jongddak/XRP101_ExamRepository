using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public Vector3 SetPoint { get; set; }


    private void Start()
    {
        Debug.Log(SetPoint.x);
    }
    public void SetPosition()
    {
        Debug.Log("셋포지션");
        transform.position = SetPoint;
    }
}
