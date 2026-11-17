using UnityEngine;

public class AutomaticPickup : MonoBehaviour
{
    public int amount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameState state = other.GetComponent<GameState>();

            if (state != null)
            {
                state.AddSupplies(amount);
                Destroy(gameObject);
            }
        }
    }
}