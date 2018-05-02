using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private Camera cam;
    private float cameraZDepth;
    private Bounds ScreenBounds;
    private int trackingSpeed;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        cameraZDepth = -10f;
        trackingSpeed = 10;

        // find scene objects border
        Renderer[] rnds = FindObjectsOfType<Renderer>();
        Bounds b = rnds[0].bounds;
        foreach (Renderer r in rnds)
        {
            if (r.gameObject.CompareTag("BouncyHome"))
            {
                continue;
            }
            b.Encapsulate(r.bounds);
        }

        // set camera bounds to scene object
        float height = cam.orthographicSize;
        float width = cam.aspect * height;
        Vector3 min = new Vector3(b.min.x + width, b.min.y + height, 0);
        Vector3 max = new Vector3(b.max.x - width, b.max.y - height, 0);
        ScreenBounds.SetMinMax(min, max);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Transform cameraTrackTarget;
        GameObject temp = GameObject.FindGameObjectWithTag("BouncyBig");
        if (temp)
        {
            cameraTrackTarget = temp.transform;
        }
        else
        {
            cameraTrackTarget = GameObject.FindGameObjectWithTag("BouncySmall").transform;
        }

        Vector2 newPosition = Vector2.Lerp(transform.position, cameraTrackTarget.position, Time.deltaTime * trackingSpeed);
        float x = Mathf.Clamp(newPosition.x, ScreenBounds.min.x, ScreenBounds.max.x);
        float y = Mathf.Clamp(newPosition.y, ScreenBounds.min.y, ScreenBounds.max.y);
        transform.position = new Vector3(x, y, cameraZDepth);
    }
}