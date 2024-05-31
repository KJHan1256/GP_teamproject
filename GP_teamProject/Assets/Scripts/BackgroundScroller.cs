using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{//배경 움직임을 위한 클래스
    private float offset;
    [SerializeField] float scrollSpeed = 0.1f;
    [SerializeField] float scrollDirection = 1.0f;
    private MeshRenderer m_Renderer;

    //배경 변경을 위한 변수
    private int eTier;

    //배경 변경을 위한 Material를 받을 리스트
    [Header("Background List")]
    [SerializeField] private List<Material> backgroundList;

    void Start()
    {
        //변수 및 배경 초기화
        eTier = 1;
        m_Renderer = this.gameObject.GetComponent<MeshRenderer>();
        
        ChangeBackground(eTier);

    }

    void FixedUpdate()
    {
        offset += scrollDirection * scrollSpeed;
        m_Renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }


    //배경 변경 함수
    public void ChangeBackground(int targetNum)
    {
        //들어온 값이 1 ~ 3 사이 일때만 작동
        if( 0 < targetNum && targetNum < 4)
        {
            int n = targetNum - 1;
            Material tempMaterial = backgroundList[n];
            m_Renderer.material = tempMaterial;
        }
        else
        {
            print("worong background number input: " +  targetNum);
        }
    }
}
