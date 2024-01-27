using UnityEngine;

public class XPObject : MonoBehaviour
{
    public int xpAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LevelManager.instance.AddXP(xpAmount);
            Destroy(gameObject);
        }
    }
}
