using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Maps : MonoBehaviour
{
    private IObjectPool<Maps> _objPool;
    public IObjectPool<Maps> ObjPool { set => _objPool = value; }
}
