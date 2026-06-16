using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GembokRumah : MonoBehaviour
{
    private bool udahDicek = false;

    public void CekGembok() {
        if (udahDicek == true) return;
        udahDicek = true;
        MisiManager.instance.GembokDiCek();
        gameObject.tag = "Untagged";
    }

    public void ResetGembok()
    {
        udahDicek = false;
        gameObject.tag = "Gembok";
    }
}
