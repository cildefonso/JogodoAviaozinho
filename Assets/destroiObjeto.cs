using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroiObjeto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ApagaObjeto", 1f);
    }

    // Update is called once per frame
    void ApagaObjeto()
    {
        Destroy(this.gameObject, 1f);
    }
}
