using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct PlayerMovement : IComponentData
{
    public float3 direction; 
    public float speed; 
    public float turnSpeed;

}
