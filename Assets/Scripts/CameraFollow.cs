using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smooth = 5f;
    void LateUpdate()
    {
        if (target == null) return;
        Vector3 pos = target.position;
        pos.z = -10;
        transform.position = Vector3.Lerp(transform.position, pos, smooth * Time.deltaTime);
    }
}