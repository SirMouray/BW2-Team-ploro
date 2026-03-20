using TMPro;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private float interactionDistance;
    [SerializeField] private TextMeshProUGUI textInteraction;
    [SerializeField] private LayerMask interactionLayer;

    private IInteractable interactable;

    private void Update()
    {
        CheckInteraction();
        if (interactable != null && Input.GetKeyDown(KeyCode.F))
            interactable.Interaction();
    }

    private void CheckInteraction()
    {
        if (textInteraction == null)
            return;

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactionDistance, interactionLayer))
        {
            IInteractable obj = hit.collider.GetComponent<IInteractable>();

            if (obj != null)
            {
                interactable = obj;
                textInteraction.text = interactable.InteractionText();
                textInteraction.gameObject.SetActive(true);
                return;
            }
        }
        interactable = null;
        textInteraction.gameObject.SetActive(false);
    }
}
