using UnityEngine;

public struct CameraEcs//Component
{
    public Transform cameraTransform;
    public Camera camera;
    public float minCameraZoom;
    public float maxCameraZoom;
    public float halfHeight;
    public float halfWidth;
}
