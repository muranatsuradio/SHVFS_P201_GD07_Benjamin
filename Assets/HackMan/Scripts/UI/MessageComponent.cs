using System;
using HackMan.Scripts.Events;
using HackMan.Scripts.Systems;
using TMPro;
using UnityEngine;

namespace HackMan.Scripts.UI
{
    public class MessageComponent : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI MessageText;

        private void OnEnable()
        {
            NewEventSystem.Instance.Subscribe<GameOverEvent>(UpdateMessageText);
        }

        private void OnDisable()
        {
            NewEventSystem.Instance.Unsubscribe<GameOverEvent>(UpdateMessageText);
        }

        private void UpdateMessageText(GameOverEvent gameOverEvent)
        {
            MessageText.text = gameOverEvent.IsWinning ? "You Win!" : "You Lose!";
        }
    }
}