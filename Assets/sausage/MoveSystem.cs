using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class MoveSystem : SystemBase
{
    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;
        Entities.ForEach((ref Translation translation, in MoveComponant moveComponant) => {
            translation.Value.z -= moveComponant.SpeedValue * deltaTime;
            if (translation.Value.z < 0) translation.Value.z = 10f;
        }).Schedule();
    }
}
