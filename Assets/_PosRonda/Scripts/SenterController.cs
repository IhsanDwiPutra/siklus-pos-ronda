using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenterController : MonoBehaviour
{
    public Light lampuSenter;
    private bool isNyala = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F)) {
            isNyala = !isNyala;
            lampuSenter.enabled = isNyala;
        }
    }


}
