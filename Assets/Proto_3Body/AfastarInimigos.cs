using UnityEngine;
using System.Collections;

public class AfastarInimigos : MonoBehaviour {

	public float forcaAfastamento;

	void OnCollisionEnter2D (Collision2D colisao) {
		if (colisao.gameObject.CompareTag ("Inimigo")) {
			Vector2 afastar = transform.position - colisao.transform.position;
			afastar = afastar.normalized * forcaAfastamento;
			rigidbody2D.AddForce (afastar, ForceMode2D.Impulse);
			Debug.DrawRay (transform.position, afastar, Color.green);
		}
	}
}
