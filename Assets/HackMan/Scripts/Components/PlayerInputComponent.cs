using System;
using HackMan.Scripts.BaseComponents;
using HackMan.Scripts.Systems;
using UnityEngine;

namespace HackMan.Scripts.Components
{
    public class PlayerInputComponent : MovementComponent
    {
        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentInputDirection = IntVector2.down;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentInputDirection = IntVector2.up;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentInputDirection = IntVector2.right;
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentInputDirection = IntVector2.left;
            }
            
            //Debug.Log($"{currentInputDirection.x}||{currentInputDirection.y}");
            base.Update();
        }
    }
}
