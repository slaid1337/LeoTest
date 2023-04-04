using Leopotam.Ecs;
using UnityEngine;

public class GameAreaInitSystem : IEcsInitSystem
{
    private EcsWorld _ecsWorld;
    private SceneData _sceneData;

    public void Init()
    {
        EcsEntity gameAreaEntity = _ecsWorld.NewEntity();

        ref var gameArea = ref gameAreaEntity.Get<GameAreaEcs>();

        gameArea.boundBox = _sceneData.gameArea.GetComponent<BoxCollider2D>();
    }
}
