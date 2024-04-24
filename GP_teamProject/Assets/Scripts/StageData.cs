using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject 
    //������ ���·� Ŭ������ �����ϱ� ���� ScriptableObject 
{
    [SerializeField] private Vector2 limitMin;
    [SerializeField] private Vector2 limitMax;
    //���¿� ������ �����͵�
    public Vector3 LimitMin => limitMin;
    public Vector3 LimitMax => limitMax;
}
