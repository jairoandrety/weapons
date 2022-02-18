using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MouseLook : MonoBehaviour
{
    [SerializeField] private CursorLockMode cursorLockMode = CursorLockMode.None; //CursorLockMode.Locked

    [SerializeField] private float mouseSensitivity = 0; // 100f
    [SerializeField] private float minXRotation = 0; //-90
    [SerializeField] private float maxXRotation = 0; //90

    [SerializeField] private GameObject playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = cursorLockMode;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minXRotation, maxXRotation);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.transform.Rotate(Vector3.up * mouseX);


    }


}
