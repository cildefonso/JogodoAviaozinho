using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class controlaJogador : MonoBehaviour {

	public static controlaJogador instance;

	private bool filled;
    	private bool comecouJogo;
    	private bool acabouJogo; 
   	 Rigidbody2D corpoJogador;
    	Vector2 forcaImpulso = new Vector2(0, 500f); 

    	public GameObject particulaPena;
    	GameObject gameEngine;
    	int intNuPontos;


    	GameObject gameSound;
    	public AudioClip somVoa;
    	public AudioClip somHit;
    	public AudioClip somScore;

	//public string nome = ""; 
	public Button btnRegister;
	public InputField nome;
	public InputField phone;
	public InputField email;
	public Text resultInsert;
	public Text txtScore;
	public Text txtMensagem;
	public GameObject objName;
	public GameObject objPhone;
	public GameObject objEmail;
	public GameObject objRegister;
	public int life = 0;

	public int Life{
		get {
			return life;
		}
	}


    void Start()  {
	Debug.Log("Start"+filled.ToString());
        gameEngine = GameObject.FindGameObjectWithTag("MainCamera");
        corpoJogador = GetComponent<Rigidbody2D>();
	txtMensagem.transform.position = new Vector2(Screen.width/2,Screen.height - 250);  
	txtMensagem.text = "Cadastre suas informações!";
	txtMensagem.fontSize = 40;
	if (instance == null){
	   instance = this;
	   DontDestroyOnLoad(gameEngine);
	}
	else if (instance != this){
		Destroy(gameEngine);
	}
    }

    // Update is called once per frame
    void Update()    {
		if (filled){
		        if (!acabouJogo){
			   	if(Input.GetButtonDown("Fire1")){ 
			       	    if(!comecouJogo){
				          comecouJogo = true;
				          corpoJogador.isKinematic = false;
					  txtMensagem.gameObject.SetActive(!txtMensagem.gameObject.activeInHierarchy);
				          gameEngine.SendMessage("comecouJogo");
		                  	  //GetComponent<Rigidbody2D>().isKinematic = false;
			   	    }
			   	    corpoJogador.velocity = new Vector2(0,0);
			   	    corpoJogador.AddForce(forcaImpulso);
				    GameObject peninhas = Instantiate(particulaPena);
			   	    Vector3 posicaoFelpudo = this.transform.position + new Vector3(0,1,0);
			   	    peninhas.transform.position = posicaoFelpudo;
		                    //gameSound.GetComponent<AudioSource>().PlayOneShot(somVoa);
				}
		        	float alturaFelpudoEmPixels = Camera.main.WorldToScreenPoint(transform.position).y;
				if (alturaFelpudoEmPixels > Screen.height || alturaFelpudoEmPixels < 0){
		           	   	//Destroy(this.gameObject);
					GetComponent<Collider2D>().enabled = false;
		            		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			    		GetComponent<Rigidbody2D>().AddForce(new Vector2(-300,0));
			    		GetComponent<Rigidbody2D>().AddTorque(300f);
			    		GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.35f, 0.35f);
				        FimDeJogo();
					//gameSound.GetComponent<AudioSource>().PlayOneShot(somHit);
			       }
			       transform.rotation = Quaternion.Euler(0,0,corpoJogador.velocity.y*3);
		      }
		}
		else {
			btnRegister.onClick = new Button.ButtonClickedEvent();
			btnRegister.onClick.AddListener(() => Registration(nome, phone, email, resultInsert));
		}
    }

    void OnCollisionEnter2D(){
         Debug.Log("test");
         if (!acabouJogo){
	    acabouJogo = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	    GetComponent<Rigidbody2D>().AddForce(new Vector2(-300,0));
	    GetComponent<Rigidbody2D>().AddTorque(300f);
	    GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.75f, 0.75f);
	    FimDeJogo();
            //gameSound.GetComponent<AudioSource>().PlayOneShot(somHit);
    
	}
    }    

    void MarcaPontos(){
         intNuPontos++;
	 txtScore.text = intNuPontos.ToString();
         //gameSound.GetComponent<AudioSource>().PlayOneShot(somScore);
    }

    void FimDeJogo(){
		
        gameEngine.SendMessage("acabouJogo");
        Invoke("RecarregarCena",2);

    }
    
    void RecarregarCena(){
        //Application.LoadLevel("SampleScene");
	int? intNuScore = Convert.ToInt32(txtScore.text);
	if (intNuScore == 0){
		txtScore.text = string.Format("Pontos: {0}", controlaJogador.instance.Life);
	}
	else if (intNuPontos > intNuScore ){
		txtScore.text = intNuPontos.ToString();
	}
	SceneManager.LoadScene("SampleScene");
    }


	public void Registration(InputField value1, InputField value2, InputField value3, Text resultInsert){
		//float _valor1= float.Parse(value1.text);
		Debug.Log("Registration");
		Debug.Log("Registration"+value1.text);
		resultInsert.text = value1.text;
		txtMensagem.text = "Toque para iniciar....!";
		txtScore.text = intNuPontos.ToString();
		txtScore.fontSize = 60;  
		filled = true;
		objName.gameObject.SetActive(!objName.gameObject.activeInHierarchy);
		objPhone.gameObject.SetActive(!objPhone.gameObject.activeInHierarchy);
		objEmail.gameObject.SetActive(!objEmail.gameObject.activeInHierarchy);
		objRegister.gameObject.SetActive(!objRegister.gameObject.activeInHierarchy);

	}



	/**
		string[] values = { "One", "1.34e28", "-26.87", "-18", "-6.00", " 0", "137", "1601.9", Int32.MaxValue.ToString() };
		int result;
		foreach (string value in values) {
			try {
				result = Convert.ToInt32(value);
				Console.WriteLine("Converted the {0} value '{1}' to the {2} value {3}.",
					value.GetType().Name, value, result.GetType().Name, result);
			}
			catch (OverflowException) {
				Console.WriteLine("{0} is outside the range of the Int32 type.", value);
			}
			catch (FormatException) {
				Console.WriteLine("The {0} value '{1}' is not in a recognizable format.",
					value.GetType().Name, value);
			}
		}
		**/

	/**void OnGUI(){
		GUI.Label(new Rect(10,10,200,20),nome);
		nome = GUI.TextField(new Rect(10,40,200,20), nome, 30);

	}
	**/
	//
	// private Rigidbody rb;
	// void Start() {
	//   rb = GetComponent<Rigidbody>();
	//}
	// void Update () {
	//Criar um Raycat
	//Objetivo do Raycast e deslocar o objeto para um direção, posição e distãncia.
	//RaycastHit objeto;
	// envia o objeto para frente ==>  transform.forward
	// envia o objeto para baixo ==>  -transform.up
	//if (Physics.Raycast(transform.position, transform.forward, out objeto, 20)){
	//   Quando ele encontrar o bjeto na distância programada vai desenhra uma lina
	//   esta linha só apresentada em tempo de desenvolvimento.
	//   Debug.DrawLine(transform.position, objeto.point);
	//   Através da declaração do "objeto.transform.gameObject" é possível
	//   acessar as propriedades para manipular o objeto.
	//   Quando colidir com o objeto vai desativar.
	//   objeto.transform.gameObject.SetActive(false);
	//   Quando ele colidir chamar a propriedade AddForce para empurar para cima
	//   rb.AddForce(transform.up * 100f)
	//   Debug.Log(objeto.transform.name);
	//   }
	//}
}
