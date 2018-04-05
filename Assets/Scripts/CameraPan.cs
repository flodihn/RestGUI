using UnityEngine;

public class CameraPan : MonoBehaviour
{
    void Update()
    {
        if(Input.GetMouseButton(1)) {
            transform.Translate(Vector3.right * -Input.GetAxis("Mouse X") * 1);
            transform.Translate(transform.up * -Input.GetAxis("Mouse Y") * 1, Space.World);
        }
    }
}