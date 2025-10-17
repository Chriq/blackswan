using System.Collections.Generic;

public static class AudioPaths {
	public static Dictionary<AudioPath, string> Lookup = new Dictionary<AudioPath, string>() {
		{AudioPath.PHASE1, "res://Audio/Music/blackswan_phase1.wav"}
	};
}

public enum AudioPath {
	NONE,
	PHASE1
}