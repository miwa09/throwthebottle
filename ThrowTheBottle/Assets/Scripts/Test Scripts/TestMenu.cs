using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TestMenu : MonoBehaviour
{
    public GameObject menuObj;
    public float timeScale = 1;
    public Button menuButton;
    public Button[] popupDisableList;
    public GameObject confirmationPopup;
    public string highscoreString;

    private void Start() {
        if (menuObj != null) {
            menuObj.SetActive(false);
        }
    }
    public void GamePause() {
        timeScale = Time.timeScale;
        Time.timeScale = 0;
        menuObj.SetActive(true);
        menuButton.enabled = false;
        print(timeScale);
    }

    public void GameResume() {
        Time.timeScale = timeScale;
        menuObj.SetActive(false);
        menuButton.enabled = true;
    }

    public void GameRestart() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenuConfirmation() {
        foreach (Button obj in popupDisableList) {
            obj.enabled = false;
        }
        confirmationPopup.SetActive(true);
    }

    public void MainMenuCancel() {
        foreach (Button obj in popupDisableList) {
            obj.enabled = true;
        }
        confirmationPopup.SetActive(false);
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void LoadScene(string scene) {
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SaveHighscore(int score, string name) {
        GameObject.FindObjectOfType<HighscoreTable>().AddHighscoreEntry(score, name, highscoreString);
    }

    public void PopupHighscore(GameObject obj) {
        obj.SetActive(true);
    }

    public void ReturnHighscore(GameObject obj) {
        obj.SetActive(false);
    }

    public void Exit() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();

    }

    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public string name;
    }
}
