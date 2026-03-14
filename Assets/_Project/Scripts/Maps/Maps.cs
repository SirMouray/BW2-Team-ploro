using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Maps : MonoBehaviour
{
    [SerializeField] private bool _isDeactive = false;
    private IObjectPool<Maps> _objPool;
    public IObjectPool<Maps> ObjPool { set => _objPool = value; }

    IEnumerator DeactiveRoutine()
    {
        //yield return new WaitForSeconds(delay);
        yield return new WaitUntil(() => _isDeactive);
        // resettare tutta la mappa
        _objPool.Release(this);
        _isDeactive = false;
    }

    public void Deactive()
    {
        StartCoroutine(DeactiveRoutine());
    }

    
}
