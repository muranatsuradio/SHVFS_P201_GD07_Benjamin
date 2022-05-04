using System;
using HackMan.Scripts.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HackMan.Scripts.Systems
{
    public class GameOverSystem : Singleton<GameOverSystem>
    {
        private void OnEnable()
        {
            NewEventSystem.Instance.Subscribe<GameOverEvent>(OnGameOver);
        }

        private void OnDisable()
        {
            NewEventSystem.Instance.Unsubscribe<GameOverEvent>(OnGameOver);
        }

        private void OnGameOver(GameOverEvent gameOverArgs)
        {
            LevelGeneratorSystem.Instance.Generate();
        }
    }
}