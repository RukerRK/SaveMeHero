using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Networking;

public class shootBulletProjectile : MonoBehaviour
{
    public Transform shootPoint;
    public Rigidbody2D bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Debug.DrawRay(ray.origin,ray.direction100 ,Color.green ,100);

            RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit2D.collider != null)
            {
                Vector2 projectileVelocity = CalculateProjetileVelocity(shootPoint.position, hit2D.point, 1f);

                Rigidbody2D fireBullet = Instantiate(bullet, shootPoint.position, quaternion.identity);
                fireBullet.velocity = projectileVelocity;
            }
        }
    }

    Vector2 CalculateProjetileVelocity(Vector2 origin ,Vector2 target ,float time)
    {
        Vector2 distance = target - origin;
        float disX = distance.x;
        float disY = distance.y;

        float velocityX = disX / time;
        float velocityY = disY / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
        Vector2 result = new Vector2(velocityX ,velocityY);

        return result;
    }

}