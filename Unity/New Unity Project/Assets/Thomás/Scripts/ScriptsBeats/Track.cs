//
//  Track.cs
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

namespace Beats
{
	/// <summary>
	/// Track Data Model.
	/// </summary>
	[HelpURL ("http://unitycoach.ca/workshops/beats")]
	[CreateAssetMenu (menuName = "UnityCoach/Beats/New Track", fileName = "New Beats Track.asset")]
	public class Track : ScriptableObject
	{
		[Header ("Playback Settings")]
		[Tooltip ("# of beats per minute")]
		/// <summary>
		/// The # of Beats per Minute.
		/// </summary>
		[Range (30, 360)] public int bpm = 120;

		/// <summary>
		/// The list of beats to be played.
		/// </summary>
		[HideInInspector] public List<int> beats = new List<int> (); // ERRATUM : initializing the list here prevents error when creating a new track with custom inspector

		#if UNITY_EDITOR // skimming random track generation from runtime
		/// <summary>
		/// The # of different inputs.
		/// </summary>
		static public int inputs = 4;

		[Header ("Random Settings")]

		[Tooltip ("# of preroll (empty) beats")]
		[Range (0f, 10f)] [SerializeField] private int _preroll = 10;
		[Tooltip ("Minimum # of beats per block")]
		[Range (1, 20)] [SerializeField] private int _minBlock = 2;
		[Tooltip ("Maximum # of beats per block")]
		[Range (1, 20)] [SerializeField] private int _maxBlock = 5;
		[Tooltip ("Minimum # of empty beats between blocks")]
		[Range (1, 20)] [SerializeField] private int _minInterval = 1;
		[Tooltip ("Maximum # of empty beats between blocks")]
		[Range (1, 20)] [SerializeField] private int _maxInterval = 2;
		[Tooltip ("# of beats blocks")]
		[Range (1, 20)] [SerializeField] private int _blocks = 10;

		/// <summary>
		/// Generate Random Beats.
		/// </summary>
		public void Randomize ()
		{
			beats = new List<int> ();

			for (int b = 0 ; b < _preroll ; b++)
			{
				beats.Add (-1);
			}

			for (int blk = 0 ; blk < _blocks ; blk++)
			{
				int blockLength = Random.Range (_minBlock, _maxBlock+1);
				for (int b = 0 ; b < blockLength ; b++)
				{
					int beat = Random.Range (0, inputs);
					beats.Add (beat);
				}

				if (blk == _blocks-1)
					break;

				int intervalLength = Random.Range (_minInterval, _maxInterval+1);
				for (int b = 0 ; b < intervalLength ; b++)
				{
					beats.Add (-1);
				}
			}
		}
		#endif
	}
}