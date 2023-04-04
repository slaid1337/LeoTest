using UnityEngine;
using Leopotam.Ecs;

public class CameraMoveSystem : IEcsRunSystem
{
    private EcsFilter<PlayerInputData, CameraEcs> _ecsFilter;

    private bool drag;
    private Vector3 mouseorigin;

    public void Run()
    {
        foreach (var i in _ecsFilter)
        {
            ref var input = ref _ecsFilter.Get1(i);
            ref var camera = ref _ecsFilter.Get2(i);

            if (!input.pointerDown)
            {
                drag = false;
                return;
            }

            Vector3 difference = input.mousePos - camera.camera.transform.position;

            if (!drag)
            {
                drag = true;
                mouseorigin = input.mousePos;
            }

            Vector3 move = mouseorigin - difference;
            camera.cameraTransform.position = move;
        }
    }
}
