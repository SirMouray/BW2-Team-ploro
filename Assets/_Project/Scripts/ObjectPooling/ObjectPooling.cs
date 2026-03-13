using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private Maps _objPrefab;
    private IObjectPool<Maps> _objPool;
    private bool _collectionCheck;
    private int _poolCapacity;
    private int _poolMaxSize;

    private void Awake()
    {
        _objPool = new ObjectPool<Maps>(Create,OnGetFromPool,OnRealeseToPool, OnDestroyPooledObj,_collectionCheck,_poolCapacity,_poolMaxSize);
    }

    private Maps Create()
    {
        Maps obj = Instantiate(_objPrefab);
        obj.ObjPool = _objPool;
        return obj;
    }

    private void OnGetFromPool(Maps pooledObj)
    {
        pooledObj.gameObject.SetActive(true);
    }

    private void OnRealeseToPool(Maps pooledObj)
    {
        pooledObj.gameObject.SetActive(false);
    }

    private void OnDestroyPooledObj(Maps pooledObj)
    {
        Destroy(pooledObj.gameObject);
    }
}
