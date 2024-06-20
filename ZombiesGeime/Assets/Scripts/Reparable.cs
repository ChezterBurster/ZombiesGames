using UnityEngine;
using UnityEngine.InputSystem;

public class Reparable : MonoBehaviour {
    public bool isScrap;
    [SerializeField] private GameObject scrapPrefab;
    [SerializeField] private GameObject reparablePrefab;
    [SerializeField] private InputActionReference repare;
    public Detector detector;
    private bool isReparing;
    private float repareTimer;

    private void Update() {
        isReparing = false;
        if (detector.target == null)
            return;
        if (detector.target.CompareTag("Player")) 
            isReparing = repare.action.IsPressed();
    }

    private void FixedUpdate() {
        if (isReparing) {
            repareTimer += 1 * Time.fixedDeltaTime;
            if (repareTimer > 5)
                Repare();
        }
    }

    private void Repare() {
        Instantiate(reparablePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void Break() {
        Instantiate(scrapPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
