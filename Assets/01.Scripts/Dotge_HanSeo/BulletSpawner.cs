using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float spawnRateMin = 0.5f;
    public float spawnRateMax = 1f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;
    public int dieCount;


   
    void Start()
    {

        timeAfterSpawn = 0f;

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);

        target = FindObjectOfType<PlayerController>().transform;

    }

    
    void Update()
    {

        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }

    }

    public void Die()
    {
        gameObject.SetActive(false);

        dieCount++;

        if (dieCount <= 1)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.ClearGame();
        }

    }

   
}
