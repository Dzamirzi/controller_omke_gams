using UnityEngine;

public class FollowMouse2D : MonoBehaviour
{
    [Header("Follow Settings")]
    public bool smoothFollow = true;
    public float followSpeed = 10f;
    public float fixedZ = 0f;

    [Header("Axis Control")]
    public bool freezeY = false;

    [Header("Movement Boundaries")]
    public bool useBoundaries = false;
    public Vector2 minBounds = new Vector2(-8f, -4f);
    public Vector2 maxBounds = new Vector2(8f, 4f);

    private Camera mainCam;
    private float frozenY;

    void Start()
    {
        mainCam = Camera.main;
        if (mainCam == null)
            Debug.LogWarning("FollowMouse2D: No camera with 'MainCamera' tag found!");
        frozenY = transform.position.y;
    }

    void Update()
    {
        if (mainCam == null) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(mainCam.transform.position.z - fixedZ);
        Vector3 targetPos = mainCam.ScreenToWorldPoint(mousePos);
        targetPos.z = fixedZ;

        if (freezeY)
            targetPos.y = frozenY;

        // 🔒 Clamp movement within boundaries
        if (useBoundaries)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, minBounds.x, maxBounds.x);
            targetPos.y = Mathf.Clamp(targetPos.y, minBounds.y, maxBounds.y);
        }

        if (smoothFollow)
        {
            transform.position = Vector3.Lerp(
                transform.position,
                targetPos,
                1f - Mathf.Exp(-followSpeed * Time.deltaTime)
            );
        }
        else
        {
            transform.position = targetPos;
        }
    }
}
