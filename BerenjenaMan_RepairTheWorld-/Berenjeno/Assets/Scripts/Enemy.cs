using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
	public GameObject deathEffect;
	Animator enemyAnim;

	void Start()
    {
        //enemyRender = GetComponent<SpriteRenderer> ();
        enemyAnim = GetComponent<Animator> ();
    }


	public void TakeDamage (int damage)
	{
		health -= damage;
		Debug.Log(health);
		if (health <= 0)
		{	
			//Die();
			Destroy(this.gameObject);
		}
	}

	public void Die ()
	{

		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		enemyAnim.SetBool("is_died", true);
		Destroy(this.gameObject);
		enemyAnim.SetBool("is_deleted", true);
	}
}
