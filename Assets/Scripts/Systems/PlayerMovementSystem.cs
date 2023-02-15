using Unity.Mathematics;
using Unity.Entities;
using Unity.Transforms;


public class PlayerMovementSystem : SystemBase
{
    protected override void OnUpdate()
    {
        float deltaTime = Time.DeltaTime;
        Entities.ForEach((ref Translation pos, in PlayerMovement move) =>
        {
            float3 normalisedDir = math.normalizesafe(move.direction);
            pos.Value += normalisedDir * move.speed * deltaTime * .1f;

        }).Run();
    }
}
