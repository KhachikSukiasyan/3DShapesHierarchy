# 3DShapesHierarchy

![1](https://github.com/KhachikSukiasyan/3DShapesHierarchy/blob/master/200px-Ellipsoid_tri-axial_abc.svg.png)
![alt tag](https://github.com/KhachikSukiasyan/3DShapesHierarchy/blob/master/240px-Parallelepipedon.png)

##DESCRIPTION
This is an example of inheritance.`Shape3D` is the base class of `Ellipsoid` and `Parallelepiped` classes.
Last two classes implement `Volume`and `Area` properties from base class.There are also functions for moving
and rotating for `Ellipsoid`. Project includes `Point3D` helper class.

Example:
```cs
    Point3D point = new Point3D(14.2f, 58.4f, 33.6f);

    Ellipsoid ell = new Ellipsoid(point, 22.5f, 42.56f, 21.4f);
    Console.WriteLine(ell.Area);
    Console.WriteLine(ell.Volume);

    Parallelepiped par = new Parallelepiped(12.3f, 45.6f, 75.5f, (float)Math.PI / 4);
    Console.WriteLine(par.Area);
    Console.WriteLine(par.Volume);
```
