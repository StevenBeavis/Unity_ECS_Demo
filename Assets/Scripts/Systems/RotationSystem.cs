using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class RotationSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation r, in Translation pos, in PlayerMovement move) =>
        {
            if (!move.direction.Equals(float3.zero))
            {
                quaternion targetRotation = quaternion.LookRotationSafe(move.direction, math.up());
                r.Value = math.slerp(r.Value, targetRotation, move.turnSpeed);

            }
           

        }).Schedule();
    }
}
