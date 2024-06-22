using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave", menuName = "ScriptableObjects/Wave", order = 1)]
public class Wave : ScriptableObject {
    public List<WaveEnemy> Enemies;
    public float spawnInterval;

    public IEnumerator SpawnInSpawner(Transform spawner){
        foreach (var enemy in Enemies){
            for (var i = 0; i < enemy.enemyCount; i++) {
                Instantiate(enemy.enemyType, spawner.position, spawner.rotation);
                yield return new WaitForSeconds(spawnInterval + Random.Range(-0.5f, 0.5f));
            }
        }
    }

    public float WaveDuration() {
        int count = 0;
        foreach(var enemy in  Enemies) {
            count += enemy.enemyCount;
        }
        return count * spawnInterval;
    }

}

[System.Serializable]
public struct WaveEnemy {
    public GameObject enemyType;
    public int enemyCount;
}
