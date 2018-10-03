package fractal;

// Tell the compiler where to find the
// definitions of the classes that this
// program uses.
import java.awt.image.BufferedImage;
import java.awt.image.WritableRaster;
import java.io.File;
import java.io.IOException;
import javax.imageio.ImageIO;
import java.util.Random;

/**
 * This is an experiment with bit-mapped graphics.
 *
 * The Bitmap class inherits from the Application class (that is what "extends"
 * means), so it gets all of the instance variables and public methods that are
 * defined in the Application class "for free."
 *
 * @author Brody Lamb
 * @version 22 March 2018
 */
public class Bitmap {

    // XMIN, XMAX, YMIN, YMAX define the rectangular
    // part of the picture that the program will draw
    // (to get whole picture:
    //     XMIN = -1
    //     XMAX = +1
    //     YMIN = -1
    //     YMAX = +1
    // Try other values!
    private static final double XMIN = -.17;
    private static final double XMAX = -.15;
    private static final double YMIN = -1.045;
    private static final double YMAX = -1.025;

    private static final double xMIN = -.66;
    private static final double xMAX = 0.25;
    private static final double yMIN = -.66;
    private static final double yMAX = 0.25;

    // change WIDTH and HEIGHT to change
    // size of the picture// 4723//6600,6682//
    private static final int WIDTH = 12574;
    private static final int HEIGHT = 12574;
    private static final double cx = -.79;
    private static final double cy = .15;

    // a higher value for MAX_ITERATIONS will
    // produce a more accurate image of the set
    // but a slower computation
    private static final int MAX_ITERATIONS = 64;

    public static void start() throws IOException {
        int type = BufferedImage.TYPE_INT_RGB;
        BufferedImage MandPicture = new BufferedImage(WIDTH, HEIGHT, type);
        WritableRaster MandRaster = MandPicture.getRaster();
        int NewNum0 = getRandom();
        int NewNum1 = getRandom();
        int NewNum2 = getRandom();
        for (int i = 0; i < HEIGHT; i++) {
            for (int j = 0; j < WIDTH; j++) {
                // Compute a color for each pixel.
                int[] c = computeColor(i, j,  NewNum0, NewNum1, NewNum2);
                MandRaster.setPixel(i, j, c);
            }
        }
        // for

        File MandFile = new File("Mandelbrot_" + NewNum0 + "_" + NewNum1 + "_" + NewNum2 + ".jpg");
        ImageIO.write(MandPicture, "jpg", MandFile);

    }

    public static void start1() throws IOException {
        int type = BufferedImage.TYPE_INT_RGB;
        BufferedImage JuliaPicture = new BufferedImage(WIDTH, HEIGHT, type);
        WritableRaster JuliaRaster = JuliaPicture.getRaster();
        int NewNum0 = getRandom();
        int NewNum1 = getRandom();
        int NewNum2 = getRandom();
        for (int i = 0; i < HEIGHT; i++) {
            for (int j = 0; j < WIDTH; j++) {
                int[] w = ComputeJulia(i, j, NewNum0,NewNum1,NewNum2);
                JuliaRaster.setPixel(i, j, w);
            }
        }
        File JuliaFile = new File("JuliaSet_" + NewNum0 + "_" + NewNum1 + "_" + NewNum2 + ".jpg");
        ImageIO.write(JuliaPicture, "jpg", JuliaFile);
    }

    // Produce an index in the range 0 to size - 1,
    // where size is the number of colors in the
    // palette.
    private static int JuliaColor(int row, int column) {
        Point p = new Point(row, column, HEIGHT, WIDTH);

        double x = p.getX();
        double y = p.getY();

        x = xMIN + (xMAX - xMIN) * (x + 1) / 2;
        y = yMIN + (yMAX - yMIN) * (y + 1) / 2;

        Complex c = new Complex(cx, cy);
        Complex z = new Complex(x, y);

        int count = 0;
        while (z.magnitude() < 2
                && count < MAX_ITERATIONS - 1) {

            // compute z = z * z + c
            z = z.multiply(z);
            z = z.add(c);
            count++;
        } // while

        return count;

    }

    private static int getRandom() {

        Random rand0 = new Random();

        int rand = rand0.nextInt(50) + 0;

        return (rand);

    }

    private static int computeColorIndex(int row, int column) {
        Point p = new Point(row, column, HEIGHT, WIDTH);

        double x = p.getX();
        double y = p.getY();

        // These next 2 statements have the
        // effect of zooming in on the image.
        x = XMIN + (XMAX - XMIN) * (x + 1) / 2;
        y = YMIN + (YMAX - YMIN) * (y + 1) / 2;

        // To produce an image of one of the Julia
        // sets rather than an image of the Mandelbrot
        // set, give z a real component equal to x and an
        // imaginary component equal to y, and then
        // give the real and imaginary components of c
        // constant values that you choose. (Try several
        // or many until you get a picture that you like.)
        Complex z = new Complex(0, 0);
        Complex c = new Complex(x, y);

        // Instead of comparing the magnitude
        // of z to 2, compare the square of the
        // magnitude of z to 4.
        // (This avoids the needs to compute a square
        // root and makes the computation faster.)
        int count = 0;
        while (z.magnitudeSquared() < 4
                && count < MAX_ITERATIONS - 1) {

            // compute z = z * z + c
            z = z.multiply(z);
            z = z.add(c);
            count++;
        } // while

        return count;
    } // computeColorIndex( int , int )

    // Use an index to select a color for a pixel.
    public static int[] ComputeJulia(int row, int column, int NewNum0, int NewNum1, int NewNum2) {
        int i = JuliaColor(row, column);
        if (i == MAX_ITERATIONS - 1) {
            int[] black = {0, 0, 0};
            return black;
        } else {
            int[] color = {i * NewNum0, i * NewNum1, i * NewNum2};
            return color;
        }
    }

    public static int[] computeColor(int row, int column, int NewNum0, int NewNum1, int NewNum2) {
        int i = computeColorIndex(row, column);
        if (i == MAX_ITERATIONS - 1) {
            int[] black = {0, 0, 0};
            return black;
        } else {
            int[] color = {i * NewNum0, i * NewNum1, i * NewNum2};
            return color;

        }
    } // computeColor( int, int )

    // Execution of the program begins in
    // the main() method.
    public static void main(String[] args) throws IOException {
        start();
        start1();
    } // main( String[] )

} // Bitmap
