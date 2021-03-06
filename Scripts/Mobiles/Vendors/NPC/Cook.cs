using System;
using System.Collections.Generic;
using Server;

namespace Server.Mobiles
{
	public class Cook : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public Cook() : base( "the cook" )
		{
			SetSkill( SkillName.Cooking, 90.0, 100.0 );
			SetSkill( SkillName.TasteID, 75.0, 98.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBCook() );

			if ( IsTokunoVendor )
				m_SBInfos.Add( new SBSECook() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.HalfApron(Utility.WhiteHue()) );
		}

		public Cook( Serial serial ) : base( serial )
		{
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