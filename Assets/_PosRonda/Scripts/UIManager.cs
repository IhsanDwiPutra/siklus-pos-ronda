using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI teksBatin;
    public TextMeshProUGUI teksDialog;

    void Awake() {
        instance = this;
    }

    private void Start() {
        teksBatin.enabled = false;
        teksDialog.enabled = false;
    }

    public void MunculinTeksBatin(string kataKata, float lamaMuncul) {
        StopAllCoroutines();

        StartCoroutine(ProsesTeks(kataKata, lamaMuncul));
    }

    IEnumerator ProsesTeks(string kataKata, float lamaMuncul) { 
        teksBatin.text = kataKata;
        teksBatin.enabled = true;

        yield return new WaitForSeconds(lamaMuncul);
        teksBatin.enabled = false;
    }

    public void SetTeksManual(string kataKata) {
        StopAllCoroutines();
        teksDialog.text = kataKata;
        teksDialog.enabled = true;
    }

    public void SembunyiTeks() {
        teksDialog.enabled = false;
    }

}
