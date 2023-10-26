using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarmlyLocomotive
{
    public class EntityTeplovoz
    {
        public int Speed { get; private set; }
       
        public double Weight { get; private set; }
        
        public Color BodyColor { get; private set; }
       
        public Color AdditionalColor { get; private set; }
        
        public double Step => (double)Speed * 100 / Weight;
        
        public void Init(int speed, double weight, Color bodyColor, Color
        additionalColor)
        {
            Speed = speed;
            Weight = weight;
            BodyColor = bodyColor;
            AdditionalColor = additionalColor;
        }
    }
}
