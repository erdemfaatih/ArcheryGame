using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level5Kamera : MonoBehaviour
{
    public float moveSpeed = 5f; // Kamera hareket hýzý
    public float shakeMagnitude = 0.1f; // Titreme þiddeti

    private Vector3 originalPosition; // Kameranýn orijinal konumu

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        // Fare giriþini al
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Kamera rotasyonunu güncelle
        float xRotation = transform.localEulerAngles.x - mouseY;
        float yRotation = transform.localEulerAngles.y + mouseX;
        transform.localEulerAngles = new Vector3(xRotation, yRotation, 0f);

        // Kamera konumunu titret
        Vector3 shakeOffset = Random.insideUnitSphere * shakeMagnitude;
        transform.localPosition = originalPosition + shakeOffset;

        // Kamera hareketini uygula
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(moveX, 0, moveZ);
    }
}
