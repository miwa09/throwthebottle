using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretEntity : MonoBehaviour
{
    public bool entityActive = false;
    public GameObject entityBG;
    public SecretTextAnimation text;
    public GameObject sound;
    float timer = 0;
    float duration;
    public AudioSource[] sounds;
    bool doOnce = true;

    private void Start() {
        if (PlayerPrefs.GetInt("mistake") == 2) {
            EntityTalk("You can't leave", 3.5f);
            return;
        }
        if (PlayerPrefs.GetInt("mistake") == 3) {
            EntityTalk("You don't learn... do you?", 6f);
            return;
        }
        if (PlayerPrefs.GetInt("mistake") == 4) {
            EntityTalk("You can keep trying... but you won't succeed...", 12f);
            return;
        }
        EntityTalk("", 5f);
        PlayerPrefs.SetInt("mistake", 1);
        PlayerPrefs.Save();
    }
    void Update()
    {
        if (entityActive) {
            GameObject.FindGameObjectWithTag("throwable").GetComponent<BetterThrow>().enabled = false;
            entityBG.SetActive(true);
            sound.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= duration) {
                timer = 0;
                entityActive = false;
                entityBG.SetActive(false);
                sound.SetActive(false);
                text.Clear();
            }
        } else if (!GameObject.FindGameObjectWithTag("throwable").GetComponent<BetterThrow>().enabled) {
            GameObject.FindGameObjectWithTag("throwable").GetComponent<BetterThrow>().enabled = true;
        }
        int misses = GameObject.FindGameObjectWithTag("GameLogic").GetComponent<NormalMode>().misses;
        if (misses >= 20 && misses < 40 && doOnce) {
            EntityTalk("keep throwing it", 4f);
            doOnce = false;
            return;
        }
        if (misses == 40) {
            doOnce = true;
            return;
        }
        if (misses > 40 && misses < 60 && doOnce) {
            EntityTalk("one day...", 2.5f);
            doOnce = false;
            return;
        }
        if (misses == 60) {
            doOnce = true;
            return;
        }
        if (misses > 60 && misses < 80 && doOnce) {
            EntityTalk("we have all the time in the world... keep throwing", 12f);
            doOnce = false;
            return;
        }
        if (misses == 80) {
            doOnce = true;
            return;
        }
        if (misses > 80 && misses < 100 && doOnce) {
            EntityTalk("throw... throw... throw...", 8f);
            return;
        }
        if (misses == 100) {
            doOnce = true;
            return;
        }
        if (misses > 100 && misses < 200 && doOnce) {
            EntityTalk("still going? good... good... because that's all you will ever. get. to. do.", 18f);
            doOnce = false;
            return;
        }
        if (misses == 200) {
            doOnce = true;
            return;
        }
        if (misses > 200 && misses < 300 && doOnce) {
            EntityTalk("I hope... you enjoy this as much as I do...", 10f);
            doOnce = false;
            return;
        }
        if (misses == 300) {
            doOnce = true;
            return;
        }
        if (misses > 300 && doOnce) {
            EntityTalk("spectacular...         keep going.", 15f);
            doOnce = false;
        }
    }

    public void EntityTalk(string addedstring, float addedduration) {
        entityActive = true;
        text.EntityType(addedstring);
        duration = addedduration;
    }

    public void Mistake() {
        int soundIndex = Random.Range(0, sounds.Length);
        sounds[soundIndex].Play();
    }
}
