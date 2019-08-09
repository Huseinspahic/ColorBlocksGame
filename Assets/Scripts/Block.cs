using System.Collections;
using UnityEngine;

public class Block : MonoBehaviour {

	void Update()
    {
        if (transform.position.y < -4f)
        {
            Destroy(gameObject);
        }
    }
}
