using UnityEngine;
using System.Collections;
using UnityEditor;
using System.IO;
using System.Text;

/// <summary>
/// Classe for changing multiple selected files in Project view from tabs to spaces 
/// </summary>
public class ChangeTabToSpace
{
	const int spacesPerTab = 4;
	static string spaces = new string (' ', spacesPerTab);
	
	[MenuItem ("Assets/TabToSpace")]
	/// <summary>
	/// Converts assets selected in project view from tabs to spaces
	/// </summary>
	static void TabToSpace ()
	{
		foreach ( Object obj in Selection.objects)
		{
			//UnityEngine.Object  obj = objs[i] as UnityEngine.Object;
			string assetPath = AssetDatabase.GetAssetPath(obj);
			if (assetPath.Length >0)
			{
				// make sure we operate on actual file assets, not on game objects in the scene window
				string fullPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + assetPath;
				Debug.Log (string.Format("Changing tabs to {0} spaces for {1}", spacesPerTab, fullPath));	
				ConvertOneFile(fullPath);
			}
		}
	}
	
	/// <summary>
	/// Converts the tabs in one file to spaces
	/// </summary>
	/// <param name='fullPath'>
	/// Full path.
	/// </param>
	static void ConvertOneFile( string fullPath)
	{
		string allText = File.ReadAllText(fullPath);
		StringBuilder sb = new StringBuilder(allText);
		sb.Replace("\t", spaces);
		File.WriteAllText(fullPath, sb.ToString());
	}
}
