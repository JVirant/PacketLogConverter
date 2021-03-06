using System.Collections;
using System.IO;
using System.Text;

namespace PacketLogConverter.LogPackets
{
	[LogPacket(0xEA, 01, ePacketDirection.ServerToClient, "Trade window")]
	public class StoC_0xEA_TradeWindow : Packet
	{
		protected byte[] slots;
		protected ushort unk1;
		protected ushort mithrilPlayer;
		protected ushort platinumPlayer;
		protected ushort goldPlayer;
		protected ushort silverPlayer;
		protected ushort copperPlayer;
		protected ushort unk2;
		protected ushort mithrilPartner;
		protected ushort platinumPartner;
		protected ushort goldPartner;
		protected ushort silverPartner;
		protected ushort copperPartner;
		protected ushort unk3;
		protected byte itemCount;
		protected byte tradeCode;
		protected byte repair;
		protected byte combine;
		protected StoC_0x02_InventoryUpdate.Item[] items;
		protected string tradeDescription;

		#region public access properties

		public byte[] Slots { get { return slots; } }
		public ushort Unk1 { get { return unk1; } }
		public ushort MithrilPlayer { get { return mithrilPlayer; } }
		public ushort PlatinumPlayer { get { return platinumPlayer; } }
		public ushort GoldPlayer { get { return goldPlayer; } }
		public ushort SilverPlayer { get { return silverPlayer; } }
		public ushort CopperPlayer { get { return copperPlayer; } }
		public ushort Unk2 { get { return unk2; } }
		public ushort MithrilPartner { get { return mithrilPartner; } }
		public ushort PlatinumPartner { get { return platinumPartner; } }
		public ushort GoldPartner { get { return goldPartner; } }
		public ushort SilverPartner { get { return silverPartner; } }
		public ushort CopperPartner { get { return copperPartner; } }
		public ushort Unk3 { get { return unk3; } }
		public byte ItemCount { get { return itemCount; } }
		public byte TradeCode { get { return tradeCode; } }
		public byte Repair { get { return repair; } }
		public byte Combine { get { return combine; } }
		public StoC_0x02_InventoryUpdate.Item[] Items { get { return items; } }
		public string TradeDescription { get { return tradeDescription; } }

		#endregion

		public enum tradeCommand : byte
		{
			unknown = 0,
			change = 1,
			begin = 2,
			close = 3,
		};

		public override void GetPacketDataString(TextWriter text, bool flagsDescription)
		{

			text.Write("code:{0}({8}) recieveItems:{1} repair:{2} combine:{3} unk1:{4} unk2:{5} unk3:{6} description:\"{7}\"",
				tradeCode, itemCount, repair, combine, unk1, unk2, unk3, tradeDescription, (tradeCommand)tradeCode);
			text.Write("\n\tgive money (copper:{0,-2} silver:{1,-2} gold:{2,-3} platinum:{3} mithril:{4,-3})",
				copperPlayer, silverPlayer, goldPlayer, platinumPlayer, mithrilPlayer);
			text.Write("\n\ttake money (copper:{0,-2} silver:{1,-2} gold:{2,-3} platinum:{3} mithril:{4,-3})",
				copperPartner, silverPartner, goldPartner, platinumPartner, mithrilPartner);

			text.Write("\n\tgive slots:(");
			for (byte i = 0; i < slots.Length ; i++)
			{
				if (i > 0)
					text.Write(',');
				text.Write("{0,-3}", slots[i]);
			}
			text.Write(")");

			for (int i = 0; i < itemCount; i++)
			{
				WriteItemInfo(i, text, flagsDescription);
			}

		}

		protected virtual void WriteItemInfo(int i, TextWriter text, bool flagsDescription)
		{
			StoC_0x02_InventoryUpdate.Item item = items[i];
			text.Write("\n\tslot:{0,-2} level:{1,-2} value1:0x{2:X2} value2:0x{3:X2} hand:0x{4:X2} damageType:0x{5:X2} objectType:0x{6:X2} weight:{7,-4} con:{8,-3} dur:{9,-3} qual:{10,-3} bonus:{11,-2} model:0x{12:X4} color:0x{13:X4} effect:0x{14:X2} flag:0x{15:X2} \"{16}\"",
				item.slot, item.level, item.value1, item.value2, item.hand, item.damageType, item.objectType, item.weight, item.condition, item.durability, item.quality, item.bonus, item.model, item.color, item.effect, item.flag, item.name);
			if (flagsDescription && item.name != null && item.name != "")
				text.Write(" ({0})", (StoC_0x02_InventoryUpdate.eObjectType)item.objectType);
		}

		/// <summary>
		/// Initializes the packet. All data parsing must be done here.
		/// </summary>
		public override void Init()
		{
			Position = 0;

			ArrayList tmp = new ArrayList(10);
			for (byte i = 0; i < 10; i++)
				tmp.Add(ReadByte());      // 0x00 - 0x09
			slots = (byte[])tmp.ToArray(typeof (byte));
			unk1 = ReadShort();           // 0x0A
			mithrilPlayer = ReadShort();  // 0x0C
			platinumPlayer = ReadShort(); // 0x0E
			goldPlayer = ReadShort();     // 0x10
			silverPlayer = ReadShort();   // 0x12
			copperPlayer = ReadShort();   // 0x14
			unk2 = ReadShort();           // 0x16
			mithrilPartner = ReadShort(); // 0x18
			platinumPartner = ReadShort();// 0x1A
			goldPartner = ReadShort();    // 0x1C
			silverPartner = ReadShort();  // 0x1E
			copperPartner = ReadShort();  // 0x20
			unk3 = ReadShort();           // 0x22
			itemCount = ReadByte();       // 0x24
			tradeCode = ReadByte();       // 0x25
			repair = ReadByte();          // 0x26
			combine = ReadByte();         // 0x27
			items = new StoC_0x02_InventoryUpdate.Item[itemCount];

			for (int i = 0; i < itemCount; i++)
			{
				ReadItem(i);
			}
			if (tradeCode != 3 && tradeCode != 0) // code = 3 is Close tradewindow
				tradeDescription = ReadPascalString();
		}

		protected virtual void ReadItem(int index)
		{
			StoC_0x02_InventoryUpdate.Item item = new StoC_0x02_InventoryUpdate.Item();

			item.slot = ReadByte();
			item.level = ReadByte();

			item.value1 = ReadByte();
			item.value2 = ReadByte();

			item.hand = ReadByte();
			byte temp = ReadByte(); //WriteByte((byte) ((item.Type_Damage*64) + item.Object_Type));
			item.damageType = (byte)(temp >> 6);
			item.objectType = (byte)(temp & 0x3F);
			item.weight = ReadShort();
			item.condition = ReadByte();
			item.durability = ReadByte();
			item.quality = ReadByte();
			item.bonus = ReadByte();
			item.model = ReadShort();
			item.color = ReadShort();
			item.flag = ReadByte();
			item.effect = ReadByte();
			item.name = ReadPascalString();

			items[index] = item;
		}

		/// <summary>
		/// Constructs new instance with given capacity
		/// </summary>
		/// <param name="capacity"></param>
		public StoC_0xEA_TradeWindow(int capacity) : base(capacity)
		{
		}
	}
}