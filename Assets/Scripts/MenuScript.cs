using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void gottoGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }
}
