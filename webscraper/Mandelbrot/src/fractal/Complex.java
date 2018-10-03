package fractal;

// This class models a complex number.
public class Complex {

    // Here are the instance variables.
    private final double real;
    private final double imag;

    // Here is a constructor.
    public Complex(double real, double imag) {
        this.real = real;
        this.imag = imag;
    } // Complex( double, double )

    // Here is an accessor method.
    public double getReal() {
        return this.real;
    } // getReal()

    // Here is an accessor method.
    public double getImag() {
        return this.imag;
    } // getImag()

    // This method computes the magnitude
    // of a complex number with same algorithm
    // used to find the length of a vector or
    // the hypotenuse of a right triangle.
    public double magnitude() {
        return Math.sqrt(this.magnitudeSquared());
    } // magnitude()

    // Sometimes it is enough to know
    // what the square of the magnitude is---this
    // requires no square root and so is faster
    // to compute.
    public double magnitudeSquared() {
        double r = this.getReal();
        double i = this.getImag();

        return r * r + i * i;
    } // magnitudeSquared()

    // Compute the sum of this complex number
    // with another complex number.
    public Complex add(Complex otherComplex) {
        double r0 = this.getReal();
        double i0 = this.getImag();

        double r1 = otherComplex.getReal();
        double i1 = otherComplex.getImag();

        return new Complex(r0 + r1, i0 + i1);
    } // add( Complex )

    // Compute the product of this complex number
    // with another complex number.
    public Complex multiply(Complex otherComplex) {
        double r0 = this.getReal();
        double i0 = this.getImag();

        double r1 = otherComplex.getReal();
        double i1 = otherComplex.getImag();

        double r = r0 * r1 - i0 * i1;
        double i = r0 * i1 + i0 * r1;

        return new Complex(r, i);
    } // multiply( Complex )

    // Here is re-definition of the toString()
    // method that this class inherits from the
    // Object class.
    // This method returns a printable representation
    // of a complex number.
    @Override
    public String toString() {
        return String.format("(%6.3f,%6.3f)",
                this.getReal(),
                this.getImag());
    } // toString()
} // Complex
