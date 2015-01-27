﻿using System;
using System.Collections.Generic;
using Sandbox.Definitions;
using SEModAPIInternal.API.Common;
using SEModAPIInternal.API.Entity.Sector.SectorObject.CubeGrid;
using SEModAPIInternal.API.Entity.Sector.SectorObject.CubeGrid.CubeBlock;
using SEModAPIInternal.Support;
using VRage;
using VRageMath;

namespace SEModAPIInternal.API.Entity.Sector.SectorObject
{
	public class CubeGridManagerManager
	{
		#region "Attributes"

		private CubeGridEntity m_parent;
		private Object m_backingObject;

		private PowerManager m_powerManager;
		private CubeGridThrusterManager m_thrusterManager;

		public static string CubeGridManagerManagerNamespace = "6DDCED906C852CFDABA0B56B84D0BD74";
		public static string CubeGridManagerManagerClass = "0A0120EAD12D237F859BDAB2D84DA72B";

		public static string CubeGridManagerManagerGetPowerManagerMethod = "F05ACB25E5255DA110249186EE895C73";
		public static string CubeGridManagerManagerGetThrusterManagerMethod = "0EF76C91FA04B0B200A3F3AC155F089D";

		#endregion "Attributes"

		#region "Constructors and Initializers"

		public CubeGridManagerManager( CubeGridEntity parent, Object backingObject )
		{
			m_parent = parent;
			m_backingObject = backingObject;

			m_powerManager = new PowerManager( GetPowerManager( ) );
			m_thrusterManager = new CubeGridThrusterManager( GetThrusterManager( ), m_parent );
		}

		#endregion "Constructors and Initializers"

		#region "Properties"

		public static Type InternalType
		{
			get
			{
				Type type = SandboxGameAssemblyWrapper.Instance.GetAssemblyType( CubeGridManagerManagerNamespace, CubeGridManagerManagerClass );
				return type;
			}
		}

		public Object BackingObject
		{
			get { return m_backingObject; }
		}

		public PowerManager PowerManager
		{
			get { return m_powerManager; }
		}

		public CubeGridThrusterManager ThrusterManager
		{
			get { return m_thrusterManager; }
		}

		#endregion "Properties"

		#region "Methods"

		public static bool ReflectionUnitTest( )
		{
			try
			{
				Type type = InternalType;
				if ( type == null )
					throw new Exception( "Could not find internal type for CubeGridManagerManager" );
				bool result = true;
				result &= BaseObject.HasMethod( type, CubeGridManagerManagerGetPowerManagerMethod );
				result &= BaseObject.HasMethod( type, CubeGridManagerManagerGetThrusterManagerMethod );

				return result;
			}
			catch ( Exception ex )
			{
				LogManager.APILog.WriteLine( ex );
				return false;
			}
		}

		private Object GetPowerManager( )
		{
			Object manager = BaseObject.InvokeEntityMethod( BackingObject, CubeGridManagerManagerGetPowerManagerMethod );
			return manager;
		}

		private Object GetThrusterManager( )
		{
			Object manager = BaseObject.InvokeEntityMethod( BackingObject, CubeGridManagerManagerGetThrusterManagerMethod );
			return manager;
		}

		#endregion "Methods"
	}

	public class CubeGridNetworkManager
	{
		//28 Packets
		public enum CubeGridPacketIds
		{
			CubeBlockHashSet = 14,				//..AAC558DB3CA968D0D3B965EA00DF05D4
			Packet1_2 = 15,
			Packet1_3 = 16,
			CubeBlockPositionList = 17,			//..5A55EA00576BB526436F3708D1F55455
			CubeBlockRemoveLists = 18,			//..94E4EFFF7257EEC85C3D8FA0F1EC9E69
			AllPowerStatus = 19,				//..782C8DC19A883BCB6A43C3006F456A2F

			//Construction/Item packets
			CubeBlockBuildIntegrityValues = 25,	//..EF2D90F50F1E378F0495FFB906D1C6C6

			CubeBlockItemList = 26,				//..3FD479635EACD6C3047ACB77CBAB645D
			Packet2_4 = 27,
			Packet2_5 = 28,
			Packet2_6 = 29,

			Packet3_1 = 4711,
			NewCubeBlock = 4712,				//..64F0E2C1B88DAB5903379AB2206F9A43
			Packet3_3 = 4713,
			Packet3_4 = 4714,

			ThrusterOverrideVector = 11212,		//..08CDB5B2B7DD39CF2E3D29D787045D83

