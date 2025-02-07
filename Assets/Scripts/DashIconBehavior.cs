using UnityEngine;
using TMPro;

public class DashIconBehavior : MonoBehaviour
{
    TextMeshProUGUI label;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string message = "";
        if(PinBehavior.cooldown > 0.0) {
            message = string.Format("{0:0.0}", PinBehavior.cooldown);
        }
        label.text = message;
    }
}
