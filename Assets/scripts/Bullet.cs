using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;
    public float explosionRadius = 0f;
    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrane = speed * Time.deltaTime;
        
        if(dir.magnitude <= distanceThisFrane)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrane, Space.World);
        transform.LookAt(target);
	}
    public void HitTarget()
    {
        GameObject effectins = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectins, 2f);

        if (explosionRadius > 0f)
        {
            //Radius
            Explode();
        } else
        {
            Damage(target.transform);
        }

        Destroy(target.gameObject);
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

}
