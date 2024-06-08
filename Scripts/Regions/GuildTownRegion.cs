using Server.Guilds;
using System.Xml;

namespace Server.Regions
{
    public class GuildTownRegion : BaseRegion
    {
        public GuildTownRegion(XmlElement xml, Map map, Region parent, Guild guild)
            : base(xml, map, parent)
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
