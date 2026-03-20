using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MisiTelepon : MonoBehaviour
{
    public AudioSource suaraHP;
    //public PlayerController playerController;
    private bool udahDiangkat = false;
    public GameObject HP;

    [Header("Komponen Player")]
    public GameObject playerParent;
    public Transform targetTeleportLuar;

    public void AngkatTelepon() {
        UIManager.instance.MunculinTeksBatin("", 0);
        if (udahDiangkat) return;
        udahDiangkat = true;
        if (suaraHP != null) suaraHP.Stop();

        Destroy(HP);

        StartCoroutine(DialogPakRT());
    }

    IEnumerator DialogPakRT() {
        string[] obrolan = {
            "Halo, Assalamualaikum? Pos Ronda RT 04 di sini.",
            "[Pak RT] : Waalaikumsalam. Ini Mas Bayu ya? Warga baru yang ngontrak di ujung jalan itu?, Ini Pak RT",
            "Eh, iya Pak RT. Betul, saya Bayu. Ini lagi giliran jaga pos, Pak.",
            "[Pak RT] : Syukurlah kalau udah standby. Maaf ya Mas, malam pertama pindah langsung bapak jadwalin ronda.",
            "Gak apa-apa, Pak. Hitung-hitung sekalian kenalan sama lingkungan komplek.",
            "[Pak RT] : Nah, gitu dong. Lingkungan kita ini biasanya aman tentram kok, Mas. Cuma...",
            "Cuma kenapa, Pak?",
            "[Pak RT] : Perasaan bapak agak gak enak malam ini. Mas Bayu tolong keliling gang ya, pastikan gembok 3 rumah warga aman.",
            "[Pak RT] : Terus, jangan lupa pukul kentongan di ujung gang buntu biar warga tau ada yang patroli.",
            "Siap, laksanakan Pak. Saya keliling bawa senter sekarang.",
            "[Pak RT] : Hati-hati ya, Mas. Kalau ada yang 'aneh-aneh', hiraukan saja. Jangan ditegur.",
            "...Halo? Pak? Aneh-aneh gimana maksudnya--",
            "*Tit.. Tit.. Tit..* (Telepon ditutup)"



            //"Halo, Pak RT? Ada apa malem-malem?",
            //"[Pak RT] : Halo, Ndro... Kamu udah standby di pos kan?",
            //"Udah Pak, ini baru aja mau nyeduh kopi.",
            //"[Pak RT] : Tolong keliling gang ya cek gembok warga. Perasaan bapak gak enak nih...",
            //"Siap Pak, aman. Saya keliling sekarang.",
            //"*Tit.. Tit.. Tit..* (Telepon ditutup)"
        };

        foreach (string kalimat in obrolan) { 
            UIManager.instance.SetTeksManual(kalimat + "\n\n<size=15><i>[Tekan SPASI]</i></size>");

            yield return null;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
        }

        UIManager.instance.SembunyiTeks();

        yield return StartCoroutine(SceneFader.instance.FadeOut(1.5f));
        yield return new WaitForSeconds(0.5f);
        if (playerParent != null && targetTeleportLuar != null) { 
            CharacterController cc = playerParent.GetComponent<CharacterController>();
            if (cc != null) cc.enabled = false;

            playerParent.transform.position = targetTeleportLuar.transform.position;
            playerParent.transform.rotation = targetTeleportLuar.transform.rotation;

            //Camera cam = playerParent.GetComponentInChildren<Camera>();
            //if (cam != null) { 
            //    cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, 0.6f, cam.transform.localPosition.z);
            //}
            if (cc != null) cc.enabled = true;

            PlayerController pc = playerParent.GetComponent<PlayerController>();
            if (pc != null) pc.canMove = true;
        }

        yield return StartCoroutine(SceneFader.instance.FadeIn(1.5f));

        UIManager.instance.MunculinTeksBatin("Hiraukan saja katanya... Bikin parno aja si Bapak.", 4f);
        yield return new WaitForSeconds(3f);
        UIManager.instance.MunculinTeksBatin("Yaudah lah. Cek 3 gembok rumah, pukul kentongan di ujung gang, terus balik tidur.", 5f);

        string daftarMisi = "TUGAS MALAM INI:\n- Cek Gembok Warga (0/3)\n- Pukul Kentongan\n- Kembali ke Pos";
        UIManager.instance.UpdateDaftarTugas(daftarMisi);
    }


}
