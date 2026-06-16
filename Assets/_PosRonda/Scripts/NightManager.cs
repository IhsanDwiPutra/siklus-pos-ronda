using UnityEngine;

public class NightManager : MonoBehaviour
{
    public static NightManager instance;

    [Header("Current Night")]
    public int currentNight = 1;

    [Header("Malam 2")]
    public Transform pagarRumah2;

    [Header("Semua Gembok")]
    public GembokRumah[] semuaGembok;

    [Header("Lampu Jalan")]
    public LampuJalan[] semuaLampu;

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

            pagarRumah2.position =
                new Vector3(
                    -1.14f,
                    0.0997f,
                    7.1832f
                );

            Debug.Log("SESUDAH = " + pagarRumah2.position);
        }

        UIManager.instance.MunculinTeksBatin(
            "Loh... pagar rumah itu kok kebuka?",
            4f);

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
        Debug.Log("Mulai Malam 3");
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
}