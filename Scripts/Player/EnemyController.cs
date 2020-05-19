using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Text EnemyScore;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyScore.text = score.ToString();
    }

    public void SetPosx(float pos_x)
    {
        transform.position = new Vector2(pos_x, transform.position.y);
    }

    public void IncreaseScore()
    {
        score++;
    }
}
