using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFactory : MonoBehaviour
{
    [SerializeField] private float spawn_delay;
    [SerializeField] private float Minx;
    [SerializeField] private float Maxx;
    [SerializeField] private float Minz;
    [SerializeField] private float Maxz;
    private float spawn_time = 0f;
    private GameObject coinPrefab;
    private GameObject currentCoin;

    // Start is called before the first frame update
    void Start()
    {
        coinPrefab = Resources.Load("Prefabs/Coin") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn_time == 0)
        {
            currentCoin = Instantiate(coinPrefab);
            currentCoin.transform.position = new Vector3(Random.Range(Minx, Maxx), coinPrefab.transform.position.y, Random.Range(Minz, Maxz));
        }

        spawn_time += Time.deltaTime;

        if (currentCoin == null)
            spawn_time = 0;
    }
}
