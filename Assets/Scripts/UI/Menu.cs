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
		Active(new Choice[0]);
	}

	public void Active(Choice[] choices)
	{
		for (int i = 0; i < buttonSets.Length; i++)
		{
			ButtonSet set = buttonSets[i];

			if (i < choices.Length)
			{
				Choice choice = choices[i];

				set.button.gameObject.SetActive(true);
				set.text.text = "▶ " + choice.text;

				int index = i;
				set.button.onClick.AddListener(() => 
				{
					choice.action?.Invoke();
					OnSelected?.Invoke(index);
					set.button.onClick.RemoveAllListeners();
				});
			}
			else
			{
				set.button.gameObject.SetActive(false);
				set.button.onClick.RemoveAllListeners();
			}
		}
	}

	public void Hide()
	{
		Active(new Choice[0]);
	}
}

[System.Serializable]
public struct Choice
{
	public string text;
	public UnityEvent action;
}
