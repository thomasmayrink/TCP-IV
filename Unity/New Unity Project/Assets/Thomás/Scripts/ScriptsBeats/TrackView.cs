//
//  TrackView.cs
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
using UnityEngine.UI;

namespace Beats
{
	/// <summary>
	/// Beats Project
	/// Track View Component.
	/// </summary>
	[HelpURL ("http://unitycoach.ca/workshops/beats")]
	[AddComponentMenu ("UnityCoach/Beats/TrackView")]
	[RequireComponent (typeof (VerticalLayoutGroup))]
	[RequireComponent (typeof (ContentSizeFitter))]
	[RequireComponent (typeof (RectTransform))]
	public class TrackView : MonoBehaviour
	{
		/// <summary>
		/// Beat View Update Trigger Type.
		/// </summary>
		public enum Trigger
		{
			/// <summary>
			/// The beat was missed.
			/// </summary>
			Missed,
			/// <summary>
			/// The beat was played with the right input.
			/// </summary>
			Right,
			/// <summary>
			/// The beat was played with the wrong input.
			/// </summary>
			Wrong
		}

//		[SerializeField] Track _track;

		[Header ("Beats' Display")]
		[Tooltip ("UI element for \"Left\" input")]
		[SerializeField] RectTransform _left;
		[Tooltip ("UI element for \"Right\" input")]
		[SerializeField] RectTransform _right;
		[Tooltip ("UI element for \"Up\" input")]
		[SerializeField] RectTransform _up;
		[Tooltip ("UI element for \"Down\" input")]
		[SerializeField] RectTransform _down;
		[Tooltip ("UI element for \"Empty\" input")]
		[SerializeField] RectTransform _empty;

		RectTransform _rTransform; // this trackview RectTransform component
		List<Image> _beatViews; // the individual beats/notes views

		Vector2 _position; // anchoredPosition temporary value
		float _beatViewSize; // beat views height
		float _spacing; // VerticalLayoutGroup spacing value

		/// <summary>
		/// The scrolling position of the TrackView.
		/// </summary>
		public float position
		{
			get { return _position.y; }
			set
			{
				if (value != _position.y)
				{
					_position.y = value;
					_rTransform.anchoredPosition = _position;
				}
			}
		}
			
		/// <summary>
		/// Initialises the TrackView with the specified Track.
		/// </summary>
		/// <param name="track">The Track to initialise the TrackView with.</param>
		public void Init (Track track)
		{
			_rTransform = (RectTransform)transform;
			_position = _rTransform.anchoredPosition;

			_beatViewSize = _empty.rect.height;
			_spacing = GetComponent<VerticalLayoutGroup>().spacing;

			_beatViews = new List<Image> ();

			foreach (int b in track.beats)
			{
				GameObject g;
				switch (b)
				{
					case 0:
						g = _left.gameObject;
						break;
					case 1:
						g = _down.gameObject;
						break;
					case 2:
						g = _up.gameObject;
						break;
					case 3:
						g = _right.gameObject;
						break;
					default:
						g = _empty.gameObject;
						break;
				}
				Image view = GameObject.Instantiate(g, transform).GetComponent<Image>();
				view.transform.SetAsFirstSibling();

				_beatViews.Add (view);
			}
		}

		void Start ()
		{
			Init (GamePlayController.Instance.track);
		}

		void Update ()
		{
			position -= (_beatViewSize+_spacing) * Time.deltaTime * GamePlayController.Instance.secondsPerBeat;
		}

		/// <summary>
		/// Triggers beat view update.
		/// </summary>
		/// <param name="index">Index of the Beat View to update.</param>
		/// <param name="trigger">Update Trigger Type.</param>
		public void TriggerBeatView (int index, Trigger trigger)
		{
			switch (trigger)
			{
				case Trigger.Missed:
					_beatViews[index].color = Color.gray;
					break;
				case Trigger.Right:
					_beatViews[index].color = Color.yellow;
					break;
				case Trigger.Wrong:
					_beatViews[index].color = Color.cyan;
					break;
			}
		}
	}
}