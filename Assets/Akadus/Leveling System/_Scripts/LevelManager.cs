using UnityEngine;
using System;

namespace Akadus.LevelSystem
{
    [System.Serializable]
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;

        public event Action OnXPAdded;

        [Header("Level Settings")]
        [SerializeField] private float levelMultiplier = 1.1f;
        [SerializeField] private int currentLevel = 1;
        [SerializeField] private int currentXP = 0;
        [SerializeField] private int maxXPForCurrentLevel = 100;

        public int CurrentLevel => currentLevel;
        public int CurrentXP => currentXP;
        public int MaxXPForCurrentLevel => maxXPForCurrentLevel;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);

            DontDestroyOnLoad(gameObject);
        }

        public void AddXP(int amount)
        {
            currentXP += amount;
            CheckForLevelUp();

            // Trigger the OnXPAdded event
            OnXPAdded?.Invoke();
        }

        private void CheckForLevelUp()
        {
            if (currentXP >= maxXPForCurrentLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            currentLevel++;
            currentXP = 0;
            maxXPForCurrentLevel = CalculateNextLevelXP(currentLevel);
            OnXPAdded?.Invoke();

            // Implement any other level-up logic
        }

        public int CalculateNextLevelXP(int currentLevel)
        {
            // You can modify this formula based on your game's needs
            return Mathf.RoundToInt(100 * Mathf.Pow(1.1f, currentLevel));
        }
    }
}
