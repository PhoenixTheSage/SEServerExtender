﻿using Microsoft.Xml.Serialization.GeneratedAssembly;

using System;
using System.Collections.Generic;
using System.IO;

using Sandbox.Common.ObjectBuilders;
using Sandbox.Common.ObjectBuilders.Definitions;
using Sandbox.Common.ObjectBuilders.Voxels;
using Sandbox.Common.ObjectBuilders.VRageData;

using SEModAPI.API.Definitions;

namespace SEModAPI.API.SaveData
{
	public class Sector : OverLayerDefinition<MyObjectBuilder_Sector>
	{
		#region "Attributes"

		private FileInfo m_fileInfo;

		private EventManager m_eventManager;
		private CubeGridManager m_cubeGridManager;

		//TODO - Build managers for these so that we aren't using lists
		private List<VoxelMap> m_voxelMaps;
		private List<FloatingObject> m_floatingObjects;
		private List<Meteor> m_meteors;
		private List<SectorObject<MyObjectBuilder_EntityBase>> m_unknownObjects;

		#endregion

		#region "Constructors and Initializers"

		public Sector(MyObjectBuilder_Sector definition, FileInfo fileInfo)
			: base(definition)
		{
			m_fileInfo = fileInfo;

			m_voxelMaps = new List<VoxelMap>();
			m_floatingObjects = new List<FloatingObject>();
			m_meteors = new List<Meteor>();
			m_unknownObjects = new List<SectorObject<MyObjectBuilder_EntityBase>>();

			List<MyObjectBuilder_GlobalEventBase> events = new List<MyObjectBuilder_GlobalEventBase>();
			foreach (var sectorEvent in definition.SectorEvents.Events)
			{
				events.Add(sectorEvent);
			}

			List<MyObjectBuilder_CubeGrid> cubeGrids = new List<MyObjectBuilder_CubeGrid>();
			foreach (var sectorObject in definition.SectorObjects)
			{
				if (sectorObject.TypeId == MyObjectBuilderTypeEnum.CubeGrid)
				{
					MyObjectBuilder_CubeGrid cubeGrid = (MyObjectBuilder_CubeGrid)sectorObject;
					cubeGrids.Add(cubeGrid);
				}
				else if (sectorObject.TypeId == MyObjectBuilderTypeEnum.VoxelMap)
				{
					MyObjectBuilder_VoxelMap voxelMap = (MyObjectBuilder_VoxelMap)sectorObject;
					m_voxelMaps.Add(new VoxelMap(voxelMap));
				}
				else if (sectorObject.TypeId == MyObjectBuilderTypeEnum.FloatingObject)
				{
					MyObjectBuilder_FloatingObject floatingObject = (MyObjectBuilder_FloatingObject)sectorObject;
					m_floatingObjects.Add(new FloatingObject(floatingObject));
				}
				else if (sectorObject.TypeId == MyObjectBuilderTypeEnum.Meteor)
				{
					MyObjectBuilder_Meteor meteor = (MyObjectBuilder_Meteor)sectorObject;
					m_meteors.Add(new Meteor(meteor));
				}
				else
				{
					m_unknownObjects.Add(new SectorObject<MyObjectBuilder_EntityBase>(sectorObject));
				}
			}

			//Build the managers from the lists
			m_eventManager = new EventManager(events);
			m_cubeGridManager = new CubeGridManager(cubeGrids);
		}

		#endregion

		#region "Properties"

		public VRageMath.Vector3I Position
		{
			get { return m_baseDefinition.Position; }
		}

		public int AppVersion
		{
			get { return m_baseDefinition.AppVersion; }
		}

		public List<Event> Events
		{
			get
			{
				//TODO - Look into changing manager base class to return a List so we don't have to do the array conversion
				List<Event> newList = new List<Event>(m_eventManager.Definitions);
				return newList;
			}
		}

		public List<CubeGrid> CubeGrids
		{
			get
			{
				//TODO - Look into changing manager base class to return a List so we don't have to do the array conversion
				List<CubeGrid> newList = new List<CubeGrid>(m_cubeGridManager.Definitions);
				return newList;
			}
		}

		public List<VoxelMap> VoxelMaps
		{
			get { return m_voxelMaps; }
		}

		public List<FloatingObject> FloatingObjects
		{
			get { return m_floatingObjects; }
		}

		public List<Meteor> Meteors
		{
			get { return m_meteors; }
		}

		public List<SectorObject<MyObjectBuilder_EntityBase>> UnknownObjects
		{
			get { return m_unknownObjects; }
		}

		#endregion

		#region "Methods"

		protected override string GetNameFrom(MyObjectBuilder_Sector definition)
		{
			return "SANDBOX_" + this.Position.X + "_" + this.Position.Y + "_" + this.Position.Z + "_";
		}

		public void Save()
		{
			ConfigFileSerializer configFileSerializer = new ConfigFileSerializer();
			configFileSerializer.WriteSpaceEngineersFile<MyObjectBuilder_Sector, MyObjectBuilder_SectorSerializer>(this.m_baseDefinition, this.m_fileInfo.FullName);
		}

		#endregion
	}
}