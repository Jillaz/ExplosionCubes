using UnityEngine;

[RequireComponent(typeof(Renderer))]

public class Painter : MonoBehaviour
{
    private Renderer _renderer;

    public void SetRandomColor()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.SetColor("_Color", Random.ColorHSV());
    }
}
