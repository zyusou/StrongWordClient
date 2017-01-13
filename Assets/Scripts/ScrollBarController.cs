using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarController : MonoBehaviour {

	private Scrollbar _scrollbar;

	// Use this for initialization
	void Start () {
		_scrollbar = GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {
		_scrollbar.value = 0;
	}


}
