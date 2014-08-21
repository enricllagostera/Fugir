using UnityEngine;
using System.Collections;

/// <summary>
/// Classe-base para todos os itens do jogo. Controla o ciclo de vida de um item.
/// </summary>
public abstract class Item : MonoBehaviour
{
	[Range (0, 60)]
	public float tempoDeVida;
	public float tempoAtivo;
	public bool destruirNoFim = true;

	// funcoes
	public abstract void Ligar ();
	public abstract void Executar ();
	public abstract void Desligar ();

	void Start () {
		tempoAtivo = 0;
		Ligar ();
	}

	void Update () {
		tempoAtivo += Time.deltaTime;
		if (tempoAtivo > tempoDeVida) {
			Desligar ();
			this.enabled = false;
			if (destruirNoFim) {
				Destroy (gameObject);
			}
		}
		else {
			Executar ();
		}
	}

	void OnEnable () {
		tempoAtivo = 0;
		Ligar ();
	}
}

