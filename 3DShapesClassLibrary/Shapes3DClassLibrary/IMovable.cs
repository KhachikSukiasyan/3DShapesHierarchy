namespace Geometry
{
    public interface IMovable
    {
        void MoveBy(float dx, float dy, float dz);
        void MoveTo(float x, float y, float z);
        void MoveTo(Point3D p);
        void MoveByAngle(float angle, Plane plane);
    }
}
