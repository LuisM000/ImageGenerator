using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGenerator.Core.Model
{
    public class ImageDimensions
    {
        public Size Resolution { get; set; }
        public double Percentage { get; set; }

        public Size GetResolution(Size originalResolution)
        {
            if (this.Percentage != 0)
            {
                return new Size(Convert.ToInt32(originalResolution.Width*this.Percentage),
                    Convert.ToInt32(originalResolution.Height*this.Percentage));
            }
            return this.Resolution;
        }
    }
}
