using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMovement : MonoBehaviour
{
    Rigidbody2D berenjenoRB;
    public float maxVelocidad;
    Animator berenjenoAnim;
    // Voltear EL Berenjeno

	bool die = false;
	float counter = 0f;
    bool puedoMover = true;
    bool enSuelo = true;
    float checkRadioGround = 0.2f;
    public LayerMask capaGround;
    public Transform checkGround;
    public float jumpPower;
	public Transform bulletSpawner;
	public GameObject bulletPrefab;

    bool voltearBerenjeno = true;
    SpriteRenderer berenjenoRender;
    // Start is called before the first frame update
    void Start()
    {
        berenjenoRB = GetComponent<Rigidbody2D> ();
        berenjenoRender = GetComponent<SpriteRenderer> ();
        berenjenoAnim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (!die)
		{
			bool puedoMover = true;
			PlayerShooting();

			/* Debug.Log(puedoMover);
			Debug.Log(enSuelo);
			Debug.Log(Input.GetAxis("Jump"));*/
			if (puedoMover && enSuelo && Input.GetAxis("Jump") > 0)
			{
				berenjenoAnim.SetBool ("is_in_ground", false);
				berenjenoRB.velocity = new Vector2(berenjenoRB.velocity.x, 0f);
				berenjenoRB.AddForce (new Vector2 (0, jumpPower),ForceMode2D.Impulse);
				enSuelo = false;
			}
			enSuelo = Physics2D.OverlapCircle (checkGround.position, checkRadioGround, capaGround);
			berenjenoAnim.SetBool("is_in_ground", enSuelo);

			float movemment = Input.GetAxis ("Horizontal");
			if (puedoMover)
			{
				if (movemment > 0 && !voltearBerenjeno)
				{
					berenjenoAnim.SetFloat("VelMovimiento", Mathf.Abs(movemment));
					Voltear ();
				}
				else if (movemment < 0 && voltearBerenjeno)
				{
					berenjenoAnim.SetFloat("VelMovimiento", Mathf.Abs(movemment));
					Voltear ();
				}
				berenjenoAnim.SetFloat("VelMovimiento", Mathf.Abs(movemment));
				//correr
				berenjenoRB.velocity = new Vector2 (movemment * maxVelocidad, berenjenoRB.velocity.y);
			}
			else
			{
				berenjenoRB.velocity = new Vector2 (0, berenjenoRB.velocity.y);
				berenjenoAnim.SetFloat("VelMovimiento", 0);
			}
		}
		else
			{

				counter++;
				if (counter == 1f)
				{
					berenjenoAnim.SetBool ("is_deleted", true);
				}
				else if (counter == 150f)
				{
					Destroy(this.gameObject);
					//cambio de escena
					SceneManager.LoadScene("Scene Prueba");
				}
				StartCoroutine ("Esperar");

			}
    }

    void Voltear ()
    {
        voltearBerenjeno = !voltearBerenjeno;
        transform.Rotate(0f,180f,0f);
    }

    public void togglePuedeMover()
    {
        puedoMover = !puedoMover;
    }

	public void PlayerShooting()
	{
		if (Input.GetButtonDown("Fire1"))
		{
			Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
		} 
	} 

	IEnumerator Esperar ()
	{
		Debug.Log("estoy esperando 3 segundos");
		yield return new WaitForSeconds(3);
	}

	void OnCollisionEnter2D(Collision2D other)
    {
		if (other.gameObject.tag == "Limits")
		{
			berenjenoAnim.SetBool("is_died", enSuelo);
			die = true;
		}
	}
}
 