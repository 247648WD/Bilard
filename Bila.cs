using System;

public class Bila
{
    private double posX;
    private double posY;
    private int vel;
    private int dir;

    public Bila(double posX, double posY, int vel, int dir)
    {
        this.posX = posX;
        this.posY = posY;
        this.vel = vel;
        this.dir = dir;
    }

    public double getX() { return posX; }
    public double getY() { return posY; }
    public int getVel() { return vel; }
    public int getDir() { return dir; }

    private void setX(double x) { this.posX = x; }
    private void setY(double y) { this.posY = y; }
    private void setVel(int vel) { this.vel = vel; }
    private void setDir(int dir) { this.dir = dir; }

    public void updatePos()
    {
        switch (dir)
        {
            case 0:
                setY(getY() + vel); break;
            case 90:
                setX(getX() + vel); break;
            case 180:
                setY(getY() - vel); break;
            case 270:
                setX(getX() - vel); break;
            default:
                break;
        }


    }

}
