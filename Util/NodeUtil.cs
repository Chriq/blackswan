using Godot;
using System;
using System.Linq;

public static class NodeUtil {
    public static T[] GetChildrenOfType<T>(Node n) {
        return n.GetChildren()
            .Where(child => child is T)
            .Cast<T>()
            .ToArray();
    }
}
