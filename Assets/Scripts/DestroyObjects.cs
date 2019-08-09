using UnityEngine;

public class DestroyObjects : MonoBehaviour
{

    public GameObject Boost;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boost")
        {
            Boost.SetActive(false);
        }

        if (col.tag == "Coin")
        {
            Destroy(col.gameObject);
            return;
        }

        if (col.tag == "Pick Up")
        {
            Destroy(col.gameObject);
            return;
        }

        if (col.tag == "Mines")
        {
            Destroy(col.gameObject);
            return;
        }
    }
}
