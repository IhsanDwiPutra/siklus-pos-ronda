using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraksiPlayer : MonoBehaviour
{
    public float jarakInteraksi = 3f;
    public Camera kameraPlayer;
    public MisiTelepon misiTelepon;
    private PlayerController playerController;

    private void Update() {
        Ray ray = kameraPlayer.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, jarakInteraksi)) {
            if (hit.collider.CompareTag("Telepon")) {
                UIManager.instance.TampilkanInteraksi("[E] Angkat");
                if (Input.GetKeyDown(KeyCode.E)) {
                    misiTelepon.AngkatTelepon();
                }
            } else if (hit.collider.CompareTag("Gembok")){
                UIManager.instance.TampilkanInteraksi("[E] Cek");
                GembokRumah gembok = hit.collider.GetComponent<GembokRumah>();
                if (Input.GetKeyDown(KeyCode.E)) if (gembok != null) gembok.CekGembok();
            
            } else if(hit.collider.CompareTag("Kentongan"))
            {
                UIManager.instance.TampilkanInteraksi("[E] Pukul Kentongan");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Kentongan ketemu");

                    MisiKentongan kentongan =
                        hit.collider.GetComponent<MisiKentongan>();

                    Debug.Log("Script = " + kentongan);

                    if (kentongan != null)
                    {
                        kentongan.PukulKentongan();
                    }
                    else
                    {
                        Debug.LogError("MisiKentongan NULL");
                    }
                }
            } else UIManager.instance.SembunyiInteraksi();
            
        } else UIManager.instance.SembunyiInteraksi();
        

    }


}
