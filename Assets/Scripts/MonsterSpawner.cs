using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour {
    public GameObject[] monsters;
    public float spawnTime;
    public float maxXpos;
    int difficulty = 1;
    int maxgroupMonsters = 4;
    // Use this for initialization
    void Start () {
     
        if (AudioManager.instance.background == true)
        {
            AudioManager.instance.Play("game");
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void StopSpawningMonsters()
    {
        CancelInvoke("SpawnMonster");
    }

    public void StartSpawingMonsters()
    {
        InvokeRepeating("SpawnMonster", 0.2f, spawnTime);
    }

    void SpawnMonster()
    {
            if (Random.Range(0, 25) == 0) {
            SpawnLife();
            }
        
             difficulty = DifficultyManager.instance.difficulty;
             if (difficulty < 2)
             {
                 Spawn();
             }
             else
             {
            //for group
                if (Random.Range(0, 10) == 0)
                {
                    SpawnGroup();
                    return;
                }

                //group end

                 Spawn();
                 int bomb = Random.Range(1, 20);
                 if (bomb < 6)
                 {
                     Invoke("SpawnBomb", 0.1f);
                 }
                
             }
         
        //SpawnGroup();
    }
    void Spawn() {
        int monsterno = Random.Range(0, 2);
        Instantiate(monsters[monsterno], new Vector3(Random.Range(-maxXpos, maxXpos), transform.position.y, 0), Quaternion.identity);
    }
    void SpawnBomb() {
        Instantiate(monsters[2], new Vector3(Random.Range(-maxXpos, maxXpos), transform.position.y, 0), Quaternion.identity);
    }
    void SpawnGroup() {
        float pos = -maxXpos;
        int monsterCount = 0;
        int monsterno = Random.Range(0, 2);
        while (pos <= maxXpos && monsterCount<=maxgroupMonsters)
        {
            if (Random.Range(0, 2) == 0)
            {
                monsterCount++;
                Instantiate(monsters[monsterno], new Vector3(pos, transform.position.y, 0), Quaternion.identity);
            }
            pos += 1; 
        }
    }
    void SpawnLife() {
        Instantiate(monsters[3], new Vector3(Random.Range(-maxXpos, maxXpos), transform.position.y, 0), Quaternion.identity);
    }
}
