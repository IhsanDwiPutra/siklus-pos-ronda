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
    public GameObject HP;


    private void Start() {
        HP.GetComponent<BoxCollider>().enabled = false;
        layarHP.SetActive(false);
        StartCoroutine(MulaiTelpon());
    }

    IEnumerator MulaiTelpon() { 
        yield return new WaitForSeconds(nungguFadeIn);
        UIManager.instance.MunculinTeksBatin("Hawa malam ini kok beda ya... Dingin banget.", 4f);

        yield return new WaitForSeconds(3f);

        UIManager.instance.MunculinTeksBatin("Baru juga sehari pindah ngontrak di sini, eh langsung kena jatah shift ronda sendirian.", 7f);

        yield return new WaitForSeconds(jedaSebelumNelpon);
        HP.GetComponent<BoxCollider>().enabled = true;

        if (suaraHP != null) {
            suaraHP.Play();
        }
        if (layarHP != null) { 
            layarHP.SetActive(true);
        }
        UIManager.instance.MunculinTeksBatin("Eh copot! Buset dah kaget gue. Tumben telepon pos bunyi jam segini. Siapa ya?", 5f);
    }

}
