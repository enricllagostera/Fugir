using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Item capaz de aproximar ou repelir objetos agrupados por uma tag qualquer.
/// </summary>
public class CampoDeForca : Item
{
	[Range (0, 10)]
	public float raio;
	[Range (-1000, 1000)]
	public float forca;
	public string tagAlvo;

	private List<Transform> inimigos;

	override public void Ligar () {
		//print (gameObject.name + " ligado");
	}

	override public void Executar () {
		inimigos = new List<Transform>();
		foreach (GameObject inimigo in GameObject.FindGameObjectsWithTag (tagAlvo)) {
			inimigos.Add (inimigo.transform);
		}
		inimigos.ForEach (inimigo => {
			float distancia = Vector2.Distance (transform.position, inimigo.transform.position);
			float fatorDistancia = 1 - Mathf.Clamp (distancia, 0, raio) / raio;
			Vector2 direcao = transform.position - inimigo.transform.position;
			inimigo.rigidbody2D.AddForce (direcao.normalized * forca, ForceMode2D.Force);
			// Debug.DrawRay (inimigo.transform.position, direcao.normalized * Mathf.Sign(forca), Color.magenta);
		});
	}

	override public void Desligar () {
		// print (gameObject.name + " desligado");
	}
}

