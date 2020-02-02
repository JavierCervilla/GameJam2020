using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float velocidad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            gameObject.transform.Translate(velocidad * -1 * Time.deltaTime, 0 , 0);
        }
        else if (Input.GetKey("right"))
            gameObject.transform.Translate(velocidad * Time.deltaTime, 0 , 0);
        else if (Input.GetKey("up"))
            gameObject.transform.Translate(0, velocidad * Time.deltaTime, 0) ;
        else if (Input.GetKey("down"))
            gameObject.transform.Translate(0, velocidad * -1 * Time.deltaTime , 0);              
    }
   
}

