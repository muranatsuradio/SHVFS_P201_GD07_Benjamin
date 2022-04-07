using System;
using System.Collections.Generic;
using UnityEngine;

namespace HackMan.Scripts
{
    public class GenericsExample : MonoBehaviour
    {
        private void OnEnable()
        {
            // GetComponent is a generic method...
            // We can have generic methods AND generic classes
            // var animator = GetComponent<Animator>();

            // var pairIntInt = new Pair<int, float>(){First = 0, Second = 1f};
            //
            // MyClass<float>.Value = 1;
            // MyClass<float>.Value = 2;
            // MyClass<int>.Value = 3;
            //
            // Debug.Log(MyClass<float>.Value);
            // Debug.Log(MyClass<float>.Value);
            // Debug.Log(MyClass<int>.Value);

            // PrintNumber(2);
            // var classOne = Produce<ClassOne>();
            // classOne.Setup();

            
        }

        // Syntax of constraints is where T : new()
        // private T Produce<T>() where T : new()
        // {
        //     T returnValue = new T();
        //     return returnValue;
        // }

        // What if we want to call setup in the generic method?
        // Constraints are useful, and sometimes necessary, but the more you use...the less your generic method is a generic method
        private T Produce<T>() where T : ClassOne, new()
        {
            T returnValue = new T();
            returnValue.Setup();
            return returnValue;
        }

        private T ProduceGeneric<T>(Action predicate) where T : new()
        {
            var returnValue = new T();
            predicate.Invoke();
            return returnValue;
        }

    private void PrintNumber<T>(T number)
        {
            Debug.Log(number);
        }
    }

    // the compiler in reality has RESERVED CHARACTERS it uses to create unique, compiler generated class names
    public class Pair<T1, T2>
    {
        public T1 First;
        public T2 Second;
    }

    public class MyClass<T>
    {
        public static int Value;

        static MyClass()
        {
            Debug.Log(typeof(MyClass<T>));
        }
    }

    // We can put constraints on our generic type arguments...
    public class ClassOne
    {
        public void Setup()
        {
            Debug.Log("fufufufufufu");
        }
    }
}