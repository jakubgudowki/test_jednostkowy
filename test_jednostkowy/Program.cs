using System;
using Xunit;

public class QuadraticEquationSolver
{
    public static (double, double) Solve(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            throw new InvalidOperationException("No real roots");
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            return (root, root);
        }
        else
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            return (root1, root2);
        }
    }
}

public class QuadraticEquationSolverTests
{
    [Theory]
    [InlineData(1, -4, 4, 2, 2)]    // One root: x = 2
    [InlineData(1, -3, 2, 1, 2)]    // Two roots: x1 = 1, x2 = 2
    public void Solve_ValidCoefficients_ReturnsCorrectRoots(double a, double b, double c, double expectedRoot1, double expectedRoot2)
    {
        // Act
        var (root1, root2) = QuadraticEquationSolver.Solve(a, b, c);

        // Assert
        Assert.Equal(expectedRoot1, root1, precision: 5);
        Assert.Equal(expectedRoot2, root2, precision: 5);
    }

    [Fact]
    public void Solve_NoRealRoots_ThrowsException()
    {
        // Arrange
        double a = 1;
        double b = 1;
        double c = 1;

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => QuadraticEquationSolver.Solve(a, b, c));
    }
}
