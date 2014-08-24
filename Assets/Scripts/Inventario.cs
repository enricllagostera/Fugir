using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Controla um encaixe capaz de soltar itens e depois se regenerar em um intervalo de tempo
/// </summary>
[System.Serializable]
public class Encaixe {
	public string botao;
	public bool disponivel;
	public float intervalo;
	public float contadorIntervalo;
	public Item item;
	
	public void Reiniciar () {
		contadorIntervalo = 0;
		disponivel = false;
	}

	public void Atualizar () {
		contadorIntervalo += Time.deltaTime;
		if (contadorIntervalo > intervalo && !disponivel) {
			disponivel = true;
		}
	}

	public void Ativar (Vector3 posicao) {
		if (disponivel) {
			GameObject.Instantiate (item.transform, posicao, Quaternion.identity);
			Reiniciar ();
		}
		else {
			//Debug.Log (item.name + " nao esta disponivel");
		}
	}
}

#region Inventario
/// <summary>
/// Lista dinamica de encaixes ativados por botoes definidos no InputManager.
/// </summary>
public class Inventario : MonoBehaviour {

	public List<Encaixe> encaixes;

	void Start () {
		encaixes.ForEach (encaixe => {
			encaixe.Reiniciar ();
		});
	}
	
	void Update () {
		encaixes.ForEach (encaixe => {
			if (Input.GetButtonDown (encaixe.botao)) {
				encaixe.Ativar (transform.position);
			}
			encaixe.Atualizar ();
		});
	}
}

#endregion
