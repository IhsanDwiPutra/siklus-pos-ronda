using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraksiPlayer : MonoBehaviour
{
    public float jarakInteraksi = 3f;
    public Camera kameraPlayer;
    public MisiTelepon misiTelepon;

    private void Update() {
        Ray ray = kameraPlayer.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, jarakInteraksi)) {
            if (hit.collider.CompareTag("Telepon")){
                if (Input.GetKeyDown(KeyCode.E)) {
                    Debug.Log("Interaksi HP");
                    misiTelepon.AngkatTelepon();
                }
            }
        }

    }


}
