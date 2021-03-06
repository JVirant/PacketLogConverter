using System.IO;
using System.Text;

namespace PacketLogConverter.LogPackets
{
	[LogPacket(0x6C, -1, ePacketDirection.ServerToClient, "Keep/Tower component overview")]
	public class StoC_0x6C_KeepComponentOverview : Packet, IObjectIdPacket, IKeepIdPacket
	{
		protected ushort keepId;
		protected ushort componentId;
		protected ushort unk1;
		protected ushort uid;
		protected byte skin;
		protected byte x;
		protected byte y;
		protected byte heading;
		protected byte height;
		protected byte health;
		protected byte status;
		protected byte flag;

		/// <summary>
		/// Gets the object ids of the packet.
		/// </summary>
		/// <value>The object ids.</value>
		public ushort[] ObjectIds
		{
			get { return new ushort[] { uid }; }
		}

		/// <summary>
		/// Gets the keep ids of the packet.
		/// </summary>
		/// <value>The keep ids.</value>
		public ushort[] KeepIds
		{
			get { return new ushort[] { keepId }; }
		}

		#region public access properties

		public ushort KeepId { get { return keepId; } }
		public ushort ComponentId { get { return componentId; } }
		public ushort Unk1 { get { return unk1; } }
		public ushort Uid { get { return uid; } }
		public byte Skin { get { return skin; } }
		public byte X { get { return x; } }
		public byte Y { get { return y; } }
		public byte Heading { get { return heading; } }
		public byte Height { get { return height; } }
		public byte Health { get { return health; } }
		public byte Status { get { return status; } }
		public byte Flag { get { return flag; } }

		#endregion

		public enum eKeepComponentType: byte
		{
			Gate = 0,
			WallInclined = 1,
			WallInclined2 = 2,
			WallAngle2 = 3,
			TowerAngle = 4,
			WallAngle = 5,
			WallAngleInternal = 6,
			TowerHalf = 7,
			WallHalfAngle = 8,
			Wall = 9,
			Keep = 10,
			Tower = 11,
			WallWithDoorLow = 12,
			WallWithDoorHigh = 13,
			BridgeHigh = 14,
			WallInclinedLow = 15,
			BridgeLow = 16,
			BridgeHightSolid = 17,
			BridgeHighWithHook = 18,
			GateFree = 19,
			BridgeHightWithHook2 = 20,
		}

		public enum eKeepComponentStatus: byte
		{
			Broken = 1,
			Climbable = 2,
			FixingDamaged = 3,
			BrokenTower = 4,
			RizedTower = 5,
		}
		public override void GetPacketDataString(TextWriter text, bool flagsDescription)
		{
			text.Write("keepId:0x{0:X4} componentId:{1,-2} unk1:0x{2:X4} uid:0x{3:X4} wallSkinId:{4,-3} x:{5,-3} y:{6,-3} rotate:{7} height:{8} health:{9,3}% status:0x{10:X2} flag:0x{11:X2}",
				keepId, componentId, unk1, uid, skin, (sbyte)x, (sbyte)y, heading, height, health, status, flag);
			if (flagsDescription)
			{
				byte componentType = skin;
				if (componentType > 20)
					componentType -= 20;
				text.Write(" ({1}{0}", (eKeepComponentType)componentType, skin > 20 ? "New" : "");
				if (status > 0)
					text.Write(",{0}", (eKeepComponentStatus)status);
				text.Write(')');
	
			}
		}

		/// <summary>
		/// Initializes the packet. All data parsing must be done here.
		/// </summary>
		public override void Init()
		{
			Position = 0;

			keepId = ReadShort();     // 0x00
			componentId = ReadShort();// 0x02
			unk1 = ReadShort();       // 0x04
			uid = ReadShort();        // 0x06
			skin = ReadByte();        // 0x08
			x = ReadByte();           // 0x09
			y = ReadByte();           // 0x0A
			heading = ReadByte();     // 0x0B
			height = ReadByte();      // 0x0C
			health = ReadByte();      // 0x0D
			status = ReadByte();      // 0x0E
			flag = ReadByte();        // 0x0F
		}

		/// <summary>
		/// Constructs new instance with given capacity
		/// </summary>
		/// <param name="capacity"></param>
		public StoC_0x6C_KeepComponentOverview(int capacity) : base(capacity)
		{
		}
	}
}
