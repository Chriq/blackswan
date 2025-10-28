using Godot;
using System;
using System.Collections.Generic;

public partial class SoundManager : Node {
	[Export] public AudioStreamPlayer backgroundMusicPlayer;
	[Export] private AudioStreamPlayer soundEffectsPlayer;

	public static SoundManager Instance;

	public AudioPath currentAudio { get; private set; } = AudioPath.NONE;

	private double _timeBegin;
	private double _timeDelay;

	public override void _Ready() {
		Instance = this;
		Play(AudioPath.PHASE1);
	}

	public void Play(AudioPath audio) {
		backgroundMusicPlayer.Stream = GetAudioStream(audio);
		backgroundMusicPlayer.Play();
		ResetAudioTimer();
	}

	public double GetSecondsPerBeat() {
		return 60d / 200d;
	}

	public double GetPlaybackTime() {
		double duration = GetStreamDuration();
		double time = (Time.GetTicksUsec() - _timeBegin) / 1000000.0d;

		if (time > duration) {
			ResetAudioTimer();
			time -= duration;
		}

		return Math.Max(0.0d, time - _timeDelay);
	}

	public double GetStreamDuration() {
		return backgroundMusicPlayer.Stream.GetLength();
	}

	public static AudioStream GetAudioStream(AudioPath audioPath) {
		if (audioPath == AudioPath.NONE) {
			return null;
		}

		return (AudioStream)GD.Load(AudioPaths.Lookup.GetValueOrDefault(audioPath));
	}

	public void ResetAudioTimer() {
		_timeBegin = Time.GetTicksUsec();
		_timeDelay = AudioServer.GetTimeToNextMix() + AudioServer.GetOutputLatency();
	}
}
