using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace TrueADT
{
	/// <summary>
	/// The header for the data containing relative offsets for the data's position
	/// throughout the ADT file.
	/// </summary>
	[WireDataContract]
	public sealed class AdtWotlkMCINDataHeader
	{
		/// <summary>
		/// Contains the flags for the file data.
		/// </summary>
		[WireMember(1)]
		public AdtMapFlags FileFlags { get; }

		//TODO: Are these 32 bit offsets or 64 bit?
		//Used pre-cat and can be read about here: https://wowdev.wiki/ADT/v18#MCIN_chunk_.28.3CCata.29
		//// Cata+: obviously gone. probably all offsets gone, except mh2o(which remains in root file).
		/// <summary>
		/// Contains the relative offset to the map chunk information header.
		/// </summary>
		[WireMember(2)]
		public uint MapChunkInformationOffset { get; }

		/// <summary>
		/// Contains the relative offset to the map structure that lists
		/// the path to all the used textures.
		/// </summary>
		[WireMember(3)]
		public uint MapTextureListOffset { get; }

		//Serializer ctor
		private AdtWotlkMCINDataHeader()
		{
			
		}
	}
}
