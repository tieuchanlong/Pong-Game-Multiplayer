using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluckController : MonoBehaviour
{
    Vector2 direction = new Vector3(-1.0f, -1.0f);
    [SerializeField] private float speed;
    private float standardSpeed;
    [SerializeField] private GameObject SpawnPoint;
    [SerializeField] private Text WaitForConnection;
    private PlayerScoreControl player;
    private EnemyController enemy;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = SpawnPoint.transform.position;
        standardSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerScoreControl>();

            if (player == null)
                speed = 0;
            else
                speed = standardSpeed;
        }

        if (enemy == null)
        {
            enemy = FindObjectOfType<EnemyController>();

            if (enemy == null)
                speed = 0;
            else
                speed = standardSpeed;
        }

        PlayerScoreControl[] scores = FindObjectsOfType<PlayerScoreControl>();

        if (scores.Length < 2)
        {
            speed = 0;
            WaitForConnection.gameObject.SetActive(true);
        }
        else
        {
            speed = standardSpeed;
            WaitForConnection.gameObject.SetActive(false);
        }

        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
            direction = new Vector2(-direction.x, direction.y);

        if (collision.gameObject.CompareTag("Player"))
            direction = new Vector2(direction.x, -direction.y);

        speed += 0.1f;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyGoal"))
        {
            transform.position = SpawnPoint.transform.position;
            speed = standardSpeed;
            player.IncreaseScore();
        }

        if (collision.gameObject.CompareTag("PlayerGoal"))
        {
            transform.position = SpawnPoint.transform.position;
            speed = standardSpeed;
            enemy.IncreaseScore();
        }
    }
}
