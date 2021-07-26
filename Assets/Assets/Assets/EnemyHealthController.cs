using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DamageEnemy(int value)
    {
        currentHealth--;
        if (currentHealth >= value)
        {
            Destroy(gameObject);
        }
    }
}
