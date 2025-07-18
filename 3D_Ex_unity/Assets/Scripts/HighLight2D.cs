using UnityEngine;

public class Highlight2D : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color highlightColor = Color.yellow; // Цвет подсветки

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    private void OnMouseEnter()
    {
        spriteRenderer.color = highlightColor;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }
}