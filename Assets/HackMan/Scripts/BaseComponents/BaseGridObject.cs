using System;
using UnityEngine;

namespace HackMan.Scripts.BaseComponents
{
    // A struct is similar to a class, but when you pass a struct as a variable, it always copy.
    // Once structs and classes are finished, we don't modify them but use extension methods.
    [Serializable]
    public struct IntVector2
    {
        public int x;
        public int y;

        private static IntVector2 zero => new IntVector2(0, 0);

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static IntVector2 operator +(IntVector2 v1, IntVector2 v2)
        {
            return new IntVector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static IntVector2 operator -(IntVector2 v)
        {
            return new IntVector2(-v.x, -v.y);
        }

        public static bool operator == (IntVector2 v1, IntVector2 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y);
        }

        public static bool operator !=(IntVector2 v1, IntVector2 v2)
        {
            return (v1.x != v2.x || v1.y != v2.y);
        }
    }

    public class BaseGridObject : MonoBehaviour
    {
        public IntVector2 GridPosition;
    }
}

