#include "ghostTakut.h"
#include "utils.h" // Assuming drawCell function is here

ghostTakut::ghostTakut(Ghost* ghost)
    : GhostDecorator(ghost) {}

void ghostTakut::draw(float cellSize, int rows) {
    float x = wrappedGhost->getX() * cellSize;
    float y = (rows - wrappedGhost->getY() - 1) * cellSize;

    // Draw blue cell for frightened ghost
    drawCell(x, y, cellSize, 0.0f, 0.0f, 1.0f);
}

float ghostTakut::getSpeed() const {
    return wrappedGhost->getSpeed() / 2.0f; // Slow them down
}
