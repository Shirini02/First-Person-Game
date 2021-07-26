using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float enemyMoveSpeed;
    public Rigidbody rb;
    public Transform target;
    public bool chasing;
    public float distanceTochase, distanceToloose,distannceToStop;
    public NavMeshAgent agent;
    Vector3 startPoint;
    public float keepChasingTime,chasecounter;
    public GameObject enemyBulletPrefab;
    public Transform enemyfirepoint;
    public float fireRate,firecount,firewaitcounter,waitbetweenshoots,shoottimecounter;//enemy firerate controll
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        shoottimecounter = 1.0f;
        firewaitcounter = waitbetweenshoots;
    }

    // Update is called once per frame
    void Update()
    {
        if (!chasing)
        {
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position)<distanceTochase)
            {
                chasing = true;
                // firecount = 1.0f;
                shoottimecounter = 1f;
                firewaitcounter = waitbetweenshoots;
            }
            if (chasecounter > 0)
            {
                chasecounter -= Time.deltaTime;
                if (chasecounter <= 0)
                {
                    agent.destination = startPoint;
                }
            }
            
            
        }
        else
        {

            //transform.LookAt(PlayerController.instance.transform.position);
            //rb.velocity = transform.forward * enemyMoveSpeed;
            if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distannceToStop)
            {

            }
            agent.destination = PlayerController.instance.transform.position;
            
            
            if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) > distanceTochase)
            {
                chasing = false;
                agent.destination = startPoint;
                chasecounter = keepChasingTime;
            }
            if(firewaitcounter>0)
            {
                firewaitcounter -= Time.deltaTime;
                if(firewaitcounter<=0)
                {
                    shoottimecounter = 1f;
                }
            }
            else
            {
                shoottimecounter -= Time.deltaTime;
                if (shoottimecounter > 0)
                {
                    firecount -= Time.deltaTime;
                    if (firecount <= 0)
                    {
                        firecount = fireRate;
                        enemyfirepoint.LookAt(PlayerController.instance.transform.position+new Vector3(0,1.5f,0));
                        //check the angle of player
                        Vector3 targetdirection = PlayerController.instance.transform.position - transform.position;
                        float angle = Vector3.SignedAngle(targetdirection, transform.forward, Vector3.up);
                        if(Mathf.Abs(angle)<40f)
                        {
                            Instantiate(enemyBulletPrefab, enemyfirepoint.position, enemyfirepoint.rotation);
                        }
                        else
                        {
                            firewaitcounter = waitbetweenshoots;
                        }
                       
                       
                    }
                    agent.destination = transform.position;

                }
                else
                {
                    firewaitcounter = waitbetweenshoots;
                }
            }
           
            
        }

    }
}
