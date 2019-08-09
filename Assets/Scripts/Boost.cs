using UnityEngine;

public class Boost : MonoBehaviour {

    public GameObject BlockSpawners;
    public GameObject CoinSpawner;
    public GameObject ColorChangeSpawnerBoost;
    public GameObject CoinRandom;
    public GameObject ColorChangerSpawner;

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.tag == "Player")
        {
            BlockSpawners.SetActive(false);
            CoinSpawner.SetActive(true);
            ColorChangeSpawnerBoost.SetActive(true);
            CoinRandom.SetActive(false);
            ColorChangerSpawner.SetActive(false);
        }
    }

    void Update()
    {
        //if (transform.position.y < -2f)
        {
          //  Destroy(gameObject);
        }
    }
}
