using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class SpawnSystem : SystemBase
{

    private List<Entity> prefabs;

    int amount;

    protected override void OnStartRunning()
    {
        prefabs = new List<Entity>();
        amount = 1;
        Entity prefab = GetSingleton<SpawnConmponant>().spawnPrefsb;
        int multiplier = GetSingleton<SpawnConmponant>().multiplier;

        for (int i = 0; i < multiplier; i++)
        {
            Entity entity = EntityManager.Instantiate(prefab);
            EntityManager.SetComponentData(entity, new Translation
            {
                Value = new float3(
                     UnityEngine.Random.Range(-30f, 30f),
                     UnityEngine.Random.Range(-5f, 0f),
                     UnityEngine.Random.Range(5f, 5f)
                    )
            });
            EntityManager.SetComponentData(entity, new Rotation
            {
                Value = quaternion.Euler(new float3(0f, -1.5f, 0f))
            });
            EntityManager.SetComponentData(entity, new MoveComponant
            {
                SpeedValue = UnityEngine.Random.Range(1f, 2f)
            });

            prefabs.Add(entity);



        }


    }

    protected override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            amount = 0;
            foreach (Entity ent in prefabs)
            {
                EntityManager.DestroyEntity(ent);
                
            }
            prefabs.Clear();
        }

        if (Input.GetKeyDown(KeyCode.I) && amount == 0)
        {
            Entity prefab = GetSingleton<SpawnConmponant>().spawnPrefsb;
            int multiplier = GetSingleton<SpawnConmponant>().multiplier;

            amount = 1;
            for (int i = 0; i < multiplier; i++)
            {
                Entity entity = EntityManager.Instantiate(prefab);
                EntityManager.SetComponentData(entity, new Translation
                {
                    Value = new float3(
                         UnityEngine.Random.Range(-2.5f, 2.5f),
                         UnityEngine.Random.Range(-5f, 0f),
                         UnityEngine.Random.Range(-2.5f, 2.5f)
                        )
                });
                EntityManager.SetComponentData(entity, new Rotation
                {
                    Value = quaternion.Euler(new float3(0f, -1.5f, 0f))
                });
                EntityManager.SetComponentData(entity, new MoveComponant
                {
                    SpeedValue = UnityEngine.Random.Range(2f, 3f)
                });

                prefabs.Add(entity);
            }
        }
    }
}
