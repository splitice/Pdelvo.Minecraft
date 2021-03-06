﻿using Pdelvo.Minecraft.Network;

namespace Pdelvo.Minecraft.Protocol.Packets
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    public class OpenWindow : Packet
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenWindow"/> class.
        /// </summary>
        /// <remarks></remarks>
        public OpenWindow()
        {
            Code = 0x64;
        }

        /// <summary>
        /// Gets or sets the window Id.
        /// </summary>
        /// <value>The window Id.</value>
        /// <remarks></remarks>
        public byte WindowId { get; set; }
        /// <summary>
        /// Gets or sets the type of the inventory.
        /// </summary>
        /// <value>The type of the inventory.</value>
        /// <remarks></remarks>
        public byte InventoryType { get; set; }
        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>The window title.</value>
        /// <remarks></remarks>
        public string WindowTitle { get; set; }
        /// <summary>
        /// Gets or sets the slots.
        /// </summary>
        /// <value>The slots.</value>
        /// <remarks></remarks>
        public byte Slots { get; set; }

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
            WindowId = reader.ReadByte();
            InventoryType = reader.ReadByte();
            WindowTitle = reader.ReadString16();
            Slots = reader.ReadByte();
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
            writer.Write(WindowId);
            writer.Write(InventoryType);
            writer.Write(WindowTitle);
            writer.Write(Slots);
        }
    }
}