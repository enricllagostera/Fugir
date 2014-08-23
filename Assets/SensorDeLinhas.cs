using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SensorDeLinhas : MonoBehaviour {

	private List<Transform> _inimigos;
	public List<Linha> linhas;
	public Linha prefabLinha;
	
	void Start () {
		AtualizarInimigos ();
	}

	void Update () {
		// lima linha
		/*
		for (int i = 0; i < _inimigos.Count; i++) {
			Vector3 origem = _inimigos[i].position;
			foreach (var outro in _inimigos) {
				if(outro != _inimigos[i]){
					Debug.DrawLine (origem, outro.position, Color.cyan);
					if (Physics2D.Linecast(origem, outro.position, 1 << LayerMask.NameToLayer("Jogador")) && !cruzando) {
						print ("cruzou");
					}
				}
			}
		}
		*/
	}

	void AtualizarInimigos () {
		linhas.ForEach (linha => Destroy (linha.gameObject));
		_inimigos = new List<Transform>();
		foreach (GameObject inimigo in GameObject.FindGameObjectsWithTag ("Inimigo")) {
			_inimigos.Add (inimigo.transform);
		}
		// int nroLinhas = Mathf.FloorToInt( ((_inimigos.Count * _inimigos.Count) + _inimigos.Count) / 2 );
		for (int j = 0; j < _inimigos.Count; j++) {
			Transform origem = _inimigos[j];
			foreach (var outro in _inimigos) {
				if (outro != _inimigos[j] && !ContemLinha(origem, outro)) {
					Linha nova = Instantiate (prefabLinha) as Linha;
					nova.inicio = origem;
					nova.fim = outro;
					nova.transform.parent = transform;
					linhas.Add (nova);
				}
			}
		}
	}

	bool ContemLinha (Transform inicio, Transform fim) {
		bool res = false;
		linhas.ForEach (linha => {
			if ((inicio == linha.inicio && fim == linha.fim) ||
			    (fim == linha.inicio && inicio == linha.fim)) {
				res = true;
			}
		});
		return res;
	}

}
