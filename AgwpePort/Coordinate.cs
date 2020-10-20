// Copyright 2008 William U. Walker
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//     
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//  
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA 

using System;
using System.Collections.Generic;
using System.Text;

namespace AgwpePort.Aprs
{
    public class Coordinate
    {
        private double _deg = 0;
        private double _min = 0;
        private double _sec = 0;

        public double Degrees
        {
            get{return _deg;}
            set{_deg = value;}
        }

        public double Minutes
        {
            get{return _min;}
            set{_min = value;}
        }

        public double Seconds
        {
            get{return _sec;}
            set{_sec = value;}
        }

        public Coordinate()
        {
            _deg = 0;
            _min = 0;
            _sec = 0;
        }

        public Coordinate(string deg, string min, string sec)
        {
            if(deg.Length == 0)
                _deg = 0;
            else
                _deg = Convert.ToDouble(deg);
            
            if(min.Length == 0)
                _min = 0;
            else
                _min = Convert.ToDouble(min);

            if(sec.Length == 0)
                _sec = 0;
            else
                _sec = Convert.ToDouble(sec);
        }

        public Coordinate(double deg, double min, double sec)
        {
            _deg = deg;
            _min = min;
            _sec = sec;
        }

        public Coordinate(double degrees)
        {
            bool isNeg = false;

            if (degrees <= 180)
            {
                _deg = Math.Floor(degrees);
                if (degrees < 0)
                {
                    degrees *= -1;
                    isNeg = true;
                }
                _deg = Math.Floor(degrees);
                _min = (degrees - _deg) * 60;
                _sec = (_min - Math.Floor(_min)) * 60;
                _min = Math.Floor(_min);
                if (isNeg)
                {
                    _deg *= -1;
                }
            }
        }

        public Coordinate(string coord)
        {
            string[] parts;
            double decValue;

            coord = coord.Trim();
            if( coord.Length > 0 )
            {
                parts = coord.Split();
                if( parts.Length > 0 )
                {
                    if( parts.Length > 1 & IsNumeric(parts[0]) )
                    {
                        _deg = Math.Floor(Convert.ToDouble(parts[0]));
                        if (IsNumeric(parts[1]))
                        {
                            _min = Convert.ToDouble(parts[1]);
                            if( parts.Length > 2 )
                            {
                                if( IsNumeric(parts[2]) )
                                {
                                    _min = Math.Floor(_min);
                                    _sec = Convert.ToDouble(parts[2]);
                                }
                                else
                                {
                                    _deg = 0;
                                    _min = 0;
                                    _sec = 0;
                                }
                            }
                            else
                            {
                                _sec = (_min - Math.Floor(_min)) * 60;
                                _min = Math.Floor(_min);
                            }
                        }
                        else
                        {
                            _deg = 0;
                            _min = 0;
                            _sec = 0;
                        }
                    }
                    else
                    {
                        if (IsNumeric(parts[0]))
                        {
                            decValue = Convert.ToDouble(parts[0]);
                            if (decValue < 0)
                            {
                                decValue *= -1;
                            }
                            _deg = Math.Floor(decValue);
                            _min = (decValue - _deg) * 60;
                            _sec = (_min - Math.Floor(_min)) * 60;
                            _min = Math.Floor(_min);
                            if (Convert.ToDouble(parts[0]) < 0)
                            {
                                _deg *= -1;
                            }
                        }
                        else
                        {
                            _deg = 0;
                            _min = 0;
                            _sec = 0;
                        }
                    }
                    // This is a valid test only if the coordinate is a longitude coordinate.
                    if (_deg >= 180 | _deg <= -180 | _min >= 60 | _sec >= 60)
                    {
                        _deg = 0;
                        _min = 0;
                        _sec = 0;
                    }
                }
            }
        }

        public bool IsNumeric(string value)
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

        public string ToDegreesString()
        {
            return ToDegrees().ToString();
        }

        public string ToDecMinuteString()
        {
            return _deg.ToString() + " " + (Math.Round((_min + _sec / 60), 3).ToString());
        }

        public string ToAprsLatString()
        {
            string retVal;
            double deg = _deg;
            double decMin = Math.Round((_min + _sec / 60), 2, MidpointRounding.ToEven);
            double min = Math.Floor(decMin);

            if (_deg < 0)
                deg = _deg * -1;

            retVal = deg.ToString().PadLeft(2, '0');

            if (min < 10)
                retVal += min.ToString().PadLeft(2, '0') + "." + Math.Floor(((decMin - min) * 100)).ToString().PadRight(2,'0');
            else
                retVal += min.ToString() + "." + Math.Floor(((decMin - min) * 100)).ToString().PadRight(2, '0');

            if (_deg < 0)
                retVal += "S";
            else
                retVal += "N";

            // Make a sanity check...
            if(retVal.Length == 8)
                return retVal;
            // Otherwise return anzero length string.
            return "";
        }

        public string ToAprsLonString()
        {
            string retVal;
            double deg = _deg;
            double decMin = Math.Round((_min + _sec / 60), 2, MidpointRounding.ToEven);
            double min = Math.Floor(decMin);

            if (_deg < 0)
                deg = _deg * -1;

            retVal = deg.ToString().PadLeft(3, '0');

            if (min < 10)
                retVal += min.ToString().PadLeft(2, '0') + "." + Math.Floor(((decMin - min) * 100)).ToString().PadRight(2, '0');
            else
                retVal += min.ToString() + "." + Math.Floor(((decMin - min) * 100)).ToString().PadRight(2, '0');

            if (_deg < 0)
                retVal += "W";
            else
                retVal += "E";

            // Make a sanity check...
            if (retVal.Length == 9)
                return retVal;
            // Otherwise return anzero length string.
            return "";
        }

        public double ToDegrees()
        {
            if( _deg >= 0 )
                return _deg + (_min + _sec / 60) / 60;
            else
                return (Math.Abs(_deg) + (_min + _sec / 60) / 60) * -1;
        }
    }
}
