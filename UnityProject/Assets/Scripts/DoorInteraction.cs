
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public string requiredKey = "Key";
    public GameHUD hud;

    private Animator animator;
    private bool isOpen = false;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void TryOpen(GameState gameState)
    {
        if (isOpen) return;

        if (gameState.HasItem(requiredKey))
        {
            animator.SetTrigger("OpenDoor");
            isOpen = true;
            hud.ShowMessage("Door opened!");
        }
        else
        {
            hud.ShowMessage("You need a key!");
        }
    }
}
