using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
	public string Scene;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene (Scene);
        }
        if (other.tag == "Finish")
        {
            SceneManager.LoadScene (Scene);
        }
    }
}
