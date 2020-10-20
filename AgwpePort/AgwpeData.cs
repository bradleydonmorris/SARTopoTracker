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
    class AgwpeData
    {
        private Queue dataBuffer;

        /// <summary>
        /// Get the number of bytes in the data buffer.
        /// </summary>
        public int Count
        {
            get { return dataBuffer.Count; }
        }

        /// <summary>
        /// Constructor for the AgwpeData class.
        /// </summary>
        public AgwpeData()
        {
            dataBuffer = new Queue();
        }

        /// <summary>
        /// Add a single byte to the data bufer.
        /// </summary>
        /// <param name="value">The byte value to add to the data buffer.</param>
        /// <returns>Returns the total number of bytes in the data buffer.</returns>
        public int AddByte(byte value)
        {
            dataBuffer.Enqueue((byte)value);
            return dataBuffer.Count;
        }

        /// <summary>
        ///  Removes all bytes from the data buffer.
        /// </summary>
        public void Clear()
        {
            dataBuffer.Clear();
        }

        /// <summary>
        /// Get a single byte value from the data buffer.  This method permanently removes the byte read from the buffer.
        /// </summary>
        /// <returns>Returns the next available byte from the data buffer.</returns>
        public byte GetByte()
        {
            return Convert.ToByte((byte)dataBuffer.Dequeue());
        }

        /// <summary>
        /// Get an array of byte values from the data buffer.  This method permanently removes the bytes read from the buffer.
        /// </summary>
        /// <param name="buffer">A byte array to store the bytes read from the data buffer.</param>
        /// <param name="offset">The offset within byte array to start storing bytes read from the data buffer.</param>
        /// <param name="size">The number of bytes to store in the byte array.</param>
        /// <returns>Returns the actual number of bytes read from the data buffer.</returns>
        public int GetBytes(byte[] buffer, int offset, int size)
        {
            int count;

            if (size > dataBuffer.Count)
                size = dataBuffer.Count;
            for (count = 0; count < size; count++)
                buffer[offset + count] = Convert.ToByte((byte)dataBuffer.Dequeue());

            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public byte[] ToByteArray()
        {
            if (dataBuffer.Count > 0)
            {
                byte[] byteArray = new byte[dataBuffer.Count];
                GetBytes(byteArray, 0, dataBuffer.Count);
                return byteArray;
            }
            return null;
        }
    }
}
