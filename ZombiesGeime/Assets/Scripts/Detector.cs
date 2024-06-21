using UnityEngine;

public class Detector: MonoBehaviour{
    public GameObject target;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("IgnoreDetector") || target != null)
            return;
        target = other.gameObject;
    }
}
