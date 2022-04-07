using System;
using UnityEngine;

namespace HackMan.Scripts.BaseComponents
{
    public class MovementComponent : BaseGridObject
    {
        public float MovementSpeed;
        protected IntVector2 targetGridPosition;
        protected float progressTarget = 1f;
        protected IntVector2 currentInputDirection;
        private IntVector2 previousInputDirection;

        protected virtual void Start()
        {
            targetGridPosition = transform.position.ToIntVector2();
        }

        protected virtual void Update()
        {
            // Debug.Log($"Transform: {transform.position}|| TargetGridPosition: {targetGridPosition.x}||{targetGridPosition.y}");
            // If we're arrived...
            if (transform.position == targetGridPosition.ToVector3())
            {
                progressTarget = 0f;
                GridPosition = targetGridPosition;
            }

            // If we set a new target AND our current input is VALID -> NOT A WALL
            if (GridPosition == targetGridPosition && !(GridPosition + currentInputDirection).IsWall())
            {
                targetGridPosition += currentInputDirection;
                previousInputDirection = currentInputDirection;
            }
            // If we set a new target AND our current input is NOT VALID -> IS A WALL
            else if (GridPosition == targetGridPosition && !(GridPosition + previousInputDirection).IsWall())
            {
                targetGridPosition += previousInputDirection;
            }

            if (GridPosition == targetGridPosition) return;

            progressTarget += MovementSpeed * Time.deltaTime;

            transform.position = Vector3.Lerp(transform.position, targetGridPosition.ToVector3(), progressTarget);
        }
    }

    // Extension methods allow us to EXTEND the functionality of our classes, without MODIFYING the class it self.
    // This follows one of our principles, that classes should be CLOSED to modification, but OPEN to extension.
    // static CLASS, static METHOD, this KEYWORD
}