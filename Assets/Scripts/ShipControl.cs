using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject bulletPrefab;
    public float speedShip = 10f;
    public float axisXLimit = 7f;
    public float reloadTime = 0.5f;
    public float elapsedTime = 0f;
    private void Update()
    {
        elapsedTime += Time.deltaTime; // ������ ������� ����� ��������
        float axisXInput = Input.GetAxis("Horizontal"); // ����������� left/right
        transform.Translate(axisXInput * speedShip * Time.deltaTime, 0f, 0f); // ����������� left/right
        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -axisXLimit, axisXLimit);
        transform.position = position;
        if (Input.GetButtonDown("Jump") && elapsedTime > reloadTime)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(0, 1.2f, 0);
            Instantiate(bulletPrefab, spawnPos, Quaternion.identity);
            elapsedTime = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider other)
    {
        gameManager.PlayerDied();
    }
}
