using UnityEngine;

public class PinBehavior : MonoBehaviour
{
    public float baseSpeed = 2.0f;
    public Vector2 newPosition;
    public Vector3 mousePosG;
    Camera cam;
    Rigidbody2D body;
    public float dashSpeed;
    bool dashing;
    public float speed;
    public float dashDuration;
    public float timeDashStart;
    public static float cooldown;
    public static float cooldownRate = 3.0f;
    public float timeDashEnd;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        dashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Dash();
    }

    void FixedUpdate()
    {
        body = GetComponent<Rigidbody2D>();
        mousePosG = cam.ScreenToWorldPoint(Input.mousePosition);
        newPosition = Vector2.MoveTowards(transform.position, mousePosG, speed * Time.fixedDeltaTime);
        //transform.position = newPosition;
        body.MovePosition(newPosition);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        string collided = collision.gameObject.tag;
        Debug.Log("Collided with " + collided);
        if(collided == "Ball" || collided == "Wall") {
            Debug.Log("Game Over");
        }
    }

    private void Dash() {
        if(dashing == true) {
            float howLong = Time.time - timeDashStart;
            if(howLong > dashDuration) {
                dashing = false;
                speed = baseSpeed;
                timeDashEnd = Time.time;
                cooldown = cooldownRate;
            }
        } else {
            cooldown = cooldown - Time.deltaTime;
            if(cooldown < 0) {
                cooldown = 0;
            }
            if(Input.GetMouseButtonDown(0) == true && cooldown == 0.0) {
                dashing = true;
                speed = dashSpeed;
                timeDashStart = Time.time;
            }
        }
    }
}
