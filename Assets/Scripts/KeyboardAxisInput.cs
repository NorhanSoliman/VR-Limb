using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardAxisInput : MonoBehaviour, ILimbInputSource
{
    public Vector2 GetValue()
    {
        if (Keyboard.current == null) return Vector2.zero;

        float x = 0f, y = 0f;
        if (Keyboard.current.hKey.isPressed) x += 1f;
        if (Keyboard.current.fKey.isPressed) x -= 1f;
        if (Keyboard.current.tKey.isPressed) y += 1f;
        if (Keyboard.current.gKey.isPressed) y -= 1f;

        return new Vector2(x, y);
    }
}