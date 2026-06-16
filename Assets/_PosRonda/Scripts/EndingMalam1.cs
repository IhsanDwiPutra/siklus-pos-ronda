using System.Collections;
using UnityEngine;

public class EndingMalam1 : MonoBehaviour
{
    bool sudahSelesai = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("MASUK TRIGGER");

        if (!other.CompareTag("Player"))
            return;

        Debug.Log("PLAYER TERDETEKSI");

        Debug.Log("sudahSelesai = " + sudahSelesai);

        if (sudahSelesai)
            return;

        Debug.Log("kentongan = " + MisiManager.instance.kentonganSudahDipukul);

        if (!MisiManager.instance.kentonganSudahDipukul)
            return;

        sudahSelesai = true;

        StartCoroutine(SelesaiMalam1());
    }

    IEnumerator SelesaiMalam1()
    {
        UIManager.instance.MunculinTeksBatin(
            "Akhirnya kelar juga ronda malam ini.",
            3f);

        yield return new WaitForSeconds(2f);

        yield return StartCoroutine(
            SceneFader.instance.FadeOut(2f));

        UIManager.instance.UpdateDaftarTugas("");

        yield return new WaitForSeconds(1f);

        UIManager.instance.SetTeksManual(
            "<size=60>MALAM KEDUA</size>");

        yield return new WaitForSeconds(3f);

        UIManager.instance.SembunyiTeks();

        NightManager.instance.NextNight();

        yield return StartCoroutine(
            SceneFader.instance.FadeIn(2f));
    }

    public void ResetFinish()
    {
        sudahSelesai = false;
    }
}