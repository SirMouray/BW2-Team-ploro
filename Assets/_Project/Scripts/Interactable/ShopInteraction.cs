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
        Time.timeScale = 0;
    }

    public string InteractionText()
    {
        return "Press F to open the shop";
    }

    public void OnEscButton()
    {
        shopCanvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
