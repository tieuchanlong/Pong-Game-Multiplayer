using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectEntityPool : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public int amountToPool;
        public GameObject objectToPool;
        public bool shouldExpand;
    }

    public static ObjectEntityPool SharedInstance; // this helps other scripts reference it

    public List<ObjectPoolItem> pooledObjects;
    //public GameObject objectToPool;
    //public int amountToPool;

    public bool shouldExpand;
    
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<ObjectPoolItem>();
        /*foreach (ObjectPoolItem item in pooledObjects)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add()
            }
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
    {
        /*for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)
            {
                return pooledObjects[i];
            }
        }
        foreach (ObjectPoolItem item in itemsToPool)
        {
            if (item.objectToPool.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = (GameObject)Instantiate(item.objectToPool);
                    obj.SetActive(false);
                    pooledObjects.Add(obj);
                    return obj;
                }
            }
        }*/
        return null;
    }

}
