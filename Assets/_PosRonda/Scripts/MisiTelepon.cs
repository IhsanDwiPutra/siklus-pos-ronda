using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MisiTelepon : MonoBehaviour
{
    public AudioSource suaraHP;
    public PlayerController playerController;
    private bool udahDiangkat = false;
    public GameObject HP;

    public void AngkatTelepon() {
        if (udahDiangkat) return;
        udahDiangkat = true;
        if (suaraHP != null) suaraHP.Stop();
        Destroy(HP);

        StartCoroutine(DialogPakRT());
    }

    IEnumerator DialogPakRT() {
        string[] obrolan = {
            "Halo, Pak RT? Ada apa malem-malem?",
            "[Pak RT] : Halo, Ndro... Kamu udah standby di pos kan?",
            "Udah Pak, ini baru aja mau nyeduh kopi.",
            "[Pak RT] : Tolong keliling gang ya cek gembok warga. Perasaan bapak gak enak nih...",
            "Siap Pak, aman. Saya keliling sekarang.",
            "*Tit.. Tit.. Tit..* (Telepon ditutup)"
        };

        foreach (string kalimat in obrolan) { 
            UIManager.instance.SetTeksManual(kalimat + "\n<size=15><i>[Tekan SPASI]</i></size>");

            yield return null;

            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0));
        }

        UIManager.instance.SembunyiTeks();

        if (playerController != null) {
            playerController.canMove = true;

            Camera cam = playerController.GetComponentInChildren<Camera>();
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, 0.6f, cam.transform.localPosition.z);
        }
    }


}
