using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameobjectPool : MonoBehaviour
{
    private List<GameObject> _pool;
    public GameObject objectToPool;
    [Tooltip("Initial pool size")]
    public uint poolSize;
    [Tooltip("Se expande?")]
    public bool shouldExpand = false;

    // Start is called before the first frame update
    void Start()
    {
        _pool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            AddGameObject();
        }
    }

    GameObject AddGameObject()
    {       
        GameObject clone = Instantiate(objectToPool);
        clone.SetActive(false);
        _pool.Add(clone); 
        return clone;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GiveInactiveGameObject() 
    {
        foreach (GameObject obj in _pool)
        {
            if (!obj.activeSelf) 
            {
                return obj;
            }
        }
        if (shouldExpand)
        {
            return AddGameObject();
        }
        return null;
    }
}
