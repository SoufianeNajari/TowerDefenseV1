using UnityEngine;

public class SortingOrderByY : MonoBehaviour
{
    public bool isTower = false;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sortingLayerName = "MobAndTower";  // Forcer la bonne sorting layer
    }

    void Update()
    {
        int baseOrder = -Mathf.RoundToInt(transform.position.y * 100);
        if (isTower)
        {
            baseOrder -= 40;  // Décalage tours
        }
        spriteRenderer.sortingOrder = baseOrder;
    }
}

