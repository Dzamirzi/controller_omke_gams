#ifndef GHOST_TAKUT_H
#define GHOST_TAKUT_H

#include "GhostDecorator.h"

// decorator takut class
class ghostTakut : public GhostDecorator {
public:
    ghostTakut(Ghost* ghost);

    void draw(float cellSize, int rows) override;
    float getSpeed() const override;
};

#endif // GHOST_TAKUT_H
