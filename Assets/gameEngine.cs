using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameEngine : MonoBehaviour
{
    public GameObject inimigo;

    void comecouJogo()
    {
        InvokeRepeating("CriaInimigo",1.0f,1.5f);
    }

    void acabouJogo()
    {
        CancelInvoke("CriaInimigo");
    }

    void CriaInimigo() {
	float alturaAleatoria = 10.0f * Random.value -5;
	GameObject novoInimigo = Instantiate(inimigo);
	novoInimigo.transform.position = new Vector2(15.0f, alturaAleatoria);
    }

}
