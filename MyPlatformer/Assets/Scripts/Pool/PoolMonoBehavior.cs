using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMonoBehavior<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; }
    public Transform Container { get; }

    private List<T> _pool;

    public PoolMonoBehavior(T prefab, int count, Transform container)
    {
        Prefab = prefab;
        Container = container;

        CreaatePool(count);
    }

    private void CreaatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActivByDefault = false)
    {
        var createdObject = GameObject.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActivByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }
    public bool HasFreeElement(out T element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeSelf)
            {
                element = item;
                element.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }
    
    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            return element;
        }
        else if (AutoExpand)
        {
            return CreateObject(true);
        }

        throw new Exception($"No Free Element in pool of type {typeof (T)}");
    }
}
