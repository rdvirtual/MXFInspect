﻿//
// MXF - Myriadbits .NET MXF library. 
// Read MXF Files.
// Copyright (C) 2015 Myriadbits, Jochem Bakker
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// For more information, contact me at: info@myriadbits.com
//

using System;
using System.ComponentModel;

namespace Myriadbits.MXF
{
	public class MXFGenericPackage : MXFInterchangeObject
	{
		[CategoryAttribute("MaterialPackage"), Description("4401")]
		public MXFUMIDKey PackageUID { get; set; }
		[CategoryAttribute("MaterialPackage"), Description("4402")]
		public string PackageName { get; set; }
		[CategoryAttribute("MaterialPackage"), Description("4404")]
		public DateTime? ModifiedDate { get; set; }
		[CategoryAttribute("MaterialPackage"), Description("4405")]
		public DateTime? CreationDate { get; set; }

		public MXFGenericPackage(MXFReader reader, MXFKLV headerKLV)
			: base(reader, headerKLV, "MaterialPackage")
		{
		}

		public MXFGenericPackage(MXFReader reader, MXFKLV headerKLV, string metadataName)
			: base(reader, headerKLV, metadataName)
		{
		}

		/// <summary>
		/// Overridden method to process local tags
		/// </summary>
		/// <param name="localTag"></param>
		protected override bool ParseLocalTag(MXFReader reader, MXFLocalTag localTag)
		{
			switch (localTag.Tag)
			{
				case 0x4401: this.PackageUID = reader.ReadUMIDKey(); return true;
				case 0x4402: this.PackageName = reader.ReadS(localTag.Size); return true;
				case 0x4403: ReadKeyList(reader, "Tracks", "Track"); return true;
				case 0x4404: this.ModifiedDate = reader.ReadTimestamp(); return true;
				case 0x4405: this.CreationDate = reader.ReadTimestamp(); return true;
			}
			return base.ParseLocalTag(reader, localTag); 
		}

	}
}
