using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SutradaraOpening : MonoBehaviour
{

    [Header("Pengaturan Waktu (Detik)")]
    public float nungguFadeIn = 5f;
    public float jedaSebelumNelpon = 5f;

    [Header("Telepon & Layar")]
    public AudioSource suaraHP;
    public GameObject layarHP;


    private void Start() {
        StartCoroutine(MulaiTelpon());
        layarHP.SetActive(false);
    }

    IEnumerator MulaiTelpon() { 
        yield return new WaitForSeconds(nungguFadeIn);
        UIManager.instance.MunculinTeksBatin("Huft... Shift pertama. Perasaan gue nggak enak banget malam ini...", 5f);

        yield return new WaitForSeconds(jedaSebelumNelpon);

        if (suaraHP != null) {
            suaraHP.Play();
        }
        if (layarHP != null) { 
            layarHP.SetActive(true);
        }
        UIManager.instance.MunculinTeksBatin("Tumben Pak RT nelpon malem-malem... Angkat dulu deh.", 5f);
    }

}
