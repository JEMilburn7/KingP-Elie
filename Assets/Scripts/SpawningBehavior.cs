using UnityEngine;

public class SpawningBehavior : MonoBehaviour
{
    public GameObject[] ballVariants;
    public GameObject targetObject;
    GameObject newObject;
    public float startTime;
    public float spawnRatio = 1.0f;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float minSpawn;
    public float maxSpawn;
    public Pins pinsDB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnBall();
        spawnPin();
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.time;
        float timeElapsed = currentTime - startTime;
        spawnRatio = Random.Range(minSpawn, maxSpawn);
        if(timeElapsed > spawnRatio) {
            spawnBall();
        }
    }

    void spawnBall() {
        int numVariants = ballVariants.Length;
        if(numVariants > 0) {
            int selection = Random.Range(0, numVariants);
            newObject = Instantiate(ballVariants[selection], new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            BallBehavior ballBehavior = newObject.GetComponent<BallBehavior>();
            ballBehavior.setBounds(minX, maxX, minY, maxY);
            ballBehavior.setTarget(targetObject);
            ballBehavior.initialPosition();
        }
        startTime = Time.time;
    }

    void spawnPin() {
        targetObject = Instantiate(pinsDB.getPin(CharacterManager.selection).prefab, new Vector3(0.0f, 0.0f, 0.0f),
            Quaternion.identity);
    }
}
