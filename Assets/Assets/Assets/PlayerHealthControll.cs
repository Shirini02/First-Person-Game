using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthControll : MonoBehaviour
{
    public static PlayerHealthControll instance;
    // Start is called before the first frame update
    public int maxhealth, currenthealth;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currenthealth = maxhealth;
        UIController.instance.healthslider.maxValue = maxhealth;
        UIController.instance.healthslider.value = currenthealth;
        UIController.instance.healthText.text = "Health:" + currenthealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamagePlayer(int damagecount)
    {
        currenthealth -= damagecount;
        if(currenthealth<=0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(0);

        }
        UIController.instance.healthslider.value = currenthealth;
        UIController.instance.healthText.text = "Health:" + currenthealth;
    }
}
