using UnityEngine;
using System.Collections;

public class EscondeInativo : MonoBehaviour {

	private SpriteRenderer _sprite;
	void Start () {
		_sprite = GetComponent<SpriteRenderer>();
	}

	void Update () {
		Vector2 dir = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (dir != Vector2.zero) {
			_sprite.enabled = true;
		}
		else {
			_sprite.enabled = false;
		}
	}
}
