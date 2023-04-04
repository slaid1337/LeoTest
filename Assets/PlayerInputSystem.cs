using UnityEngine;
using Leopotam.Ecs;

public class PlayerInputSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _ecsFilter;
    private SceneData _sceneData;

    public void Run()
    {
        foreach (var i in _ecsFilter)
        {
            ref var input = ref _ecsFilter.Get1(i);
            ref var camera = ref _ecsFilter.Get2(i);

            input.zoomInput = Input.GetAxis("Mouse ScrollWheel") * _sceneData.zoomSpeed;
            input.pointerDown = Input.GetMouseButton(0);
            input.pointerDownOnce = Input.GetMouseButtonDown(1);
            input.mousePos = camera.camera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
