using HackMan.Scripts.Events;
using UnityEngine;

namespace HackMan.Scripts.Systems
{
    public class CollectionSystem : Singleton<CollectionSystem>
    {
        private int _collectedAmount;
        
        private void OnEnable()
        {
            NewEventSystem.Instance.Subscribe<CollectionEvent>(OnCollected);
        }

        private void OnDisable()
        {
            NewEventSystem.Instance.Unsubscribe<CollectionEvent>(OnCollected);
        }

        private void OnCollected(CollectionEvent collectionEvent)
        {
            Destroy(collectionEvent.CollectableComponent.gameObject);

            _collectedAmount++;

            if (_collectedAmount != LevelGeneratorSystem.Instance.GetCollectionAmount()) return;
            
            NewEventSystem.Instance.Publish(new GameOverEvent(true));
        }
    }
}