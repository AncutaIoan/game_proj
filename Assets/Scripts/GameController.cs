using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameController instance;

    private static float health = 6 ;
    private static float maxHealth = 6 ;
    private static float moveSpeed = 5f;
    private static float maxMoveSpeed = 15f;

    private static float fireRate = 0.5f;

    public static float Health
    {
        get => health;
        set => health = value;
    }
    public static float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }
    public static float MoveSpeed{
        get => moveSpeed;
        set => moveSpeed = value;
    }
    public static float MaxMoveSpeed
    {
        get => maxMoveSpeed;
        set => maxMoveSpeed = value;
    }
    public static float FireRate
    {
        get => fireRate;
        set => fireRate = value;
    }
   // public static Text HealthText { get => healthText; set => healthText = value; }

    public Text healthText;

    void Awake()
    {
    
        if(instance == null)
        {
            instance = this;

        }
    }

    // Update is called once per frame
    void Update()
    {

        healthText.text = "Health:" + health;

    }
    public static void DamagePlayer(int damage)
    {
        health -= damage;
        if(health <=0 )
        {
            KillPlayer();

        }
        
    }
    public static void HealPlayer(float healAmount)
    {
        health = Mathf.Min(maxHealth, health + healAmount);


    }
    public static void IncreaseMoveSpeed(float speedMoveChange)
    {
        moveSpeed = Mathf.Min(maxMoveSpeed, moveSpeed+speedMoveChange);
    }

    private static void KillPlayer()
    {

    }
}
