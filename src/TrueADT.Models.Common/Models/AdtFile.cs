using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FreecraftCore.Serializer;

namespace TrueADT.Models
{
	/// <summary>
	/// Model for the ADT file which is just a collection of data chunks.
	/// </summary>
	[WireDataContract]
	public sealed class AdtFile : IEnumerable<AdtDataChunk>
	{
		/// <summary>
		/// The serialized data chunks present in the deserialized ADT file.
		/// </summary>
		[ReadToEnd]
		[WireMember(1)]
		private AdtDataChunk[] _Chunks { get; }

		/// <summary>
		/// Collection of all the data chunks in the ADT file.
		/// </summary>
		public IEnumerable<AdtDataChunk> Chunks => _Chunks;

		//Serializer ctor
		private AdtFile()
		{
			
		}

		/// <inheritdoc />
		public IEnumerator<AdtDataChunk> GetEnumerator()
		{
			return Chunks.GetEnumerator();
		}

		/// <inheritdoc />
		IEnumerator IEnumerable.GetEnumerator()
		{
			return Chunks.GetEnumerator();
		}
	}
}
