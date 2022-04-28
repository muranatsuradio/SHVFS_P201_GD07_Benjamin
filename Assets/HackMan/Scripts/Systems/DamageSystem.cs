using System;
using HackMan.Scripts.Events;
using UnityEngine;

namespace HackMan.Scripts.Systems
{
    public class DamageSystem : Singleton<DamageSystem>
    {
        private void OnEnable()
        {
            NewEventSystem.Instance.Subscribe<DamageEvent>(OnDamaged);
        }

        private void OnDisable()
        {
            NewEventSystem.Instance.Unsubscribe<DamageEvent>(OnDamaged);
        }

        private void OnDamaged(DamageEvent damageEvent)
        {
            NewEventSystem.Instance.Publish(new GameOverEvent(false));
        }
    }
}