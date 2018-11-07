using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteDesktopViewer
{
    public class MouseController
    {
        private static readonly int _screenWidth = Screen.PrimaryScreen.Bounds.Width;
        private static readonly int _screenHeight = Screen.PrimaryScreen.Bounds.Height;
        
        public static int screenWidth
        {
            get
            {
                return _screenWidth;
            }
        }

        public static int screenHeight
        {
            get
            {
                return _screenHeight;
            }
        }

        private static readonly double _mouseXpercentage = (double)Cursor.Position.X / (double)screenWidth;
        private static readonly double _mouseYpercentage = (double)Cursor.Position.Y / (double)screenHeight;

        public static double mouseWidthPositionInPercentage
        {
            get
            {
                return _mouseXpercentage;
            }
        }

        public static double mouseHeightPositionInPercentage
        {
            get
            {
                return _mouseYpercentage;
            }
        }


    }
}
