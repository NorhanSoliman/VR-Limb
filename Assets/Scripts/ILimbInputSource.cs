using UnityEngine;

public interface ILimbInputSource
{
    Vector2 GetValue(); // x = axis 1 (e.g. curl), y = axis 2 (e.g. splay/rotate)
}