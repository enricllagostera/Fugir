using UnityEngine;
using System.Collections;

public class ControlarJogador : MonoBehaviour {

	private Motor _motor;
	private Vector2 _entrada;

	void Start () {
		_motor = GetComponent<Motor> ();
	}

	// Update is called once per frame
	void Update () {
		_entrada = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis("Vertical"));
		_motor.direcao = _entrada;

		// FIXME sair do jogo
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
