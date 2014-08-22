using UnityEngine;
using System.Collections;

public class ControlarInimigo : MonoBehaviour {

	private Motor _motor;
	public Transform alvo;
	private Vector2 _direcao;

	// Use this for initialization
	void Start () {
		_motor = GetComponent<Motor> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (alvo != null) {
			_direcao = alvo.position - transform.position;

		}
		else {
			_direcao = Vector3.zero;
			// FIXME reiniciar quando perder
			if (Input.GetKeyDown(KeyCode.Escape)) {
				Application.LoadLevel(Application.loadedLevel);
			}
		}
		_motor.direcao = _direcao;
	}
}
