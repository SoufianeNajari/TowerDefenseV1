using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class TowerTile : MonoBehaviour
{

    public GameObject towerPrefab;
    bool isOccupied = false;
    public int towerCost = 8;

    public void SpawnTower()
    {
        if (isOccupied) { return; }

        if (MoneyManager.Instance.money < towerCost) { return; }
        MoneyManager.Instance.UseMoney(towerCost);

        int x = Mathf.FloorToInt(transform.position.x);
        int y = Mathf.FloorToInt(transform.position.y);
        Instantiate(towerPrefab, new Vector3(x, y, 0), Quaternion.identity);
        isOccupied = true;
    }



}
