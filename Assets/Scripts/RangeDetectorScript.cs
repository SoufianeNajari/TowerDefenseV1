using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RangeDetector : MonoBehaviour
{
    public Tower tower;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        tower.OnEnemyEnter(collision);
    }
    

    void OnTriggerExit2D(Collider2D collision)
    {
        tower.OnEnemyExit(collision);
    }

}
