using UnityEngine;

public class HealthManager: MonoBehaviour {
    [SerializeField] private float life = 10;

    private float timeFactor;

    void Update() {
        timeFactor = Time.deltaTime;
        if (life <= 0) {
            if (gameObject.CompareTag("Interactable"))
                GetComponent<Reparable>().Break();
            else
                Destroy(gameObject);
        }
    }

    public void GetDamage(int damage) {
        life -= damage;
    }

    public void GetDamageOverTime(int damage)
    {
        life -= damage * timeFactor;
    }
}