using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TeaMaterial
{
    A = 0,
    B,
    C,
    D,
    E,
    F,
    G = 6,
}
public class TeaStatus
{
    public TeaMaterial teaMaterial { get; }
    public string name { get; set; }
    public string efficacy { get; set; }

    public TeaStatus()
    { 

    }

    public TeaStatus(TeaMaterial _teaMaterial, string _name, string _efficacy)
    {
        this.teaMaterial = _teaMaterial;
        this.name = _name;
        this.efficacy = _efficacy;
    }

    public TeaStatus SetTeaStatus(TeaMaterial _teaMaterial)
    {
        TeaStatus teaStatus = null;

        switch (_teaMaterial)
        {
            case TeaMaterial.A:
                teaStatus = new TeaStatus(TeaMaterial.A, "죽어가는 산호초", "잠에 취하게 한다.");
                break;
            case TeaMaterial.B:
                teaStatus = new TeaStatus(TeaMaterial.B, "보랏빛 버섯", "불안함을 없앤다.");
                break;
            case TeaMaterial.C:
                teaStatus = new TeaStatus(TeaMaterial.C, "요상한 잡초", "타인에 대해 이해하는 감정이 생긴다.");
                break;
            case TeaMaterial.D:
                teaStatus = new TeaStatus(TeaMaterial.D, "자작나무 껍질", "무기력함을 없앤다.");
                break;
            case TeaMaterial.E:
                teaStatus = new TeaStatus(TeaMaterial.E, "이슬", "자신감이 생긴다.");
                break;
            case TeaMaterial.F:
                teaStatus = new TeaStatus(TeaMaterial.F, "선인장의 꽃", "몸을 개운하게 만든다.");
                break;
            case TeaMaterial.G:
                teaStatus = new TeaStatus(TeaMaterial.G, "봉황의 깃털", "몸을 따뜻하게 만든다.");
                break;
        }
        return teaStatus;
    }

    //public 
}
