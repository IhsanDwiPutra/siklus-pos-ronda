using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisiKentongan : MonoBehaviour
{
    public AudioSource suaraKentongan;
    private bool udahDipukul = false;

    public void PukulKentongan() {
        if (MisiManager.instance.gembokSelesai < MisiManager.instance.totalGembok) {
            UIManager.instance.MunculinTeksBatin("Gue harus ngecek 3 gembok warga dulu sebelum mukul ini.", 3f);
            return;
        }

        if (udahDipukul) return;
        udahDipukul = true;

        if (suaraKentongan != null) suaraKentongan.Play();

        MisiManager.instance.KentonganDipukul();

        StartCoroutine(MulaiTeror());
    }

    IEnumerator MulaiTeror() {
        yield return new WaitForSeconds(4f);

        UIManager.instance.MunculinTeksBatin("Udah kelar semua. Mending buruan balik ke pos.", 5f);
    }

    public void ResetKentongan()
    {
        udahDipukul = false;
        gameObject.tag = "Kentongan";
    }
}
