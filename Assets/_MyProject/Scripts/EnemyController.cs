using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController instance;
    public static float speed = 3;
    private GameObject spawner;
 
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        spawner = GameObject.Find("EnemySpawner");
    }
    private void Update()
    {
        if(PlayerController.instance != null)
        {
            if(PlayerController.instance.flag == 1)
            {
                Destroy(spawner);
                Destroy(GetComponent<EnemyController>());
            }
        }
        _EnemyMovement();
    }
    void _EnemyMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
        EnemyDestroy();
    }
    void EnemyDestroy()
    {
        if(transform.position.x < -7.5f)
        {
            Destroy(gameObject);
        }
    }
}
