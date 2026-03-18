using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    protected UnityEvent onEnter, onExit;

    protected void Awake()
    {
        animator = GetComponent<Animator>();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        //animazione apertura
    }

    protected virtual IEnumerator OnTriggerExit(Collider other)
    {
        yield return new WaitForSeconds(2);
        //animazione chiusura
    }
}
