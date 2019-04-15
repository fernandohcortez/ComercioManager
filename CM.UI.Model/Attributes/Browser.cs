using System;
using System.Windows;

namespace CM.UI.Model.Attributes
{
    public class BrowserAttribute : Attribute
    {
        public bool Visible { get; set; } = true;
        public int FixedWidth { get; set; }
        public string Title { get; set; }
        public BrowserAttributeAlignment Alignment { get; set; }
        public bool WrapText { get; set; }
    }
}
