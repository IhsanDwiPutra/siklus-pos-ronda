using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Status Player")]
    public bool canMove = false;

    [Header("Pengaturan Jalan")]
    public float kecepatanJalan = 0.3f;
    public float gravitasi = -9.81f;

    [Header("Pengaturan Kamera (Nengok)")]
    public float sensitivitasMouse = 2f;
    public Transform kameraPlayer;

    private CharacterController controller;
    private Vector3 kecepatanJatuh;
    private float rotasiX = 0f;

    [Header("Setingan Goyangan Kepala(Headbob)")]
    public float bobSpeed = 10f; // Kecepatan langkah kaki (Makin besar makin cepat ngayun)
    public float bobAmount = 0.05f; // Tinggi ayunan
    float defaultPosY = 0.6f; // Posisi tinggi kamera
    float timer = 0f;

    private void Start() {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        defaultPosY = kameraPlayer.transform.localPosition.y;
    }

    private void Update() {
        float mouseX = Input.GetAxis("Mouse X") * sensitivitasMouse;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivitasMouse;

        rotasiX -= mouseY;
        rotasiX = Mathf.Clamp(rotasiX, -90f, 90f);

        kameraPlayer.localRotation = Quaternion.Euler(rotasiX, 0f, 0f);

        transform.Rotate(Vector3.up * mouseX);

        if (canMove == true) { 
        
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 arahGerak = transform.right * x + transform.forward * z;

            controller.Move(arahGerak * kecepatanJalan * Time.deltaTime);

            if (controller.isGrounded && kecepatanJatuh.y < 0) {
                kecepatanJatuh.y = -2f;
            }
            kecepatanJatuh.y += gravitasi * Time.deltaTime;
            controller.Move(kecepatanJatuh * Time.deltaTime);

            // Headbob
            if (Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f) {
                timer += Time.deltaTime * bobSpeed;
                kameraPlayer.transform.localPosition = new Vector3(kameraPlayer.transform.localPosition.x, defaultPosY + Mathf.Sin(timer) * bobAmount, kameraPlayer.transform.localPosition.z);

            } else {
                timer = 0f;
                kameraPlayer.transform.localPosition = new Vector3(kameraPlayer.transform.localPosition.x, Mathf.Lerp(kameraPlayer.transform.localPosition.y, defaultPosY, Time.deltaTime * bobSpeed), kameraPlayer.transform.localPosition.z);
            }
        }

    }
}
