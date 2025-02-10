using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DashIconBehavior : MonoBehaviour
{
    TextMeshProUGUI label;
    public float fill;
    Image overlay;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        label = GetComponent<TextMeshProUGUI>();
        Image[] images = GetComponentsInChildren<Image>();
        for(int i = 0; i < images.Length; i++) {
            if(images[i].tag == "overlay") {
                overlay = images[i];
            }
        }
        fill = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        string message = "";
        if(PinBehavior.cooldown > 0.0) {
            message = string.Format("{0:0.0}", PinBehavior.cooldown);
            fill = PinBehavior.cooldown / PinBehavior.cooldownRate;
            overlay.fillAmount = fill;
        }
        label.text = message;
    }
}
