using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public class FollowEntity : MonoBehaviour
{
    public Entity entity;
    public float3 offset = float3.zero;

    private EntityManager manager;

    private void Awake()
    {
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    private void LateUpdate()
    {
        if (entity == null)
        {
            return;
        }

        Translation entityPosition = manager.GetComponentData<Translation>(entity);
        transform.position = entityPosition.Value + offset;
    }
}
