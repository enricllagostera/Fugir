using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class Portao : MonoBehaviour
{
	public bool aberto;

	// Use this for initialization
	void Awake ()
	{
		MessageKit.addObserver (Eventos.VitoriaFase, Abrir);
		aberto = false;
	}

	// Update is called once per frame
	void Abrir ()
	{
		//GetComponent<SpriteRenderer>().color = Color.green;
		GetComponent<Animator>().SetTrigger("AbrirPortao");
		aberto = true;
	}

	void OnTriggerEnter2D (Collider2D outro) {
		if (outro.CompareTag ("Player") && aberto) {
			Application.LoadLevel (Application.loadedLevel);
		}
	}

	void OnDestroy () {
		MessageKit.removeObserver (Eventos.VitoriaFase, Abrir);
	}
}

