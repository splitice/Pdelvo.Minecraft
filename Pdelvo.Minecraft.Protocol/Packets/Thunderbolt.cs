﻿using Pdelvo.Minecraft.Network;

namespace Pdelvo.Minecraft.Protocol.Packets
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class Thunderbolt : Packet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Thunderbolt"/> class.
        /// </summary>
        /// <remarks></remarks>
        public Thunderbolt()
        {
            Code = 0x47;
        }

        /// <summary>
        /// Gets or sets the entity Id.
        /// </summary>
        /// <value>The entity Id.</value>
        /// <remarks></remarks>
        public int EntityId { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Thunderbolt"/> is unknown.
        /// </summary>
        /// <value><c>true</c> if unknown; otherwise, <c>false</c>.</value>
        /// <remarks></remarks>
        public bool Unknown { get; set; }
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
            Unknown = reader.ReadBoolean();
            PositionX = reader.ReadInt32();
            PositionY = reader.ReadInt32();
            PositionZ = reader.ReadInt32();
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
            writer.Write(Unknown);
            writer.Write(PositionX);
            writer.Write(PositionY);
            writer.Write(PositionZ);
        }
    }
}