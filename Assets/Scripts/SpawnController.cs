//using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Player;

    public GameObject Level1;

    [SerializeField] Vector2 spawnArea;
    public float spawnTime;
    private float lastSpawn;
    private float addDamage;
    private float addHealth;

    private GameObject clone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        GameObject newEnemy = Instantiate(Level1);
        newEnemy.GetComponent<EnemyController>().Target = Player;
        newEnemy.transform.position = position + Player.transform.position;
        newEnemy.transform.parent = transform;
        newEnemy.GetComponent<Stats>().damage += addDamage;
        newEnemy.GetComponent<Stats>().maxHealth += addHealth;
        newEnemy.GetComponent<Stats>().currentHealth = newEnemy.GetComponent<Stats>().maxHealth;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = Random.value > 0.5f ? -0.5f : 0.5f;
        if(Random.value > 0.5f)
        {
            position.x = Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = Random.Range(-spawnArea.y, spawnArea.y);
            position.y = spawnArea.x * f;
        }
        position.z = 0;

        return position;
    }

    // Update is called once per frame
    void Update()
    {
        if((Time.realtimeSinceStartup-lastSpawn)>spawnTime)
        {
            lastSpawn = Time.realtimeSinceStartup;

            int Total = Random.Range(1, 5);
            int spawned = 0;

            while (spawned < Total)
            {
                SpawnEnemy();
                spawned += 1;
            }
        }

        if (Time.realtimeSinceStartup > 60 && spawnTime == 5)
        {
            spawnTime = 4;
            addHealth = 10;
            addDamage = 1;
        }
        else if (Time.realtimeSinceStartup > 120 && spawnTime == 4)
        {
            spawnTime = 3;
            addHealth = 20;
            addDamage = 1.5f;
        }
        else if (Time.realtimeSinceStartup > 180 && spawnTime == 3)
        {
            spawnTime = 2;
            addHealth = 30;
            addDamage = 2;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Player.transform.position, spawnArea);
    }
}
