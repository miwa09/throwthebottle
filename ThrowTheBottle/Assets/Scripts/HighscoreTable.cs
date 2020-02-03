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
    private void Awake() {
        entryContainer = transform.Find("highscoreEntryContainer");
        entryTemplate = entryContainer.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);


        //highscoreEntryList = new List<HighscoreEntry>() {
        //    new HighscoreEntry{ score = 10000, name = "AAA" },
        //    new HighscoreEntry{ score = 5232, name = "JAG"},
        //    new HighscoreEntry{ score = 61235, name = "FUK"},
        //    new HighscoreEntry{ score = 2513, name = "CAT" },
        //    new HighscoreEntry{ score = 25034, name = "SIG"},
        //    new HighscoreEntry{ score = 84232, name = "SHT"},
        //    new HighscoreEntry{ score = 15232, name = "BBB" },
        //    new HighscoreEntry{ score = 33333, name = "F"},
        //    new HighscoreEntry{ score = 80085, name = "ASS"},
        //};

        //AddHighscoreEntry(10000, "CMK");

        string jsonString = PlayerPrefs.GetString("highscoreTable");
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

            highscoreEntryTransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
                CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        }

        //Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        //string json = JsonUtility.ToJson(highscores);
        //PlayerPrefs.SetString("highscoreTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        //Debug.Log(PlayerPrefs.GetString("highscoreTable"));
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
        PlayerPrefs.SetString("highscoreTable", "");
    }

    void AddHighscoreEntry(int score, string name) {
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
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
