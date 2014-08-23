using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class Linha : MonoBehaviour
{
	public Transform inicio;
	public Transform fim;
	public bool cruzando;

	void Update () {
		transform.position = Vector3.Lerp (inicio.position, fim.position, 0.5f);
		transform.right = fim.position - inicio.position;
		transform.localScale = new Vector3 (Vector3.Distance (inicio.position, fim.position), 1, 1);
	}

	void OnTriggerEnter2D (Collider2D outro) {
		if (outro.CompareTag("Player")) {
			cruzando = true;
		}
	}

	void OnTriggerExit2D (Collider2D outro) {
		if (outro.CompareTag("Player")) {
			cruzando = false;
			MessageKit.post (Eventos.Cruzou);
		}
	}
}

