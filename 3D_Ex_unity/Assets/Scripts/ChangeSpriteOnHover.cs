using UnityEngine;

public class ChangeSpriteOnHover : MonoBehaviour
{
    public Sprite normalSprite; // Обычный спрайт
    public Sprite hoverSprite;  // Спрайт при наведении
    
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = normalSprite;
    }

    private void OnMouseEnter()
    {
        spriteRenderer.sprite = hoverSprite; // Меняем спрайт
    }

    private void OnMouseExit()
    {
        spriteRenderer.sprite = normalSprite; // Возвращаем обратно
    }
}