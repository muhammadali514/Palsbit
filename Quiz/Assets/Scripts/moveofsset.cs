using UnityEngine;
using System.Collections;

public class moveofsset : MonoBehaviour {

	private Material material;
	public float velocity;
	private float offset;

	// Use this for initialization
	void Start () {
		material = GetComponent<Renderer> ().material;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		offset += 0.001f;

		material.SetTextureOffset("_MainTex", new Vector2(offset * velocity, 0));
	
	}
}
