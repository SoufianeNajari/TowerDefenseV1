using UnityEngine;

public class TileClickManager : MonoBehaviour
{

    public LayerMask tileLayer;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            RaycastHit2D hit = Physics2D.Raycast(worldPos, Vector2.zero, Mathf.Infinity, tileLayer);
            
            if (hit.collider != null)
            {
                TowerTile tile = hit.collider.GetComponent<TowerTile>();
                if (tile != null)
                {
                    tile.SpawnTower();
                }
            }
        }
    }
}
