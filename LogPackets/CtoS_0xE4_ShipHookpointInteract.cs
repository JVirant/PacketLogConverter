using System.IO;
using System.Text;

namespace PacketLogConverter.LogPackets
{
	[LogPacket(0xE4, -1, ePacketDirection.ClientToServer, "Ship hookpoint interact")]
	public class CtoS_0xE4_ShipHookpointInteract: Packet, IObjectIdPacket
	{
		protected ushort unk1;
		protected ushort objectOid;
		protected ushort unk2;
		protected byte slot;
		protected byte flag;
		protected byte currency;
		protected byte unk3;
		protected ushort unk4;
		protected uint type; // 00 - buy item from store, 01-choose shippoint, 02-choose shopShipPoint

		/// <summary>
		/// Gets the object ids of the packet.
		/// </summary>
		/// <value>The object ids.</value>
		public ushort[] ObjectIds
		{
			get { return new ushort[] { objectOid }; }
		}

		public enum eType: uint
		{
			SwitchToSeat = 1,
			ShipStore = 2,
		}

		#region public access properties

		public ushort ObjectOid { get { return objectOid; } }
		public byte Slot { get { return slot; } }
		public byte Flag { get { return flag; } }
		public byte Currency { get { return currency; } }
		public uint Type { get { return type; } }

		#endregion

		public override void GetPacketDataString(TextWriter text, bool flagsDescription)
		{
			text.Write("unk1:0x{0:X4} objectOid:0x{1:X4} unk2:0x{2:X4} slot:{3,-2} flag:{4} currency:{5} unk3:0x{6:X2} unk4:0x{7:X4} type:{8}{9}",
				unk1, objectOid, unk2, slot, flag, currency, unk3, unk4, type, flagsDescription ? "(" + (eType)type + ")" : "");
		}

		/// <summary>
		/// Initializes the packet. All data parsing must be done here.
		/// </summary>
		public override void Init()
		{
			Position = 0;
			unk1 = ReadShort();
			objectOid = ReadShort();
			unk2 = ReadShort();
			slot = ReadByte();
			flag = ReadByte();
			currency = ReadByte();
			unk3 = ReadByte();
			unk4 = ReadShort();
			type = ReadIntLowEndian();
//			unk5 = ReadByte();
//			unk6 = ReadShort();
		}

		/// <summary>
		/// Constructs new instance with given capacity
		/// </summary>
		/// <param name="capacity"></param>
		public CtoS_0xE4_ShipHookpointInteract(int capacity) : base(capacity)
		{
		}
	}
}