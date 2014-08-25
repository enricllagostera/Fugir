using UnityEngine;
using System.Collections;

public class Motor : MonoBehaviour {

	public float velocidadeTranslacao;
	public float suavizacaoRotacao;
	private Vector3 _direcao;
	public Vector3 direcao {
		get {return _direcao.normalized; }
		set	{ _direcao = value.normalized; }
	}
	private float _velRotacao;

	public float anguloAlvo;
	public float novoAngulo;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (_direcao != Vector3.zero) {
			// Vector2 novaPosicao = transform.position + _direcao * velocidadeTranslacao * Time.fixedDeltaTime;
			transform.right = Vector3.Lerp (transform.right, _direcao, Time.fixedDeltaTime * suavizacaoRotacao);
			rigidbody2D.AddForce (_direcao * velocidadeTranslacao * rigidbody2D.mass * Time.fixedDeltaTime, ForceMode2D.Impulse);
		}

		Debug.DrawRay(transform.position, transform.right, Color.red);
	}
}
