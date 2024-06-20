using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    [SerializeField] private Rigidbody rb;
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference fire;
    [SerializeField] private GameObject bulletPrefab;
    public int speed;
    private Vector2 direction;
    private Vector2 centerPoint;
    private bool fireUp;
    private bool canFire = true;
    private float fireTimer = 0f;
    public float fireRate = 0.6f;
    private bool dead;

    void Start() {
        centerPoint = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    private void Update() {
        direction = move.action.ReadValue<Vector2>();
        fireUp = fire.action.IsPressed();
    }

    private void FixedUpdate() {
        transform.position += speed * Time.fixedDeltaTime * new Vector3(direction.x, 0, direction.y);
        if (fireUp && canFire){
            Shoot();
        }else{
            canFire = Time.time > fireTimer;
        }
    }

    private void Shoot() {
        var direction = Mouse.current.position.ReadValue() - centerPoint;
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
        bullet.GetComponent<BulletController>().Shoot();
        fireTimer = Time.time + fireRate;
        canFire = false;
    }

    public void Die() {
        if (dead)
            return;
        Debug.Log("You LOSE");
        Time.timeScale = 0;
        dead = true;
    }
}

