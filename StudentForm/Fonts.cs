using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd;
namespace StudentForm
{
    
    internal class Fonts
    {   //"Microsoft San Sarif"
        Layout layout = new Layout();
        public Font smallFont;
        public Font mediumFont;
        public Font LargeFont;
        public Fonts()
        {
            smallFont = new Font(layout.fontFamily, layout.fontSize*0.45F);
            mediumFont = new Font(layout.fontFamily, layout.fontSize*0.7F);
            LargeFont = new Font(layout.fontFamily, layout.fontSize*1.8F);
        }
        public Color btnPrimary = Color.SteelBlue;
        public Color btnSecondary = Color.Gray;
        public Color btnDanger = Color.DarkRed;
        public Color selectionColor = Color.DodgerBlue;
        public Color selectionForeColor = Color.White;
    }
}
