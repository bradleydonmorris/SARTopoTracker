// Copyright 2007 William U. Walker
// http://www.codeplex.com/AgwpePort
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public License
// as published by the Free Software Foundation; either version 2.1
// of the License, or (at your option) any later version.
//     
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//  
// You should have received a copy of the GNU Lesser General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace AgwpePort
{
    class AgwpeThread
    {
        protected byte state = 0;
        protected bool endThread = false;
        protected int offset = 0;
        protected uint dataLen = 0;
        protected TcpClient tcpClient;
        protected NetworkStream stream;
        protected byte[] frameBuffer = new byte[36];
        protected AgwpeData dataBuffer;
        protected AgwpePort parent;

        public const byte STANDBY = 0;
        public const byte RD_FRAME_DATA = 1;
        public const byte RD_PKT_DATA = 2;
        public const byte FRAME_DATA_RDY = 3;
        public const byte PKT_DATA_RDY = 4;

        public AgwpeThread(byte radioPort, string host, int port, AgwpePort parent)
        {
            this.parent = parent;
            tcpClient = new TcpClient(host, port);
            stream = tcpClient.GetStream();
            dataBuffer = new AgwpeData();
        }

        // This method will be called when the thread is started.
        public void Monitor()
        {
            int dataByte;

            while (!endThread)
            {
                if (stream.DataAvailable)
                {
                    switch (state)
                    {
                        case STANDBY: // Transaction complete, standing by
                        case RD_FRAME_DATA: // Reading incoming frame data
                            state = RD_FRAME_DATA;
                            offset += stream.Read(frameBuffer, offset, 36 - offset);
                            if (offset == 36)
                            {
                                offset = 0;
                                dataLen = BitConverter.ToUInt32(frameBuffer, 28);
                                if (dataLen > 0)
                                    state = RD_PKT_DATA;
                            }
                            break;
                        case RD_PKT_DATA: // Reading incoming packet data
                            if (dataLen > 0)
                            {
                                dataByte = stream.ReadByte();
                                if (dataByte >= 0)
                                {
                                    dataBuffer.AddByte((byte)dataByte);
                                    --dataLen;
                                    if (dataLen == 0)
                                    {
                                        state = STANDBY;
                                        if (dataBuffer.Count >= BitConverter.ToUInt32(frameBuffer, 28))
                                            parent.OnFrameReceived(new AgwpeEventArgs(frameBuffer, dataBuffer.ToByteArray()));
                                    }
                                }
                            }
                            break;
                    }
                }
                // Pause to allow the system to work on other waiting threads.
                Thread.Sleep(1);
            }
            // Close the NetworkStream.
            stream.Close();
            // Close the TcpClient.
            tcpClient.Close();
            stream = null;
        }

        public bool Connected()
        {
            if (tcpClient != null)
                return tcpClient.Connected;
            else
                return false;
        }
        
        public bool DataAvailable()
        { 
            return stream.DataAvailable; 
        } 
        
        public void Write(byte[] buffer)
        {
            if (stream != null)
            {
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        public void WriteByte(byte value)
        {
            if (stream != null)
                stream.WriteByte(value);
        }

        public int Read(byte[] buffer, int offset, int size)
        {
            return dataBuffer.GetBytes(buffer, offset, size);
        }

        public byte ReadByte()
        {
            return dataBuffer.GetByte();
        }

        public void End()
        {
            endThread = true;
        }
    }
}
