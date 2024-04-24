using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float scrollRange = 13.0f;
    [SerializeField] private float moveSpeed = 3.0f;
    [SerializeField] private float moveDirection = -1;
    
    

    void Update()
    {
        transform.position += new Vector3(moveDirection * moveSpeed * Time.deltaTime,0f, 0f);
        
        if(transform.position.x <= scrollRange*(-1.0f))
        {
            transform.position = new Vector3(target.position.x + 14.0f, 0f, 0f);
        }
    }
}
