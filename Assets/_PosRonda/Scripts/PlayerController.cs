using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Pengaturan Jalan")]
    public float kecepatanJalan = 0.3f;
    public float gravitasi = -9.81f;

    [Header("Pengaturan Kamera (Nengok)")]
    public float sensitivitasMouse = 2f;
    public Transform kameraPlayer;

    private CharacterController controller;
    private Vector3 kecepatanJatuh;
    private float rotasiX = 0f;

    private void Start() {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        float mouseX = Input.GetAxis("Mouse X") * sensitivitasMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivitasMouse;

        rotasiX -= mouseY;
        rotasiX = Mathf.Clamp(rotasiX, -90f, 90f);

        kameraPlayer.localRotation = Quaternion.Euler(rotasiX, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 arahGerak = transform.right * x + transform.forward * z;

        controller.Move(arahGerak * kecepatanJalan * Time.deltaTime);

        if (controller.isGrounded && kecepatanJatuh.y < 0) {
            kecepatanJatuh.y = -2f;
        }
        kecepatanJatuh.y += gravitasi * Time.deltaTime;
        controller.Move(kecepatanJatuh * Time.deltaTime);
    }

}
