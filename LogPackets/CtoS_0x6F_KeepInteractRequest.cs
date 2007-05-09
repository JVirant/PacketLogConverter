using System.Text;

namespace PacketLogConverter.LogPackets
{
	[LogPacket(0x6F, -1, ePacketDirection.ClientToServer, "Keep/Tower interact")]
	public class CtoS_0x6F_KeepInteractRequest : Packet, IObjectIdPacket
	{
		protected ushort keepId;
		protected ushort componentId;
		protected ushort request;
		protected ushort hpIndex;

		/// <summary>
		/// Gets the object ids of the packet.
		/// </summary>
		/// <value>The object ids.</value>
		public ushort[] ObjectIds
		{
			get { return new ushort[] { keepId }; }
		}

		#region public access properties

		public ushort KeepId { get { return keepId; } }
		public ushort ComponentId { get { return componentId; } }
		public ushort Responce { get { return request; } }
		public ushort HPIndex { get { return hpIndex; } }

		#endregion

		public override string GetPacketDataString(bool flagsDescription)
		{
			StringBuilder str = new StringBuilder();
			string type;
			switch (request)
			{
				case 0:
					type = "interact";
					break;
				case 1:
					type = "showHookPoints";
					break;
				case 2:
					type = "chooseHookPoint";
					break;
				default:
					type = "unknown";
					break;
			}

			str.AppendFormat("keepId:0x{0:X4} componentId:{1} request:0x{2:X4}({3}) hookPointId:0x{4:X4}", keepId, componentId, request, type, hpIndex);

			return str.ToString();
		}

		/// <summary>
		/// Initializes the packet. All data parsing must be done here.
		/// </summary>
		public override void Init()
		{
			Position = 0;

			keepId = ReadShort();
			componentId = ReadShort();
			request = ReadShort();
			hpIndex = ReadShort();
		}

		/// <summary>
		/// Constructs new instance with given capacity
		/// </summary>
		/// <param name="capacity"></param>
		public CtoS_0x6F_KeepInteractRequest(int capacity) : base(capacity)
		{
		}
	}
}