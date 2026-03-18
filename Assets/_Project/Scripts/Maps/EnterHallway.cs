using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterHallway : DoorTrigger
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        onEnter?.Invoke();  //--> Attiviamo il prossimo pezzo di mappa e disattiviamo i nemici nella mappa precedente
    }
}
