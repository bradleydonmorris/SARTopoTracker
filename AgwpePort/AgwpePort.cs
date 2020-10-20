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
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Drawing;

namespace AgwpePort
{
    [ToolboxBitmap(typeof(AgwpePort), "AgwpePort")]
    public partial class AgwpePort : Component
    {
        protected string agwpeHost = "localhost";
        protected int port = 8000;
        protected byte radioPort = 0;
        protected long timeOut = 3000;
        private AgwpeThread agwpeThreadObject;
        private Thread thread;

        // Properties
        /// <summary>
        /// Gets or sets the AGWPE configured radio port to use for sending and receiving packet data.
        /// </summary>
        public byte RadioPort
        {
            set { radioPort = value; }
            get { return radioPort; }
        }

        /// <summary>
        /// Gets or sets the hostname or IP address of the machine running a AGWPE process.
        /// </summary>
        public string Host
        {
            set { agwpeHost = value; }
            get { return agwpeHost; }
        }

        /// <summary>
        /// Gets or sets the TCP port number used to connect to a running AGWPE process.
        /// </summary>
        public int Port
        {
            set { port = value; }
            get { return port; }
        }

        /// <summary>
        /// Gets or sets the timeout value, in milliseconds, used when waiting on data to be read from AGWPE.
        /// </summary>
        public long TimeOut
        {
            set { timeOut = value; }
            get { return timeOut; }
        }

