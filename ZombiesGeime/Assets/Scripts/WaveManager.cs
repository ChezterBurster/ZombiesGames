using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {
    public List<Transform> Spawners;
    public List<Wave> Waves;
    public float waitTime;
    private float timer;
    private bool isWaiting;
    private int waveCount = 0;

    private void Start() {
        StartWave();
    }

    private void Update() {
        if (!isWaiting &&Time.time >= timer) {
            Wait();
        }
        if (isWaiting && timer <= Time.time){
            StartWave();
        }
    }

    private void Wait() {
        waveCount ++;
        timer = Time.time + waitTime;
        isWaiting = true;
    }

    private void StartWave(){
        if (waveCount >= Waves.Count)
            return;
        foreach (var spawner in Spawners) {
            StartCoroutine(Waves[waveCount].SpawnInSpawner(spawner));
        }
        timer = Time.time + Waves[waveCount].WaveDuration();
        isWaiting = false;
    }
}

