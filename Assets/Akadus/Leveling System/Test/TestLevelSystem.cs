using UnityEngine;

namespace Akadus.LevelSystem
{
    public class TestLevelSystem : MonoBehaviour
    {
        public XPBarUI xpBarUI;
        public int xp;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Simulate gaining XP when the space key is pressed
                GainXP(Random.Range(10, 30));
                GainXP(xp);
            }
        }

        private void GainXP(int amount)
        {
            LevelManager.instance.AddXP(amount);
            xpBarUI.UpdateXPBar();
        }
    }
}
