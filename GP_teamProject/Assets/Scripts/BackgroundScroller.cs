using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{//배경 움직임을 위한 클래스

    [SerializeField] private Transform target;              //배경이 계속 이어지게 움직이도록 자신의 앞에 올 배경의 좌표를 받는 부분
    [SerializeField] private float scrollRange = 12.8f;     //배경의 크기, 이 값 이상으로 좌표가 변하면 화면을 나간 것
    [SerializeField] private float moveSpeed = 0.02f;        //배경의 이동 속도
    [SerializeField] private float moveDirection = -1;      //배경이 움짇이는 방향, 항상 1의 값을 가져야 하며 음수는 왼쪽, 양수는 반대 방향
    
    

    void FixedUpdate()
    {
        if (transform.position.x <= scrollRange * (-1.0f))      //화면을 나간 배경이 다시 나오도록 앞으로 보내는 코드
        {
            Vector3 temp = transform.position;
            temp.x = scrollRange * 2;   //카메라에서 나가면 배경의 크기 * 2 의 위치로 이동
            transform.position = temp;
           
        }


        Vector3 pos = transform.position;
        pos.x += moveDirection * moveSpeed;
        transform.position = pos;
        //배경을 움직이는 코드, FixedUpdate 안이므로 델타타임 없이


    }
}
