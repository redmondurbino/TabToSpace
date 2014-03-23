/*
The MIT License (MIT)

Copyright (c) 2014 Redmond Urbino

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

// git repo at https://github.com/redmondurbino/TabToSpace
*/
		
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
