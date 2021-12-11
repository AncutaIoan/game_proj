using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject heartContainer;
    private float fillValue;


    // Update is called once per frame
    void Update()
    {
        heartContainer= GameObject.FindGameObjectWithTag("fullhppic");
        fillValue = (float)GameController.Health;
        fillValue = fillValue / GameController.MaxHealth;
        heartContainer.GetComponent<Image>().fillAmount = fillValue;

    }
}
