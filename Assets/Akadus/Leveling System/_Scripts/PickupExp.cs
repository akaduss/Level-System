using UnityEngine;

namespace Akadus.LevelSystem
{
    public class XPObject : MonoBehaviour
    {
        [SerializeField] private int xpAmount = 10;

        [Header("Prototyping")]
        [SerializeField] private float tempCubeSize = 0.5f;

        private static readonly string PlayerTag = "Player";

        private void Start()
        {
            if (ObjectPoolManager.instance != null)
            {
                GameObject xpObjectPrefab = ObjectPoolManager.instance.GetXPObject(transform.position);

                if (xpObjectPrefab != null)
                {
                    // Handle the case when the prefab is not null
                    // For example, you might want to set specific properties or behaviors here
                }
            }
            else
            {
                // Create a temporary cube for prototype purposes
                CreateTemporaryCube();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                if (LevelManager.instance != null)
                {
                    LevelManager.instance.AddXP(xpAmount);
                }

                if (ObjectPoolManager.instance != null)
                {
                    ObjectPoolManager.instance.ReturnXPObject(gameObject);
                }
            }
        }

        private void CreateTemporaryCube()
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetPositionAndRotation(transform.position, transform.rotation);
            cube.transform.localScale = Vector3.one * tempCubeSize; // Adjust the scale

            cube.GetComponent<Renderer>().material.color = new Color(1.0f, 0.92f, 0.016f); // Yellow color

            Destroy(gameObject); // Destroy the current object
        }

    }
}
