using System.Collections.Generic;

public static class AudioPaths {
	public static Dictionary<AudioPath, string> Lookup = new Dictionary<AudioPath, string>() {
		{AudioPath.INTRO, "res://Audio/Music/blackswan_intro.wav"},
		{AudioPath.PHASE1, "res://Audio/Music/blackswan_phase1.wav"},
		{AudioPath.TRANSITION, "res://Audio/Music/blackswan_transition.wav"},
		{AudioPath.PHASE2, "res://Audio/Music/blackswan_phase2.wav"},
		{AudioPath.OUTRO, "res://Audio/Music/blackswan_outro.wav"}
	};
}

public enum AudioPath {
	NONE,
	INTRO,
	PHASE1,
	TRANSITION,
	PHASE2,
	OUTRO
}