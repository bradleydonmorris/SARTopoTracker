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

namespace AgwpePort
{
    /// <summary>
    /// Provides data for the OnFrameReceived event.
    /// </summary>
    public class AgwpeEventArgs : EventArgs
    {
        private byte[] header;
        private byte[] data;
        private readonly AgwpeHeader frameHeader;
        private readonly object frameData;

        /// <summary>
        /// Gets an AgwpeHeader object representing the received AGWPE frame header.
        /// </summary>
        public AgwpeHeader FrameHeader
        {
            get { return frameHeader; }
        }

        /// <summary>
        /// Gets an object representing the received AGWPE frame data.
        /// </summary>
        /// <remarks>
        /// The returned object is specific to the DataKind value as follows:<br/>
        /// DataKind    Object type
        /// --------    --------------------
        ///     R       AgwpeVersion
        ///     G       AgwpePortInfo
        ///     g       AgwpePortCapability
        ///     X       boolean
        ///     y       int
        ///     Y       int
        ///     H       AgwpeStationsHeard
        ///     C       AgwpeAX25Connect
        ///     D       AgwpeAX25Data
        ///     d       AgwpeAX25Disconnect
        ///     U       AgwpeMoniUnproto
        ///     I       AgwpeMoniConnInfo
        ///     S       AgwpeMoniSuperInfo
        ///     T       AgwpeMoniOwn
        ///     K       AgwpeMoniRaw
        /// </remarks>
        public object FrameData
        {
            get { return frameData; }
        }

        /// <summary>
        /// Gets a byte array containing the received AGWPE frame header.
        /// </summary>
        public byte[] HeaderBytes
        {
            get { return header; }
        }

        /// <summary>
        /// Gets a byte array containing the received AGWPE frame data.
        /// </summary>
        public byte[] DataBytes
        {
            get { return data; }
        }
        
        /// <summary>
        /// Constructor for the AgwpeEventArgs class.
        /// </summary>
        /// <param name="header">A byte array containing the received AGWPE frame header.</param>
        /// <param name="data">A byte array containing the received AGWPE frame data.</param>
        public AgwpeEventArgs(byte[] header, byte[] data)
        {
            if (header != null & header.Length == 36)
            {
                this.header = new byte[36];
                header.CopyTo(this.header, 0);
            }

            if (data != null & data.Length > 0)
            {
                this.data = new byte[data.Length];
                data.CopyTo(this.data, 0);
            }

            frameHeader = new AgwpeHeader(header);

            if (frameHeader.DataLen > 0 & data.GetLength(0) >= frameHeader.DataLen)
            {
                switch (frameHeader.DataKind)
                {
                    case (byte)'R': // Version
                        frameData = new AgwpeVersion(data);
                        break;
                    case (byte)'X': // Callsign Registration
                        if (data[0] == 1)
                            frameData = true;
                        else
                            frameData = false;
                        break;
                    case (byte)'G': // Port Information
                        frameData = new AgwpePortInfo(data, frameHeader.DataLen);
                        break;
                    case (byte)'g': // Port Capability
                        frameData = new AgwpePortCapability(data);
                        break;
                    case (byte)'y': // Frames Outstanding on a Port
                    case (byte)'Y': // Frames Outstanding on a Connection
                        frameData = System.BitConverter.ToUInt32(data, 0);
                        break;
                    case (byte)'H': // Stations Heard on a Port
                        frameData = new AgwpeStationsHeard(data, frameHeader.DataLen);
                        break;
                    case (byte)'C': // AX.25 Connection Received
                    case (byte)'c': // Non-Standard AX.25 Connection Received
                    case (byte)'v': // AX.25 Connection Using Digipeaters Received
                        frameData = new AgwpeAX25Connect(data, frameHeader.DataLen);
                        break;
                    case (byte)'d': // AX.25 Disconnect Received
                    case (byte)'D': // AX.25 Connection Data
                    case (byte)'S': // Monitored Supervisory Information
                    case (byte)'T': // Monitoring Own Information
                    case (byte)'K': // Monitored Information in Raw Format
                        frameData = new AgwpeAX25Data(data, frameHeader.DataLen);
                        break;
                    case (byte)'I': // Monitored Connected Information
                        frameData = new AgwpeMoniConnInfo(data, frameHeader.DataLen);
                        break;
                    case (byte)'U': // Monitored Unproto Information
                        frameData = new AgwpeMoniUnproto(data, frameHeader.DataLen);
                        break;
                }
            }
            else
                this.frameData = null;
        }
    }

