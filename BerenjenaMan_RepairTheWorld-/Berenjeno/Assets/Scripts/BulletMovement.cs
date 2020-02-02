using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
	private Rigidbody2D bulletRB;
	public int damage = 20;
 	public float velocidad = 10.0f;
	private Enemy enemy;

	void Awake()
	{
		bulletRB = GetComponent<Rigidbody2D>();
	}
    // Start is called before the first frame update
    void Start()
    {
       // bulletRB.velocity = new Vector(bulletSpeed, bulletRB.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocidad * Time.deltaTime,0,0);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
		//Debug.Log(other);
        
		if (other.gameObject.tag == "Enemy")
		{
			Debug.Log(other);
			other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
			//Debug.Log(damage);
        	Destroy(this.gameObject);
		}
		else if(other.gameObject.tag == "Ground")
		{
			Destroy(this.gameObject);
		}
		else if (other.gameObject.tag == "Limits")
		{
			Destroy(this.gameObject);
		}

    }
}
