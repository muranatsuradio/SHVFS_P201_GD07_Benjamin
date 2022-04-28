using System;
using HackMan.Scripts.Components;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HackMan.Scripts.Events
{
    public class CollectionEvent
    {
        public CollectableComponent CollectableComponent { get; }

        public CollectionEvent(CollectableComponent collectableComponent)
        {
            this.CollectableComponent = collectableComponent;
        }
    }
}