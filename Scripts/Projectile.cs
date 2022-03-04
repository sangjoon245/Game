using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;
    public int playerShotId = -1;
    // Update is called once per frame

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        if (this.playerShotId == -1)
        {
            Debug.Log("The projectile's ID is NULL!");
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.up, out hitInfo, speed * Time.deltaTime, whatIsSolid))
            {
                //Debug.Log("Hit something!");
                if (hitInfo.collider.CompareTag("Player"))
                {
                    if (this.playerShotId != hitInfo.collider.transform.parent.GetComponent<PlayerManager>().GetId())
                    {
                        //Debug.Log("Hit Player!");
                        DestroyProjectile();
                    }
                }
                if (hitInfo.collider.CompareTag("Wall"))
                {
                    //Ray ray = new Ray(transform.position, transform.up);
                    //Vector3 reflectDir = Vector3.Reflect(ray.direction, hitInfo.normal);
                    //float rot = 90 - Mathf.Atan2(reflectDir.y, reflectDir.x) * Mathf.Rad2Deg;
                    //transform.eulerAngles = new Vector3(0, 0, rot);
                    //Debug.Log(hitInfo.collider);
                    //DestroyProjectile();
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.up, Color.white, 0.01f);
            }
            //transform.Translate(Vector3.up * speed * Time.deltaTime);
            transform.Rotate(0f, Time.deltaTime * 1050f, 0f, Space.Self);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    public void IgnorePlayer(int _PlayerShotId)
    {
        this.playerShotId = _PlayerShotId;
    }
}
