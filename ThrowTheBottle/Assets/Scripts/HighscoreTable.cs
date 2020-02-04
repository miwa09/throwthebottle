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
        if (PlayerPrefs.GetInt("needLists") != 1) {
            InstantiateLists();
        }
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

    void InstantiateLists() {
        InstantiateLists1();
        InstantiateLists1C();
        InstantiateLists2();
        InstantiateLists2C();
        InstantiateLists3();
        InstantiateLists3C();
        PlayerPrefs.SetInt("needLists", 1);
        PlayerPrefs.Save();
    }

    void InstantiateLists1C() {
        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{ score = 7351, name = "NAT" },
            new HighscoreEntry{ score = 5563, name = "OSC" },
            new HighscoreEntry{ score = 3248, name = "TIM" },
        };

        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscore1Chaos", json);
        PlayerPrefs.Save();
    }

    void InstantiateLists1() {
        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{ score = 6000, name = "DAN" },
            new HighscoreEntry{ score = 3600, name = "OSC" },
        };

        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscore1", json);
        PlayerPrefs.Save();
    }

    void InstantiateLists3C() {
        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{ score = 9139, name = "1ST" },
            new HighscoreEntry{ score = 8777, name = "2ND" },
            new HighscoreEntry{ score = 8602, name = "TIM" },
            new HighscoreEntry{ score = 7503, name = "ING" },
            new HighscoreEntry{ score = 7442, name = "MRY" },
            new HighscoreEntry{ score = 6606, name = "ELV" },
            new HighscoreEntry{ score = 6123, name = "SAM" },
        };

        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscore3Chaos", json);
        PlayerPrefs.Save();
    }
    void InstantiateLists3() {
        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{ score = 7900, name = "SAM" },
            new HighscoreEntry{ score = 6500, name = "ULY" },
            new HighscoreEntry{ score = 5000, name = "NAT" },
        };

        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscore3", json);
        PlayerPrefs.Save();
    }

    void InstantiateLists2() {
        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{ score = 3000, name = "CHA" },
            new HighscoreEntry{ score = 2200, name = "LIZ" },
            new HighscoreEntry{ score = 1750, name = "IMP" },
            new HighscoreEntry{ score = 1550, name = "CON" },
            new HighscoreEntry{ score = 1000, name = "KAT" },

        };

        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscore2", json);
        PlayerPrefs.Save();
    }
    void InstantiateLists2C() {
        highscoreEntryList = new List<HighscoreEntry>() {
            new HighscoreEntry{ score = 8352, name = "TIM" },
            new HighscoreEntry{ score = 5336, name = "HAR" },
            new HighscoreEntry{ score = 5293, name = "ELV" },
        };

        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscore2Chaos", json);
        PlayerPrefs.Save();
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

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public string name;
    }

}
