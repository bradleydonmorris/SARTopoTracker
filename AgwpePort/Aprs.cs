// Copyright 2008 William U. Walker
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
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace AgwpePort.Aprs
{
    #region " Enumeration definitions "
    /// <summary>
    /// Specifies values that describe APRS data types.
    /// </summary>
    public enum AprsDataType
    {
        InvalidOrTest = 0,
        Unused = 1,
        WeatherReport = 2,
        PositionNoTimeNoMessage = 3,
        PositionWithTimeNoMessage = 4,
        PositionNoTimeWithMessage = 5,
        PositionWithTimeWithMessage = 6,
        Object = 7,
        Item = 8,
        Message = 9,
        Bulletin = 10,
        Announcement = 11,
        Query = 12,
        Status = 13,
        ThirdParty = 14
    }

    /// <summary>
    /// Specifies values that describe APRS data extension types.
    /// </summary>
    public enum DataExtensionType 
    {
        None = 0, 
        CourseSpeed = 1, 
        PowerHeightGain = 2, 
        PreCalcRadioRange = 3, 
        DFStrengthHeightGain = 4, 
        StormData = 5,
        AreaObject = 6,
        SignPost = 7
    }

    /// <summary>
    /// Specifies values that describe the APRS Object status.
    /// </summary>
    public enum AprsObjectItemStatus
    {
        Killed = 0,
        Alive = 1,
        None = 2
    }
    
    /// <summary>
    /// 
    /// </summary>
    public enum AprsAreaObject
    {
        OpenCircle = 0,
        LineDownRight = 1,
        OpenEllipse = 2,
        OpenTriangle = 3,
        OpenBox = 4,
        FilledCircle = 5,
        LineDownLeft = 6,
        FilledEllipse = 7,
        FilledTriangle = 8,
        FilledBox = 9,
        None = 10
    }

    /// <summary>
    /// 
    /// </summary>
    public enum AprsAreaColor
    {
        Grey = 0,
        Blue = 1,
        Green = 2,
        Cyan = 3,
        Red = 4,
        Magenta = 5,
        Yellow = 6,
        Silver = 7,
        Black = 8,
        DarkBlue = 9,
        DarkGreen = 10,
        DarkCyan = 11,
        DarkRed = 12,
        DarkMagenta = 13,
        Brown = 14,
        DarkGrey = 15
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public partial class AprsData
    {
        #region " Private members and public property definitions "
        private AprsDataType dataType;
        private string dataTypeString;
        private string name;
        private AprsObjectItemStatus objectItemStatus;
        private string timeStamp;
        private string longitude;
        private string latitude;
        private int course;
        private int speed;
        private int altitude;
        private string symbolTableCode;
        //private byte[] micEData;
        //private string nmeaSentence;
        //private string wxStationData;
        private string comment;
        private int txPower;
        private int antennaHaat;
        private int antennaGain;
        private int antennaDir;
        private double radioRange;
        private double pcRadioRange;
        private DataExtensionType extType;
        private AprsAreaObject areaObject;
        private AprsAreaColor areaColor;
        private int areaLatOffset;
        private int areaLonOffset;
        private string messageAddressee;
        private string messageText;
        private string messageNumber;
        private string thirdPartySource;
        private string thirdPartyDest;
        private string thirdPartyVia;
        private byte[] thirdPartyData;
        
        /// <summary>
        /// Gets the enumerated type of the data represented in the APRS object.
        /// </summary>
        public AprsDataType DataType
        {
            get { return dataType; }
        }

        /// <summary>
        /// Gets a string which describes the APRS data type represented by this instance of AprsPacket.
        /// </summary>
        public string DataTypeString
        {
            get { return dataTypeString; }
        }

        public DateTime TimeStamp
        {
            get { return AprsCalc.TimeStampToDateTime(timeStamp); }
        }

        public string TimeStampString
        {
            get { return timeStamp; }
        }

        public string Name
        {
            get { return name; }
        }

        public AprsObjectItemStatus Status
        {
            get { return objectItemStatus; }
        }

        public double Longitude
        {
            get { return AprsCalc.LatLonToDouble(longitude); }
        }

        public double Latitude
        {
            get { return AprsCalc.LatLonToDouble(latitude); }
        }

        public int Course
        {
            get { return course; }
        }

        public int Speed
        {
            get { return speed; }
        }

        public int Altitude
        {
            get { return altitude; }
        }

        public string SymbolTableCode
        {
            get { return symbolTableCode; }
        }

        public string Comment
        {
            get { return comment; }
        }

        public int TxPower
        {
            get { return txPower; }
        }

        public int HeightAboveAvgTerrain
        {
            get { return antennaHaat; }
        }

        public int AntennaGain
        {
            get { return antennaGain; }
        }

        public double RadioRange
        {
            get { return radioRange; }
        }

        public double PreCalcRadioRange
        {
            get { return pcRadioRange; }
        }

        public DataExtensionType DataExtensionType
        {
            get { return extType; }
        }

        public AprsAreaObject AreaObject
        {
            get { return areaObject; }
        }

        public AprsAreaColor AreaColor
        {
            get { return areaColor; }
        }

        public int LatitudeOffset
        {
            get { return areaLatOffset; }
        }

        public int LongitudeOffset
        {
            get { return areaLonOffset; }
        }

        public string MsgAddressee
        {
            get { return messageAddressee; }
        }

        public string MsgText
        {
            get { return messageText; }
        }

        public string MsgNumber
        {
            get { return messageNumber; }
        }

        public string ThirdPartySource
        {
            get { return thirdPartySource; }
        }

        public string ThirdPartyDest
        {
            get { return thirdPartyDest; }
        }

        public string ThirdPartyVia
        {
            get { return thirdPartyVia; }
        }

        public byte[] ThirdPartyData
        {
            get { return thirdPartyData; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the AprsPacket class.
        /// </summary>
        public AprsData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AprsPacket class.
        /// </summary>
        /// <param name="dataStr">String containing APRS data.</param>
        public AprsData(string dataStr)
        {
            // Initialize the instance data
            InitializeData();
            if(dataStr != null)
                if(dataStr.Length > 0)
                    Parse(ASCIIEncoding.UTF8.GetBytes(dataStr));
            if (thirdPartyData != null)
                if (thirdPartyData.Length > 0)
                    Parse(thirdPartyData);
        }

        /// <summary>
        /// Initializes a new instance of the AprsPacket class.
        /// </summary>
        /// <param name="data">Byte array containing APRS data.</param>
        public AprsData(byte[] data)
        {
            // Initialize the instance data
            InitializeData();
            if (data != null)
                if (data.Length > 0)
                    Parse(data);
            if (thirdPartyData != null)
                if (thirdPartyData.Length > 0)
                    Parse(thirdPartyData);
        }

        /// <summary>
        /// Identify and retrieve component values of APRS data structures.
        /// </summary>
        /// <param name="data">Byte array containing APRS data.</param>
        /// <returns>
        /// Parse returns True if the information contained in parameter, data, can be successfully identified 
        /// as a valid APRS data type and, if applicable, parsed to retrieve component values identifiable 
        /// with that found in an APRS data structure.
        /// Otherwise Parse returns False.
        /// </returns>
        public bool Parse(byte[] data)
        {
            if (data != null)
            {
                // Declare a working variable to store offset position within the data array.
                int index;

                switch (data[0])
                {
                    case (byte)'!':
                        dataTypeString = "Position without timestamp (no APRS messaging), or Ultimeter 2000 WX Station";
                        dataType = AprsDataType.PositionNoTimeNoMessage;
                        index = ParsePositionTimeString(data);
                        ParseLatLonExtended(data, index);
                        break;
                    case (byte)'/':
                        dataTypeString = "Position with timestamp (no APRS messaging)";
                        dataType = AprsDataType.PositionWithTimeNoMessage;
                        index = ParsePositionTimeString(data);
                        ParseLatLonExtended(data, index);
                        break;
                    case (byte)'=':
                        dataTypeString = "Position without timestamp (with APRS messaging)";
                        dataType = AprsDataType.PositionNoTimeWithMessage;
                        index = ParsePositionTimeString(data);
                        ParseLatLonExtended(data, index);
                        break;
                    case (byte)'@':
                        dataTypeString = "Position with timestamp (with APRS messaging)";
                        dataType = AprsDataType.PositionWithTimeWithMessage;
                        index = ParsePositionTimeString(data);
                        ParseLatLonExtended(data, index);
                        break;
                    case (byte)';':
                        dataTypeString = "Object";
                        dataType = AprsDataType.Object;
                        // Make sure we have at least a minimum length information array.
                        if (data.Length >= 18)
                        {
                            name = ASCIIEncoding.ASCII.GetString(data, 1, 9);
                            // Get the APRS objects status. live = *, killed = _
                            if (data[10] == (byte)'*')
                                objectItemStatus = AprsObjectItemStatus.Alive;
                            else if (data[10] == (byte)'_')
                                objectItemStatus = AprsObjectItemStatus.Killed;
                            // Store the timestamp data in the timeStamp field.
                            timeStamp = ASCIIEncoding.ASCII.GetString(data, 11, 7);
                            ParseLatLonExtended(data, 18);
                        }
                        break;
                    case (byte)')':
                        dataTypeString = "Item";
                        dataType = AprsDataType.Item;
                        // Start with the byte array index at the status byte.
                        index = ASCIIEncoding.ASCII.GetString(data).IndexOfAny(new char[]{'!', '_'});
                        // Make sure we have at least a minimum length information array.
                        if (data.Length >= index)
                        {
                            name = ASCIIEncoding.ASCII.GetString(data, 1, index - 1);
                            // Get the APRS items status. live = !, killed = _
                            if (data[index] == (byte)'!')
                                objectItemStatus = AprsObjectItemStatus.Alive;
                            else if (data[index] == (byte)'_')
                                objectItemStatus = AprsObjectItemStatus.Killed;
                            // Set the index value to point at the latitude data.
                            ParseLatLonExtended(data, index += 1);
                        }
                        break;
                    case (byte)':':
                        dataTypeString = "Message, Bulletin or Announcement";
                        dataType = AprsDataType.Message;
                        // Make sure we have at least a minimum length information array.
                        if (data.Length >= 11)
                        {
                            // Determine if this is a message, bulletin or announcement.
                            if (ASCIIEncoding.ASCII.GetString(data, 1, 3).Contains("BLN"))
                            {
                                // Is the identifier a digit? If so...
                                if (data[4] >= 48 & data[4] <= 57)
                                {
                                    // Its a bulletin, record the bulletin number.
                                    messageNumber = (data[4] - 48).ToString();
                                    dataType = AprsDataType.Bulletin;
                                }
                                else
                                {
                                    // Otherwise its an announcement, record the announcement identifier.
                                    messageNumber = ASCIIEncoding.ASCII.GetString(data, 4, 1);
                                    dataType = AprsDataType.Announcement;
                                }
                            }
                            else
                            {
                                // Its a message, record the addressee.
                                messageAddressee = ASCIIEncoding.ASCII.GetString(data, 1, 9);
                            }
                            // See if there is any message text.
                            if (data.Length > 11)
                            {
                                // Get the offset of the end of the message text.
                                // If the message information contains the message ID marker "{"...
                                if (ASCIIEncoding.ASCII.GetString(data).Substring(12, Math.Min(data.Length - 12, 67)).Contains("{"))
                                {
                                    // Then the message text ends at the offset of the marker.
                                    index = ASCIIEncoding.ASCII.GetString(data).IndexOf("{", 12);
                                    // Record the message number.
                                    messageNumber = ASCIIEncoding.ASCII.GetString(data, index + 1, Math.Min(data.Length - index - 1,5));
                                }
                                else
                                    // Otherwise it extends to the end of the information field.
                                    index = data.Length;
                                // Record the message text.
                                messageText = ASCIIEncoding.ASCII.GetString(data, 11, index - 11);
                            }
                        }
                        break;
                    case (byte)'}':
                        dataTypeString = "Third-Party Traffic";
                        dataType = AprsDataType.ThirdParty;
                        index = ASCIIEncoding.ASCII.GetString(data).IndexOf('>', 0, Math.Min(data.Length, 11));
                        // Make sure we have at least a minimum length information array.
                        if (index > 0)
                        {
                            int tmpIndex = index;
                            thirdPartySource = ASCIIEncoding.ASCII.GetString(data, 1, index - 1);
                            index = ASCIIEncoding.ASCII.GetString(data).IndexOf(',', index, Math.Min(data.Length, 11));
                            if (index > 0)
                            {
                                thirdPartyDest = ASCIIEncoding.ASCII.GetString(data, tmpIndex + 1, index - tmpIndex - 1);
                                tmpIndex = index;
                                index = ASCIIEncoding.ASCII.GetString(data).IndexOf(':', tmpIndex, data.Length - tmpIndex);
                                if (index > 0)
                                    thirdPartyVia = ASCIIEncoding.ASCII.GetString(data, tmpIndex + 1, index - tmpIndex - 1);
                            }
                            else
                            {
                                index = ASCIIEncoding.ASCII.GetString(data).IndexOf(':', tmpIndex, data.Length - tmpIndex);
                                if (index > 0)
                                    thirdPartyDest = ASCIIEncoding.ASCII.GetString(data, tmpIndex + 1, index - tmpIndex - 1);
                            }
                            if (index > 0)
                            {
                                thirdPartyData = new byte[data.Length - index - 1];
                                Array.Copy(data,index + 1,thirdPartyData,0,data.Length - index - 1);
                            }
                        }
                        break;
                    case (byte)'?':
                        dataTypeString = "Query";
                        dataType = AprsDataType.Query;
                        break;
                    case (byte)'>':
                        dataTypeString = "Status";
                        dataType = AprsDataType.Status;
                        break;
                    case (byte)'_':
                        dataTypeString = "Weather Report (without position)";
                        dataType = AprsDataType.WeatherReport;
                        break;
                    case (byte)'<':
                        dataTypeString = "Station Capabilities";
                        break;
                    case (byte)'\'':
                        dataTypeString = "TM-D700 Data";
                        break;
                    case (byte)'$':
                        dataTypeString = "Raw GPS Data or Ultimeter 2000 WX Station";
                        break;
                    case (byte)0x1c:
                        dataTypeString = "Current Mic-E Data";
                        break;
                    case (byte)0x1d:
                        dataTypeString = "Old Mic-E Data";
                        break;
                    case (byte)'`':
                        dataTypeString = "Current Mic-E Data (not used in TM-D700)";
                        break;
                    case (byte)'&':
                        dataTypeString = "[Reserved - Map Feature]";
                        break;
                    case (byte)'+':
                        dataTypeString = "[Reserved - Shelter data with time]";
                        break;
                    case (byte)'.':
                        dataTypeString = "[Reserved - Space Weather]";
                        break;
                    case (byte)'#':
                        dataTypeString = "Peet Bros U-II Weather Station";
                        break;
                    case (byte)'%':
                        dataTypeString = "Agrelo DF Jr/MicroFinder";
                        break;
                    case (byte)'*':
                        dataTypeString = "Peet Bros U-II Weather Station";
                        break;
                    case (byte)'T':
                        dataTypeString = "Telemetry Data";
                        break;
                    case (byte)'{':
                        dataTypeString = "User-Defined APRS Packet Format";
                        break;
                    case (byte)',':
                        dataTypeString = "Invalid or Test Data";
                        dataType = AprsDataType.InvalidOrTest;
                        break;
                    case (byte)'[':
                        dataTypeString = "Maidenhead Grid Locator Beacon (obsolete)";
                        break;
                    case (byte)'"':
                    case (byte)'(':
                    case (byte)'-':
                    case (byte)'\\':
                    case (byte)']':
                    case (byte)'^':
                        dataTypeString = "Unused";
                        dataType = AprsDataType.Unused;
                        break;
                    default:
                        // Look for the '!' identifier in the first 40 bytes rather than just the first byte. 
                        // This is to support X1J TNC digipeaters.
                        if (ASCIIEncoding.ASCII.GetString(data).Substring(0, Math.Min(data.Length, 40)).Contains("!"))
                        {
                            dataTypeString = "Position without timestamp (no APRS messaging), or Ultimeter 2000 WX Station";
                            dataType = AprsDataType.PositionNoTimeNoMessage;
                            index = ParsePositionTimeString(data);
                            ParseLatLonExtended(data, index);
                        }
                        break;
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Sets all fields to default values.
        /// </summary>
        private void InitializeData()
        {
            dataType = AprsDataType.InvalidOrTest;
            dataTypeString = "";
            name = "";
            objectItemStatus = AprsObjectItemStatus.None;
            timeStamp = "";
            longitude = "";
            latitude = "";
            course = 0;
            speed = 0;
            altitude = 0;
            symbolTableCode = "";
            //micEData;
            //nmeaSentence;
            //wxStationData;
            comment = "";
            txPower = 0;
            antennaHaat = 0;
            antennaGain = 0;
            antennaDir = 0;
            radioRange = 0;
            pcRadioRange = 0;
            extType = DataExtensionType.None;
            areaObject = AprsAreaObject.None;
            areaColor = AprsAreaColor.Black;
            areaLatOffset = 0;
            areaLonOffset = 0;
            messageAddressee = "";
            messageText = "";
            messageNumber = "";
            thirdPartySource = "";
            thirdPartyDest = "";
            thirdPartyVia = "";
        }

        /// <summary>
        /// Parses the beginning of an APRS position report to determine the type of position report and, 
        /// if applicable, to extract the timestamp.
        /// </summary>
        /// <param name="data">Byte array containing APRS data.</param>
        /// <returns>Returns an integer value which is the offset in the byte array to the start of the 
        /// lat/lon position information.
        /// </returns>
        private int ParsePositionTimeString(byte[] data)
        {
            // Set the timestamp value.
            if (data[0] == (byte)'!' | data[0] == (byte)'=') // No timestamp
                timeStamp = "";
            else if (data.Length >= 8 & (data[0] == (byte)'/' | data[0] == (byte)'@')) // Has timestamp
            {
                // Store the timestamp data in the timeStamp field.
                timeStamp = ASCIIEncoding.ASCII.GetString(data, 1, 7);
                // Return the index to the latitude data.
                return(8);
            }
            return(1);
        }

        /// <summary>
        /// Parses APRS data types which include lat/lon position information, beginning with the lat/lon data.
        /// </summary>
        /// <param name="data">Byte array containing APRS data.</param>
        /// <param name="index">The offset within the byte array at which lat/lon information begins.</param>
        private void ParseLatLonExtended(byte[] data, int index)
        {
            // Make sure we have at least a minimum length information array and uncompressed position data.
            if (data.Length >= index + 19 & data[index] != (byte)'/' & data[index] != (byte)'\\')
            {
                latitude = ASCIIEncoding.ASCII.GetString(data, index, 8);
                longitude = ASCIIEncoding.ASCII.GetString(data, index + 9, 9);
                symbolTableCode = ASCIIEncoding.ASCII.GetString(data, index + 8, 1) + ASCIIEncoding.ASCII.GetString(data, index + 18, 1);
                if (data.Length >= index + 26)
                {
                    if (data[index + 22] == (byte)'/')
                    {
                        // The character "l" indicates the symbol for an Area Symbol (box, circle, line, triangle or ellipse)
                        if (symbolTableCode == @"\l")
                        {
                            areaObject = (AprsAreaObject)data[index + 19] - 48;
                            areaColor = (AprsAreaColor)data[index + 23] - 48;
                            if(AprsCalc.IsNumeric(ASCIIEncoding.ASCII.GetString(data, index + 20, 2)))
                                areaLatOffset = Convert.ToInt32(ASCIIEncoding.ASCII.GetString(data, index + 20, 2));
                            if(AprsCalc.IsNumeric(ASCIIEncoding.ASCII.GetString(data, index + 24, 2)))
                                areaLonOffset = Convert.ToInt32(ASCIIEncoding.ASCII.GetString(data, index + 24, 2));
                            //Parse the corridor width here.
                            extType = DataExtensionType.AreaObject;
                        }
                        // The character "m" indicates the symbol for a Value Signpost.
                        else if (symbolTableCode == @"\m")
                        {
                            // Parse the signpost overlay here.
                            extType = DataExtensionType.SignPost;
                        }
                        else
                        {
                            if(AprsCalc.IsNumeric(ASCIIEncoding.ASCII.GetString(data, index + 19, 3)))
                                course = Convert.ToInt32(ASCIIEncoding.ASCII.GetString(data, index + 19, 3));
                            if(AprsCalc.IsNumeric(ASCIIEncoding.ASCII.GetString(data, index + 23, 3)))
                                speed = Convert.ToInt32(ASCIIEncoding.ASCII.GetString(data, index + 23, 3));
                            extType = DataExtensionType.CourseSpeed;
                        }
                        index += 26;
                    }
                    else
                    {
                        switch (ASCIIEncoding.ASCII.GetString(data, index + 19, 3))
                        {
                            case "PHG": // Power, Height, Gain and directional information.
                                txPower = (int)Math.Pow(Convert.ToInt32(((byte)(data[index + 22] - 48)).ToString()), 2);
                                antennaHaat = (int)(10 * Math.Pow(2, Convert.ToDouble(((byte)(data[index + 23] - 48)).ToString())));
                                antennaGain = Convert.ToInt32(((byte)(data[index + 24] - 48)).ToString());
                                antennaDir = Convert.ToInt32(((byte)(data[index + 25] - 48)).ToString()) * 45;
                                // Calculate a rough estimate of the stations average range based on the information given.
                                radioRange = AprsCalc.PhgRange(txPower, antennaHaat, antennaGain);
                                extType = DataExtensionType.PowerHeightGain;
                                index += 26;
                                break;
                            case "RNG": // Pre-calculated radio range information.
                                if(AprsCalc.IsNumeric(ASCIIEncoding.ASCII.GetString(data, index + 22, 4)))
                                    pcRadioRange = Convert.ToInt32(ASCIIEncoding.ASCII.GetString(data, index + 22, 4));
                                extType = DataExtensionType.PreCalcRadioRange;
                                index += 26;
                                break;
                            case "DFS":
                                // Parse the DF data here.
                                extType = DataExtensionType.DFStrengthHeightGain;
                                index += 26;
                                break;
                            default:
                                index += 19;
                                break;
                        }
                    }
                    // If there is still more information, it is contained in the comment field.
                    if (data.Length > index)
                    {
                        // Parse the comment field information to extract any available formated data.

                        // The character "_" indicates the course and speed extended data should be considered 
                        // as wind direction and windspeed. It is a further indication that weather report data
                        // may be available to be parsed.
                        if (symbolTableCode == @"/_")
                        {
                            // Parse weather report data here.
                            extType = DataExtensionType.StormData;
                        }
                    }
                    comment = ASCIIEncoding.ASCII.GetString(data, index, data.Length - index);
                    if (comment.Contains("/A="))
                    {
                        index = comment.IndexOf("/A=");
                        if (comment.Length >= index + 9 & AprsCalc.IsNumeric(comment.Substring(index + 3, 6)))
                            altitude = Convert.ToInt32(comment.Substring(index + 3, 6));
                    }
                }
            } // Otherwise, make sure we have at least a minimum length information array and compressed position data.
            else if (data.Length >= index + 13 & (data[index] == (byte)'/' | data[index] == (byte)'\\'))
            {
                // Parse compressed position report here.
            }
        }
    }
}
