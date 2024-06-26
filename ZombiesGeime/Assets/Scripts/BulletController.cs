using UnityEngine;

public class BulletController : MonoBehaviour {
    private int lifeSpan = 5;
    private float deathTimer;
    public int damage = 2;
    [SerializeField] private Rigidbody rb;

    private void Awake() {
        deathTimer = Time.time + lifeSpan;
    }

    public void Shoot() => rb.AddForce(transform.forward * 1000);

    private void Update() {
        if (Time.time >= deathTimer)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy"))
            other.GetComponent<HealthManager>().GetDamage(damage);
        if (!other.CompareTag("Interactable") && !other.CompareTag("Player"))
            Destroy(gameObject);
    }
}