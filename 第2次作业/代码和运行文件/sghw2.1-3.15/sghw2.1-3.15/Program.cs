using System;
using System.Collections.Generic;
namespace ShapeAreaCalculator
{
    // 1. 抽象类
    public abstract class Shape
    {
        public abstract double CalculateArea();
        public abstract bool IsValid();
    }

    // 2. 长方形类
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override bool IsValid()
        {
            return Width > 0 && Height > 0;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    // 3. 正方形类
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public override bool IsValid()
        {
            return SideLength > 0;
        }

        public override double CalculateArea()
        {
            return SideLength * SideLength;
        }
    }

    // 4. 圆形类
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override bool IsValid()
        {
            return Radius > 0;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            Random random = new Random();

            Console.WriteLine("---正在随机生成 10 个形状---");

            // 随机创建 10 个形状对象
            for (int i = 0; i < 10; i++)
            {
                int shapeType = random.Next(0, 3); // 0: 长方形, 1: 正方形, 2: 圆形

                double val1 = Math.Round(random.NextDouble() * 12 - 2, 2);
                double val2 = Math.Round(random.NextDouble() * 12 - 2, 2);

                Shape newShape = null;

                switch (shapeType)
                {
                    case 0:
                        newShape = new Rectangle(val1, val2);
                        Console.WriteLine($"[{i + 1}] 创建了 长方形 (宽:{val1}, 高:{val2})");
                        break;
                    case 1:
                        newShape = new Square(val1);
                        Console.WriteLine($"[{i + 1}] 创建了 正方形 (边长:{val1})");
                        break;
                    case 2:
                        newShape = new Circle(val1);
                        Console.WriteLine($"[{i + 1}] 创建了 圆形 (半径:{val1})");
                        break;
                }

                shapes.Add(newShape);
            }

            Console.WriteLine("\n--- 开始计算面积 ---");

            double totalArea = 0;

            // 遍历并计算面积
            foreach (var shape in shapes)
            {
                if (shape.IsValid())
                {
                    double area = shape.CalculateArea();
                    totalArea += area;
                    // 使用格式化输出保留两位小数
                    Console.WriteLine($"{shape.GetType().Name} 是合法的，面积为: {area:F2}");
                }
                else
                {
                    Console.WriteLine($"{shape.GetType().Name} 参数不合法 ，无法计算面积。");
                }
            }

            Console.WriteLine("\n---------------------------");
            Console.WriteLine($"所有合法形状的面积之和为: {totalArea:F2}");
            Console.WriteLine("----------------------------");
        }
    }
}