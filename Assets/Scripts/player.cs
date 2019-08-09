using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    private int count;
    private int countcoin;

    public SpriteRenderer sr;

    public float speed = 15f;

    public float mapwidth = 5f;

    private Rigidbody2D rb;

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    private BlockSpawner SpawnsBlocks;

    public Text countText;
    public Text countCoin;
    //--SPAWNBOOST
    public GameObject booster;
    Vector2 boostposition = new Vector2(0, 16);
    //------------
    void Start ()
    {
        SetCountCoin();
        countcoin = 0;

        SetCountText();
        SetRandomColor();
        rb = GetComponent<Rigidbody2D>();
        count = 0;
    }

	void FixedUpdate()
    {
        if (Input.touchCount == 1)
        {
            var touch = Input.touches[0];
            if (touch.position.x < Screen.width / 2)
            {
                rb.AddForce(new Vector2(-5f, 0) * Time.fixedDeltaTime * speed, ForceMode2D.Impulse);
            }
            else if (touch.position.x > Screen.width / 2)
            {
                rb.AddForce(new Vector2(5f, 0) * Time.fixedDeltaTime * speed, ForceMode2D.Impulse);
            }
        }
        if (Input.touchCount == 0)
        {
            rb.velocity = Vector2.zero;
        }
        if (Input.touchCount == 2)
        {
            rb.velocity = Vector2.zero;
        }

        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapwidth, mapwidth);

        rb.MovePosition(newPosition);

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        //-RespawnBoost-//
        StartCoroutine("RespawnBoost");


        if (col.tag == "Coin")
        {
            countcoin = countcoin + 1;
            SetCountCoin();
            Destroy(col.gameObject);
            return;
        }

        if (col.tag == "Boost")
        {
            booster.SetActive(false);
            return;
           // Destroy(col.gameObject);
           // return;
        }

        if (col.tag == "Pick Up")
        {
            count = count + 1;
            SetCountText();
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if(col.tag != currentColor)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    int nextSpawn = 25;
    //-RESPAWNBOOST-//
    IEnumerator RespawnBoost()
    {
        if (countcoin == nextSpawn)
        {
            nextSpawn += 25;
            Destroy(booster);
            booster.SetActive(true);
            booster = (GameObject)Instantiate(booster, boostposition, Quaternion.identity);
            yield return null;

            booster.GetComponent<Boost>().enabled = true;
            booster.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    //    void OnCollisionEnter2D()
    //    {
    //        FindObjectOfType<GameManager>().EndGame();
    //    }
    //
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString ();
    }

    void SetCountCoin()
    {
        countCoin.text = "Coins: " + countcoin.ToString();
    }
}
