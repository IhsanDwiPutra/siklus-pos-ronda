using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraksiPlayer : MonoBehaviour
{
    public float jarakInteraksi = 3f;
    public Camera kameraPlayer;
    public MisiTelepon misiTelepon;
    private PlayerController playerController;

    private void Start() {
        playerController = GetComponent<PlayerController>();
    }

    private void Update() {
        Ray ray = kameraPlayer.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, jarakInteraksi)) {
            if (hit.collider.CompareTag("Telepon")) {
                UIManager.instance.TampilkanInteraksi("[E] Angkat");
                if (Input.GetKeyDown(KeyCode.E)) {
                    misiTelepon.AngkatTelepon();
                }
            } else if (hit.collider.CompareTag("Senter")){
                UIManager.instance.TampilkanInteraksi("[E] Ambil Senter");
                if (Input.GetKeyDown(KeyCode.E)) {
                    playerController.punyaSenter = true;
                }
            } else UIManager.instance.SembunyiInteraksi();
            
        } else UIManager.instance.SembunyiInteraksi();
        

    }


}
