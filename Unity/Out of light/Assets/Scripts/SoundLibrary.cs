using UnityEngine;
using System.Collections.Generic;

public class SoundLibrary : MonoBehaviour
{
	public SoundGroup[] soundGroups;

	Dictionary<string, AudioClip[]> groupDictionary = new Dictionary<string, AudioClip[]>();

	private void Awake()
	{
		foreach (SoundGroup sg in soundGroups)
			groupDictionary.Add(sg.groupName, sg.group);
	}

	public AudioClip GetSoundFromName(string name)
	{
		if (groupDictionary.ContainsKey(name))
		{
			AudioClip[] sounds = groupDictionary[name];
			return sounds[Random.Range(0, sounds.Length)];
		}
		return null;
	}

	[System.Serializable]
	public class SoundGroup
	{
		public string groupName;
		public AudioClip[] group;
	}
}