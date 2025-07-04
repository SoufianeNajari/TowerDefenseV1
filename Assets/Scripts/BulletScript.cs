using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed = 1f;
    public float bulletDamage;
    public Collider2D enemy; //collider
    private Vector3 direction;
    private Vector3 enemyPos;


    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
            //Calcul de traj et d'angle de la balle :
            enemyPos = enemy.transform.position;
            direction = enemyPos - transform.position;
            
            float angle = -Vector2.SignedAngle(direction, Vector2.right); //angle du vecteur directeur
            Quaternion angleQuaternion = Quaternion.Euler(0, 0, angle); //angle transformé en quaternion

            //Déplacement + rotation
            transform.position += direction.normalized * bulletSpeed *  Time.deltaTime;
            transform.rotation = angleQuaternion;

            if (enemy.OverlapPoint(transform.position))
            {
                enemy.gameObject.GetComponent<enemyScript>().Hit(bulletDamage);
                Destroy(gameObject);
            }

        }
        else
        {
            direction = enemyPos - transform.position;
            transform.position += direction.normalized * bulletSpeed *  Time.deltaTime;
            if (direction.magnitude <= 0.2) // Magic number, jsp 
            {
                Destroy(gameObject);
            }       
        }
    }
}
