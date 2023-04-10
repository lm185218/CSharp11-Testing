using System.Numerics;

namespace CSharp11
{
    static class GenericMathSupport
    {
        //this method calls a generic Square All method to demonstrate the new generic math support in c#11
        public static void NewMathChanges()
        {
            double[] doubles = new[] { 3.9, 2.2, 8.6, 4.0, 0.0 };
            var squaredDoubles = SquareAll(doubles);
            foreach (var d in squaredDoubles)
            {
                Console.Write($"{d},");
            }
            Console.WriteLine();

            int[] ints = new[] { 0, 1, 2, 3 };
            var squaredInts = SquareAll(ints);
            foreach (var i in squaredInts)
            {
                Console.Write($"{i},");
            }
            Console.WriteLine();
        }

        // generic SquareAll method that lets us have one method for any type that inherits INumber<T>
        private static T[] SquareAll<T>(T[] values)
           where T : INumber<T>
        {
            List<T> squared = new List<T>();
            foreach (var v in values)
            {
                //INumber contains a definition for zero that all implenting types must specify. Since 0 isnt a valid double and 0.0 isnt a valid int
                var result = v.Equals(T.Zero) ? T.Zero : v * v;

                squared.Add(result);
            }

            return squared.ToArray();
        }
    }
}
