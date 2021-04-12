//
//  TrackEditor.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2017 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Beats
{
	/// <summary>
	/// Track Data Model Custom Inspector.
	/// </summary>
	[CustomEditor (typeof (Track))]
	public class TrackEditor : Editor
	{
		private Track track;

		private Vector2 _beatsDataScrollViewPosition;
		private bool _displayBeatsData;

		private void OnEnable ()
		{
			track = (Track) target;
		}

		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();

			// ERRATUM : initializing the list in the Track prevents error when creating a new track with custom inspector
//			if (track.beats == null)
//				return;

			if (track.beats.Count == 0)
			{
				EditorGUILayout.HelpBox ("Empty Track", MessageType.Info);

				if (GUILayout.Button ("Generate Random Track", EditorStyles.miniButton))
					track.Randomize ();
			}
			else
			{
				if (GUILayout.Button ("Update Random Track", EditorStyles.miniButton))
					track.Randomize ();

				_displayBeatsData = EditorGUILayout.Foldout(_displayBeatsData, "Display Beats");

				if (_displayBeatsData)
				{
					_beatsDataScrollViewPosition = EditorGUILayout.BeginScrollView (_beatsDataScrollViewPosition);
					
					for (int i = 0 ; i < track.beats.Count ; i++)
					{
						track.beats[i] = EditorGUILayout.IntSlider (track.beats[i], -1, Track.inputs-1);
					}
					
					EditorGUILayout.EndScrollView ();
				}
			}

			EditorUtility.SetDirty (track); // mark the track object "dirty" so that the editor saves it on project save
		}
	}
}