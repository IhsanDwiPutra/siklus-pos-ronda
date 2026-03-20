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

    [Header("UI Interkasi")]
    public TextMeshProUGUI UIInteraksi;

    [Header("UI Daftar Tugas")]
    public TextMeshProUGUI teksTugas;

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

    public void TampilkanInteraksi(string pesan) { 
        UIInteraksi.text = pesan;
        UIInteraksi.enabled = true;
    }

    public void SembunyiInteraksi() {
        UIInteraksi.text = "";
        UIInteraksi.enabled = false;
    }

    public void UpdateDaftarTugas(string tugasBaru) {
        teksTugas.text = tugasBaru;
        teksTugas.enabled = true;
    }

    public void SembunyiDaftarTugas() {
        teksTugas.enabled = false;
    }

}
