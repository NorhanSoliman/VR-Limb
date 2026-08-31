using UnityEngine;
using Meta.WitAi.Json;

public class VoiceLimbInputSource : MonoBehaviour, ILimbInputSource
{
    [SerializeField] private float lerpSpeed = 5f;

    private Vector2 currentInput = Vector2.zero;
    private Vector2 targetInput = Vector2.zero;

    public Vector2 GetValue()
    {
        return currentInput;
    }

    void Update()
    {
        currentInput = Vector2.Lerp(currentInput, targetInput, Time.deltaTime * lerpSpeed);
    }

    // Temporary Debug Method: Prints the exact JSON returned by Wit.ai
    public void OnRawResponse(WitResponseNode response)
    {
        Debug.Log($"[Wit.ai Raw JSON]: {response.ToString()}");
    }

    public void OnMoveLimbDirection(string direction)
    {
        // 1. CONFIRM EVENT TRIGGER
        Debug.Log($"[Voice Input Received]: Raw direction string = '{direction}'");

        switch (direction?.ToLower().Trim())
        {
            case "in":
                targetInput = new Vector2(targetInput.x, 1f);
                Debug.Log("Target set to: IN");
                break;

            case "out":
                targetInput = new Vector2(targetInput.x, 0f);
                Debug.Log("Target set to: OUT");
                break;

            case "left":
                targetInput = new Vector2(-1f, targetInput.y);
                Debug.Log("Target set to: LEFT");
                break;

            case "right":
                targetInput = new Vector2(1f, targetInput.y);
                Debug.Log("Target set to: RIGHT");
                break;

            default:
                Debug.LogWarning($"[Voice Input Warning]: Received '{direction}', but it didn't match 'in', 'out', 'left', or 'right'.");
                break;
        }
    }
}