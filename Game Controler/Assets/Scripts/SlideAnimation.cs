using UnityEngine;

public class SliderMovement : MonoBehaviour
{
    public Vector3 pos1 = new Vector3(0, 0, 0);
    public Vector3 pos2 = new Vector3(5, 0, 0);
    public float speed = 2f;

    private bool isMoving = true;

    void Start()
    {
        transform.position = pos1;
    }

    void Update()
    {
        if (!isMoving) return;

        transform.position = Vector3.MoveTowards(transform.position, pos2, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pos2) < 0.001f)
        {
            isMoving = false;
        }
    }
}
