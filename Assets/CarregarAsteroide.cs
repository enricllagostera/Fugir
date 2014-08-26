using UnityEngine;
using System.Collections;

public class CarregarAsteroide : MonoBehaviour {

	public Sprite[] sprites;
	PolygonCollider2D _collider;

	void Start () {
		GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
		_collider = gameObject.AddComponent<PolygonCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
