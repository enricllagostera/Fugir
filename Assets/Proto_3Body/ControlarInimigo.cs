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
		_direcao = alvo.position - transform.position;
		_motor.direcao = _direcao;
	}
}
