using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public static class NodeUtil {
    public static T[] GetChildrenOfType<T>(Node n) {

        List<T> children = n.GetChildren()
            .Where(child => child is T)
            .Cast<T>()
            .ToList();

        foreach (Node child in n.GetChildren()) {
            T[] grandChildren = GetChildrenOfType<T>(child);
            children.AddRange(grandChildren);
        }

        return children.ToArray();
    }
}