    /// <summary>
    /// Contains the header information for an AGWPE frame.
    /// </summary>
    public struct AgwpeHeader
    {
        private int port;
        private string callFrom;
        private string callTo;
        private byte dataKind;
        private byte pid;
        private uint dataLen;

        /// <summary>
        /// Gets the AGWPE configured radio port the transmission was heard on.
        /// </summary>
        public int Port
        {
            get { return port; }
        }

        /// <summary>
        /// Gets the identifier used by the originator of the packet transmission.
        /// </summary>
        public string CallFrom
        {
            get { return callFrom; }
        }

        /// <summary>
        /// Gets the registered identifier used by the intended recipient of the packet transmission.
        /// </summary>
        public string CallTo
        {
            get { return callTo; }
        }

        /// <summary>
        /// Gets the one byte identifier which indicates the type of data associated with the received AGWPE frame.
        /// </summary>
        public byte DataKind
        {
            get { return dataKind; }
        }

        /// <summary>
        /// Gets the PID of the received AGWPE frame.
        /// </summary>
        public byte Pid
        {
            get { return pid; }
        }

        /// <summary>
        /// Gets the length, in bytes, of data associated with the received AGWPE frame.
        /// </summary>
        public int DataLen
        {
            get { return (int)dataLen; }
        }

        /// <summary>
        /// Constructor for the AgwpeHeader structure.
        /// </summary>
        /// <param name="header">A byte array containing the received AGWPE frame header.</param>
        public AgwpeHeader(byte[] header)
        {
            if (header.Length == 36)
            {
                port = header[0];
                dataKind = header[4];
                pid = header[6];
                callFrom = ASCIIEncoding.UTF8.GetString(header, 8, AgwpeFrame.GetEndOfText(header, 8, 10) - 8);
                callTo = ASCIIEncoding.UTF8.GetString(header, 18, AgwpeFrame.GetEndOfText(header, 18, 10) - 18);
                dataLen = BitConverter.ToUInt32(header, 28);
            }
            else
            {
                port = 0;
                dataKind = 0;
                pid = 0;
                callFrom = "";
                callTo = "";
                dataLen = 0;
            }
        }

        public string ToString()
        {
            return "" + port + ":Fm " + callFrom + " To " + callTo + " <" + (char)dataKind + " pid=" + pid.ToString("X2") + " Len=" + dataLen + " >";
        }
    }

    /// <summary>
    /// Contains data returned in an AGWPE "R" frame.
    /// </summary>
    public struct AgwpeVersion
    {
        private int major;
        private int minor;

        /// <summary>
        /// Get the major version number of the AGWPE software.
        /// </summary>
        public int Major
        {
            get { return major; }
        }

        /// <summary>
        /// Get the minor version number of the AGWPE software.
        /// </summary>
        public int Minor
        {
            get { return minor; }
        }
        
        /// <summary>
        /// Constructor for the AgwpeVersion class.
        /// </summary>
        /// <param name="data">The data associated with the AGWPE frame information contained in an AgwpeEventArgs object.</param>
        public AgwpeVersion(byte[] data)
        {
            if (data.GetLength(0) == 8)
            {
                major = (int)System.BitConverter.ToInt16(data, 0);
                minor = (int)System.BitConverter.ToInt16(data, 4);
            }
            else
            {
                major = 0;
                minor = 0;
            }
        }

