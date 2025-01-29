using UnityEngine;
using TMPro;

public class TimerBehavior : MonoBehaviour
{
    private float timer;
    private TextMeshProUGUI textField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textField = GetComponent<TextMeshProUGUI>();
        if(textField == null) {
            Debug.Log("No component found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        textField.text = timer.ToString();
        //Debug.Log(timer);

        if(textField != null) {
            int minutes = Mathf.FloorToInt(timer/60);
            int seconds = Mathf.FloorToInt(timer%60);
            string timeLabel =
            string.Format("Time: <color=#FF80F5>{0:00}<color=#7E0404>:<color=#FF80F5>{1:00}", minutes, seconds);
            textField.SetText(timeLabel);
        }
    }
}
