using UnityEngine;
using System;
using Unity.Entities;

public class PlayerInput : SystemBase
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref PlayerMovement move, in InputP input) => 
        {
            bool isUpKeyPressed = Input.GetKey(input.upK);
            bool isDownKeyPressed = Input.GetKey(input.downK);

            bool isRightKeyPressed = Input.GetKey(input.rightK);
            bool isLeftKeyPressed = Input.GetKey(input.leftK);

            move.direction.z = Convert.ToInt32(isUpKeyPressed);
            move.direction.z -= Convert.ToInt32(isDownKeyPressed);
            
            move.direction.x = Convert.ToInt32(isRightKeyPressed);
            move.direction.x -= Convert.ToInt32(isLeftKeyPressed);


        }).Run();
    }
}
