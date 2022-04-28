using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HackMan.Scripts.Examples
{
    public class DelegateExample : MonoBehaviour
    {
        /*  The compiler converts this into a class...
            class MeDelegate{}
            And since it's a class, we can create a new object from it.. */
        // first class objects
        // Delegate can turn a method to an object...
        public delegate void MeDelegate();

        public delegate bool MeDelegateInt(int n);

        public delegate int MeDelegateReturnInt();

        public delegate T MeDelegateGeneric<T>();

        private void OnEnable()
        {
            // We're NOT invoking Foo, we're just passing it!
            /*
            var meDelegate = new MeDelegate(Foo);
            */
            // This is a reference to a class...but it's also treated like a method..
            // The compiler is helping us here. We can call/invoke it with...

            /* meDelegate.Invoke(); */

            // We can also invoke it like this: (the compiler gives us this syntactic sugar)
            // If we write it like this, the compiler will turn it into meDelegate.Invoke(); 
            /* meDelegate(); */

            // meDelegate references Foo, so it's a reference to an object, and a method...

            // This is some more syntactic sugar...  a short way, but gets turned into the full bit in line 18.
            /* MeDelegate meDelegate2 = Goo; */
            
            /*  InvokeDelegate(new MeDelegate(Goo));
                InvokeDelegate(Goo);              */

            // Delegates are references to objects AND methods
            /* Debug.Log($"Target: {meDelegate.Target} | Method: {meDelegate.Method}");
               Debug.Log($"Target: {meDelegate2.Target} | Method: {meDelegate2.Method}");*/

            // The same reason we parameterize this Square, is why we want to parameterize our code, or references to code(methods).

            /* var result = GetAllNumbersLessThanFive(new List<int>() {3, 4, 5, 6, 7});
            
               foreach (var number in result)
               {
                  Debug.Log(number);
               }
            */
            // Before the difference was just the number...but now we've change the expression... we're changed the code
            // How can we use Delegates to parameterize our GetAllNumbersLessThanXYZ???

            /*
            var numbers = new List<int>() {11, 4, 5, 6, 3};
            var resultLessThanFive = GetAllNumbers(numbers, LessThanFive);
            */

            // This is kind of neat...but we still have to deal with making several methods.
            // So let's go back to lambdas. We are passing methods, why can we just paste the method self.

            /*var numbers = new List<int>() {11, 4, 15, 6, 0};
               var result = GetAllNumbers(numbers, i => i < 5);
               foreach (var number in result)
               {
                   Debug.Log(number);
               }
            */

            // Delegate Chaining
            // We can add and remove delegates...
            // These are immutable..
            /*
            MeDelegate meDelegate = Moo;
            meDelegate = (MeDelegate) Delegate.Combine(meDelegate, (MeDelegate) Boo);
            meDelegate = meDelegate + Foo;
            meDelegate += Moo;

            meDelegate.Invoke();

            foreach (var @delegate in meDelegate.GetInvocationList())
            {
                Debug.Log($"Target: {@delegate.Target} | Method: {@delegate.Method}");
            }
            */

            /*
            MeDelegateReturnInt meDelegate = () => 5;
            meDelegate += () => 10;
            Debug.Log(meDelegate());
            */

            /*
            MeDelegateGeneric<int> meDelegate = () => 5;
            meDelegate += () => 10;
            foreach (var value in GetAllReturnValue(meDelegate))
            {
                Debug.Log(value);
            }
            */
            
            // Func and Action
            
            // Func has a return..
            /*
            Func<int> meDelegate = () => 5;
            Func<int, int> meDelegate2 = i => i + 5;
            Func<int, int, int> meDelegate3 = (a, b) => a + b;
            */

            // Action returns void
            /*
            Action meDelegate = () => Debug.Log("Hello");
            Action<int> meDelegate2 = i => Debug.Log(i);
            Action<int, int> meDelegate3 = (a, b) => Debug.Log(a + b);
            */
            
            // The difference between delegates and events
            // An event is a delegate with two restriction: you can't assign to it directly, and you can't invoke it directly..

            var trainsSignal = new TrainsSignal();
            trainsSignal.TrainsComing += ATrainsComing;
            trainsSignal.HereComesATrain();
            // transSignal.TrainsComing = null;   // Can't assign to it directly.
            // transSignal.TrainsComing.Invoke(); // Can't invoke it directly.
        }

        private void ATrainsComing()
        {
            Debug.Log("Here comes the train!");
        }

        private static IEnumerable<T1> GetAllReturnValue<T1>(MeDelegateGeneric<T1> d)
        {
            foreach (MeDelegateGeneric<T1> del in d.GetInvocationList())
            {
                yield return del();
            }
        }

        private static List<int> GetAllNumbersLessThanFive(List<int> numbers)
        {
            return numbers.Where(number => number < 5).ToList();
        }

        private static List<int> GetAllNumbers(List<int> numbers, MeDelegateInt del)
        {
            return numbers.Where(number => del(number)).ToList();
        }

        public void InvokeDelegate(MeDelegate del)
        {
            del();
        }

        public void Foo()
        {
            Debug.Log("Foo");
        }

        public void Goo()
        {
            Debug.Log("Goo");
        }

        public void Boo()
        {
            Debug.Log("Booooooooooooo!!!!!!");
        }

        public void Moo()
        {
            Debug.Log("Moo!");
        }

        public bool LessThanFive(int n)
        {
            return n < 5;
        }
    }

    public class TrainsSignal
    {
        public event Action TrainsComing;

        public void HereComesATrain()
        {
             TrainsComing?.Invoke();
        }
    }
}