using Leopotam.Ecs;
using UnityEngine;

public class CameraLockSystem : IEcsRunSystem
{
    private EcsFilter<CameraEcs> _ecsFilter;
    private SceneData _sceneData;

    public void Run()
    {
        foreach (var i in _ecsFilter)
        {
            ref var camera = ref _ecsFilter.Get1(i);

            camera.halfHeight = camera.camera.orthographicSize;
            camera.halfWidth = camera.halfHeight * Screen.width / Screen.height;

            float clampedX = Mathf.Clamp(camera.cameraTransform.position.x, _sceneData.minBounds.x + camera.halfWidth, _sceneData.maxBounds.x - camera.halfWidth);
            float clampedY = Mathf.Clamp(camera.cameraTransform.position.y, _sceneData.minBounds.y + camera.halfHeight, _sceneData.maxBounds.y - camera.halfHeight);
            camera.cameraTransform.position = new Vector3(clampedX, clampedY, camera.cameraTransform.position.z);
        }
    }
}
