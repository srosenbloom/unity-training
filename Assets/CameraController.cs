using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector2 rotation = Vector2.zero;
    public float speed = 3;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            rotation.y += Input.GetAxis ("Mouse X");
            rotation.x += -Input.GetAxis ("Mouse Y");
            transform.eulerAngles = rotation * speed;
        }
    }
}
