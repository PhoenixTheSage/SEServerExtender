﻿using System;
using System.Collections.Generic;

using Sandbox.Common.ObjectBuilders;
using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Common.ObjectBuilders.Voxels;

using SEModAPI.API.Definitions;

namespace SEModAPI.API.SaveData
{
	public class VoxelMap : SectorObject<MyObjectBuilder_VoxelMap>
	{
		#region "Constructors and Initializers"

		public VoxelMap(MyObjectBuilder_VoxelMap definition)
			: base(definition)
		{}

		#endregion

		#region "Properties"

		public string Filename
		{
			get { return m_baseDefinition.Filename; }
			set
			{
				if (m_baseDefinition.Filename == value) return;
				m_baseDefinition.Filename = value;
				Changed = true;
			}
		}

		#endregion

		#region "Methods"

		protected override string GetNameFrom(MyObjectBuilder_VoxelMap definition)
		{
			return definition.Filename;
		}

		#endregion
	}
}