using HackMan.Scripts.Events;
using HackMan.Scripts.Systems;
using UnityEngine;

namespace HackMan.Scripts.Components
{
    public class CollectorComponent : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<CollectableComponent>())
            {
                NewEventSystem.Instance.Publish(new CollectionEvent(other.GetComponent<CollectableComponent>()));
            }
        }
    }
}