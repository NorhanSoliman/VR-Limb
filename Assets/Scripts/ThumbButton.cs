using UnityEngine;

public class ThumbButton : MonoBehaviour
{
    public int buttonNumber;

    private bool pressed = false;

    // The color the button changes to when pressed
    public Color pressedColor = Color.green;

    private Renderer buttonRenderer;

    private void Start()
    {
        // Get the Renderer of this button
        buttonRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Ignore the trigger if this button was already pressed
        if (pressed)
            return;

        // Check if the extra thumb touched the button
        if (other.CompareTag("ThumbTip"))
        {
            // Mark this specific button as pressed
            pressed = true;

            Debug.Log("Button " + buttonNumber + " pressed!");

            // Change button color
            if (buttonRenderer != null)
            {
                buttonRenderer.material.color = pressedColor;
            }
        }
    }
}