using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate = 5f;
    public bool canSpawn = false;
    private bool startedCoroutine;
    private PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if (PlayerPrefs.GetInt("Tutorial") == 0) 
            canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead) canSpawn = false;
        
        if(canSpawn && !startedCoroutine)
        {
            StartCoroutine(Spawner());
            startedCoroutine = true;
        }
    }
    private void Spawn()
    {
        ObjectPooler.instance.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
    }
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (canSpawn)
        {
            yield return wait;
            if (ObjectPooler.instance.CountActive("Enemy") < 2)
                Spawn();
        
        }
    }

}
