using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerScoreControl : MonoBehaviour
{
    private int score = 0;
    [SerializeField] private Text ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.FindGameObjectWithTag("PlayerScore").GetComponent<Text>();
        ScoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        score++;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            ScoreText.text = score.ToString();
            Destroy(other.gameObject);
        }*/
    }
}
