using System;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace TrueADT
{
	/// <summary>
	/// The header for a file chunk.
	/// See: https://wowdev.wiki/Chunk
	/// </summary>
	[WireDataContract]
	public sealed class AdtDataChunk
	{
		//For the ADT this is a reversed string for the actual header name. Like MHDR backwards "RDHM"
		/// <summary>
		/// The name of the header type.
		/// </summary>
		[ReverseData]
		[DontTerminate]
		[KnownSize(4)]
		[WireMember(1)]
		public string Token { get; }

		[SendSize(SendSizeAttribute.SizeType.Int32)] //WoW uses a uint chunk size int he chunk def
		[WireMember(2)]
		public byte[] ChunkBytes { get; }

		//After this header should be the data.
		//Serializer ctor
		private AdtDataChunk()
		{
			
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return $"Token: {Token} Size: {ChunkBytes?.Length}";
		}
	}
}
