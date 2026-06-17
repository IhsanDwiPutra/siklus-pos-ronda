using UnityEngine;
using System.Collections;

public class NightManager : MonoBehaviour
{
    public static NightManager instance;

    [Header("DEBUG")]
    public bool debugMode;
    public int mulaiDariMalam = 1;

    [Header("Current Night")]
    public int currentNight = 1;

    [Header("Malam 2")]
    public Transform pagarRumah2;

    [Header("Semua Gembok")]
    public GembokRumah[] semuaGembok;

    [Header("Lampu Jalan")]
    public LampuJalan[] semuaLampu;

    [Header("Malam 3")]
    public GameObject hantuMalam3;

    private void Start()
    {
        if (!debugMode)
            return;

        currentNight = mulaiDariMalam;

        switch (currentNight)
        {
            case 2:
                StartNight2();
                break;

            case 3:
                StartNight3();
                break;

            case 4:
                StartNight4();
                break;
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void NextNight()
    {
        currentNight++;

        Debug.Log("Malam sekarang: " + currentNight);

        switch (currentNight)
        {
            case 2:
                StartNight2();
                break;

            case 3:
                StartNight3();
                break;

            case 4:
                StartNight4();
                break;

            case 5:
                StartNight5();
                break;
        }
    }

    void StartNight2()
    {
        ResetMisiMalam();

        MisiKentongan[] semuaKentongan =
            FindObjectsOfType<MisiKentongan>();

        foreach (MisiKentongan k in semuaKentongan)
        {
            k.ResetKentongan();
        }

        EndingMalam1 ending =
            FindObjectOfType<EndingMalam1>();

        if (ending != null)
        {
            ending.ResetFinish();
        }
        
        Debug.Log("Mulai Malam 2");

        if (pagarRumah2 != null)
        {
            Debug.Log("SEBELUM = " + pagarRumah2.position);

            pagarRumah2.position += new Vector3(0f, 0f, 2.7f);                

            Debug.Log("SESUDAH = " + pagarRumah2.position);
        }

        StartCoroutine(Malam2Routine());

        string daftarMisi =
            "TUGAS MALAM KEDUA:\n" +
            "- Cek Gembok Warga (0/3)\n" +
            "- Pukul Kentongan\n" +
            "- Kembali ke Pos";

        UIManager.instance.UpdateDaftarTugas(
            daftarMisi);
    }

    void StartNight3()
    {
        ResetMisiMalam();

        MisiKentongan[] semuaKentongan =
            FindObjectsOfType<MisiKentongan>();

        foreach (MisiKentongan k in semuaKentongan)
        {
            k.ResetKentongan();
        }

        EndingMalam1 ending =
            FindObjectOfType<EndingMalam1>();

        if (ending != null)
        {
            ending.ResetFinish();
        }

        StartCoroutine(Malam3Routine());

        string daftarMisi =
            "TUGAS MALAM KETIGA:\n" +
            "- Cek Gembok Warga (0/3)\n" +
            "- Pukul Kentongan\n" +
            "- Kembali ke Pos";

        UIManager.instance.UpdateDaftarTugas(
            daftarMisi
        );
    }

    void StartNight4()
    {
        Debug.Log("Mulai Malam 4");
    }

    void StartNight5()
    {
        Debug.Log("Mulai Malam 5");
    }

    void ResetMisiMalam()
    {
        MisiManager.instance.ResetMalam();

        foreach (GembokRumah gembok in semuaGembok)
        {
            if (gembok != null)
                gembok.ResetGembok();
        }
    }

    public void MatikanSemuaLampu()
    {
        foreach (LampuJalan lampu in semuaLampu)
        {
            if (lampu != null)
            {
                lampu.MatikanLampu();
            }
        }

        Debug.Log("Semua lampu mati");
    }

    public void LampuMatiMalam2()
    {
        foreach (LampuJalan lampu in semuaLampu)
        {
            if (lampu != null)
            {
                lampu.MatikanLampu();
            }
        }

        Debug.Log("Lampu jalan mati");

        UIManager.instance.MunculinTeksBatin(
            "Lho... lampu jalannya mati?",
            4f
        );
    }

    public void MunculkanHantuMalam3()
    {
        if(currentNight != 3)
            return;

        StartCoroutine(HantuMalam3Routine());
    }

    IEnumerator HantuMalam3Routine()
    {
        if (hantuMalam3 == null)
            yield break;

        hantuMalam3.SetActive(true);

        UIManager.instance.MunculinTeksBatin(
            "Eh...? Itu siapa di sana?",
            3f
        );

        yield return new WaitForSeconds(2f);

        hantuMalam3.SetActive(false);
    }

    public IEnumerator MulaiMalamBaru(
        string judul,
        string subtitle)
    {
        yield return StartCoroutine(
            SceneFader.instance.FadeOut(2f));

        UIManager.instance.UpdateDaftarTugas("");

        yield return new WaitForSeconds(1f);

        UIManager.instance.TampilkanJudulMalam(
            "<size=60>" + judul + "</size>\n\n" +
            subtitle
        );

        yield return new WaitForSeconds(3f);

        UIManager.instance.SembunyikanJudulMalam();

        yield return StartCoroutine(
            SceneFader.instance.FadeIn(2f));
    }

    IEnumerator Malam2Routine()
    {
        yield return StartCoroutine(
            MulaiMalamBaru(
                "MALAM 2",
                "Shift Kedua"
            )
        );

        UIManager.instance.MunculinTeksBatin(
            "Loh... pagar rumah itu kok kebuka?",
            4f
        );

        string daftarMisi =
            "TUGAS MALAM KEDUA:\n" +
            "- Cek Gembok Warga (0/3)\n" +
            "- Pukul Kentongan\n" +
            "- Kembali ke Pos";

        UIManager.instance.UpdateDaftarTugas(
            daftarMisi
        );
    }

    IEnumerator Malam3Routine()
    {
        yield return StartCoroutine(
            MulaiMalamBaru(
                "MALAM 3",
                "Shift Ketiga"
            )
        );

        UIManager.instance.MunculinTeksBatin(
            "Perasaan gue gak enak malam ini...",
            4f
        );

        string daftarMisi =
            "TUGAS MALAM KETIGA:\n" +
            "- Cek Gembok Warga (0/3)\n" +
            "- Pukul Kentongan\n" +
            "- Kembali ke Pos";

        UIManager.instance.UpdateDaftarTugas(
            daftarMisi
        );
    }
}