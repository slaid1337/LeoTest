using UnityEngine;

public class SceneData : MonoBehaviour
{
    public BoxCollider2D gameAreaBounds;
    public Transform gameArea;
    public Transform cameraTransform;
    public float minCameraZoom;
    public float maxCameraZoom;
    public float zoomSpeed;
    public Vector3 minBounds;
    public Vector3 maxBounds;

    private void Awake()
    {
        minBounds = gameAreaBounds.bounds.min;
        maxBounds = gameAreaBounds.bounds.max;
    }
}