        // Constructors
        /// <summary>
        /// Constructor for the AgwpePort class which initializes the component then creates a new thread to 
        /// connect to a AGWPE process running on host/port.
        /// The radioPort, agwpeHost and port are initialize to 0, "localhost" and 8000 respectively.
        /// </summary>
        public AgwpePort()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for the AgwpePort class, used by the Visual Studio IDE, which initializes the component 
        /// then creates a new thread to connect to a AGWPE process running on host/port.
        /// The radioPort, agwpeHost and port are initialize to 0, "localhost" and 8000 respectively.
        /// </summary>
        public AgwpePort(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// Constructor for the AgwpePort class which initializes the component then creates a new thread to 
        /// connect to a AGWPE process running on host/port.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        public AgwpePort(byte radioPort)
        {
            InitializeComponent();
            this.radioPort = radioPort;
        }

        /// <summary>
        /// Constructor for the AgwpePort class which initializes the component then creates a new thread to 
        /// connect to a AGWPE process running on host/port.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        /// <param name="host">The hostname or IP address of the machine running AGWPE, default is "localhost".</param>
        public AgwpePort(byte radioPort, string host)
        {
            InitializeComponent();
            this.radioPort = radioPort;
            agwpeHost = host;
        }

        /// <summary>
        /// Constructor for the AgwpePort class which initializes the component then creates a new thread to 
        /// connect to a AGWPE process running on host/port.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        /// <param name="host">The hostname or IP address of the machine running AGWPE, default is "localhost".</param>
        /// <param name="port">The TCP port that AGWPE is listening on, default is port 8000.</param>
        public AgwpePort(byte radioPort, string host, int port)
        {
            InitializeComponent();
            this.radioPort = radioPort;
            agwpeHost = host;
            this.port = port;
        }

        // Methods
        /// <summary>
        /// Creates a new thread to connect to a AGWPE process running on host/port.
        /// </summary>
        public void Open()
        {
            if (thread == null)
            {
                agwpeThreadObject = new AgwpeThread(radioPort,agwpeHost,port,this);
                thread = new Thread(agwpeThreadObject.Monitor);
                thread.Start();
            }
        }

        /// <summary>
        /// Creates a new thread to connect to a AGWPE process running on host/port.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        public void Open(byte radioPort)
        {
            this.radioPort = radioPort;
            Open();
        }

        /// <summary>
        /// Creates a new thread to connect to a AGWPE process running on host/port.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        /// <param name="host">The hostname or IP address of the machine running AGWPE, default is "localhost".</param>
        public void Open(byte radioPort, string host)
        {
            this.radioPort = radioPort;
            agwpeHost = host;
            Open();
        }

        /// <summary>
        /// Creates a new thread to connect to a AGWPE process running on host/port.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        /// <param name="host">The hostname or IP address of the machine running AGWPE, default is "localhost".</param>
        /// <param name="port">The TCP port that AGWPE is listening on, default is port 8000.</param>
        public void Open(byte radioPort, string host, int port)
        {
            this.radioPort = radioPort;
            agwpeHost = host;
            this.port = port;
            Open();
        }

        /// <summary>
        /// Closes the connection and ends the thread used to talk to the AGWPE process.
        /// </summary>
        public void Close()
        {
            if (thread != null)
            {
                if (thread.IsAlive)
                {
                    // Send the stop request to the thread.
                    agwpeThreadObject.End();
                    // Give the thread 1 second to terminate.
                    thread.Join(1000);
                }
            }
            agwpeThreadObject = null;
            thread = null;
        }

        /// <summary>
        /// Checks to see if any data is ready to be read from the AGWPE connection.
        /// </summary>
        /// <returns>Returns true if data is available.</returns>
        public bool DataAvailable()
        {
            if (IsOpen())
                return agwpeThreadObject.DataAvailable();
            else
                return false;
        }

        /// <summary>
        /// Checks to see if the connection thread and TCP connection are alive.
        /// </summary>
        /// <returns>Returns true if the thread and connection are alive.</returns>
        public bool IsOpen()
        {
            if (thread != null)
                if (thread.IsAlive)
                    return agwpeThreadObject.Connected();
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataKind"></param>
        /// <param name="dataLen"></param>
        /// <returns></returns>
        private byte[] GetAgwpeFrame(byte dataKind, uint dataLen)
        {
            byte[] frame = new byte[dataLen + 36];
            // Set the DataKind byte in the AGWPE frame.
            frame[AgwpeFrame.DATAKIND] = dataKind;
            // Copy the four byte array containing the DataLen value to the AGWPE frame.
            BitConverter.GetBytes(dataLen).CopyTo(frame, AgwpeFrame.DATALEN);
            return (frame);
        }

        /// <summary>
        /// Converts the String array past in the via parameter to a single byte array containing data 
        /// from all elements of the original String array.
        /// </summary>
        /// <param name="via">A String array containing a list of relay stations, one in each element of the array.</param>
        /// <returns>A single byte array containing data from all elements of the original String array.
        /// </returns>
        private byte[] GetViaChain(string[] via)
        {
            byte[] viaData;
            int viaCount = 0, offset = 0;

            for (int count = 0; count < via.Length ; count++)
            {
                // Remove leading and trailing white-space characters from each via String.
                via[count] = via[count].Trim();
                // If the via String still contains characters...
                if (via[count].Length > 0)
                    // Increment the valid via counter.
                    viaCount++;
            }
            if (viaCount > 0)
            {
                viaData = new byte[(viaCount * 10) + 1];
                viaData[0] = (byte)viaCount;
                for (int count = 0; count < via.Length; count++)
                {
                    if (via[count].Length > 0)
                    {
                        ASCIIEncoding.UTF8.GetBytes(via[count], 0, via[count].Length, viaData, (offset * 10) + 1);
                        offset++;
                    }
                }
                return viaData;
            }
            return null;
        }

        //----------------------------------------------------------------------------
        /// <summary>
        /// Sends login information to a AGWPE process running on a remote machine.
        /// </summary>
        /// <param name="userName">A Login name as configured in the WinSock Interface Security tab of AGWPE.</param>
        /// <param name="password">A Password as configured in the WinSock Interface Security tab of AGWPE.</param>
        public void AppLogin(string userName, string password)
        {
            byte[] frame = GetAgwpeFrame((byte)'P', 510);

            // Test to ensure the username and password do not exceed 255 bytes.

            // Copy the username and password characters to the frame as bytes.
            ASCIIEncoding.UTF8.GetBytes(userName, 0, userName.Length, frame, AgwpeFrame.DATASTART);
            ASCIIEncoding.UTF8.GetBytes(password, 0, password.Length, frame, 291);

            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// An application needs to register at least one callsign with AGWPE as a pre-requisite to be able to send data thru an AX.25
        /// port or to sustain a connection and before any attempt to do so.
        /// An application could register almost anything as a callsign, for example: W5ZIO-1 or EOC
        /// </summary>
        /// <param name="callSign">An identifier for this station.</param>
        /// <returns>Returns true or false depending on the success of the registration.</returns>
        public void RegisterCallSign(string callSign)
        {
            byte[] frame = GetAgwpeFrame((byte)'X', 0);

            // Test to ensure the callsign does not exceed 10 bytes.

            // Copy the callsign characters to the frame as bytes.
            ASCIIEncoding.UTF8.GetBytes(callSign, 0, callSign.Length, frame, AgwpeFrame.CALLFROM);
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// This is the opposite function of RegisterCallSign, it means the callsign is no longer used by the
        /// application. From the moment the application becomes unregistered, all activity heard by AGWPE on the AX.25 
        /// ports directed to that callsign is ignored.
        /// </summary>
        /// <param name="callFrom">The identifier being unregistered.</param>
        public void UnRegisterCallSign(string callSign)
        {
            byte[] frame = GetAgwpeFrame((byte)'x', 0);

            // Test to ensure the callsign does not exceed 10 bytes.

            // Copy the callsign characters to the frame as bytes.
            ASCIIEncoding.UTF8.GetBytes(callSign, 0, callSign.Length, frame, AgwpeFrame.CALLFROM);
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Requests the major and minor version from the AGWPE process application.
        /// </summary>
        public void GetVersion()
        {
            agwpeThreadObject.Write(GetAgwpeFrame((byte)'R', 0));
        }

        /// <summary>
        /// Requests information about all currently defined radio ports.
        /// </summary>
        public void GetPortInfo()
        {
            agwpeThreadObject.Write(GetAgwpeFrame((byte)'G', 0));
        }

        /// <summary>
        /// Requests information about a specific radio port.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port information is being requested for.</param>
        public void GetPortCapability(byte radioPort)
        {
            byte[] frame = GetAgwpeFrame((byte)'g', 0);

            // Copy the radioPort value to the frame.
            frame[AgwpeFrame.PORT] = radioPort;
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Requests the number of frames queued to be transmitted on a currently defined radio port for the connection specified
        /// by the callFrom and callTo parameters.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port information is being requested for.</param>
        /// <param name="callFrom">An identifier for this station if this station initiated the connection, or the remote station otherwise.</param>
        /// <param name="callTo">The identifier of the remote packet station if the remote station initiated the connection, or this station otherwise.</param>
        public void GetConnectionFrames(byte radioPort, string callFrom, string callTo)
        {
            byte[] frame;

            frame = GetAgwpeFrame((byte)'Y', 0);

            frame[AgwpeFrame.PORT] = radioPort;
            ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
            ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Requests the total number of frames, queued by all connections, to be transmitted on a currently defined radio port.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port information is being requested for.</param>
        public void GetOutstandingFrames(byte radioPort)
        {
            byte[] frame = GetAgwpeFrame((byte)'y', 0);

            // Copy the radioPort value to the frame.
            frame[AgwpeFrame.PORT] = radioPort;
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Requests the last 20 stations heard by AGWPE. THe stations heard will be returned by 20 different AGWPE frames,
        /// each containing one station heard or default information if less than 20 stations have been heard. 
        /// These 20 stations are stored in AGWPE, so each time AGWPE is started the list starts over with 0 stations heard.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port the station list is being requested for.</param>
        public void StationsHeard(byte radioPort)
        {
            byte[] frame = GetAgwpeFrame((byte)'H', 0);

            // Copy the radioPort value to the frame.
            frame[AgwpeFrame.PORT] = radioPort;
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Enable monitoring of activity on all configured radio ports. Traffic is not filtered by any callsign.
        /// </summary>
        public void StartMonitoring()
        {
            agwpeThreadObject.Write(GetAgwpeFrame((byte)'m', 0));
        }

        /// <summary>
        /// Used to send AX.25 unproto (UI) frames. No callsign registration is required before using this method.
        /// This method is used for APRS, beacons, message broadcasts, NETROM L3 broadcasts, 
        /// TCP/IP over AX.25, FBB mail, etc.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending packet data.</param>
        /// <param name="callFrom">An identifier for this station.</param>
        /// <param name="callTo">The identifier of the remote packet station.</param>
        /// <param name="data">A byte array of data to be sent.</param>
        public void SendUnproto(byte radioPort, string callFrom, string callTo, byte[] data)
        {
            byte[] frame;

            if(data != null & data.Length > 0)
                frame = GetAgwpeFrame((byte)'M', (uint)data.Length);
            else
                frame = GetAgwpeFrame((byte)'M', 0);

            frame[AgwpeFrame.PORT] = radioPort;
            ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
            ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
            if(data.Length > 0)
                data.CopyTo(frame, AgwpeFrame.DATASTART);
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Used to send AX.25 unproto (UI) frames. No callsign registration is required before using this method.
        /// This method is used for APRS, beacons, message broadcasts, NETROM L3 broadcasts, 
        /// TCP/IP over AX.25, FBB mail, etc.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending packet data.</param>
        /// <param name="callFrom">An identifier for this station.</param>
        /// <param name="callTo">The identifier of the remote packet station.</param>
        /// <param name="data">A byte array of data to be sent.</param>
        /// <param name="via">A String array containing a list of relay stations, one in each element of the array.</param>
        public void SendUnproto(byte radioPort, string callFrom, string callTo, byte[] data, string[] via)
        {
            byte[] frame;
            byte[] viaChain;

            viaChain = GetViaChain(via);
            if (viaChain != null)
            {
                if (data != null & data.Length > 0)
                    frame = GetAgwpeFrame((byte)'V', (uint)viaChain.Length + (uint)data.Length);
                else
                    frame = GetAgwpeFrame((byte)'V', (uint)viaChain.Length);

                frame[AgwpeFrame.PORT] = radioPort;
                ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
                ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
                viaChain.CopyTo(frame, AgwpeFrame.DATASTART);
                if (data.Length > 0)
                    data.CopyTo(frame, AgwpeFrame.DATASTART + viaChain.Length);
                agwpeThreadObject.Write(frame);
            }
            else
                SendUnproto(radioPort, callFrom, callTo, data);
        }

        /// <summary>
        /// Used to send port and callsign information to AGWPE when an AX.25 connection with another station is required.
        /// The station originating the connection (CallFrom) must have been previously registered with AGWPE for the
        /// connection to be successfully established.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        /// <param name="callFrom">An identifier for this station.</param>
        /// <param name="callTo">The identifier of the remote packet station.</param>
        public void AX25Connect(byte radioPort, string callFrom, string callTo)
        {
            byte[] frame;

            frame = GetAgwpeFrame((byte)'C', 0);

            frame[AgwpeFrame.PORT] = radioPort;
            frame[AgwpeFrame.PID] = 0xF0;
            ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
            ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Used to send port and callsign information to AGWPE when an AX.25 connection with another station is required.
        /// The station originating the connection (CallFrom) must have been previously registered with AGWPE for the
        /// connection to be successfully established.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        /// <param name="callFrom">An identifier for this station.</param>
        /// <param name="callTo">The identifier of the remote packet station.</param>
        /// <param name="via">A String array containing a list of relay stations, one in each element of the array.</param>
        public void AX25Connect(byte radioPort, string callFrom, string callTo, string[] via)
        {
            byte[] frame;
            byte[] viaChain;

            viaChain = GetViaChain(via);
            if (viaChain != null)
            {
                frame = GetAgwpeFrame((byte)'v', (uint)viaChain.Length);

                frame[AgwpeFrame.PORT] = radioPort;
                frame[AgwpeFrame.PID] = 0xF0;
                ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
                ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
                viaChain.CopyTo(frame, AgwpeFrame.DATASTART);
                agwpeThreadObject.Write(frame);
            }
            else
                AX25Connect(radioPort, callFrom, callTo);
        }

        /// <summary>
        /// Used to send port and callsign information to AGWPE when an AX.25 connection with another station is required.
        /// The station originating the connection (CallFrom) must have been previously registered with AGWPE for the
        /// connection to be successfully established.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending and receiving packet data.</param>
        /// <param name="callFrom">An identifier for this station.</param>
        /// <param name="callTo">The identifier of the remote packet station.</param>
        /// <param name="pid">The non-standard AX.25 PID to be used for this connection. AX.25 data frames must use the same PID.</param>
        public void AX25Connect(byte radioPort, string callFrom, string callTo, byte pid)
        {
            byte[] frame;

            frame = GetAgwpeFrame((byte)'c', 0);

            frame[AgwpeFrame.PORT] = radioPort;
            frame[AgwpeFrame.PID] = pid;
            ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
            ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Used to send data over an established AX.25 connection.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending packet data.</param>
        /// <param name="callFrom">An identifier for this station.</param>
        /// <param name="callTo">The identifier of the remote packet station.</param>
        /// <param name="data">A byte array of data to be sent.</param>
        public void SendAX25Data(byte radioPort, string callFrom, string callTo, byte[] data)
        {
            byte[] frame;

            if (data != null & data.Length > 0)
                frame = GetAgwpeFrame((byte)'D', (uint)data.Length);
            else
                frame = GetAgwpeFrame((byte)'D', 0);

            frame[AgwpeFrame.PORT] = radioPort;
            frame[AgwpeFrame.PID] = 0xF0;
            ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
            ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
            if (data.Length > 0)
                data.CopyTo(frame, AgwpeFrame.DATASTART);
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Used to send data over an established AX.25 connection.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio port to use for sending packet data.</param>
        /// <param name="callFrom">An identifier for this station.</param>
        /// <param name="callTo">The identifier of the remote packet station.</param>
        /// <param name="data">A byte array of data to be sent.</param>
        /// <param name="pid">The non-standard AX.25 PID to be used for this connection. The AX.25 connection frame must use the same PID.</param>
        public void SendAX25Data(byte radioPort, string callFrom, string callTo, byte[] data, byte pid)
        {
            byte[] frame;

            if (data != null & data.Length > 0)
                frame = GetAgwpeFrame((byte)'D', (uint)data.Length);
            else
                frame = GetAgwpeFrame((byte)'D', 0);

            frame[AgwpeFrame.PORT] = radioPort;
            frame[AgwpeFrame.PID] = pid;
            ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
            ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
            if (data.Length > 0)
                data.CopyTo(frame, AgwpeFrame.DATASTART);
            agwpeThreadObject.Write(frame);
        }

        /// <summary>
        /// Used to send port and callsign information to AGWPE to disconnect an AX.25 connection with another station.
        /// If a disconnection request is sent without a connection first being established, AGWPE will ignore the request.
        /// </summary>
        /// <param name="radioPort">The AGWPE configured radio used by the established connection.</param>
        /// <param name="callFrom">An identifier for this station.</param>
        /// <param name="callTo">The identifier of the remote packet station.</param>
        public void AX25Disconnect(byte radioPort, string callFrom, string callTo)
        {
            byte[] frame;

            frame = GetAgwpeFrame((byte)'d', 0);

            frame[AgwpeFrame.PORT] = radioPort;
            frame[AgwpeFrame.PID] = 0xF0;
            ASCIIEncoding.UTF8.GetBytes(callFrom, 0, callFrom.Length, frame, AgwpeFrame.CALLFROM);
            ASCIIEncoding.UTF8.GetBytes(callTo, 0, callTo.Length, frame, AgwpeFrame.CALLTO);
            agwpeThreadObject.Write(frame);
        }

        // Events
        public delegate void AgwpeFrameReceivedEventHandler(object sender, AgwpeEventArgs e);
        public event AgwpeFrameReceivedEventHandler FrameReceived;
        public virtual void OnFrameReceived(AgwpeEventArgs e)
        {
            if (FrameReceived != null)
                FrameReceived(this, e);
        }
    }
}
