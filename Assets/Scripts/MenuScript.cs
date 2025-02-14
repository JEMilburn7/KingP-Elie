using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void gotoGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainGame");
    }

    public void gotoMenu() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void gotoCharSelect() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelection");
    }
}
