using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace TrueADT
{
	//Appears to be the header for the file itself.
	/// <summary>
	/// Model that contains version information.
	/// </summary>
	[WireDataContract]
	public sealed class AdtVersionInfo
	{
		//TODO: Is it ADT version or client version?
		/// <summary>
		/// The version of the game this ADT file is for.
		/// </summary>
		[WireMember(1)]
		public uint VersionNumber { get; }

		//Serializer ctor
		private AdtVersionInfo()
		{
			
		}
	}
}
