using System;
using Server;
using Server.Engines.Craft;
using Server.Network;
using Server.Targeting;

namespace Server.Items
{
	public class Hammer : BaseTool
	{
		public override CraftSystem CraftSystem{ get{ return DefCarpentry.CraftSystem; } }

		[Constructable]
		public Hammer() : base( 0x102A )
		{
			Weight = 2.0;
		}

		[Constructable]
		public Hammer( int uses ) : base( uses, 0x102A )
		{
			Weight = 2.0;
		}

		public Hammer( Serial serial ) : base( serial )
		{
		}

        public override void OnSingleClick(Mobile from)
        {
            if (this.Name != null)
            {
                from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", this.Name));
            }
            else
            {
                from.Send(new AsciiMessage(Serial, ItemID, MessageType.Label, 0, 3, "", "a hammer"));
            }
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!IsChildOf(from.Backpack))
                from.SendAsciiMessage("That must be in your pack for you to use it.");
            else
                from.Target = new CarpentryTarget(this);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}