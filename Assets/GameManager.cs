using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject CoinSpawner;
    public GameObject ColorChangerSpawnerBoost;
    public GameObject CoinRandom;
    public GameObject BlockSpawner;
    public GameObject ColorChangerSpawner;
    public GameObject Boost1;

	public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
 
    void Update()
    {
      
        if (CoinSpawner.activeInHierarchy)
        {
            Invoke("CoinSpawnerOff", 2f);
        }

        if (ColorChangerSpawnerBoost.activeInHierarchy)
        {
            Invoke("ColorChangerSpawnerBoostOff", 2f);
        }

        if (CoinRandom.activeInHierarchy == false)
        {
            Invoke("CoinRandomOn", 3f);
        }

        if (BlockSpawner.activeInHierarchy == false)
        {
            Invoke("BlockSpawnerOn", 5f);
        }

        if (ColorChangerSpawner.activeInHierarchy == false)
        {
            Invoke("ColorChangerSpawnerOn", 2f);
        }
    }
   
    public void CoinSpawnerOff()
    {
        //Debug.Log("Deactivated CoinSpawner");
        CoinSpawner.SetActive(false);
    }

    public void ColorChangerSpawnerBoostOff()
    {
        //Debug.Log("Deactivated ColorChangerSpawner");
        ColorChangerSpawnerBoost.SetActive(false);
    }

    public void CoinRandomOn()
    {
        //Debug.Log("Activate CoinRandom");
        CoinRandom.SetActive(true);
    }

    public void BlockSpawnerOn()
    {
        //Debug.Log("Activate BlockSpawner");
        BlockSpawner.SetActive(true);
    }

    public void ColorChangerSpawnerOn()
    {
        //Debug.Log("Activate ColorChangerSpawner");
        ColorChangerSpawner.SetActive(true);
    }
}
