using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeaSelect : MonoBehaviour
{
    public TeaStatus teaStatus;
    public TeaMaterial teaMaterial;

    public void TeaSelects()
    {
        teaStatus = new TeaStatus();
        teaStatus = teaStatus.SetTeaStatus(teaMaterial);
    }
}
