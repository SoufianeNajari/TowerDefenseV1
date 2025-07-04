using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float fireCooldown = 0.4f;
    private float timer;
    public float damage = 1f;
    
    private List<Collider2D> enemiesInRange = new List<Collider2D>();
    
    public void OnEnemyEnter(Collider2D collision)
    {
        enemiesInRange.Add(collision);
    }

    public void OnEnemyExit(Collider2D collision)
    {
        enemiesInRange.Remove(collision);
    }

    
    void Shoot(Collider2D target)
    {
        //angle du vecteur directeur
        float angle = -Vector2.Angle(target.transform.position - transform.position, Vector2.right);
        //angle transformé en quaternion
        Quaternion angleQuaternion = Quaternion.Euler(0, 0, angle);


        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position + new Vector3(0.5f,1, 0), angleQuaternion);
        bulletInstance.GetComponent<BulletScript>().enemy = target;
        bulletInstance.GetComponent<BulletScript>().bulletDamage = damage;
    }


    void Update()
    {
        timer += Time.deltaTime;
        enemiesInRange.RemoveAll(enemy => enemy == null);

        if (timer > fireCooldown && enemiesInRange.Count != 0)
        {
            timer = 0;
            Shoot(enemiesInRange[0]);
            
        }
    }

}
