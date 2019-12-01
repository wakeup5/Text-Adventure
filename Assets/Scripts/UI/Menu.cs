using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
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

	public event UnityAction<int> OnSelected;

	private void Awake()
	{
		Active(new string[0]);

		for (int i = 0; i < buttonSets.Length; i++)
		{
			int index = i;
			buttonSets[i].button.onClick.AddListener(() =>
			{
				OnSelected?.Invoke(index);
			});
		}
	}
 
	public void Active(string[] choices)
	{
		for (int i = 0; i < buttonSets.Length; i++)
		{
			ButtonSet set = buttonSets[i];

			if (i < choices.Length)
			{
				set.button.gameObject.SetActive(true);
				set.text.text = "▶ " + choices[i];
			}
			else
			{
				set.button.gameObject.SetActive(false);
			}
		}
	}

	public void Hide()
	{
		Active(new string[0]);
	}
}