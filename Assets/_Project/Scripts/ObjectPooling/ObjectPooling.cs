using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private Maps[] _objPrefab;
    private IObjectPool<Maps> _objPool;
    private bool _collectionCheck;
    private int _poolCapacity = 5;
    private int _poolMaxSize = 10;

    private void Awake()
    {
        _objPool = new ObjectPool<Maps>(Create, OnGetFromPool, OnRealeseToPool, OnDestroyPooledObj, _collectionCheck, _poolCapacity, _poolMaxSize);
    }

    private Maps Create()
    {
        Maps obj = Instantiate(_objPrefab[Random.Range(0, _objPrefab.Length)]);
        obj.gameObject.SetActive(false);
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Maps mapsobj = _objPool.Get();
            mapsobj.transform.SetPositionAndRotation(new Vector3(Random.Range(0, 20), Random.Range(0, 20)), Quaternion.identity);
            mapsobj.Deactive();
        }
    }
}
