using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
	[SerializeField]
	private ButtonSet[] buttonSets;

	[System.Serializable]
	public struct ButtonSet
	{
		public Button button;
		public Text text;
	}


}
