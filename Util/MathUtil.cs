using Godot;

public static class MathUtil {
    public static float Map(float value, float fromMin, float fromMax, float toMin, float toMax, bool clamp = false) {
        float val = toMin + (toMax - toMin) * ((value - fromMin) / (fromMax - fromMin));
        return clamp ? Mathf.Clamp(val, Mathf.Min(toMin, toMax), Mathf.Max(toMin, toMax)) : val;
    }

    // 0 <= x <= 1
    public static float EaseInOut(float t) {
        return t < 0.5 ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
    }
}
