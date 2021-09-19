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
                teaStatus = new TeaStatus(TeaMaterial.A, "산호초", "효능A");
                break;
            case TeaMaterial.B:
                teaStatus = new TeaStatus(TeaMaterial.B, "보랏빛 버섯", "효능B");
                break;
            case TeaMaterial.C:
                teaStatus = new TeaStatus(TeaMaterial.C, "요상한 잡초", "효능C");
                break;
            case TeaMaterial.D:
                teaStatus = new TeaStatus(TeaMaterial.D, "자작나무 껍질", "효능D");
                break;
            case TeaMaterial.E:
                teaStatus = new TeaStatus(TeaMaterial.E, "이슬", "효능E");
                break;
            case TeaMaterial.F:
                teaStatus = new TeaStatus(TeaMaterial.F, "선인장의 꽃", "효능F");
                break;
            case TeaMaterial.G:
                teaStatus = new TeaStatus(TeaMaterial.G, "축소된 바오밥나무", "효능G");
                break;
        }
        return teaStatus;
    }

    //public 
}
