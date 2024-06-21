using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField]private GameObject zombiePrefab;
    public float spawnInterval;
    private bool canSpawn;
    private float timer;

    private void Start() {
        timer = spawnInterval;
    }

    private void Update() {
        if (Time.time > timer) 
            canSpawn = true;
    }

    void FixedUpdate() {
        if (canSpawn) {
            Instantiate(zombiePrefab, transform.position, transform.rotation);
            timer = Time.time + spawnInterval;
            canSpawn = false;
        }
    }

}
