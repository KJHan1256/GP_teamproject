using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{//배경 움직임을 위한 클래스
    private float offset;
    [SerializeField] float scrollSpeed = 0.1f;
    [SerializeField] float scrollDirection = 1.0f;
    private MeshRenderer m_Renderer;

    void Start()
    {
        m_Renderer = this.gameObject.GetComponent<MeshRenderer>();
    }

    void FixedUpdate()
    {
        offset += scrollDirection * scrollSpeed;
        m_Renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }

}
