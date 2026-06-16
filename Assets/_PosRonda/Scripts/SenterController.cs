using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenterController : MonoBehaviour
{
    public Light lampuSenter;
    private bool isNyala = false;
    PlayerController playerController;

    private void Start() {
        playerController = GetComponentInParent<PlayerController>();
    }

    private void Update() {
        if (playerController.canMove && Input.GetKeyDown(KeyCode.F)) {
            isNyala = !isNyala;
            lampuSenter.enabled = isNyala;
        }
    }


}
