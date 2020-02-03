using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour {
    Transform entryContainer;
    Transform entryTemplate;
    public float templateHeight;
    List<HighscoreEntry> highscoreEntryList;
    List<Transform> highscoreEntryTransformList;
    public bool recording = true;
    public string highscoreString;
    public int amountToCreate = 20;
    private void Awake() {
        if (!recording) {
            entryContainer = transform.Find("highscoreEntryContainer");
            entryTemplate = entryContainer.Find("highscoreEntryTemplate");

            entryTemplate.gameObject.SetActive(false);

            string jsonString = PlayerPrefs.GetString(highscoreString);
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            if (highscores.highscoreEntryList.Count > 0) {
                for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
                    for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                        if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                            HighscoreEntry tmp = highscores.highscoreEntryList[i];
                            highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                            highscores.highscoreEntryList[j] = tmp;
                        }
                    }
                }
                if (highscores.highscoreEntryList.Count > 20) {
                    for (int i = 0; i < highscores.highscoreEntryList.Count - 20; i++) {
                        highscores.highscoreEntryList.RemoveAt(highscores.highscoreEntryList.Count - (i + 1));
                    }
                    string json = JsonUtility.ToJson(highscores);
                    PlayerPrefs.SetString(highscoreString, json);
                    PlayerPrefs.Save();
                }

                highscoreEntryTransformList = new List<Transform>();
                for (int i = 0; i < amountToCreate; i++) {
                    CreateHighscoreEntryTransform(highscores.highscoreEntryList[i], entryContainer, highscoreEntryTransformList);
                }
                //foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
                //    CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
                //}
            }
        }
    }

    void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank) {
            default: rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("posText").GetComponent<Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }

    void ClearHighscores() {
        PlayerPrefs.SetString(highscoreString, "");
    }

    public void AddHighscoreEntry(int score, string name, string leaderboard) {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString(leaderboard);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString(leaderboard, json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public string name;
    }

}
