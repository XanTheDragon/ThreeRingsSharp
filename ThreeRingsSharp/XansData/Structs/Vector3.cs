﻿using com.threerings.math;
using org.omg.PortableServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ThreeRingsSharp.XansData.Structs {

	/// <summary>
	/// Stores three <see langword="float"/> values that represent a coordinate in 3D space.<para/>
	/// Unlike <see cref="System.Numerics.Vector3"/>, this does not contain any vector math methods. This is strictly for data storage.
	/// </summary>
	public struct Vector3 : IEquatable<Vector3> {

		/// <summary>
		/// The X component of this <see cref="Vector3"/> which generally represents left or right positions relative to the world.
		/// </summary>
		public float X;

		/// <summary>
		/// The Y component of this <see cref="Vector3"/> which generally represents upward or downward positions relative to the world.
		/// </summary>
		public float Y;

		/// <summary>
		/// The Z component of this <see cref="Vector3"/> which generally represents forward or backward positions relative to the world.
		/// </summary>
		public float Z;

		/// <summary>
		/// Construct a new <see cref="Vector3"/> with the given X, Y, and Z coordinates.
		/// </summary>
		/// <param name="x">The X component of this Vector3.</param>
		/// <param name="y">The Y component of this Vector3.</param>
		/// <param name="z">The Z component of this Vector3.</param>
		public Vector3(float x = 0, float y = 0, float z = 0) {
			X = x;
			Y = y;
			Z = z;
		}

		/// <summary>
		/// Returns a list of <see cref="Vector3"/>s composed of the given float array, taking each value out in triplets.<para/>
		/// Throws <see cref="DataMisalignedException"/> if the float array's length is not divisible by three.
		/// </summary>
		/// <param name="values">The float array to be translated into a <see cref="Vector3"/> array.</param>
		/// <returns></returns>
		public static Vector3[] FromFloatArray(float[] values) {
			int lenDiv3 = values.Length / 3;
			if (values.Length % 3 != 0) throw new DataMisalignedException("Failed to convert float[] to Vector3[] -- Float array does not have a length divisible by 3!");
			Vector3[] vecs = new Vector3[lenDiv3];
			for (int idx = 0; idx < values.Length; idx += 3) {
				vecs[idx / 3] = new Vector3(values[idx], values[idx + 1], values[idx + 2]);
			}
			return vecs;
		}

		#region Casts to and from OOO Vector3f to this Vector3
		public static implicit operator Vector3f(Vector3 input) {
			return new Vector3f(input.X, input.Y, input.Z);
		}

		public static implicit operator Vector3(Vector3f input) {
			return new Vector3(input.x, input.y, input.z);
		}
		#endregion

		#region Equality: Vector3 to Vector3
		public static bool operator ==(Vector3 left, Vector3 right) => left.Equals(right);

		public static bool operator !=(Vector3 left, Vector3 right) => !(left == right);

		public bool Equals(Vector3 other) {
			if (ReferenceEquals(this, other)) return true;
			return X == other.X && Y == other.Y && Z == other.Z;
		}
		#endregion

		#region Equality: Vector3 to Vertex
		// Note: Cases where Vertex is the left operand are defined in Vertex.
		public static bool operator ==(Vector3 left, Vertex right) => left == right.Point;

		public static bool operator !=(Vector3 left, Vertex right) => !(left == right);
		#endregion

		#region Stock Object Overrides
		public override bool Equals(object obj) => obj is Vector3 other ? Equals(other) : ReferenceEquals(this, obj);

		public override int GetHashCode() {
			return HashCode.Combine(X, Y, Z);
		}

		/// <summary>
		/// Converts this <see cref="Vector3"/> into a string where each component is separated by a single space: <c>X Y Z</c>
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			return $"{X} {Y} {Z}";
		}
		#endregion
	}
}
