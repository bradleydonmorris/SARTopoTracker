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

namespace AgwpePort.Aprs
{
    /// <summary>
    /// 
    /// </summary>
    public class AprsCalc
    {
        public static string Base91Encode(string dataStr)
        {
            return "";
        }

        public static byte[] Base91Encode(byte[] data)
        {
            return data;
        }

        public static string Base91Decode(string dataStr)
        {
            return "";
        }

        public static byte[] Base91Decode(byte[] data)
        {
            return data;
        }

        public static double PhgRange(int power, int haat, int gain)
        {
            double adjGain = Math.Pow(10, ((double)gain) / 10);
            return Math.Sqrt(2 * (double)haat * Math.Sqrt(((double)power / 10) * (adjGain / 2)));
        }

        public static DateTime TimeStampToDateTime(string timeStamp)
        {
            DateTime now = DateTime.Now;
            int month, day, hour, minute;
            bool local = true;

            if (timeStamp != null)
            {
                timeStamp = timeStamp.Trim();
                //
                if (timeStamp.Trim().Length == 7)
                {
                    if (timeStamp.EndsWith("z") | timeStamp.EndsWith("h"))
                        local = false;
                    day = Convert.ToInt32(timeStamp.Substring(0, 2));
                    hour = Convert.ToInt32(timeStamp.Substring(2, 2));
                    minute = Convert.ToInt32(timeStamp.Substring(4, 2));
                    if (day > now.Day)
                        now = now.AddMonths(-1);
                    // Test the format and validate the values.
                    if(local & day <= 31 & hour < 24 & minute < 60)
                        // Day/Hours/Minutes in the local time zone.
                        return new DateTime(now.Year, now.Month, day, hour, minute, 0);
                    else if(timeStamp.EndsWith("z") & day <= 31 & hour < 24 & minute < 60)
                        // Day/Hours/Minutes in UTC.
                        return new DateTime(now.Year, now.Month, day, hour, minute, 0).ToLocalTime();
                    else if(timeStamp.EndsWith("h") & day < 24 & hour < 60 & minute < 60)
                        // Hours/Minutes/Seconds in UTC.
                        // In this case, day = hours/hour = minutes/minute = seconds.
                        return new DateTime(now.Year, now.Month, now.Day, day, hour, minute).ToLocalTime();
                }
                else if (timeStamp.Trim().Length == 8)
                {
                    month = Convert.ToInt32(timeStamp.Substring(0, 2));
                    day = Convert.ToInt32(timeStamp.Substring(2, 2));
                    hour = Convert.ToInt32(timeStamp.Substring(4, 2));
                    minute = Convert.ToInt32(timeStamp.Substring(6, 2));
                    if(month > 0 & month <= 12 & day > 0 & day <= 31 & hour > 0 & hour < 24 & minute > 0 & minute < 60)
                        // Month/Day/Hours/Minutes in UTC.
                        return new DateTime(now.Year, month, day, hour, minute, 0).ToLocalTime();
                }
            }
            return new DateTime(1900,1,1);
        }

        public static double LatLonToDouble(string latlon)
        {
            double deg = 0, min = 0;

            if (latlon != null)
            {
                latlon = latlon.Trim().Replace(" ","0");
                // Determine if the string is a latitude or longitude.
                if (latlon.Length == 8 & (latlon.EndsWith("S") | latlon.EndsWith("N")))
                {
                    // It's a latitude.
                    deg = Convert.ToDouble(latlon.Substring(0, 2));
                    min = Convert.ToDouble(latlon.Substring(2, 5)) / 60;
                }
                else if (latlon.Length == 9 & (latlon.EndsWith("E") | latlon.EndsWith("W")))
                {
                    // It's a longitude.
                    deg = Convert.ToDouble(latlon.Substring(0, 3));
                    min = Convert.ToDouble(latlon.Substring(3, 5)) / 60;
                }
                else
                {
                    // Not a valid latitude or longitude string.
                    return 0;
                }
                // If the coordinate is South latitude or West longitude...
                if (latlon.EndsWith("S") | latlon.EndsWith("W"))
                    // Make the value negative.
                    deg = (deg + min) * -1;
                else
                    // Otherwise leave it positive.
                    deg = deg + min;
                // Return the converted value.
                return deg;
            }
            // Not a valid latitude or longitude string.
            return 0;
        }

        public static bool IsNumeric(string value)
        {
            try
            {
                Double.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
