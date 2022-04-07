using UnityEngine;

namespace HackMan.Scripts.BaseComponents
{
    // A struct is similar to a class, but when you pass a struct as a variable, it always copy.
    // Once structs and classes are finished, we don't modify them but use extension methods.

    public class BaseGridObject : MonoBehaviour
    {
        public IntVector2 GridPosition;
    }
}

