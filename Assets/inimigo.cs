using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    GameObject jogadorFelpudo;
    bool marcouPonto;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-4,0);
    	jogadorFelpudo = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (transform.position.x < -25) {
	   Destroy(this.gameObject);
	}
        else {
	    if (transform.position.x < jogadorFelpudo.transform.position.x){
               if (!marcouPonto) {
		  Debug.Log("entrei");
		  marcouPonto = true;
		  GetComponent<Rigidbody2D>().velocity = new Vector2(-7.5f,5.0f);
		  GetComponent<Rigidbody2D>().isKinematic = false;
		  GetComponent<Rigidbody2D>().AddTorque(-50f);
		  GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.35f);

	          jogadorFelpudo.SendMessage("MarcaPontos");
	       }
            }
		




        }

    }
}
