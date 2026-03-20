using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private Canvas shopCanvas;
    public void Interaction()
    {
        if (shopCanvas == null)
            return;
        shopCanvas.gameObject.SetActive(true);
    }

    public string InteractionText()
    {
        return "Press F to open the shop";
    }
}
