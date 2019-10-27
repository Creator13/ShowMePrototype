using UnityEngine;

public class MouseLook : MonoBehaviour {
    [SerializeField] private bool invertY;
    [SerializeField] private float speedY;
    [SerializeField] private bool invertX;
    [SerializeField] private float speedX;

#if UNITY_EDITOR
    [SerializeField] private bool lockCursor = true;
#endif

    private bool cursorLocked;

    private bool CursorLocked {
        set {
            // Set lock state
            Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
            // Hide cursor
            Cursor.visible = !value;
            // Save value
            cursorLocked = value;
        }
        get => cursorLocked;
    }

    private void Start() {
        CursorLocked = lockCursor;
    }

    private void Update() {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Escape)) {
            CursorLocked = !CursorLocked;
        }
#endif

        float rotY = Input.GetAxis("Mouse X");
        float rotX = Input.GetAxis("Mouse Y");

        // Apply inversion
        if (invertY) rotY *= -1;
        if (invertX) rotX *= -1;

        transform.eulerAngles += new Vector3(rotX * speedX, rotY * speedY);
    }
}
