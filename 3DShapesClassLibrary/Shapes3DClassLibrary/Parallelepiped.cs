using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
    public class Parallelepiped: Shape3D
    {
        //Lengths of  vertices
        protected float A;
        protected float B;
        protected float C;

        //smallest angle between adjacent 
        protected float smallAngle;

        public override float Area
        {
            get
            {
               return 2 *(A * C + A * B + B * C * (float)Math.Sin(smallAngle));
            }
        }

        public override float Volume
        {
            get
            {
                return A * B * C * (float)Math.Sin(smallAngle);
            }
        }

        public Parallelepiped(float aSide, float bSide, float cSide,float angle)
        {
            A = aSide;
            B = bSide;
            C = cSide;
            smallAngle = correctAngle(angle);
        }

        private float correctAngle(float angle)
        {
            float formattedAngle;
            if (angle >= 0)
            {
                formattedAngle = angle % (float)(Math.PI * 2);

                if (formattedAngle > (float)Math.PI)
                    return -(float)(Math.PI * 2) - formattedAngle;
                else
                    return formattedAngle;
            }
            else
            {
                formattedAngle = angle % (float)(Math.PI * 2);

                if (formattedAngle < -(float)Math.PI)
                    return (float)(Math.PI * 2) - (-formattedAngle);
                else
                    return formattedAngle;
            }
        }
    }
}
