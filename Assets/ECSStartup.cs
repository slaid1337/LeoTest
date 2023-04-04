using UnityEngine;
using Leopotam.Ecs;

public class ECSStartup : MonoBehaviour
{
    [SerializeField] private SceneData _sceneData;

    private EcsWorld _ecsWorld;

    private EcsSystems _cameraSystems;
    private EcsSystems _gameAreaSystems;

    private void Start()
    {
        _ecsWorld = new EcsWorld();
        _cameraSystems = new EcsSystems(_ecsWorld);
        _gameAreaSystems = new EcsSystems(_ecsWorld);

        _cameraSystems
            .Add(new CameraInitSystem())
            .Add(new PlayerInputSystem())
            .Add(new CameraZoomSystem())
            .Add(new CameraMoveSystem())
            .Add(new CameraLockSystem())
            .Inject(_sceneData);

        _cameraSystems.Init();

        _gameAreaSystems
            .Add(new GameAreaInitSystem())
            .Inject(_sceneData);

        _gameAreaSystems.Init();
        
    }

    private void Update()
    {
        _cameraSystems?.Run();
        _gameAreaSystems?.Run();
    }

    private void OnDestroy()
    {
        _ecsWorld.Destroy();
        _ecsWorld = null;
    }
}
