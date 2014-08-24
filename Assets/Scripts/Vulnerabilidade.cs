using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class Vulnerabilidade : MonoBehaviour {

	public string tagInimigo;
	
	void OnCollisionEnter2D (Collision2D colisao) {
		if (colisao.collider.CompareTag (tagInimigo)){
			MessageKit.post (Eventos.DerrotaFase);
			Destroy (gameObject);
		}
	}
}
