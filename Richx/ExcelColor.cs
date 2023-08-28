﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Richx
{
    public static class ExcelColor
    {
        private static readonly RgbColor[,] _themeColors = new RgbColor[,]
        {
            { 0xFFFFFF, 0x000000, 0xE7E6E6, 0x44546A, 0x5B9BD5, 0xED7D31, 0xA5A5A5, 0xFFC000, 0x4472C4, 0x70AD47 },
            { 0xF2F2F2, 0x7F7F7F, 0xD0CECE, 0xD6DCE4, 0x222A35, 0xFBE5D5, 0xEDEDED, 0x525252, 0xD9E2F3, 0xE2EFD9 },
            { 0xD8D8D8, 0x595959, 0xAEABAB, 0xADB9CA, 0xBDD7EE, 0xF7CBAC, 0xDBDBDB, 0xFEE599, 0xB4C6E7, 0xC5E0B3 },
            { 0xBFBFBF, 0x3F3F3F, 0x757070, 0x8496B0, 0x9CC3E5, 0xF4B183, 0xC9C9C9, 0xFFD965, 0xB4C6E7, 0xA8D08D },
            { 0xA5A5A5, 0x262626, 0x3A3838, 0x323F4F, 0x2E75B5, 0xC55A11, 0x7B7B7B, 0xBF9000, 0x2F5496, 0xA8D08D },
            { 0x7F7F7F, 0x0C0C0C, 0x171616, 0x222A35, 0x1E4E79, 0x833C0B, 0x525252, 0x7F6000, 0x2F5496, 0x375623 },
        };
        public static RgbColor Theme(int row, int col)
        {
            return _themeColors[row, col];
        }

        private static readonly RgbColor[,] _standardColors = new RgbColor[,]
        {
            { 0xBF0000, 0xFE0000, 0xFEBF00, 0xFEFE00, 0x91CE4F, 0x00B050, 0x00AFEE, 0x006FBE, 0x002060, 0x6F309F },
        };
        public static RgbColor Standard(int row, int col)
        {
            return _standardColors[row, col];
        }
    }
}
