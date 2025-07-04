using System.IO;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class enemyScript : MonoBehaviour
{
    
    public float moveSpeed;
    public float maxHp;
    public int rewardMoney = 10;
    public Image healthFillImage;
    public Transform[] path;

    private float hp;
    private int pathCount = 1;



    void Start()
    {
        //Ligne a delete, il faudra donner ces 2 var au moment d'instantiate
        moveSpeed = 1f;
        maxHp = 20f;
        rewardMoney = 10;
        //
        hp = maxHp;
    }

    void Update()
    {
        ShowHealth();

        if (hp <= 0) { Death(); }

        if (pathCount < path.Length)
        {
            MoveTo(path[pathCount]);
            return;
        }

        WaveManager.Instance.HitCore();
        Destroy(gameObject);

    }

    public void Hit(float damage)
    {
        hp -= damage;
    }


    void MoveTo(Transform point)
    {
        transform.position += (point.position - transform.position).normalized * moveSpeed *  Time.deltaTime;

        if ((point.position - transform.position).magnitude < 0.1)
        {
            pathCount ++;
        }
    }

    void ShowHealth()
    {
        if (healthFillImage != null)
        {
            
            healthFillImage.fillAmount = hp / maxHp;
        }
    }

    void Death()
    {
        MoneyManager.Instance.AddMoney(rewardMoney);
        Destroy(gameObject);
    }

}
