using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class SpawnController : MonoBehaviour
{
    public GameObject Player;

    public GameObject Level1;

    [SerializeField] Vector2 spawnArea;
    public float spawnTime;
    private float lastSpawn;

    private GameObject clone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();

        GameObject newEnemy = Instantiate(Level1);
        newEnemy.GetComponent<EnemyController>().Target = Player;
        newEnemy.transform.position = position;
        newEnemy.transform.parent = transform;
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
            SpawnEnemy();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Player.transform.position, spawnArea);
    }
}
