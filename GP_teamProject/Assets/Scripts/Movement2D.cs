using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour     //오브젝트의 이동을 위한 클래스
{
    [SerializeField] private float moveSpeed = 0.0f;
    [SerializeField] private Vector3 moveDiredtion = Vector3.zero;

    void Update()
    {
        transform.position += moveDiredtion * moveSpeed * Time.deltaTime;
    }

    public void MoveTo(Vector3 direction)
    {
        moveDiredtion = direction;
    }
}
