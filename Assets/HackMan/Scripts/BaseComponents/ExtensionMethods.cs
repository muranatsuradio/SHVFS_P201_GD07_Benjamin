using HackMan.Scripts.Systems;
using UnityEngine;

namespace HackMan.Scripts.BaseComponents
{
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

        public static bool IsWall(this IntVector2 vector2)
        {
            return LevelGeneratorSystem.CurrentLevel.Grid[Mathf.Abs(vector2.y), Mathf.Abs(vector2.x)] == 1;
        }
    }
}