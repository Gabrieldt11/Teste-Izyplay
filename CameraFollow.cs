using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public float speed = 5.0f;
    Camera cam;
    public Transform knife;
    Vector3 halfSizeCam;

    void Start()
    {
        cam = GetComponent<Camera>();
        float zDepth = knife.position.z - transform.position.z;
        float yHalf = zDepth * Mathf.Tan(Mathf.Deg2Rad * cam.fieldOfView/2f);
        float xHalf = yHalf * ((float) Screen.width / Screen.height);
        halfSizeCam = new Vector3(xHalf, yHalf, zDepth);
    }

    void FixedUpdate()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Lerp(pos.x, knife.position.x, speed * Time.deltaTime);
        pos.y = Mathf.Lerp(pos.y, knife.position.y, speed * Time.deltaTime);

        pos.x = Mathf.Clamp(pos.x, -25 + halfSizeCam.x, 70 + halfSizeCam.x);
        pos.y = Mathf.Clamp(pos.y, halfSizeCam.y, 50f - halfSizeCam.y);

        transform.position = pos;
    }
}
