// Original code by Richard Parsons
// http://www.codeproject.com/KB/miscctrl/richtextboxextended.aspx

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Drawing.Printing;


namespace AgwpePort.Windows.Forms
{
    public partial class RichTextBoxExtended : RichTextBox
    {
        //Convert the unit used by the .NET framework (1/100 inch) 
        //and the unit used by Win32 API calls (twips 1/1440 inch)
        private const double anInch = 14.4;
        private Color htmlFgColor;
        private Color htmlBgColor;
        private Font htmlFont;

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct CHARRANGE
        {
            public int cpMin;         //First character of range (0 for start of doc)
            public int cpMax;           //Last character of range (-1 for end of doc)
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FORMATRANGE
        {
            public IntPtr hdc;             //Actual DC to draw on
            public IntPtr hdcTarget;       //Target DC for determining text formatting
            public RECT rc;                //Region of the DC to draw to (in twips)
            public RECT rcPage;            //Region of the whole DC (page size) (in twips)
            public CHARRANGE chrg;         //Range of text to draw (see earlier declaration)
        }

        private const int WM_USER = 0x0400;
        private const int EM_FORMATRANGE = WM_USER + 57;

        [DllImport("USER32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        public string Html
        {
            get
            {
                return (GetHtml());
            }
        }

        private string HtmlColorFromColor(Color color)
        {
            string retVal = "";

            if (color.IsNamedColor)
                retVal = color.Name.ToLower();
            else
            {
                retVal = color.Name;
                if (retVal.Length > 6)
                    retVal = retVal.Substring(retVal.Length - 6, 6);
                retVal = "#" + retVal.ToUpper();
            }
            return (retVal);
        }

        private string HtmlFontStyleFromFont(Font font)
        {
            string retVal = "";

            if (font.Italic)
                retVal += "italic ";
            else
                retVal += "normal ";

            retVal += "normal ";

            if (font.Bold)
                retVal += "bold ";
            else
                retVal += "normal ";

            retVal += font.SizeInPoints + "pt/normal ";

            retVal += font.FontFamily.Name;

            return (retVal);
        }

        private string HtmlSpan()
        {
            string retVal = "";

            retVal += "\r\n            <span style=\"color:" + HtmlColorFromColor(this.SelectionColor) +
                ";background-color:" + HtmlColorFromColor(this.SelectionBackColor) +
                ";font:" + HtmlFontStyleFromFont(this.SelectionFont) + "\">\r\n                ";

            htmlFgColor = this.SelectionColor;
            htmlBgColor = this.SelectionBackColor;
            htmlFont = this.SelectionFont;

            return (retVal);
        }

        private string GetHtml()
        {
            string retVal = "<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n" +
                            "    <head>\r\n" +
                            "        <title>\r\n" +
                            "        </title>\r\n" +
                            "    </head>\r\n" +
                            "    <body>\r\n" +
                            "        <div>";
            HorizontalAlignment hAlign = HorizontalAlignment.Left;

            htmlFgColor = Color.Black;
            htmlBgColor = Color.Black;
            htmlFont = this.Font;

            for (int offset = 0; offset < this.Text.Length - 1; offset++)
            {
                this.Select(offset, 1);

                // Paragraph
                if (offset == 0)
                {
                    retVal += "\r\n            <p style=\"text-align:" + this.SelectionAlignment.ToString() + "\">";
                    hAlign = this.SelectionAlignment;
                }
                //else
                //{
                //    if (this.SelectionAlignment != hAlign)
                //    {
                //        retVal += "\r\n    </span>\r\n    </p>";
                //        retVal += "\r\n    <p style=\"text-align:" + this.SelectionAlignment.ToString() + "\">";
                //        hAlign = this.SelectionAlignment;
                //    }
                //}

                // Span
                if (offset == 0)
                {
                    if (this.SelectionColor != htmlFgColor | this.SelectionBackColor != htmlBgColor | this.SelectionFont.GetHashCode() != htmlFont.GetHashCode())
                        retVal += HtmlSpan();
                }
                else
                {
                    if (this.SelectionColor != htmlFgColor | this.SelectionBackColor != htmlBgColor | this.SelectionFont.GetHashCode() != htmlFont.GetHashCode())
                    {
                        retVal += "\r\n            </span>";
                        retVal += HtmlSpan();
                    }
                }

                switch (Convert.ToChar(this.Text.Substring(offset, 1)))
                {
                    case '\n':
                        retVal += "<br />\r\n                ";
                        break;
                    case '\t':
                        retVal += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                        break;
                    default:
                        retVal += this.Text.Substring(offset, 1);
                        break;
                }
            }

            retVal += "\r\n            </span>" +
                      "\r\n            </p>" +
                      "\r\n        </div>" +
                      "\r\n    </body>" +
                      "\r\n</html>";
            //            retVal = retVal.Replace(Convert.ToString('\n'), "<br />");

            return (retVal);
        }

        private string GetHtml2()
        {
            string retVal = "<div>";
            Color fgColor = Color.Black;
            Color bgColor = Color.Black;
            Font font = this.Font;
            HorizontalAlignment hAlign = HorizontalAlignment.Left;

            for (int offset = 0; offset < this.Text.Length - 1; offset++)
            {
                this.Select(offset, 1);
                // Foreground Color
                if (offset == 0)
                {
                    retVal += "<span style=\"color:" + HtmlColorFromColor(this.SelectionColor) + "\">";
                    fgColor = this.SelectionColor;
                }
                else
                {
                    if (this.SelectionColor != fgColor)
                    {
                        retVal += "</span>";
                        retVal += "<span style=\"color:" + HtmlColorFromColor(this.SelectionColor) + "\">";
                        fgColor = this.SelectionColor;
                    }
                }
                // Background Color
                if (offset == 0)
                {
                    retVal += "<span style=\"background-color:" + HtmlColorFromColor(this.SelectionBackColor) + "\">";
                    bgColor = this.SelectionBackColor;
                }
                else
                {
                    if (this.SelectionBackColor != bgColor)
                    {
                        retVal += "</span>";
                        retVal += "<span style=\"background-color:" + HtmlColorFromColor(this.SelectionBackColor) + "\">"; ;
                        bgColor = this.SelectionBackColor;
                    }
                }
                // Font
                if (offset == 0)
                {
                    retVal += "<span style=\"font:" + HtmlFontStyleFromFont(this.SelectionFont) + "\">";
                    font = this.SelectionFont;
                }
                else
                {
                    if (this.SelectionFont.GetHashCode() != font.GetHashCode())
                    {
                        retVal += "</span>";
                        retVal += "<span style=\"font:" + HtmlFontStyleFromFont(this.SelectionFont) + "\">"; ;
                        font = this.SelectionFont;
                    }
                }
                // Alignment
                if (offset == 0)
                {
                    retVal += "<p style=\"text-align:" + this.SelectionAlignment.ToString() + "\">";
                    hAlign = this.SelectionAlignment;
                }
                else
                {
                    if (this.SelectionAlignment != hAlign)
                    {
                        retVal += "</p>";
                        retVal += "<p style=\"text-align:" + this.SelectionAlignment.ToString() + "\">";
                        hAlign = this.SelectionAlignment;
                    }
                }

                retVal += this.Text.Substring(offset, 1);
            }

            retVal += "</span>";
            retVal += "</span>";
            retVal += "</span>";
            retVal += "</p>";
            retVal += "</div>";
            retVal = retVal.Replace(Convert.ToString('\n'), "<br />");

            return (retVal);
        }

        // Render the contents of the RichTextBox for printing
        //	Return the last character printed + 1 (printing start from this point for next page)
        public int Print(int charFrom, int charTo, PrintPageEventArgs e)
        {
            //Calculate the area to render and print
            RECT rectToPrint;
            rectToPrint.Top = (int)(e.MarginBounds.Top * anInch);
            rectToPrint.Bottom = (int)(e.MarginBounds.Bottom * anInch);
            rectToPrint.Left = (int)(e.MarginBounds.Left * anInch);
            rectToPrint.Right = (int)(e.MarginBounds.Right * anInch);

            //Calculate the size of the page
            RECT rectPage;
            rectPage.Top = (int)(e.PageBounds.Top * anInch);
            rectPage.Bottom = (int)(e.PageBounds.Bottom * anInch);
            rectPage.Left = (int)(e.PageBounds.Left * anInch);
            rectPage.Right = (int)(e.PageBounds.Right * anInch);

            IntPtr hdc = e.Graphics.GetHdc();

            FORMATRANGE fmtRange;
            fmtRange.chrg.cpMax = charTo;				//Indicate character from to character to 
            fmtRange.chrg.cpMin = charFrom;
            fmtRange.hdc = hdc;                    //Use the same DC for measuring and rendering
            fmtRange.hdcTarget = hdc;              //Point at printer hDC
            fmtRange.rc = rectToPrint;             //Indicate the area on page to print
            fmtRange.rcPage = rectPage;            //Indicate size of page

            IntPtr res = IntPtr.Zero;

            IntPtr wparam = IntPtr.Zero;
            wparam = new IntPtr(1);

            //Get the pointer to the FORMATRANGE structure in memory
            IntPtr lparam = IntPtr.Zero;
            lparam = Marshal.AllocCoTaskMem(Marshal.SizeOf(fmtRange));
            Marshal.StructureToPtr(fmtRange, lparam, false);

            //Send the rendered data for printing 
            res = SendMessage(Handle, EM_FORMATRANGE, wparam, lparam);

            //Free the block of memory allocated
            Marshal.FreeCoTaskMem(lparam);

            //Release the device context handle obtained by a previous call
            e.Graphics.ReleaseHdc(hdc);

            //Return last + 1 character printer
            return res.ToInt32();
        }
    }
}
