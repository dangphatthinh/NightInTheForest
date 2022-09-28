using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyGhostHolder;
    [SerializeField] private float time = 8f;
    private float timecounter = 0f;
    [SerializeField]private float maxTime = 3f;
    [SerializeField] private float minTime = 1f;

    private void Start()
    {
        StartCoroutine(Spawner());
    }
    private void Update()
    {
        timecounter += Time.deltaTime;
        if (timecounter < time)
            return;
        else
        {
            EnemyController.speed += 0.5f;
            timecounter = 0;
            maxTime = Mathf.Clamp(maxTime -= 0.2f, 0.8f,3f);
            minTime = Mathf.Clamp(minTime -= 0.05f, 0.5f, 1f);
        }
    }
    //Delay for 1s
    IEnumerator Spawner() 
    {
        yield return new WaitForSeconds(Random.Range(minTime,maxTime));    
        Vector2 temp = enemyGhostHolder.transform.position;
        temp.y = Random.Range(0f, 0.5f);
        Instantiate(enemyGhostHolder, temp, Quaternion.identity);
        StartCoroutine(Spawner());
        
    }
}
