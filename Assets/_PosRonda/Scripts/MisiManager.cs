using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisiManager : MonoBehaviour
{
    public static MisiManager instance;

    public int gembokSelesai = 0;
    public int totalGembok = 3;
    public bool kentonganSudahDipukul = false;

    private void Awake() {
        instance = this;
    }

    public void GembokDiCek() { 
        gembokSelesai++;
        string daftarMisi = "TUGAS MALAM INI:\n- Cek Gembok Warga (" + gembokSelesai + "/" + totalGembok + ")\n- Pukul Kentongan\n- Kembali ke Pos";
        UIManager.instance.UpdateDaftarTugas(daftarMisi);

        if (gembokSelesai >= totalGembok) {
            UIManager.instance.MunculinTeksBatin("Semua rumah aman. Tinggal mukul kentongan di ujung gang nih.", 4f);
        } else { 
            int sisa = totalGembok - gembokSelesai;
            UIManager.instance.MunculinTeksBatin("Gemboknya karatan tapi aman. Sisa " + sisa + " rummah lagi.", 3f);
        }
    }

    public void KentonganDipukul()
    {
        kentonganSudahDipukul = true;

        string daftarMisi =
        "TUGAS MALAM INI:\n" +
        "- Cek Gembok Warga (Selesai)\n" +
        "- Pukul Kentongan (Selesai)\n" +
        "- KEMBALI KE POS!! (CEPAT)";

        UIManager.instance.UpdateDaftarTugas(daftarMisi);

        if (NightManager.instance.currentNight == 2)
        {
            NightManager.instance.LampuMatiMalam2();
        }
    }

    public void ResetMalam()
    {
        gembokSelesai = 0;
        kentonganSudahDipukul = false;
    }
}
