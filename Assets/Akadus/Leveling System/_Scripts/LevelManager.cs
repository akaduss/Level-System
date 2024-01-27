using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 1;
    public int currentXP = 0;
    public int maxXPForCurrentLevel = 100;

    public static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void AddXP(int amount)
    {
        currentXP += amount;
        CheckForLevelUp();
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
        UpdateMaxXPForCurrentLevel();
        // Implement any other level-up logic
    }

    private void UpdateMaxXPForCurrentLevel()
    {
        // Adjust max XP for the next level as needed
        maxXPForCurrentLevel = CalculateNextLevelXP(currentLevel);
    }

    public static int CalculateNextLevelXP(int currentLevel)
    {
        // You can modify this formula based on your game's needs
        return Mathf.RoundToInt(100 * Mathf.Pow(1.1f, currentLevel));
    }
}
