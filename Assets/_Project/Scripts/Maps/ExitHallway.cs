using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitHallway : DoorTrigger
{
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        onExit?.Invoke();   //--> disattiviamo il pezzo di mappa precedente e spawniamo i nemici nel pezzo di mappa successivo
    }
}
