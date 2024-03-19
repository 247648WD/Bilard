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

    public double GetX() { return posX; }
    public double GetY() { return posY; }
    public int GetVel() { return vel; }
    public int GetDir() { return dir; }

    private void SetX(double x) { this.posX = x; }
    private void SetY(double y) { this.posY = y; }
    private void SetVel(int vel) { this.vel = vel; }
    private void SetDir(int dir) { this.dir = dir; }

    public void UpdatePos()
    {
        switch (dir)
        {
            case 0:
                SetY(GetY() + vel); break;
            case 90:
                SetX(GetX() + vel); break;
            case 180:
                SetY(GetY() - vel); break;
            case 270:
                SetX(GetX() - vel); break;
            default:
                SetX(GetX() + (vel / Math.Sqrt(1 + Math.Tan(dir) * Math.Tan(dir))));
                SetY(GetY() + (vel * Math.Tan(dir) / Math.Sqrt(1 + Math.Tan(dir) * Math.Tan(dir))));
                break;
        }


    }

}
