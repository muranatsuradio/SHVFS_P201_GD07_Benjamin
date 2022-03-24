using System;
using HackMan.Scripts.Systems;
using UnityEngine;

namespace HackMan.Scripts.BaseComponents
{
    public class BaseGridMovement : BaseGridObject
    {
        public float MovementSpeed;
        protected IntVector2 targetGridPosition;
        protected float progressTarget = 1f;
        protected IntVector2 currentInputDirection;
        private IntVector2 previousInputDirection;

        private void Start()
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
            if (GridPosition == targetGridPosition && LevelGeneratorSystem.Grid[
                    Mathf.Abs(targetGridPosition.y + currentInputDirection.y),
                    Mathf.Abs(targetGridPosition.x + currentInputDirection.x)] != 1)
            {
                targetGridPosition += currentInputDirection;
                previousInputDirection = currentInputDirection;
            }
            // If we set a new target AND our current input is NOT VALID -> IS A WALL
            else if (GridPosition == targetGridPosition && LevelGeneratorSystem.Grid[
                         Mathf.Abs(GridPosition.y + previousInputDirection.y),
                         Mathf.Abs(GridPosition.x + previousInputDirection.x)] != 1)
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

    public static class ExtensionMethods
    {
        public static Vector3 ToVector3(this IntVector2 vector2)
        {
            return new Vector3(vector2.x, vector2.y);
        }

        public static IntVector2 ToIntVector2(this Vector3 vector3)
        {
            return new IntVector2((int) vector3.x, (int) vector3.y);
        }
    }
}