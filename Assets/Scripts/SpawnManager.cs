using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Enemy enemyPrefab;
    public GameObject powerUpPrefab;
    public float RandomFloat=9f;
    public int enemyCount;
    private int enemyWaveNum=1;
    private int powerUpNum;
    // Start is called before the first frame update
    void Start()
    {
        SpawnGeneretorEnemy(3);
        Instantiate(powerUpPrefab,GenerateSpawnPosition(),powerUpPrefab.transform.rotation);
    }

    void SpawnGeneretorEnemy(int enemySpawnnums=1)
    {
        for(int i=0;i<enemySpawnnums;i++)
        {
            Instantiate(enemyPrefab,GenerateSpawnPosition(),enemyPrefab.transform.rotation);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        float posX=Random.Range(-RandomFloat,RandomFloat);
        float posZ=Random.Range(-RandomFloat,RandomFloat);
        return new Vector3(posX,0,posZ);
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount=GameObject.FindGameObjectsWithTag("Enemy").Length;
        powerUpNum=GameObject.FindGameObjectsWithTag("PowerUp").Length;
        
        if(enemyCount==0)
        {
            Debug.Log("eney count  "+enemyCount);
            enemyWaveNum++;
            SpawnGeneretorEnemy(enemyWaveNum);

            if(powerUpNum==0)
            Instantiate(powerUpPrefab,GenerateSpawnPosition(),powerUpPrefab.transform.rotation);
        }        

        
    }
}
