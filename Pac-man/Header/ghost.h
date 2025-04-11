#ifndef GHOST_H
#define GHOST_H

#include <string>
#include <GL/glut.h>

class Ghost {
protected:
    int x, y; // Position on the grid
public:
    Ghost(int startX, int startY) : x(startX), y(startY) {}
    virtual ~Ghost() {}

    virtual void move() = 0;
    virtual std::string getColorName() const = 0;
    virtual float getSpeed() const = 0;
    virtual void draw(float cellSize, int rows) const;

    int getX() const { return x; }
    int getY() const { return y; }
};

#endif // GHOST_H
