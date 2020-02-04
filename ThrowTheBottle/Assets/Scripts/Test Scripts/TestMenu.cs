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
    //public string highscoreString;
    [Tooltip("You really, really shouldn't")]
    public bool entity = false;
    bool entityUnpause = false;
    float timer;
    int timesResumed = 0;
    public GameObject menuButtonObj;

    private void Start() {
        if (menuObj != null) {
            menuObj.SetActive(false);
        }
    }

    private void Update() {
       if (entityUnpause) {
            timer += Time.unscaledDeltaTime;
            if (timer >= 0.2f) {
                GameResume();
                timer = 0;
                entityUnpause = false;
            }
       }
    }
    public void GamePause() {
        if (entity) {
            timesResumed++;
            if (timesResumed == 5) {
                GameObject.FindGameObjectWithTag("unyielding").GetComponent<SecretEntity>().EntityTalk("", 1.5f);
                return;
            }
            if (timesResumed == 8) {
                GameObject.FindGameObjectWithTag("unyielding").GetComponent<SecretEntity>().EntityTalk("Stop", 1.1f);
                return;
            }
            if (timesResumed == 10) {
                GameObject.FindGameObjectWithTag("unyielding").GetComponent<SecretEntity>().EntityTalk("Enough...", 2.5f);
                return;
            }
            if (timesResumed == 11) {
                GameObject.FindGameObjectWithTag("unyielding").GetComponent<SecretEntity>().EntityTalk("You are mine... and you will. not. leave.", 9.5f);
            }
            if (timesResumed >= 12 && timesResumed <= 20) {
                GameObject.FindGameObjectWithTag("unyielding").GetComponent<SecretEntity>().Mistake();
                return;
            }
            if (timesResumed > 20) {
                menuButtonObj.SetActive(false);
                return;
            }
        }
        timeScale = Time.timeScale;
        Time.timeScale = 0;
        menuObj.SetActive(true);
        menuButton.enabled = false;
        if (entity) {
            float chance = Random.Range(0, 100);
            if (chance < 10f) {
                return;
            } else entityUnpause = true;
        }
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

    public void SaveHighscore(int score, string name, string highscoreString) {
        GameObject.FindObjectOfType<HighscoreTable>().AddHighscoreEntry(score, name, highscoreString);
    }

    public void PopupHighscore(GameObject obj) {
        obj.SetActive(true);
    }

    public void ReturnHighscore(GameObject obj) {
        obj.SetActive(false);
    }

    public void ChaosMode() {
        GameObject.FindGameObjectWithTag("PData").GetComponent<ModeSelector>().ChaosMode();
    }

    public void NormalMode() {
        GameObject.FindGameObjectWithTag("PData").GetComponent<ModeSelector>().NormalMode();
    }

    public void NextPanel(GameObject panelOn) {
        GameObject.FindGameObjectWithTag("fadeout").GetComponent<MenuFade>().panelOn = panelOn;
        GameObject.FindGameObjectWithTag("fadeout").GetComponent<MenuFade>().Animate();
    }

    public void DisablePanel(GameObject panelOff) {
        GameObject.FindGameObjectWithTag("fadeout").GetComponent<MenuFade>().panelOff = panelOff;
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
