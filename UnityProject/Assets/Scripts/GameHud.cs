
using UnityEngine;
using TMPro;

public class GameHUD : MonoBehaviour
{
    public GameState gameState;

    public TMP_Text suppliesText;
    public TMP_Text inventoryText;
    public TMP_Text messageText;

    public float messageDuration = 3f;

    private float messageEndTime;

    void Start()
    {
        messageText.text = "";
    }

    void Update()
    {
        suppliesText.text = "Supplies: " + gameState.supplies;

        inventoryText.text = gameState.HasItem("Key")
            ? "Key: Yes"
            : "Key: No";

        if (messageText.text != "" &&
            Time.time >= messageEndTime)
        {
            messageText.text = "";
        }
    }

    public void ShowMessage(string message)
    {
        messageText.text = message;
        messageEndTime = Time.time + messageDuration;
    }
}
