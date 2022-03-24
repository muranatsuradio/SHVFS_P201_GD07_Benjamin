using HackMan.Scripts.BaseComponents;
using UnityEngine;

namespace HackMan.Scripts
{
    public class HackManComponent : BaseGridMovement
    {
        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentInputDirection = new IntVector2(0, -1);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentInputDirection = new IntVector2(0, 1);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                currentInputDirection = new IntVector2(1, 0);
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                currentInputDirection = new IntVector2(-1, 0);
            }
            
            Debug.Log($"{currentInputDirection.x}||{currentInputDirection.y}");
            base.Update();
        }
    }
}
