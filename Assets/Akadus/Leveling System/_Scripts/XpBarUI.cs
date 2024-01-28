using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Akadus.LevelSystem
{
    public class XPBarUI : MonoBehaviour
    {
        [SerializeField] private Image xpFillImage;
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI currentXpText;
        [SerializeField] private TextMeshProUGUI nextLevelXpText;
        [SerializeField] private TextMeshProUGUI xpPercentageText;

        private LevelManager levelManager;

        private void Start()
        {
            xpFillImage = GetComponent<Image>();
            levelManager = LevelManager.instance;

            if (levelManager != null)
            {
                levelManager.OnXPAdded += UpdateXPBar;
            }

            UpdateXPBar();
        }

        public void UpdateXPBar()
        {
            if (levelManager != null)
            {
                float fillAmount = (float)levelManager.CurrentXP / levelManager.MaxXPForCurrentLevel;
                xpFillImage.fillAmount = fillAmount;
                levelText.text = levelManager.CurrentLevel.ToString();
                currentXpText.text = levelManager.CurrentXP.ToString();
                nextLevelXpText.text = levelManager.MaxXPForCurrentLevel.ToString();

                // Calculate and display XP percentage
                int xpPercentage = Mathf.RoundToInt((float)levelManager.CurrentXP / levelManager.MaxXPForCurrentLevel * 100);
                xpPercentageText.text = "%" + xpPercentage.ToString();
            }
        }
    }
}
