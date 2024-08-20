using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUniversal : MonoBehaviour
{
    public LayerMask collisionLayer;
    public float radius = 1f;
    public int damage = 40;
    public bool isPlayer, isEnemy;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        DetectCollision();
    }
    public void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, radius, collisionLayer);
        if (hit.Length > 0)
        {
            if (isPlayer)
            {
                hit[0].gameObject.GetComponent<EnemyManager>().TakeDamage(damage);
            }
            if (isEnemy)
            {
                hit[0].gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
            //Debug.Log("hit " + hit[0].gameObject.name);
            gameObject.SetActive(false);
        }
    }
}
