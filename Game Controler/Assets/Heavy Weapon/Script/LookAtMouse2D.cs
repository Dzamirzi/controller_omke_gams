using UnityEngine;

public class LookAtMouse2D : MonoBehaviour
{
    [Header("Rotation Settings")]
    public bool smoothRotate = true;
    public float rotateSpeed = 10f;
    public float rotationOffset = 0f;

    [Header("Rotation Limits")]
    public bool limitRotation = false;
    [Tooltip("Minimum rotation angle (in degrees, relative to the sprite’s forward).")]
    public float minAngle = -45f;
    [Tooltip("Maximum rotation angle (in degrees, relative to the sprite’s forward).")]
    public float maxAngle = 45f;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        if (mainCam == null)
            Debug.LogWarning("LookAtMouse2D: No camera with 'MainCamera' tag found!");
    }

    void Update()
    {
        if (mainCam == null) return;

        Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - transform.position).normalized;
        float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + rotationOffset;

        // 🔒 Clamp rotation if enabled
        if (limitRotation)
            targetAngle = Mathf.Clamp(targetAngle, minAngle + rotationOffset, maxAngle + rotationOffset);

        if (smoothRotate)
        {
            float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, targetAngle, rotateSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        }
    }
}
