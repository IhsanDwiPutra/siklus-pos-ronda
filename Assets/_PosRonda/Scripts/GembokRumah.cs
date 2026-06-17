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
        if (
            NightManager.instance.currentNight == 3 &&
            MisiManager.instance.gembokSelesai >= 3
        )
        {
            NightManager.instance.MunculkanHantuMalam3();
        }
        gameObject.tag = "Untagged";
    }

    public void ResetGembok()
    {
        udahDicek = false;
        gameObject.tag = "Gembok";
    }
}
