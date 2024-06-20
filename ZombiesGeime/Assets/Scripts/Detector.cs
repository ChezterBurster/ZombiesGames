using UnityEngine;

public class Detector: MonoBehaviour{
    public GameObject target;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("IgnoreDetector"))
            return;
        target = other.gameObject;
    }
}
