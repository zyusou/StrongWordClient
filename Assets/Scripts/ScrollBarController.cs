using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarController : MonoBehaviour {

	private Scrollbar _scrollBar;

	// Use this for initialization
	void Start () {
		_scrollBar = GetComponent<Scrollbar>();
	}
	
	// Update is called once per frame
	void Update () {
		_scrollBar.value = 0;
	}
}
