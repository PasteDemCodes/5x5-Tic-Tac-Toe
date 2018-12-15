using System.Windows.Media;

namespace TicTacToe
{
    class ColorPallete
    {
        public SolidColorBrush MainTextColor { set; get; }
        public SolidColorBrush MainNavbarColor { set; get; }
        public SolidColorBrush MainBodyColor { set; get; }
        public SolidColorBrush FocusedColor { set; get; }
        public SolidColorBrush SelectedColor { set; get; }
        public SolidColorBrush ErrorColor { set; get; }
        public SolidColorBrush MainTextboxBorderColor { get; set; }
        public SolidColorBrush WinnerColor { get; set; }


        // Default Colors
        public ColorPallete()
        {
            WinnerColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF3DF756"));
            MainTextColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFFFF"));
            MainNavbarColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF282828"));
            MainBodyColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF191919"));
            FocusedColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF4A4A4A"));
            SelectedColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF393939"));
            ErrorColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#f44242"));
            MainTextboxBorderColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFABADB3"));
    
        }

    }
}

