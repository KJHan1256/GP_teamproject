using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{//��� �������� ���� Ŭ����
    private float offset;
    [SerializeField] float scrollSpeed = 0.1f;
    [SerializeField] float scrollDirection = 1.0f;
    private MeshRenderer m_Renderer;

    //��� ������ ���� ����
    private int eTier;

    //��� ������ ���� Material�� ���� ����Ʈ
    [Header("Background List")]
    [SerializeField] private List<Material> backgroundList;

    void Start()
    {
        //���� �� ��� �ʱ�ȭ
        eTier = 1;
        m_Renderer = this.gameObject.GetComponent<MeshRenderer>();
        
        ChangeBackground(eTier);

    }

    void FixedUpdate()
    {
        offset += scrollDirection * scrollSpeed;
        m_Renderer.material.mainTextureOffset = new Vector2(offset, 0);
    }


    //��� ���� �Լ�
    public void ChangeBackground(int targetNum)
    {
        //���� ���� 1 ~ 3 ���� �϶��� �۵�
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
