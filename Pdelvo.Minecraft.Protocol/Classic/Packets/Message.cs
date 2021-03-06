﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdelvo.Minecraft.Protocol.Classic.Packets
{

    public class Message : Protocol.Packets.Packet
    {
        public byte MessageColor { get; set; }
        public string TextMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <remarks></remarks>
        public Message()
        {
            Code = 0x0D;
        }

        /// <summary>
        /// Receives the specified reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="version">The version.</param>
        /// <remarks></remarks>
        protected override void OnReceive(Network.BigEndianStream reader, int version)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            MessageColor = reader.ReadByte();
            TextMessage = reader.ReadClassicString();

        }

        /// <summary>
        /// Sends the specified writer.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="version">The version.</param>
        /// <remarks></remarks>
        protected override void OnSend(Network.BigEndianStream writer, int version)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");
            writer.Write(Code);

            writer.Write(MessageColor);
            writer.WriteClassicString(TextMessage);
        }
    }
}
