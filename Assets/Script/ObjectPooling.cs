using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance;
    public GameObject objectToPool;
    public int poolSize = 10;
    private List<GameObject> pool;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectToPool);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        GameObject newObj = Instantiate(objectToPool);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }
}
