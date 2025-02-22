using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuScript : MonoBehaviour
{
    public void gotoGame() {
        WaitForSoundAndTransition("MainGame");
    }

    private IEnumerator WaitForSoundAndTransition(string sceneName) {
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
        yield return new WaitForSeconds(source.clip.length);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void gotoMenu() {
        WaitForSoundAndTransition("MainMenu");
    }

    public void gotoCharSelect() {
        WaitForSoundAndTransition("CharacterSelection");
    }
}
