using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeathZone : MonoBehaviour
{
    public GameObject key;
    public float score;
    public float scoreGoal;
    public Text scoreText;  //Reference to the text object 
    private bool _keyUnlocked;
    public AudioSource gotKey;

    private void Start()
    {
        _keyUnlocked = false;
    }

    private void Update()
    {
        if (score >= scoreGoal && !_keyUnlocked)
        {
            _keyUnlocked = true;
            gotKey.Play();
            key.GetComponent<Collider2D>().enabled = true;
            key.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D hitBox)
    {
        if (!hitBox.CompareTag($"Enemy")) return;
        score += 0.5f;
        scoreText.text = score.ToString(CultureInfo.InvariantCulture);
    }

    public void Reset(){
        score = 0;
        scoreText.text = score.ToString(CultureInfo.InvariantCulture);
    }
}
