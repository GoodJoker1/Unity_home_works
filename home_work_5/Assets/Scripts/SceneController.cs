using UnityEngine;
using System.Collections;
public class SceneController : MonoBehaviour
{
    [SerializeField] 
    private GameObject enemyPrefab; 
    //private GameObject _enemy;
    public Transform[] spawnPoints;
    private int enemyCount = 0;


    void Update()
    {
        if (enemyCount < 20) 
        {
            SpawnEnemy();
        }
    }
    //void Update() {
    //    if (_enemy == null) { 
    //        _enemy = Instantiate(enemyPrefab) as GameObject; 
    //        _enemy.transform.position = new Vector3(0, 1, 0); 
    //        float angle = Random.Range(0, 360); 
    //        _enemy.transform.Rotate(0, angle, 0); 
    //    } 
    //}

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Vector3 spawnPosition = spawnPoints[spawnIndex].position;

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        enemyCount++;

        float angle = Random.Range(0, 360);
        newEnemy.transform.Rotate(0, angle, 0);
    }
}
