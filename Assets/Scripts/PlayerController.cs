using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    Rigidbody rigidbody;

    public GameObject projectilePrefab;
    public float projectileSpeed;
    private float lastFire;
    public float fireDelay;
    public int collectedAmount;

    public Vector3 coords;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;


    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float zAxis = Input.GetAxis("Vertical");
        rigidbody.velocity = new Vector3(xAxis * speed, 0, zAxis * speed);

        if (Input.GetMouseButtonDown(0) && Time.time > lastFire + fireDelay)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance=10;
            Plane plane = new Plane(Vector3.up, Vector3.zero);

            if (plane.Raycast(ray, out distance))
            {
                Vector3 target = ray.GetPoint(distance);
                coords = target - transform.position;
                float rotation = Mathf.Atan2(coords.x, coords.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, rotation, 0);
            }
            shootFire(coords.x, coords.z);
            lastFire = Time.time;
        }
       


        


    }
    void shootFire(float x, float z)
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation) as GameObject;
        projectile.AddComponent<Rigidbody>();
        projectile.GetComponent<Rigidbody>().velocity = new Vector3(
            (x < 0)? Mathf.Floor(x)* projectileSpeed : Mathf.Ceil(x) * projectileSpeed , 
            0,
            (z < 0) ? Mathf.Floor(z) * projectileSpeed : Mathf.Ceil(z) * projectileSpeed
            );


    }
}
