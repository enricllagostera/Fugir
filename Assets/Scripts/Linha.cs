using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class Linha : MonoBehaviour
{
	public static int contagemCruzamento = 0;
	public Transform inicio;
	public Transform fim;
	public bool cruzando;
	private Color cor;

	void Start () {
		contagemCruzamento = 0;
	}

	void Update () {
		transform.position = Vector3.Lerp (inicio.position, fim.position, 0.5f);
		transform.right = fim.position - inicio.position;
		transform.localScale = new Vector3 (Vector3.Distance (inicio.position, fim.position), 1, 1);
	}

	void OnTriggerEnter2D (Collider2D outro) {
		if (outro.CompareTag("Player")) {
			cruzando = true;
			cor = outro.GetComponent<SpriteRenderer>().color;
			outro.GetComponent<SpriteRenderer>().color = GetComponentInChildren<SpriteRenderer>().color;
		}
	}

	void OnTriggerExit2D (Collider2D outro) {
		if (outro.CompareTag("Player")) {
			cruzando = false;
			contagemCruzamento++;
			MessageKit.post (Eventos.Cruzou);
			outro.GetComponent<SpriteRenderer>().color = cor;
		}
	}
}

