using SCN.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace SCN.Audio
{
	[CreateAssetMenu(fileName = "Audio global", menuName = "SCN/Scriptable Objects/Audio default")]
	public class AudioGlobal : ScriptableObject
	{
		static AudioGlobal instance;
		public static AudioGlobal Instance
		{
			get
			{
				if (instance == null)
				{
					Setup();
				}

				return instance;
			}
		}

		static void Setup()
		{
			instance = LoadSource.LoadObject<AudioGlobal>("Audio global");
			if (instance == null)
			{
				Debug.LogError("Create 'Audio global' in Resources" +
					".SCN => Scriptable Objects => Audio default");

				return;
			}

			instance.happyVoiceLength = instance.cheeringVoices.Length;
			instance.cheeringVoiceRandom = new RandomNoRepeat<AudioClip>(instance.cheeringVoices);
		}

		[Space(2)]
		[Header("Action sound")]
		[SerializeField] AudioClip[] actionSounds;

		[Space(4)]
		[Header("Character special")]
		[SerializeField] AudioClip[] characterSpecialVoices;

		[Space(4)]
		[Header("Cheering voice")]
		[SerializeField] AudioClip[] cheeringVoices;

		[Space(4)]
		[Header("Emotional voice")]
		[SerializeField] AudioClip[] emotionalVoices;

		[Space(4)]
		[Header("Greeting")]
		[SerializeField] AudioClip[] characterSpeechs; // 0: hello, 1: goodbye

		int happyVoiceLength;
		RandomNoRepeat<AudioClip> cheeringVoiceRandom;

		#region 0. Action sound
		public void PlayActionSound(ActionOp option, bool stopAllSound = false
			, System.Action onDone = null, bool ignoreIfPlaying = false)
		{
			AudioPlayer.Instance.PlaySound(actionSounds[(int)option]
				, false, stopAllSound, onDone, ignoreIfPlaying);
		}
		#endregion

		#region 1. Character special
		public void PlayCharacterSpecialVoice(CharacterSpecialOp option
			, bool stopAllSound = false, System.Action onDone = null, bool ignoreIfPlaying = false)
		{
			AudioPlayer.Instance.PlaySound(characterSpecialVoices[(int)option]
				, false, stopAllSound, onDone, ignoreIfPlaying);
		}
		#endregion

		#region 2. Cheering voice
		public void PlayCheeringlVoice(CheeringVoiceOp option, bool stopAllSound = false
			, System.Action onDone = null, bool ignoreIfPlaying = false)
		{
			AudioPlayer.Instance.PlaySound(cheeringVoices[(int)option]
				, false, stopAllSound, onDone, ignoreIfPlaying);
		}

		public void PlayRandomCheeringVoice(bool stopAllSound = false
			, System.Action onDone = null, bool ignoreIfPlaying = false)
		{
			AudioPlayer.Instance.PlaySound(cheeringVoices[Random.Range(0, happyVoiceLength)]
				, false, stopAllSound, onDone, ignoreIfPlaying);
		}

		public void PlayRandomNoRepeatCheeringVoice(bool stopAllSound = false
			, System.Action onDone = null, bool ignoreIfPlaying = false)
		{
			AudioPlayer.Instance.PlaySound(cheeringVoiceRandom.Random()
				, false, stopAllSound, onDone, ignoreIfPlaying);
		}
		#endregion

		#region 3. Emotional voice
		public void PlayEmotionalVoice(EmotionalVoiceOp option, bool stopAllSound = false
			, System.Action onDone = null, bool ignoreIfPlaying = false)
		{
			AudioPlayer.Instance.PlaySound(emotionalVoices[(int)option]
				, false, stopAllSound, onDone, ignoreIfPlaying);
		}
		#endregion

		#region 4. Character speech
		public void PlayCharacterSpeech(CharacterSpeechOp option, bool stopAllSound = false
			, System.Action onDone = null, bool ignoreIfPlaying = false)
		{
			AudioPlayer.Instance.PlaySound(characterSpeechs[(int)option]
				, false, stopAllSound, onDone, ignoreIfPlaying);
		}
		#endregion

		public enum ActionOp
		{
			/// <summary>
			/// Khi bam vao button
			/// </summary>
			Btn = 0,
			/// <summary>
			/// Khi hoan thanh 1 session choi
			/// </summary>
			Complete = 1,
			/// <summary>
			/// Khi 1 object nao do duoc show ra
			/// </summary>
			PopUp = 2,
			/// <summary>
			/// Khi thuc hien hanh dong dung
			/// </summary>
			Correct = 3,
			/// <summary>
			/// Khi thuc hien hanh dong sai
			/// </summary>
			Wrong = 4
		}

		public enum CharacterSpecialOp
		{
			/// <summary>
			/// Tieng Hooray cua nam
			/// </summary>
			BoyHooray = 0,

			/// <summary>
			/// Tieng Hooray cua nu
			/// </summary>
			GirlHooray = 1,

			/// <summary>
			/// Tieng hu' cua nam
			/// </summary>
			BoyHowling = 2,

			/// <summary>
			/// Tieng hu' cua nu
			/// </summary>
			GirlHowling = 3
		}

		public enum CheeringVoiceOp
		{
			Cool_B = 0,
			Cool_G = 1,
			WellDone_B = 2,
			WellDone_G = 3,
			Wonderful_B = 4,
			Wow_G = 5,
			SoCool_G = 6,
			Perfect_B = 7,
			SoInteresting_G = 8,
			YesYes_BG = 9,
			YoureGreat_B = 10,
			GreatJob_B = 11,
			ILikeIt_G = 12,
			Awesome_G = 13,
			GoodJob_G = 14,
			SoBeautiful_G = 15
		}

		public enum EmotionalVoiceOp
		{
			Hmm = 0,
			Laugh = 1,
			YummyYummy = 2,
			Zeee = 3
		}

		public enum CharacterSpeechOp
		{
			Hello = 0,
			Goodbye = 1,
			Thankiu_B = 2,
			Thankiu_G = 3
		}

#if UNITY_EDITOR
		[ContextMenu(nameof(AssignObject))]
		void AssignObject()
		{
			actionSounds = LoadSource.LoadAllAssetAtPath<AudioClip>(
				"Assets/SCNLib/Audio default/Audio/Sound effect/0. Action sound");
			characterSpecialVoices = LoadSource.LoadAllAssetAtPath<AudioClip>(
				"Assets/SCNLib/Audio default/Audio/Sound effect/1. Character special");
			cheeringVoices = LoadSource.LoadAllAssetAtPath<AudioClip>(
				"Assets/SCNLib/Audio default/Audio/Sound effect/2. Cheering voice");
			emotionalVoices = LoadSource.LoadAllAssetAtPath<AudioClip>(
				"Assets/SCNLib/Audio default/Audio/Sound effect/3. Emotional voice");
			characterSpeechs = LoadSource.LoadAllAssetAtPath<AudioClip>(
				"Assets/SCNLib/Audio default/Audio/Sound effect/4. Character speech");
        }
#endif
	}
}