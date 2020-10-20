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
using System.Text;

namespace AgwpePort
{
    struct AgwpeFrame
    {
        public const byte PORT      = 0;
        public const byte DATAKIND  = 4;
        public const byte PID       = 6;
        public const byte CALLFROM  = 8;
        public const byte CALLTO    = 18;
        public const byte DATALEN   = 28;
        public const byte DATASTART = 36;

        // Static methods --------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int GetEndOfText(byte[] bytes, int index, int count)
        {
            int offset;

            for (offset = 0; offset < count; offset++)
                if (bytes[index + offset] == 0)
                    break;
            return index + offset;
        }

        /// <summary>
        /// Retrieves the substring between the occurances of the string parameters "from" and "to". 
        /// The search begins at the specified index.
        /// </summary>
        /// <param name="str">The input string to parse.</param>
        /// <param name="startIndex">The starting position to search for the "from" parameter value.</param>
        /// <param name="from">The start value which bounds the string value to retrieve.</param>
        /// <param name="to">The end value which bounds the string value to retrieve.</param>
        /// <returns></returns>
        public static string Parse(string str, int startIndex, string from, string to)
        {
            int start, finish, length;

            length = from.Length;
            if ((str.Length > startIndex + length) & length > 0)
            {
                start = str.IndexOf(from, startIndex);
                if (start >= 0)
                {
                    finish = str.IndexOf(to, start);
                    if (str.Length >= finish & finish > (start + length))
                    {
                        return str.Substring(start + length, finish - (start + length));
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int GetEndOfHeader(byte[] bytes, int count)
        {
            int offset;

            for (offset = 0; offset < count; offset++)
                if (bytes[offset] == '\r')
                    break;
            return offset;
        }
    }
}
