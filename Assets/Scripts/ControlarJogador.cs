using UnityEngine;
using System.Collections;

public class ControlarJogador : MonoBehaviour {
	public static bool comecou;
	private Motor _motor;
	private Vector2 _entrada;

	void Start () {
		_motor = GetComponent<Motor> ();
		comecou = false;
	}

	// Update is called once per frame
	void Update () {
		_entrada = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis("Vertical"));
		if(comecou) {
			_motor.direcao = _entrada;
		}
		else if (_entrada != Vector2.zero) {
			comecou = true;
		}


		
		// FIXME sair do jogo
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
	}
}
