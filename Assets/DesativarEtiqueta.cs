using UnityEngine;
using System.Collections;
using Prime31.MessageKit;

public class DesativarEtiqueta : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<TextMesh>().text = Linha.totalCruzamento.ToString();
		MessageKit.addObserver(Eventos.CruzouLinha, TrocarValor);
		MessageKit.addObserver(Eventos.VitoriaFase, Abrir);
	}

	void Abrir () {
		gameObject.SetActive(false);
	}
	
	void TrocarValor () {
		GetComponent<TextMesh>().text = (Linha.totalCruzamento - Linha.contagemCruzamento).ToString();
	}

	void OnDestroy () {
		MessageKit.clearMessageTable();
	}
}
