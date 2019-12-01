using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	[SerializeField]
	private TextMesh textMesh;

	[SerializeField]
	private string characterName;

	public string CharacterName { get => characterName; }

#if UNITY_EDITOR
	private void OnValidate()
	{
		if (textMesh != null)
		{
			textMesh.text = characterName;
		}
	}
#endif
}