			ThrusterGyroForceVectors = 15262,	//..632113536EC30663C6FF30251EFE637A
			Packet5_2 = 15263,
			Packet5_3 = 15264,
			CubeBlockOrientationIsh = 15265,	//..69FB43596400BF997D806DF041F2B54D
			CubeBlockFactionData = 15266,		//..090EFC311778552F418C0835D1248D60
			CubeBlockOwnershipMode = 15267,		//..F62F6360C3B7B7D32C525D5987F70A68

			AllPowerStatus2 = 15271,			//..903CC5CD740D130E90DB6CBF79F80F4F

			HandbrakeStatus = 15275,			//..4DCFFCEE8D5BA392C7A57ACD6470D7CD
			Packet7_1 = 15276,

			Packet8_1 = 15278,
			Packet8_2 = 15279,
			Packet8_3 = 15280,
		}

		#region "Attributes"

		private CubeGridEntity m_cubeGrid;
		private Object m_netManager;

		private static bool m_isRegistered;

		public static string CubeGridGetNetManagerMethod = "AF2DACDED0370C8DBA03A53FDA4E2C47";

		//Definition
		public static string CubeGridNetManagerNamespace = "5F381EA9388E0A32A8C817841E192BE8";

		public static string CubeGridNetManagerClass = "E727876839B1C8FFEE302CD2A1948CDA";

		//Methods
		public static string CubeGridNetManagerBroadcastCubeBlockBuildIntegrityValuesMethod = "F7C40254F25941842EA6558205FAC160";

		public static string CubeGridNetManagerBroadcastCubeBlockFactionDataMethod = "EF45C83059E3CD5A2C5354ABB687D861";
		public static string CubeGridNetManagerBroadcastCubeBlockRemoveListsMethod = "4A75379DE89606408396FDADD89822F3";
		public static string CubeGridNetManagerBroadcastAddCubeBlockMethod = "0B27B2B92323D75DF73055AD0A6DB4B6";

		//Fields
		public static string CubeGridNetManagerCubeBlocksToDestroyField = "8E76EFAC4EED3B61D48795B2CD5AF989";

		//////////////////////////////////////////////////////////////////

		public static string CubeGridIntegrityChangeEnumNamespace = CubeGridEntity.CubeGridNamespace + "." + CubeGridEntity.CubeGridClass;
		public static string CubeGridIntegrityChangeEnumClass = "55D3513B52D474C7AF161242E01FB9A9";

		#endregion "Attributes"

		#region "Constructors and Initializers"

		public CubeGridNetworkManager( CubeGridEntity cubeGrid )
		{
			m_cubeGrid = cubeGrid;
			object entity = m_cubeGrid.BackingObject;
			m_netManager = BaseObject.InvokeEntityMethod( entity, CubeGridGetNetManagerMethod );

			Action action = RegisterPacketHandlers;
			SandboxGameAssemblyWrapper.Instance.EnqueueMainGameAction( action );
		}

		#endregion "Constructors and Initializers"

		#region "Properties"

		public static Type InternalType
		{
			get
			{
				Type type = SandboxGameAssemblyWrapper.Instance.GetAssemblyType( CubeGridNetManagerNamespace, CubeGridNetManagerClass );
				return type;
			}
			private set
			{
				//Do nothing!
			}
		}

		#endregion "Properties"

		#region "Methods"

		public static bool ReflectionUnitTest( )
		{
			try
			{
				Type type = InternalType;
				if ( type == null )
					throw new Exception( "Could not find internal type for CubeGridNetworkManager" );
				bool result = true;
				result &= BaseObject.HasMethod( type, CubeGridNetManagerBroadcastCubeBlockBuildIntegrityValuesMethod );
				result &= BaseObject.HasMethod( type, CubeGridNetManagerBroadcastCubeBlockFactionDataMethod );
				result &= BaseObject.HasMethod( type, CubeGridNetManagerBroadcastCubeBlockRemoveListsMethod );
				result &= BaseObject.HasMethod( type, CubeGridNetManagerBroadcastAddCubeBlockMethod );
				result &= BaseObject.HasField( type, CubeGridNetManagerCubeBlocksToDestroyField );

				Type type2 = CubeGridEntity.InternalType.GetNestedType( CubeGridIntegrityChangeEnumClass );
				if ( type2 == null )
					throw new Exception( "Could not find type for CubeGridNetworkManager-CubeGridIntegrityChangeEnum" );

				return result;
			}
			catch ( Exception ex )
			{
				Console.WriteLine( ex );
				return false;
			}
		}

		public void BroadcastCubeBlockFactionData( CubeBlockEntity cubeBlock )
		{
			try
			{
				BaseObject.InvokeEntityMethod( m_netManager, CubeGridNetManagerBroadcastCubeBlockFactionDataMethod, new object[ ] { m_cubeGrid.BackingObject, cubeBlock.ActualObject, cubeBlock.Owner, cubeBlock.ShareMode } );
			}
			catch ( Exception ex )
			{
				LogManager.ErrorLog.WriteLine( ex );
			}
		}

