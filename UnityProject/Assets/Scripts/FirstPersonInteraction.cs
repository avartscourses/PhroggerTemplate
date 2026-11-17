
using UnityEngine;

public class FirstPersonInteraction : MonoBehaviour
{
    public float interactionDistance = 2.5f;

    private GameState gameState;

    void Awake()
    {
        gameState = GetComponentInParent<GameState>();
    }

    public void TryInteract()
    {
        Debug.Log("TryInteract called!");

        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            Debug.Log("Ray hit: " + hit.collider.name);
            Debug.Log("Tag: " + hit.collider.tag);

            // Συλλογή αντικειμένων
            if (hit.collider.CompareTag("Collectible"))
            {
                CollectibleItem item =
                    hit.collider.GetComponent<CollectibleItem>();

                if (item != null)
                {
                    item.Collect(gameState);
                }
            }

            // Αλληλεπίδραση με πόρτα
            DoorInteraction door =
                hit.collider.GetComponent<DoorInteraction>();

            if (door != null)
            {
                door.TryOpen(gameState);
            }
        }
    }
}
