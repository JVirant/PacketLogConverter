using System;
using System.Text;

namespace PacketLogConverter.LogPackets
{
	[LogPacket(0x0C, -1, ePacketDirection.ClientToServer, "House item placement request")]
	public class CtoS_0x0C_HouseItemPlacementRequest: Packet, IOidPacket
	{
		protected ushort slot;
		protected ushort houseOid;
		protected ushort surface;
		protected byte place;
		protected byte rotation;
		protected short x;
		protected short y;

		public int Oid1 { get { return houseOid; } }
		public int Oid2 { get { return int.MinValue; } }

		#region public access properties

		public ushort Slot { get { return slot; } }
		public ushort HouseOid { get { return houseOid; } }
		public ushort Surface { get { return surface; } }
		public byte Place { get { return place; } }
		public byte Rotation { get { return rotation; } }
		public short X { get { return x; } }
		public short Y { get { return y; } }

		#endregion

		public enum ePlaceType: byte
		{
			gardenDecoration = 1,
			wallDecoration = 2,
			floorDecoration = 3,
			exteriorDecoration = 4,
			hookPoints = 5
		}

		public override string GetPacketDataString(bool flagsDescription)
		{
			StringBuilder str = new StringBuilder();

			str.AppendFormat("slot:{0,-3} houseOid:0x{1:X4} surface:{2} place:{3}({4}) rotation:{5} (x:{6} y:{7})",
				slot, houseOid, surface, place, (ePlaceType)place, rotation, x, y);

			return str.ToString();
		}

		/// <summary>
		/// Initializes the packet. All data parsing must be done here.
		/// </summary>
		public override void Init()
		{
			Position = 0;

			slot = ReadShort();
			houseOid = ReadShort();
			surface = ReadShort();
			place = ReadByte();
			rotation = ReadByte();
			x = (short)ReadShort();
			y = (short)ReadShort();
		}

		/// <summary>
		/// Constructs new instance with given capacity
		/// </summary>
		/// <param name="capacity"></param>
		public CtoS_0x0C_HouseItemPlacementRequest(int capacity) : base(capacity)
		{
		}
	}
}