using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_CustomerMasterData : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public int ID;
		public string characterName;
		public float time;
		public string smoothie;
		public string wrongTaste;
		public string wrongEffect;
		public string fast;
		public string soso;
		public string late;
		public int speed;
	}
}

