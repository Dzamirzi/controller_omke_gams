#ifndef GHOST_DECORATOR_H
#define GHOST_DECORATOR_H

#include "Ghost.h" // Include base ghost interface/class

// Abstract Decorator class
class GhostDecorator : public Ghost {
protected:
    Ghost* wrappedGhost; // The ghost we're wrapping

public:
    GhostDecorator(Ghost* ghost);
    
    virtual void move() override;
    virtual void draw(float cellSize, int rows) override;
    virtual float getSpeed() const override;
    virtual std::string getColorName() const override;

    // Optional: Access position via decorator
    virtual int getX() const override { return wrappedGhost->getX(); }
    virtual int getY() const override { return wrappedGhost->getY(); }
};

#endif // GHOST_DECORATOR_H
