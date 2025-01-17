using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float minX = -10.62f;
    public float maxX = 10.61f;
    public float minY = -4.08f;
    public float maxY = 4.06f;
    public float minSpeed;
    public float maxSpeed;
    Vector2 targetPosition;
    public int secondsToMaxSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        secondsToMaxSpeed = 30;
        maxSpeed = 2.0f;
        minSpeed = .75f;
        targetPosition = getRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 currentPosition = gameObject.GetComponent<Transform>().position;
        if(targetPosition != currentPosition) {
            float currentSpeed = minSpeed;
            Vector2 newPosition = Vector2.MoveTowards(currentPosition, targetPosition, currentSpeed);
            transform.position = newPosition;
        } else {
            targetPosition = getRandomPosition();
        }

            getRandomPosition();

    }

    Vector2 getRandomPosition() {
        float randomX = Random.Range(minX,maxX);
        float randomY = Random.Range(minY,maxY);
        Vector2 v = new Vector2(randomX,randomY);
        return v;
    }
}
