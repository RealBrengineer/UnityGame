using UnityEngine;

public class MouseLook : MonoBehaviour
{

    #region Public Variables
    public float mouseSensitivity = 3f;
    public Transform playerBody;
    float xRotation = 0f;
    #endregion

    #region Unity Methods
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseSensitivityFactor = 100 * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * (mouseSensitivityFactor) * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * (mouseSensitivityFactor) * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    #endregion
}
