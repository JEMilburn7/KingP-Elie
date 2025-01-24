using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float minX = -10.66f;
    public float maxX = 10.61f;
    public float minY = -4.08f;
    public float maxY = 4.06f;
    public float minSpeed;
    public float maxSpeed;
    Vector2 targetPosition;
    public int secondsToMaxSpeed;
    public GameObject target;
    public float minLaunchSpeed;
    public float maxLaunchSpeed;
    public float minTimeToLaunch;
    public float maxTimeToLaunch;
    public float cooldown;
    public bool launching;
    public float launchDuartion;
    public float timeLaunchStart;
    public float timeLastLaunch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //secondsToMaxSpeed = 30;
        //maxSpeed = 10.0f;
        //minSpeed = .01f;
        targetPosition = getRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(launching == false && onCooldown() == false) {
            Launch();
        }
        
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        float distance = Vector2.Distance(currentPosition, targetPosition);
        if(distance > 0.1f) {
            float difficulty = getDifficultyPercentage();
            float currentSpeed;
            if(launching == true) {
                float launchingForHowLong = Time.time - timeLaunchStart;
                if(launchingForHowLong > launchDuartion) {
                    startCooldown();
                }
                currentSpeed = Mathf.Lerp(minLaunchSpeed, maxLaunchSpeed, difficulty);
            } else {
                currentSpeed = Mathf.Lerp(minSpeed, maxSpeed, difficulty);
            }
            currentSpeed = currentSpeed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            transform.position = newPosition;
        } else {
            if(launching == true) {
                startCooldown();
            }
            targetPosition = getRandomPosition();
        }


    }

    Vector2 getRandomPosition() {
        float randomX = Random.Range(minX,maxX);
        float randomY = Random.Range(minY,maxY);
        Vector2 v = new Vector2(randomX,randomY);
        return v;
    }
    private float getDifficultyPercentage() {
        float difficulty = Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxSpeed);
        return difficulty;
    }

    public void Launch () {
        targetPosition = target.transform.position;

        if(launching == false) {
            timeLaunchStart = Time.time;
            launching = true;
        }
    }

    public bool onCooldown() {
        bool result = false;

        float timeSinceLastLaunch = Time.time - timeLastLaunch;
        if(timeSinceLastLaunch < cooldown) {
            result = true;
        }

        return result;
    }

    public void startCooldown() {
        timeLastLaunch = Time.time;
        launching = false;

    }
}
