using System.Collections.Generic;
using UnityEngine;

namespace BlocksLogic.Pool
{
    public class ObjectPooler
    {
        private GameObject prefab;
        private Transform objectsParent;
        private List<GameObject> cachedObjects;
    
        public ObjectPooler(GameObject prefab, int initialAmount)
        {
            this.prefab = prefab;
    
            if (prefab.GetComponent<PoolableObject>() == null)
                prefab.AddComponent<PoolableObject>();
            
            cachedObjects = new List<GameObject>(initialAmount);
            objectsParent = new GameObject($"{prefab.name}Parent").transform;
            SpawnObjectsInPool(initialAmount);
        }
    
        private void SpawnObjectsInPool(int initialAmount)
        {
            for (int i = 0; i < initialAmount; i++)
            {
                InstantiateObject();
            }
        }
    
        public void ReturnObject(GameObject gameObject)
        {
            gameObject.transform.SetParent(objectsParent);
            gameObject.SetActive(false);
        }
    
        public GameObject GetObject()
        {
            GameObject objectFromPool = null;
            foreach (var obj in cachedObjects)
            {
                if (!obj.activeInHierarchy)
                {
                    objectFromPool = obj;
                    break;
                }
            }
    
            if (objectFromPool==null)
            {
                objectFromPool = InstantiateObject();
            }
    
            return objectFromPool;
        }
    
        private GameObject InstantiateObject()
        {
            var newObject = Object.Instantiate(prefab, objectsParent);
            var poolableObject = newObject.GetComponent<PoolableObject>();
            poolableObject.SetPool(this);
            
            newObject.SetActive(false);
            cachedObjects.Add(newObject);
            return newObject;
        }
    }
}

    
