using System;
using HackMan.Scripts.Events;
using HackMan.Scripts.Systems;
using UnityEngine;

namespace HackMan.Scripts.Components
{
    public class DamagerComponent : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<DamagableComponent>())
            {
                NewEventSystem.Instance.Publish(new DamageEvent(other.GetComponent<DamagableComponent>()));
            }
        }
    }
}