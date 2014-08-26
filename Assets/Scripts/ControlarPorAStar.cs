using UnityEngine;
using System.Collections;
using Pathfinding;

public class ControlarPorAStar : MonoBehaviour {

	public Transform alvo;
	private Seeker _seeker;
	private Path _path;
	public int pontoAtual;
	[Range (0, 5)] public float intervalo = 0.5f;
	public float tolerancia = 2;
	private Motor _motor;

	void Start () {
		_seeker = GetComponent<Seeker>();
		StartCoroutine ("AtualizarAlvo");
		_motor = GetComponent<Motor>();
	}

	IEnumerator AtualizarAlvo () {
		while (enabled && alvo != null) {
			_seeker.StartPath (transform.position, alvo.position, CalculouCaminho);
			yield return new WaitForSeconds (intervalo);
		}
	}

	public void CalculouCaminho (Path p) {
		Debug.Log ("Caminho calculado. Erros? "+p.error);
		if (!p.error) {
			_path = p;
			pontoAtual = 0;
		}
	}

	void Update () {
		if(ControlarJogador.comecou) {

			transform.right = rigidbody2D.velocity;

			if (alvo == null) {
				// FIXME reiniciar quando perder
				if (Input.GetKeyDown(KeyCode.Space)) {
					Application.LoadLevel(Application.loadedLevel);
				}
			}

			if (_path == null) {
				//We have no path to move after yet
				print ("espera");
				return;
			}
			
			if (pontoAtual >= _path.vectorPath.Count) {
				Debug.Log ("Fim do caminho");
				return;
			}
			
			//Direction to the next waypoint
			Vector3 dir = (_path.vectorPath[pontoAtual]-transform.position).normalized;
			_motor.direcao = dir;
			
			//Check if we are close enough to the next waypoint
			//If we are, proceed to follow the next waypoint
			if (Vector3.Distance (transform.position, _path.vectorPath[pontoAtual]) < tolerancia) {
				pontoAtual++;
				return;
			}
		}

	}
}
