using CustomsFramework;
using Server.Guilds;
using Server.Multis;
using Server.Regions;
using System;

namespace Server.Items
{
    public class Townstone : Item
    {
        private int m_GuildId;
        private string m_TownName = "Unnamed Town";
        private Region m_TownRegion;

        #region Command Properties
        [CommandProperty(AccessLevel.GameMaster)]
        public string TownName
        {
            get
            {
                return this.m_TownName;
            }
            set
            {
                this.m_TownName = value;
                this.InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int GuildId
        {
            get
            {
                return this.m_GuildId;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public Region TownRegion
        {
            get
            {
                return this.m_TownRegion;
            }
            set
            {
                this.m_TownRegion = value;
            }
        }
        #endregion

        public Townstone(BaseGuild g)
            : base(0xED4)
        {
            this.m_GuildId = g.Id;
            this.m_TownName = String.Format("{0}'s Town", g.Name);
            this.Movable = false;
        }

        public Townstone(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)1); // version
            writer.Write(this.m_GuildId);
            writer.Write(this.m_TownName);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            switch (version)
            {
                case 1:
                    {
                        this.m_GuildId = reader.ReadInt();
                        this.m_TownName = reader.ReadString();

                        goto case 0;
                    }
                case 0:
                    {
                        break;
                    }
            }
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);
        }

        public override void OnSingleClick(Mobile from)
        {
            this.LabelTo(from, this.m_TownName);
        }

        public override void OnAfterDelete()
        {
            // TODO rabbi cleanup town region?
        }

        public override void OnDoubleClick(Mobile from)
        {
            // TODO rabbi custom town system gump
        }
    }

    [Flipable(0x14F0, 0x14EF)]
    public class TownstoneDeed : Item
    {
        [Constructable]
        public TownstoneDeed() : base(0x14F0)
        {
            this.Weight = 1.0;
            this.Name = "a townstone deed";
            this.BlessItem();
        }

        public TownstoneDeed(Serial serial)
            : base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!this.IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            from.SendLocalizedMessage(1062838); // Where would you like to place this decoration?
            from.BeginTarget(-1, true, Targeting.TargetFlags.None, new TargetStateCallback(Placement_OnTarget), null);
        }

        public void Placement_OnTarget(Mobile from, object targeted, object state)
        {
            if (!this.IsChildOf(from.Backpack))
            {
                from.SendLocalizedMessage(1042001); // That must be in your pack for you to use it.
                return;
            }

            IPoint3D p = targeted as IPoint3D;
            if (p == null || this.Deleted)
                return;
            Point3D loc = new Point3D(p);

            if (from.Guild == null) 
            {
                return;
                // TODO rabbi you need to check that this is being put in a good region too, and probably some other stuff
            }

            // Create the townstone
            Item townstone = new Townstone(from.Guild);
            townstone.MoveToWorld(loc, from.Map);

            // Create the town region
            Rectangle2D townArea = new Rectangle2D(loc.X - 40, loc.Y - 40, 80, 80);
            Rectangle2D[] totalTownArea = new Rectangle2D[] { townArea };
            string regionName = String.Format("{0} Town", from.Guild.Name);
            GuildTownRegion region = new GuildTownRegion(regionName, Map.Felucca, totalTownArea, from.Guild);
            region.Register();

            ((Townstone)townstone).TownRegion = region;

            this.Delete();
        }
    }
}
