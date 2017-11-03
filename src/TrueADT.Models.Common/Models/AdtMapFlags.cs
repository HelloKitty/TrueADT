using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace TrueADT
{
	/// <summary>
	/// Flags for optional data or behaviour that the ADT files contain.
	/// Commonly called MHDRFlags in the SMMapHeader.
	/// </summary>
	[Flags]
	[WireDataContract]
	public enum AdtMapFlags
	{
		/// <summary>
		/// Indicates that the ADT defines a bounding box for flying collision.
		/// </summary>
		FlyingBoundingBoxObject = 1,

		//TODO: Explore what this is.
		/// <summary>
		/// Set on some Northrend maps. Unknown.
		/// </summary>
		Northrend = 2,
	}
}
