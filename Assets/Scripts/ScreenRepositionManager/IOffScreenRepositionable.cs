
using UnityEngine;

public interface IOffScreenRepositionable
{
    Vector3 ObjectDirection { get; }
    Vector3 Position { get; set; }
    Bounds Bounds { get; }
}