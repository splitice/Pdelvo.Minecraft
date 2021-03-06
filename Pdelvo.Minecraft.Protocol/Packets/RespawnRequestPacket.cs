﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pdelvo.Minecraft.Network;

namespace Pdelvo.Minecraft.Protocol.Packets
{
    [RequireVersion(36)]
    public class RespawnRequestPacket : Packet
    {
        public byte ResponseType { get; set; }
          /// <summary>
        /// Initializes a new instance of the <see cref="EmptyPacket"/> class.
        /// </summary>
        /// <remarks></remarks>
        public RespawnRequestPacket()
        {
            Code = 0xCD;
        }


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
            ResponseType = reader.ReadByte();
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
            writer.Write(ResponseType);
        }
    }
}
