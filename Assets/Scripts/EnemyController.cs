using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,
    Follow,
    Die,
    Attack

};
public class EnemyController : MonoBehaviour
{

    GameObject player;
    
    public EnemyState currentState = EnemyState.Wander;
    public float range;
    public float input;
    public float speed;
    public float hp;
    public float coolDown;
    public float attackRange;
    private bool chooseDir = false;
    private bool dead = false;
    private bool isStuck = false;
    private bool coolDownAttack = false;
     
    private Vector3 randomDir;

    


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case(EnemyState.Wander):
                Wander();
                break;
            case(EnemyState.Follow):
                Follow();
                break;
            case(EnemyState.Die):
                break;
            case(EnemyState.Attack):
                Attack();
                break;


        }
        if (isPlayerInRange(range) && currentState != EnemyState.Die)
        {
            currentState = EnemyState.Follow;
        }
        else if( (!isPlayerInRange(range) || isStuck) && currentState != EnemyState.Die)
        {
            currentState = EnemyState.Wander;

        }
        if(Vector3.Distance(transform.position, player.transform.position) <= attackRange)
        {
            currentState = EnemyState.Attack;

        }

    }

    private bool isPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;

    }
    private IEnumerator ChooseDirection()
    {
        chooseDir = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randomDir = new Vector3(0, Random.Range(0, 360), 0);
        Quaternion nextRotation = Quaternion.Euler(randomDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRotation, Random.Range(0.5f, 2.5f));
        chooseDir = false;

    }
    void Wander()
    {
        if(!chooseDir)
        {
            StartCoroutine(ChooseDirection());

        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if (isPlayerInRange(range))
            currentState = EnemyState.Follow;

    }
    void Follow()
    {

        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);


    }
    void Attack()
    {
        if (!coolDownAttack)
        {
            GameController.DamagePlayer(1);
            StartCoroutine(CoolDown());
        }
    }  
    private IEnumerator CoolDown()
    {
        coolDownAttack = true;
        yield return new WaitForSeconds(coolDown);
        coolDownAttack = false;

    }
    public void Death()
    {
        Destroy(gameObject);
        
    }
    private void OnTriggerEnter(Collider coll)
    {

        if (coll.tag == "Wall" || coll.tag == "Rock")
        {

            isStuck = true;


        }
        else
            isStuck = false;



    }
}