		public void BroadcastCubeBlockBuildIntegrityValues( CubeBlockEntity cubeBlock )
		{
			try
			{
				Type someEnum = CubeGridEntity.InternalType.GetNestedType( CubeGridIntegrityChangeEnumClass );
				Array someEnumValues = someEnum.GetEnumValues( );
				Object enumValue = someEnumValues.GetValue( 0 );
				BaseObject.InvokeEntityMethod( m_netManager, CubeGridNetManagerBroadcastCubeBlockBuildIntegrityValuesMethod, new object[ ] { cubeBlock.BackingObject, enumValue, 0L } );
			}
			catch ( Exception ex )
			{
				LogManager.ErrorLog.WriteLine( ex );
			}
		}

		public void BroadcastCubeBlockRemoveLists( )
		{
			BaseObject.InvokeEntityMethod( m_netManager, CubeGridNetManagerBroadcastCubeBlockRemoveListsMethod );
		}

		public void BroadcastAddCubeBlock( CubeBlockEntity cubeBlock )
		{
			try
			{
				Type packedStructType = CubeGridEntity.InternalType.GetNestedType( CubeGridEntity.CubeGridPackedCubeBlockClass );
				Object packedStruct = Activator.CreateInstance( packedStructType );
				MyCubeBlockDefinition def = MyDefinitionManager.Static.GetCubeBlockDefinition( cubeBlock.ObjectBuilder );

				//Set def id
				BaseObject.SetEntityFieldValue( packedStruct, "35E024D9E3B721592FB9B6FC1A1E239A", (DefinitionIdBlit)def.Id );

				//Set position
				BaseObject.SetEntityFieldValue( packedStruct, "5C3938C9B8CED1D0057CCF12F04329AB", cubeBlock.Position );

				//Set block size
				BaseObject.SetEntityFieldValue( packedStruct, "0DDB53EB9299ECC9826DF9A47E5E4F38", new Vector3UByte( def.Size ) );

				//Set block margins
				BaseObject.SetEntityFieldValue( packedStruct, "4045ED59A8C93DE0B41218EF2E947E55", new Vector3B( 0, 0, 0 ) );
				BaseObject.SetEntityFieldValue( packedStruct, "096897446D5BD5243D3D6E5C53CE1772", new Vector3B( 0, 0, 0 ) );

				//Set block margin scale
				BaseObject.SetEntityFieldValue( packedStruct, "E28B9725868E18B339D1E0594EF14444", new Vector3B( 0, 0, 0 ) );

				//Set orientation
				Quaternion rot;
				cubeBlock.BlockOrientation.GetQuaternion( out rot );
				BaseObject.SetEntityFieldValue( packedStruct, "F1AAFF5C8F200592F313BC7E02140A38", Base6Directions.GetForward( rot ) );
				BaseObject.SetEntityFieldValue( packedStruct, "E80AA7B84131E39F9F88209A109EED59", Base6Directions.GetUp( rot ) );

				//Set color
				BaseObject.SetEntityFieldValue( packedStruct, "556976F2528411FF5F95FC75DC13FEED", ColorExtensions.PackHSVToUint( cubeBlock.ColorMaskHSV ) );

				object[ ] parameters = {
					packedStruct,
					new HashSet<Vector3UByte>(),
					cubeBlock.EntityId,
					MyRandom.Instance.CreateRandomSeed()
				};
				BaseObject.InvokeEntityMethod( m_netManager, CubeGridNetManagerBroadcastAddCubeBlockMethod, parameters );
			}
			catch ( Exception ex )
			{
				LogManager.ErrorLog.WriteLine( ex );
			}
		}

		protected static void RegisterPacketHandlers( )
		{
			try
			{
				if ( m_isRegistered )
					return;

				bool result = true;

				//Skip the overrides for now until we figure out more about client controlled position packets
				/*
				Type packetType = InternalType.GetNestedType("08CDB5B2B7DD39CF2E3D29D787045D83", BindingFlags.Public | BindingFlags.NonPublic);
				MethodInfo method = typeof(CubeGridNetworkManager).GetMethod("ReceiveThrusterManagerVectorPacket", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
				result &= NetworkManager.RegisterCustomPacketHandler(PacketRegistrationType.Instance, packetType, method, InternalType);
				Type packetType2 = InternalType.GetNestedType("632113536EC30663C6FF30251EFE637A", BindingFlags.Public | BindingFlags.NonPublic);
				MethodInfo method2 = typeof(CubeGridNetworkManager).GetMethod("ReceiveThrusterGyroForceVectorPacket", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
				result &= NetworkManager.RegisterCustomPacketHandler(PacketRegistrationType.Instance, packetType2, method2, InternalType);
				*/

				if ( !result )
					return;

				m_isRegistered = true;
			}
			catch ( Exception ex )
			{
				LogManager.ErrorLog.WriteLine( ex );
			}
		}

