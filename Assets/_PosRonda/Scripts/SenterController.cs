using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenterController : MonoBehaviour
{
    public Light lampuSenter;
    private bool isNyala = false;
    private bool punyaSenter;

    private void Start() {
        PlayerController pc = GetComponentInParent<PlayerController>();
        punyaSenter = pc.punyaSenter;
    }

    private void Update() {
        if (punyaSenter && Input.GetKeyDown(KeyCode.F)) {
            isNyala = !isNyala;
            lampuSenter.enabled = isNyala;
        }
    }


}
