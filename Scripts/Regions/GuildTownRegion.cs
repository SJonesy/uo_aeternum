using Server.Factions;
using Server.Guilds;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using System.Xml;

namespace Server.Regions
{
    public class GuildTownRegion : BaseRegion
    {
        public GuildTownRegion(string name, Map map, Rectangle2D[] area, BaseGuild guild, Townstone townStone)
            : base(name, map, 1, area)
        {
            m_owningGuildId = guild.Id;
            m_townStone = townStone;
        }

        private int m_owningGuildId;
        private bool m_publicHousing;
        private Townstone m_townStone;

        public override bool AllowHousing(Mobile from, Point3D p)
        {
            return from.Guild.Id == OwningGuildId;
        }

        public override void OnEnter(Mobile m)
        {
            if (m is PlayerMobile)
            {
                m.SendMessage("Now entering: {0}", m_townStone.TownName);
            }
        }

        public override void OnExit(Mobile m)
        {
            if (m is PlayerMobile)
            {
                m.SendMessage("Now leaving: {0}", m_townStone.TownName);
            }
        }

        #region Command Properties
        [CommandProperty(AccessLevel.GameMaster)]
        public int OwningGuildId
        {
            get
            {
                return this.m_owningGuildId;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public bool PublicHousing
        {
            get
            {
                return this.m_publicHousing;
            }
        }
        #endregion
    }
}
