using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            //other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(2);
            Destroy(other.gameObject);
        }
    }
    
}
