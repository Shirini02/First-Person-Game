using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody bulletrb;
    public float lifeTime;
    public GameObject effects;
    public int damage = 1;
    public bool damageEnemy,damageplayer;
    // Start is called before the first frame update
    void Start()
    {
        damageplayer = true;
    }

    // Update is called once per frame
    void Update()
    {
        bulletrb.velocity = transform.forward * bulletSpeed;
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
        }
        //Destroy(gameObject,2f);
        //Instantiate(effects, transform.position, transform.rotation);
        if(other.gameObject.tag=="Player"&&damageplayer)
        {
            // Debug.Log("player got hit");
            PlayerHealthControll.instance.DamagePlayer(damage);
        }
            Destroy(gameObject, 2f);
        Instantiate(effects, transform.position, transform.rotation);
    }

}