		protected static void ReceiveThrusterManagerVectorPacket<T>( Object instanceNetManager, ref T packet, Object masterNetManager ) where T : struct
		{
			try
			{
				//For now we ignore any inbound packets that set the positionorientation
				//This prevents the clients from having any control over the actual ship position
			}
			catch ( Exception ex )
			{
				LogManager.ErrorLog.WriteLine( ex );
			}
		}

		protected static void ReceiveThrusterGyroForceVectorPacket<T>( Object instanceNetManager, ref T packet, Object masterNetManager ) where T : struct
		{
			try
			{
				//For now we ignore any inbound packets that set the positionorientation
				//This prevents the clients from having any control over the actual ship position
			}
			catch ( Exception ex )
			{
				LogManager.ErrorLog.WriteLine( ex );
			}
		}

		#endregion "Methods"
	}

	public class CubeGridThrusterManager
	{
		#region "Attributes"

		private Object m_thrusterManager;
		private CubeGridEntity m_parent;

		private bool m_dampenersEnabled;

		public static string CubeGridThrusterManagerNamespace = "8EAF60352312606996BD8147B0A3C880";
		public static string CubeGridThrusterManagerClass = "958ADAA3423FBDC5DE98C1A32DE7258C";

		public static string CubeGridThrusterManagerGetEnabled = "51FDDFF9224B3F717EEFFEBEA5F1BAF6";
		public static string CubeGridThrusterManagerSetEnabled = "86B66668D555E1C1B744C17D2AFA77F7";
		public static string CubeGridThrusterManagerSetControlEnabled = "BC83851AFAE183711CFB864BA6F62CC6";

		#endregion "Attributes"

		#region "Constructors and Initializers"

		public CubeGridThrusterManager( Object thrusterManager, CubeGridEntity parent )
		{
			m_thrusterManager = thrusterManager;
			m_parent = parent;
		}

		#endregion "Constructors and Initializers"

		#region "Properties"

		public Object BackingObject
		{
			get { return m_thrusterManager; }
		}

		public bool DampenersEnabled
		{
			get { return InternalGetDampenersEnabled( ); }
			set
			{
				m_dampenersEnabled = value;

				Action action = InternalUpdateDampenersEnabled;
				SandboxGameAssemblyWrapper.Instance.EnqueueMainGameAction( action );
			}
		}

		#endregion "Properties"

		#region "Methods"

		public static bool ReflectionUnitTest( )
		{
			try
			{
				bool result = true;
				Type type = SandboxGameAssemblyWrapper.Instance.GetAssemblyType( CubeGridThrusterManagerNamespace, CubeGridThrusterManagerClass );
				if ( type == null )
					throw new Exception( "Could not find type for CubeGridThrusterManager" );
				result &= BaseObject.HasMethod( type, CubeGridThrusterManagerGetEnabled );
				result &= BaseObject.HasMethod( type, CubeGridThrusterManagerSetEnabled );
				result &= BaseObject.HasMethod( type, CubeGridThrusterManagerSetControlEnabled );

				return result;
			}
			catch ( Exception ex )
			{
				LogManager.APILog.WriteLine( ex );
				return false;
			}
		}

		protected bool InternalGetDampenersEnabled( )
		{
			bool result = (bool)BaseObject.InvokeEntityMethod( BackingObject, CubeGridThrusterManagerGetEnabled );
			return result;
		}

		protected void InternalUpdateDampenersEnabled( )
		{
			foreach ( CubeBlockEntity cubeBlock in m_parent.CubeBlocks )
			{
				if ( cubeBlock is CockpitEntity )
				{
					CockpitEntity cockpit = (CockpitEntity)cubeBlock;
					if ( cockpit.IsPassengerSeat )
						continue;

					cockpit.NetworkManager.BroadcastDampenersStatus( m_dampenersEnabled );
					break;
				}
			}

			BaseObject.InvokeEntityMethod( BackingObject, CubeGridThrusterManagerSetEnabled, new object[ ] { m_dampenersEnabled } );
			//BaseObject.InvokeEntityMethod(BackingObject, CubeGridThrusterManagerSetControlEnabled, new object[] { m_dampenersEnabled });
		}

		#endregion "Methods"
	}
}