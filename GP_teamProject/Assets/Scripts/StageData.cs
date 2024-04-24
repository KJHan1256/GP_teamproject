using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StageData : ScriptableObject 
    //에셋의 형태로 클래스를 저장하기 위한 ScriptableObject 
{
    [SerializeField] private Vector2 limitMin;
    [SerializeField] private Vector2 limitMax;
    //에셋에 저장항 데이터들
    public Vector3 LimitMin => limitMin;
    public Vector3 LimitMax => limitMax;
}
