using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Devastating.Scripts.Singleton
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }

                DontDestroyOnLoad(_instance.gameObject);
                
                return _instance;
            }
        }
    }
}