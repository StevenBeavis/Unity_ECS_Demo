using UnityEngine;
using Unity.Entities;

[GenerateAuthoringComponent]
public struct InputP : IComponentData
{
    public KeyCode upK;
    public KeyCode downK;
    public KeyCode rightK;
    public KeyCode leftK;
}
