using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathDelay());
        

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }

    }
    
        // Update is called once per frame
        void Update()
    {
        
    }
    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);

    }
    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Enemy")
        {
            coll.gameObject.GetComponent<EnemyController>().Death();
            Destroy(gameObject);
        }
        if (coll.tag == "Wall")
        {
            Destroy(gameObject);
        }


    }
}
