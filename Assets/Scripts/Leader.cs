using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

[RequiresEntityConversion]
[AddComponentMenu("Custom/Leader Authoring")]
public class Leader : MonoBehaviour, IConvertGameObjectToEntity
{
    public GameObject follower;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        FollowEntity followEntity = follower.GetComponent<FollowEntity>();

        if (followEntity == null)
        {
            followEntity = follower.AddComponent<FollowEntity>();
        }

        followEntity.entity = entity;
    }
}
