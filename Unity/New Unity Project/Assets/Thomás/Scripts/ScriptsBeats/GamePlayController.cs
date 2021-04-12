//
//  GamePlayController.cs
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
	[HelpURL ("http://unitycoach.ca/workshops/beats")]
	[AddComponentMenu ("UnityCoach/Beats/GamePlayController")]
	public class GamePlayController : MonoBehaviour
	{
		[Header ("Inputs")]
		[Tooltip ("Keycode for \"Left\" input")]
		[SerializeField] KeyCode _left = KeyCode.LeftArrow;
		[Tooltip ("Keycode for \"Down\" input")]
		[SerializeField] KeyCode _down = KeyCode.DownArrow;
		[Tooltip ("Keycode for \"Up\" input")]
		[SerializeField] KeyCode _up = KeyCode.UpArrow;
		[Tooltip ("Keycode for \"Right\" input")]
		[SerializeField] KeyCode _right = KeyCode.RightArrow;

		[Header ("Track")]
		[Tooltip ("Beats Track to play")]
		[SerializeField] private Track _track;
		/// <summary>
		/// The current Track.
		/// </summary>
		public Track track {get {return _track;}}

		/// <summary>
		/// # of seconds per beat.
		/// </summary>
		public float secondsPerBeat {get; private set;}
		/// <summary>
		/// # of beats per second.
		/// </summary>
		public float beatsPerSecond {get; private set;}

		private bool _played; // has the player played within the current beat
		private bool _completed; // has the player completed the track

		private TrackView _trackView; // the trackview to send events to
		private WaitForSeconds waitAndStop; // the WaitForSeconds YieldInstruction to use to Wait and Stop the game at the end of the track

		#region Singleton
		private static GamePlayController _instance;
		/// <summary>
		/// Current GamePlayController instance.
		/// </summary>
		public static GamePlayController Instance
		{
			get
			{
				if (_instance == null)
					_instance = (GamePlayController)GameObject.FindObjectOfType(typeof(GamePlayController));
				
				return _instance;
			}
		}

		void OnDestroy()
		{
			_instance = null;
		}
		#endregion

		#region MonoBehaviour Methods
		void Awake ()
		{
			_instance = this;
			secondsPerBeat = track.bpm/60f;
			beatsPerSecond = 60f/track.bpm;
			waitAndStop = new WaitForSeconds (beatsPerSecond*2);

			_trackView = FindObjectOfType<TrackView>();
			if (!_trackView)
				Debug.LogWarning ("No TrackView found in current scene");
		}

		void Start ()
		{
			InvokeRepeating ("NextBeat", 0f, beatsPerSecond);
		}

		void Update ()
		{
			if (_played || _completed)
				return;

			if (Input.GetKeyDown (_left))
				PlayBeat (0);
			if (Input.GetKeyDown (_down))
				PlayBeat (1);
			if (Input.GetKeyDown (_up))
				PlayBeat (2);
			if (Input.GetKeyDown (_right))
				PlayBeat (3);
		}
		#endregion

		#region GamePlay
		private int _current;
		/// <summary>
		/// The current beat index.
		/// </summary>
		public int current
		{
			get { return _current; }
			private set
			{
				if (value != _current)
				{
					_current = value;

					if (_current == _track.beats.Count)
					{
						CancelInvoke("NextBeat");

						_completed = true;

						StartCoroutine (WaitAndStop ());
					}
				}
			}
		}

		void PlayBeat (int input)
		{
			_played = true;

			if (_track.beats[current] == -1)
			{
//				Debug.Log (string.Format("{0} played untimely", input));
			}
			else if (_track.beats[current] == input)
			{
//				Debug.Log (string.Format("{0} played right", input));
				_trackView.TriggerBeatView (current, TrackView.Trigger.Right);
			}
			else
			{
//				Debug.Log (string.Format("{0} played, {1} expected", input, _track.beats[current]));
				_trackView.TriggerBeatView (current, TrackView.Trigger.Wrong);
			}
		}

		void NextBeat ()
		{
//			Debug.Log ("Tick");

			if (!_played && _track.beats[current] != -1)
			{
//				Debug.Log (string.Format("{0} missed", _track.beats[current]));
				_trackView.TriggerBeatView (current, TrackView.Trigger.Missed);
			}
			_played = false;

			current++;
		}

		private IEnumerator WaitAndStop ()
		{
			yield return waitAndStop;
			enabled = false;
		}
		#endregion
	}
}