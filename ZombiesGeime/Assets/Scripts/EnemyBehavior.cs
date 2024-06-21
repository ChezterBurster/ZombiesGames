using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
    public Detector detector;
    public int speed = 3;
    public int attack = 10;

    private void Update() {
        LookAtTarget();
    }

    private void FixedUpdate() {
        transform.position += speed * Time.fixedDeltaTime * transform.forward;
    }
    
    private void OnCollisionStay(Collision other) {
        if (other.collider.CompareTag("Player") || other.collider.CompareTag("Interactable")) 
            other.collider.GetComponent<HealthManager>().GetDamageOverTime(attack);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.CompareTag("Bullet")) {
            var targetPos = other.transform.position;
            float angle = Mathf.Atan2(targetPos.x, targetPos.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
        }
    }

    private void LookAtTarget() {
        if (detector.target == null)
            return;
        if (detector.target.tag == gameObject.tag) {
            detector.target = null;
            return;
        }
        var target = (Vector3)(detector.target?.transform.position);
        var targetPos = new Vector3(target.x, 0.5f, target.z) - transform.position;
        float angle = Mathf.Atan2(targetPos.x, targetPos.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
    }
}
