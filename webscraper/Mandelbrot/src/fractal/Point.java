
package fractal;

// A class to model a point in the plane.
public class Point {
    // Here are the instance variables.
    private final double x;
    private final double y;
    
    // Here is a constructor.
    public Point( int row, int column,
            int numberOfRows, int numberOfColumns ) {
        double xCoord = ((double) row)/(numberOfRows - 1);
        xCoord = 2 * xCoord - 1;
        
        double yCoord = ((double) column)/(numberOfColumns - 1);
        yCoord = 2 * yCoord - 1;
        
        this.x = xCoord;
        this.y = yCoord;
    } // Point( int, int, int, int )
    
    // Here is an accessor method.
    public double getX() {
        return this.x;
    } // getX()
    
    // Here is an accessor method.
    public double getY() {
        return this.y;
    } // getY()
    
    // Here is re-definition of the toString()
    // method that this class inherits from the
    // Object class.
    // This method returns a printable representation
    // of a point.
    @Override
    public String toString() {
        return String.format( "(%6.3f,%6.3f)", 
                this.getX(),
                this.getY());
    } // toString()
} // Point
