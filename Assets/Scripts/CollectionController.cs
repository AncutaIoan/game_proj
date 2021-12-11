using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public string description;
    public Sprite itemImage;

}
public class CollectionController : MonoBehaviour
{
    public Item item;
    public float healthChange;
    public float moveSpeedChange;
    public float bulletSizeChange;
    public float attackSpeedChange;

    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Player")
        {
            
            GameController.HealPlayer(healthChange);
            GameController.IncreaseMoveSpeed(moveSpeedChange);
            Destroy(gameObject);

        }
    }

}
