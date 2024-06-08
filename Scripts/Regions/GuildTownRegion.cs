using Server.Guilds;
using System.Xml;

namespace Server.Regions
{
    public class GuildTownRegion : BaseRegion
    {
        public GuildTownRegion(string name, Map map, Rectangle2D[] area, BaseGuild guild)
            : base(name, map, 1, area)
        {
            m_owningGuildId = guild.Id;
        }

        private int m_owningGuildId;
        private bool m_PublicHousing;

        public override bool AllowHousing(Mobile from, Point3D p)
        {
            return from.Guild.Id == OwningGuildId;
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
                return this.m_PublicHousing;
            }
        }
        #endregion
    }
}
