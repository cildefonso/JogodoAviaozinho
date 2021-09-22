using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveFundo : MonoBehaviour
{
    float larguraTela;
   // public Text txtLarguraTela;
   // public Text txtAlturaTela;
    // Start is called before the first frame update
    void Start()    {
		
		//Esse objeto é a renderização da tela
		SpriteRenderer grafico = GetComponent<SpriteRenderer>();

		float larguraImagem = grafico.sprite.bounds.size.x;
		//Irá retornar o tamanho da tela.
		float alturaImagem = grafico.sprite.bounds.size.y;
		float alturaTela = Camera.main.orthographicSize*2f;
		larguraTela = alturaTela/Screen.height*Screen.width;
		//print(alturaTela);  
		//The current height of the screen window in pixels
		Vector2 novaEscala = transform.localScale;
		novaEscala.x = larguraTela / larguraImagem + 0.25f; 
		novaEscala.y = alturaTela / alturaImagem;
		this.transform.localScale = novaEscala;

		if (this.name == "imagemFundo2") {
			transform.position = new Vector2(larguraTela, 0f);
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2(-3,0);


    }

    // Update is called once per frame
    void Update(){
		//txtLarguraTela.text= transform.position.x.ToString();
		//txtAlturaTela.text = larguraTela.ToString();
			
        if(transform.position.x <= -larguraTela){
	    transform.position = new Vector2(larguraTela,0f); 
	}  
    }
		
}
