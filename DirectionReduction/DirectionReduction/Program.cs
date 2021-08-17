namespace DirectionReduction
{
    class Program
    {
        public static void Main()
        {
            string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] b = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
            string[] c = new string[] { "EAST", "EAST", "SOUTH", "EAST", "SOUTH", "SOUTH", "SOUTH", "EAST", "EAST", "SOUTH", "NORTH", "NORTH", "NORTH", "SOUTH", "SOUTH" };
            string[] d = new string[] { "NORTH" };
            string[] e = new string[] { };

            var resA = DirReductionSolver.Reduce(a);
            var resB = DirReductionSolver.Reduce(b);
            var resC = DirReductionSolver.Reduce(c);
            var resD = DirReductionSolver.Reduce(d);
            var resE = DirReductionSolver.Reduce(e);
        }
    }
}
