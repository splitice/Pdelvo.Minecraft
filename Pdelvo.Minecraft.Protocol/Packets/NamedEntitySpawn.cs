﻿using Pdelvo.Minecraft.Network;

namespace Pdelvo.Minecraft.Protocol.Packets
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class NamedEntitySpawn : Packet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NamedEntitySpawn"/> class.
        /// </summary>
        /// <remarks></remarks>
        public NamedEntitySpawn()
        {
            Code = 0x14;

            MetaData = new MetadataInfo();
        }

        /// <summary>
        /// Gets or sets the entity Id.
        /// </summary>
        /// <value>The entity Id.</value>
        /// <remarks></remarks>
        public int EntityId { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        /// <remarks></remarks>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the X.
        /// </summary>
        /// <value>The X.</value>
        /// <remarks></remarks>
        public int PositionX { get; set; }
        /// <summary>
        /// Gets or sets the Y.
        /// </summary>
        /// <value>The Y.</value>
        /// <remarks></remarks>
        public int PositionY { get; set; }
        /// <summary>
        /// Gets or sets the Z.
        /// </summary>
        /// <value>The Z.</value>
        /// <remarks></remarks>
        public int PositionZ { get; set; }
        /// <summary>
        /// Gets or sets the rotation.
        /// </summary>
        /// <value>The rotation.</value>
        /// <remarks></remarks>
        public byte Rotation { get; set; }
        /// <summary>
        /// Gets or sets the pitch.
        /// </summary>
        /// <value>The pitch.</value>
        /// <remarks></remarks>
        public byte Pitch { get; set; }
        /// <summary>
        /// Gets or sets the current item.
        /// </summary>
        /// <value>The current item.</value>
        /// <remarks></remarks>
        public short CurrentItem { get; set; }

        /// <summary>
        /// Gets or sets the current item.
        /// </summary>
        /// <value>The current item.</value>
        /// <remarks></remarks>
        public MetadataInfo MetaData { get; set; }

        /// <summary>
        /// Receives the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="version">The version.</param>
        /// <remarks></remarks>
        protected override void OnReceive(BigEndianStream reader, int version)
        {
            if (reader == null)
                throw new System.ArgumentNullException("reader");
            EntityId = reader.ReadInt32();
            Name = reader.ReadString16();
            PositionX = reader.ReadInt32();
            PositionY = reader.ReadInt32();
            PositionZ = reader.ReadInt32();
            Rotation = reader.ReadByte();
            Pitch = reader.ReadByte();
            CurrentItem = reader.ReadInt16();
            if (version >= 38)
                MetaData = reader.ReadMetaData(version);
            else
            {
                MetaData = new MetadataInfo();
                MetaData.Data = new System.Collections.Generic.Dictionary<byte, object>
                {
                    {17,(byte)0},
                    {0,(byte)0},
                    {16,(byte)0},
                    {33,(short)300},
                    {72,(int)0}
                };
            }
        }

        /// <summary>
        /// Sends the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="version">The version.</param>
        /// <remarks></remarks>
        protected override void OnSend(BigEndianStream writer, int version)
        {
            if (writer == null)
                throw new System.ArgumentNullException("writer");
            writer.Write(Code);
            writer.Write(EntityId);
            writer.Write(Name);
            writer.Write(PositionX);
            writer.Write(PositionY);
            writer.Write(PositionZ);
            writer.Write(Rotation);
            writer.Write(Pitch);
            writer.Write(CurrentItem);
            if (version >= 38)
                writer.Write(MetaData);
        }
    }
}