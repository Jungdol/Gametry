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
                teaStatus = new TeaStatus(TeaMaterial.A, "A", "효능A");
                break;
            case TeaMaterial.B:
                teaStatus = new TeaStatus(TeaMaterial.B, "B", "효능B");
                break;
            case TeaMaterial.C:
                teaStatus = new TeaStatus(TeaMaterial.C, "C", "효능C");
                break;
            case TeaMaterial.D:
                teaStatus = new TeaStatus(TeaMaterial.D, "D", "효능D");
                break;
            case TeaMaterial.E:
                teaStatus = new TeaStatus(TeaMaterial.E, "E", "효능E");
                break;
            case TeaMaterial.F:
                teaStatus = new TeaStatus(TeaMaterial.F, "F", "효능F");
                break;
            case TeaMaterial.G:
                teaStatus = new TeaStatus(TeaMaterial.G, "G", "효능G");
                break;
        }
        return teaStatus;
    }

    //public 
}
