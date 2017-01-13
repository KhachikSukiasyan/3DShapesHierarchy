using System;

namespace Geometry
{
    public class Ellipsoid : Shape3D, IMovable
    {
        //Lengths of  vertices
        protected float A;
        protected float B;
        protected float C;

        //protected Point3D aVertex;
        //protected Point3D bVertex;
        //protected Point3D cVertex;

        //angles  of  vertices
        protected Angle3D anglesA;
        protected Angle3D anglesB;
        protected Angle3D anglesC;

        // Constructors
        public Ellipsoid() : base()
        {
            ctorHelper();
        }

        public Ellipsoid(float a, float b, float c) : this(new Point3D(), a, b, c) { }


        public Ellipsoid(Point3D location, float a, float b, float c) : base(location)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            ctorHelper();
        }

        // Helpers
        private void ctorHelper()
        {
            anglesA.alpha = 0;
            anglesA.beta = 0;

            anglesB.alpha = 0;
            anglesB.beta = (float)Math.PI / 2;

            anglesC.alpha = (float)Math.PI / 2;
            anglesC.beta = 0;

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


        // Properties
        public float a
        {
            get { return A; }
            set {
                if (value + A > 0)
                    value += A;
                else
                    Console.WriteLine("negative value will be obtained");
            }
        }

        public float b
        {
            get { return B; }
            set {
                if (value + B > 0)
                    value += A;
                else
                    Console.WriteLine("negative value will be obtained");
            }
        }
        public float c
        {
            get { return C; }
            set {
                if (value + C > 0)
                    value += A;
                else
                    Console.WriteLine("negative value will be obtained");
            }
        }

        // Shape3D, base class methods
        public override float Area
        {
            get
            {
                float p = 1.6075f;
                return 4f * (float)Math.PI * (float)Math.Pow(Math.Pow(a * b, p) + Math.Pow(a * c, p) + Math.Pow(b * c, p), 1f / p);
            }
        }

        public override float Volume
        {
            get
            {
                return 4f / 3f * (float)Math.PI * a * b * c;
            }
        }

        //IMovable
        public void MoveBy(float dx, float dy, float dz)
        {
            var p = new Point3D();

            p.X = this.Location.X + dx;
            p.Y = this.Location.Y + dy;
            p.Z = this.Location.Z + dz;

            this.Location = p;
        }

        public void MoveTo(Point3D p)
        {
            this.Location = p;
        }

        public void MoveTo(float x, float y, float z)
        {
            this.Location = new Point3D(x, y, z);
        }

        public void MoveByAngle(float angle,Plane plane)
        {
            switch (plane)
            {
                case Plane.XY:
                    {
                        anglesA.beta = correctAngle(anglesA.beta + angle);
                        anglesB.beta = correctAngle(anglesB.beta + angle);
                    }
                    break;
                case Plane.XZ:
                    {
                        anglesA.alpha = correctAngle(anglesA.alpha + angle);
                        anglesC.alpha = correctAngle(anglesC.alpha + angle);
                    }
                    break;
                case Plane.YZ:
                    {
                        anglesB.beta = correctAngle(anglesB.beta + angle);
                        anglesC.beta = correctAngle(anglesC.beta + angle);

                    }
                    break;
                default:
                    break;
            }
        }
    }
}
