using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour, IInteractable
{
    public void Interaction()
    {
        SceneManager.LoadScene(2);
    }

    public string InteractionText()
    {
        return "Press F to start the game";
    }
}
