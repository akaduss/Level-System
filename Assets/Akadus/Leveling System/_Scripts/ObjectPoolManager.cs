using System.Collections.Generic;
using UnityEngine;

namespace Akadus.LevelSystem
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager instance;

        [SerializeField] private GameObject xpObjectPrefab;
        [SerializeField] private int poolSize = 10;

        private List<GameObject> xpObjectPool;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);

            InitializePool();
        }

        private void InitializePool()
        {
            xpObjectPool = new List<GameObject>();

            for (int i = 0; i < poolSize; i++)
            {
                GameObject xpObject = Instantiate(xpObjectPrefab, transform);
                xpObject.SetActive(false);
                xpObjectPool.Add(xpObject);
            }
        }

        public GameObject GetXPObject(Vector3 position)
        {
            foreach (GameObject xpObject in xpObjectPool)
            {
                if (!xpObject.activeInHierarchy)
                {
                    xpObject.transform.position = position;
                    xpObject.SetActive(true);
                    return xpObject;
                }
            }

            // If no inactive objects are found, consider expanding the pool or handle accordingly
            return null;
        }

        public void ReturnXPObject(GameObject xpObject)
        {
            xpObject.SetActive(false);
        }
    }
}
