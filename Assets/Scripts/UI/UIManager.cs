using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]
	private Speech topSpeech;

	[SerializeField]
	private Speech bottomSpeech;

	[SerializeField]
	private Menu menu;

	private void Awake()
	{
		menu.OnSelected += OnMenuSelected;

		menu.Hide();
		topSpeech.Hide();
		bottomSpeech.Hide();
	}

	private void Start()
	{
		//menu.Active(new Choice[2] {
		//	new Choice() { text = "길을 막아선다.", action = null },
		//	new Choice() { text = "그대로 사라진다.", action = null }
		//});
	}

	private void OnDestroy()
	{
		menu.OnSelected -= OnMenuSelected;	
	}

	private void OnMenuSelected(int i)
	{

	}
}
