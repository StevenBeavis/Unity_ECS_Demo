using Unity.Entities;

[GenerateAuthoringComponent]
public struct SpawnConmponant : IComponentData
{
    public Entity spawnPrefsb;
    public int multiplier;
}

