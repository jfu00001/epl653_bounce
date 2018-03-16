using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
    public Transform cameraTrackTarget;

    public float trackingSpeed;

    public float cameraZDepth = -10f;
    public float minX, minY;
    public float maxX, maxY;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraTrackTarget != null)
        {
            var newPosition = Vector2.Lerp(transform.position, cameraTrackTarget.position, Time.deltaTime * trackingSpeed);
            var camPosition = new Vector3(newPosition.x, newPosition.y, cameraZDepth);

            var newX = Mathf.Clamp(camPosition.x, minX, maxX);
            var newY = Mathf.Clamp(camPosition.y, minY, maxY);
            transform.position = new Vector3(newX, newY, cameraZDepth);
        }
    }
}