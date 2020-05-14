﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThreeRingsSharp.XansData.Exceptions;

namespace ThreeRingsSharp.XansData.IO {

	/// <summary>
	/// Represents a class that can export data in a specific 3D model format.
	/// </summary>
	public abstract class AbstractModelExporter {

		/// <summary>
		/// A message accompanied with all exports describing the tool used to export the model.
		/// </summary>
		public const string TOOL = "Exported by ThreeRingsSharp (Spiral Knights Animator Tools V2)";

		/// <summary>
		/// Exports the data stored in the given <see cref="Model3D"/>(s) to the given file.
		/// </summary>
		/// <param name="models">The models that should be exported.</param>
		/// <param name="toFile">The file to write the data to.</param>
		public abstract void Export(Model3D[] models, FileInfo toFile);

		/// <summary>
		/// A generic constructor for <see cref="AbstractModelExporter"/>. Required for the factory to interface with this class properly.
		/// </summary>
		public AbstractModelExporter() { }

	}
}