        /// <summary>
        /// Converts the numeric version information of this instance to it equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the major and minor version of the AGWPE software.</returns>
        public override string ToString()
        {
            return major.ToString() + "." + minor.ToString();
        }
    }

    /// <summary>
    /// Contains data returned in an AGWPE "G" frame: Get port information for all configured AGWPE radio ports.
    /// </summary>
    public struct AgwpePortInfo
    {
        private string infoString;
        private byte portCount;

        /// <summary>
        /// 
        /// </summary>
        public string PortInfo
        {
            get { return infoString; }
        }

        /// <summary>
        /// 
        /// </summary>
        public byte PortCount
        {
            get { return portCount; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataLen"></param>
        public AgwpePortInfo(byte[] data, int dataLen)
        {
            if (dataLen > 0 & data.GetLength(0) >= dataLen)
            {
                infoString = ASCIIEncoding.UTF8.GetString(data, 0, AgwpeFrame.GetEndOfText(data, 0, dataLen));
                portCount = data[0];
            }
            else
            {
                infoString = "";
                portCount = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return infoString;
        }
    }

    /// <summary>
    /// Contains data returned in an AGWPE "g" frame: Get port capability for a specified radio port.
    /// </summary>
    public struct AgwpePortCapability
    {
        private int baud;
        private byte trafficLevel;
        private byte txDelay;
        private byte txTail;
        private byte persist;
        private byte slotTime;
        private byte maxFrame;
        private byte activeConnections;
        private uint rxByteCount;

        public int Baud
        {
            get { return baud; }
        }

        public byte TrafficLevel
        {
            get { return trafficLevel; }
        }

        public byte TXDelay
        {
            get { return txDelay; }
        }

        public byte TXTail
        {
            get { return txTail; }
        }

        public byte Persist
        {
            get { return persist; }
        }

        public byte SlotTime
        {
            get { return slotTime; }
        }

        public byte MaxFrame
        {
            get { return maxFrame; }
        }

        public byte Connections
        {
            get { return activeConnections; }
        }

        public uint RXByteCount
        {
            get { return rxByteCount; }
        }

        public AgwpePortCapability(byte[] data)
        {
            if (data.GetLength(0) == 12)
            {
                switch (data[0])
                {
                    case 0:
                        baud = 1200;
                        break;
                    case 1:
                        baud = 2400;
                        break;
                    case 2:
                        baud = 4800;
                        break;
                    case 3:
                        baud = 9600;
                        break;
                    case 4:
                        baud = 19200;
                        break;
                    default:
                        baud = (int)data[0];
                        break;
                }
                trafficLevel = data[1];
                txDelay = data[2];
                txTail = data[3];
                persist = data[4];
                slotTime = data[5];
                maxFrame = data[6];
                activeConnections = data[7];
                rxByteCount = System.BitConverter.ToUInt32(data, 8);
            }
            else
            {
                baud = -1;
                trafficLevel = 0;
                txDelay = 0;
                txTail = 0;
                persist = 0;
                slotTime = 0;
                maxFrame = 0;
                activeConnections = 0;
                rxByteCount = 0;
            }
        }

        public override string ToString()
        {
            return "Baud: " + baud + ";Traffic Level: " + trafficLevel + ";TX Delay: " + txDelay + 
                ";TX Tail: " + txTail + ";Persist: " + persist + ";Slot Time: " + slotTime + 
                ";Max Frame: " + maxFrame + ";Active Connections: " + activeConnections + 
                ";Bytes Received in the Last Two Minutes: " + rxByteCount;
        }
    }

    /// <summary>
    /// Contains data returned in an AGWPE "H" frame: Get a list of the last 20 stations heard on a specified port. This frame is 
    /// returned by AGWPE 20 times. Once for each station in the list. The data will be "blank" for all 
    /// frames after the last station heard if less than 20 stations have been heard.
    /// </summary>
    public struct AgwpeStationsHeard
    {
        private string station;
        private DateTime firstHeard;
        private DateTime lastHeard;

        public string Station
        {
            get { return station; }
        }

        public DateTime FirstHeard
        {
            get { return firstHeard; }
        }

        public DateTime LastHeard
        {
            get { return lastHeard; }
        }

        public AgwpeStationsHeard(byte[] data, int dataLen)
        {
            station = "";
            firstHeard = DateTime.Now;
            lastHeard = DateTime.Now;

            if (dataLen > 0 & data.GetLength(0) >= dataLen)
            {
                station = ASCIIEncoding.UTF8.GetString(data, 0, 10).Trim();
                if (station.Length > 0)
                {
                    firstHeard = new DateTime(BitConverter.ToUInt16(data, dataLen - 32),
                        BitConverter.ToUInt16(data, dataLen - 30), BitConverter.ToUInt16(data, dataLen - 26),
                        BitConverter.ToUInt16(data, dataLen - 24), BitConverter.ToUInt16(data, dataLen - 22),
                        BitConverter.ToUInt16(data, dataLen - 20), BitConverter.ToUInt16(data, dataLen - 18));
                    lastHeard = new DateTime(BitConverter.ToUInt16(data, dataLen - 16),
                        BitConverter.ToUInt16(data, dataLen - 14), BitConverter.ToUInt16(data, dataLen - 10),
                        BitConverter.ToUInt16(data, dataLen - 8), BitConverter.ToUInt16(data, dataLen - 6),
                        BitConverter.ToUInt16(data, dataLen - 4), BitConverter.ToUInt16(data, dataLen - 2));
                }
            }
        }

        public override string ToString()
        {
            return station + " " + firstHeard.ToString() + " " + lastHeard.ToString();
        }
    }

    /// <summary>
    /// Contains data returned in an AGWPE "C" frame: Read AX25 Connection frames.
    /// </summary>
    public struct AgwpeAX25Connect
    {
        //private byte[] ax25Data;
        private string dataString;
        private bool localInit;
        private bool connected;

        public bool LocalInit
        {
            get { return localInit; }
        }

        public bool Connected
        {
            get { return connected; }
        }

        //public byte[] AX25Data
        //{
        //    get { return ax25Data; }
        //}

        public AgwpeAX25Connect(byte[] data, int dataLen)
        {
            if (dataLen > 0 & data.GetLength(0) >= dataLen)
            {
                //ax25Data = new byte[dataLen];
                //data.CopyTo(ax25Data, 0);
                dataString = ASCIIEncoding.UTF8.GetString(data);
                localInit = dataString.ToUpper().Contains("CONNECTED WITH");
                connected = true;
            }
            else 
            {
                //ax25Data = new byte[0];
                dataString = "";
                localInit = false;
                connected = false;
            }
        }

        public string ToString()
        {
            return dataString;
        }
    }

    /// <summary>
    /// Contains data returned in an AGWPE "d", "D", "S" "T" or "K" frame.
    /// </summary>
    public struct AgwpeAX25Data
    {
        private byte[] ax25Data;
        private string dataString;

        public byte[] AX25Data
        {
            get { return ax25Data; }
        }

        public AgwpeAX25Data(byte[] data, int dataLen)
        {
            if (dataLen > 0 & data.GetLength(0) >= dataLen)
            {
                ax25Data = new byte[dataLen];
                data.CopyTo(ax25Data, 0);
                dataString = ASCIIEncoding.UTF8.GetString(ax25Data);
            }
            else
            {
                ax25Data = new byte[0];
                dataString = "";
            }
        }

        public string ToString()
        {
            return dataString;
        }
    }

    /// <summary>
    /// Contains data returned in an AGWPE "I" frame: Read AX25 Information frames and data.
    /// </summary>
    public struct AgwpeMoniConnInfo
    {
        private byte port;
        private string ax25CallFrom;
        private string ax25CallTo;
        private string ax25Via;
        private string ax25Type;
        private int ax25RXCount;
        private int ax25TXCount;
        private byte ax25Pid;
        private int ax25Len;
        private string ax25Time;
        private string ax25Header;
        private byte[] ax25Data;
        private string dataString;

        public byte Port
        {
            get { return port; }
        }

        public string AX25CallFrom
        {
            get { return ax25CallFrom; }
        }

        public string AX25CallTo
        {
            get { return ax25CallTo; }
        }

        public string AX25Via
        {
            get { return ax25Via; }
        }

        public string AX25Type
        {
            get { return ax25Type; }
        }

        public int AX25RXCount
        {
            get { return ax25RXCount; }
        }

        public int AX25TXCount
        {
            get { return ax25TXCount; }
        }

        public byte AX25Pid
        {
            get { return ax25Pid; }
        }

        public int AX25DataLen
        {
            get { return ax25Len; }
        }

        public string AX25Time
        {
            get { return ax25Time; }
        }

        public string AX25Header
        {
            get { return ax25Header; }
        }

        public byte[] AX25Data
        {
            get { return ax25Data; }
        }

        public AgwpeMoniConnInfo(byte[] data, int dataLen)
        {
            port = 0;
            ax25CallFrom = "";
            ax25CallTo = "";
            ax25Via = "";
            ax25Type = "";
            ax25RXCount = 0;
            ax25TXCount = 0;
            ax25Pid = 0;
            ax25Len = 0;
            ax25Time = "";
            ax25Header = "";
            ax25Data = new byte[0];
            dataString = "";

            if (dataLen > 0 & data.GetLength(0) >= dataLen)
            {
                ax25Header = ASCIIEncoding.UTF8.GetString(data, 0, AgwpeFrame.GetEndOfHeader(data, dataLen)).Trim();
                try
                {
                    port = (byte)(Convert.ToByte(ax25Header.Substring(0, ax25Header.IndexOf(':'))) - 1);
                    ax25CallFrom = AgwpeFrame.Parse(ax25Header, 0, "Fm ", " To");
                    ax25CallTo = AgwpeFrame.Parse(ax25Header, 0, "To ", " <");
                    if(ax25CallTo.Contains(" Via "))
                    {
                        ax25CallTo = AgwpeFrame.Parse(ax25Header, 0, "To ", " Via");
                        ax25Via = AgwpeFrame.Parse(ax25Header, 0, "Via ", " <");
                    }
                    ax25Type = AgwpeFrame.Parse(ax25Header, 0, "<", " ");
                    ax25RXCount = Convert.ToInt32(AgwpeFrame.Parse(ax25Header, ax25Header.IndexOf("<" + ax25Type) + 2, "R", " "));
                    ax25TXCount = Convert.ToInt32(AgwpeFrame.Parse(ax25Header, ax25Header.IndexOf("<" + ax25Type) + 2, "S", " "));
                    ax25Pid = byte.Parse(AgwpeFrame.Parse(ax25Header.ToLower(), 0, "pid=", " "), System.Globalization.NumberStyles.HexNumber);
                    ax25Len = Convert.ToInt32(AgwpeFrame.Parse(ax25Header.ToLower(), 0, "len=", ">"));
                    ax25Time = AgwpeFrame.Parse(ax25Header, 0, "[", "]");
                    if (ax25Len > 0 & (data.GetLength(0) - (AgwpeFrame.GetEndOfHeader(data, dataLen) + 1)) >= ax25Len)
                    {
                        ax25Data = new byte[ax25Len];
                        ax25Data = ASCIIEncoding.UTF8.GetBytes(ASCIIEncoding.UTF8.GetChars(data, AgwpeFrame.GetEndOfHeader(data, dataLen) + 1, ax25Len));
                        dataString = ASCIIEncoding.UTF8.GetString(ax25Data, 0, AgwpeFrame.GetEndOfText(ax25Data, 0, ax25Len));
                    }
                    else
                    {
                        ax25Len = 0;
                        ax25Data = new byte[0];
                    }
                }
                catch (FormatException fe)
                { }
            }
        }

        public string ToString()
        {
            return dataString;
        }
    }

    /// <summary>
    /// Contains data returned in an AGWPE "U" frame: Read AX25 Unproto frames and data sent from a remote packet radio station.
    /// </summary>
    public struct AgwpeMoniUnproto
    {
        private byte port;
        private string ax25CallFrom;
        private string ax25CallTo;
        private string ax25Via;
        private string ax25Type;
        private byte ax25Pid;
        private int ax25Len;
        private string ax25Time;
        private string ax25Header;
        private byte[] ax25Data;
        private string dataString;


		public string DataString
		{
			get { return dataString; }
		}

		public byte Port
        {
            get { return port; }
        }

        public string AX25CallFrom
        {
            get { return ax25CallFrom; }
        }

        public string AX25CallTo
        {
            get { return ax25CallTo; }
        }

        public string AX25Via
        {
            get { return ax25Via; }
        }

        public string AX25Type
        {
            get { return ax25Type; }
        }

        public byte AX25Pid
        {
            get { return ax25Pid; }
        }

        public int AX25DataLen
        {
            get { return ax25Len; }
        }

        public string AX25Time
        {
            get { return ax25Time; }
        }

        public string AX25Header
        {
            get { return ax25Header; }
        }

        public byte[] AX25Data
        {
            get { return ax25Data; }
        }

        public AgwpeMoniUnproto(byte[] data, int dataLen)
        {
            port = 0;
            ax25CallFrom = "";
            ax25CallTo = "";
            ax25Via = "";
            ax25Type = "";
            ax25Pid = 0;
            ax25Len = 0;
            ax25Time = "";
            ax25Header = "";
            ax25Data = new byte[0];
            dataString = "";

            if (dataLen > 0 & data.GetLength(0) >= dataLen)
            {
                ax25Header = ASCIIEncoding.UTF8.GetString(data, 0, AgwpeFrame.GetEndOfHeader(data, dataLen)).Trim();
                try
                {
                    port = (byte)(Convert.ToByte(ax25Header.Substring(0, ax25Header.IndexOf(':'))) - 1);
                    ax25CallFrom = AgwpeFrame.Parse(ax25Header, 0, "Fm ", " To");
                    ax25CallTo = AgwpeFrame.Parse(ax25Header, 0, "To ", " <");
                    if(ax25CallTo.Contains(" Via "))
                    {
                        ax25CallTo = AgwpeFrame.Parse(ax25Header, 0, "To ", " Via");
                        ax25Via = AgwpeFrame.Parse(ax25Header, 0, "Via ", " <");
                    }
                    ax25Type = AgwpeFrame.Parse(ax25Header, 0, "<", " ");
                    ax25Pid = byte.Parse(AgwpeFrame.Parse(ax25Header.ToLower(), 0, "pid=", " "), System.Globalization.NumberStyles.HexNumber);
                    ax25Len = Convert.ToInt32(AgwpeFrame.Parse(ax25Header.ToLower(), 0, "len=", ">"));
                    ax25Time = AgwpeFrame.Parse(ax25Header, 0, "[", "]");
                    if (ax25Len > 0 & (data.GetLength(0) - (AgwpeFrame.GetEndOfHeader(data, dataLen) + 1)) >= ax25Len)
                    {
                        ax25Data = new byte[ax25Len];
                        ax25Data = ASCIIEncoding.UTF8.GetBytes(ASCIIEncoding.UTF8.GetChars(data, AgwpeFrame.GetEndOfHeader(data, dataLen) + 1, ax25Len));
                        dataString = ASCIIEncoding.UTF8.GetString(ax25Data, 0, AgwpeFrame.GetEndOfText(ax25Data, 0, ax25Len)).Trim();
                    }
                    else
                    {
                        ax25Len = 0;
                        ax25Data = new byte[0];
                    }
                }
                catch (FormatException fe)
                { }
            }
        }

        public string ToString()
        {
            return dataString;
        }
    }
}
