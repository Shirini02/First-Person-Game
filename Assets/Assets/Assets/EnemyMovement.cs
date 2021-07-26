using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public bool shouldMove;
    public bool shouldRotate;
    public float targetMoveSpeed;
    public float targetRotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldMove)
        {
            transform.position += new Vector3(targetMoveSpeed, 0, 0);
        }
        if (shouldRotate)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, targetRotateSpeed * Time.deltaTime, 0f));
        }
    }
}
