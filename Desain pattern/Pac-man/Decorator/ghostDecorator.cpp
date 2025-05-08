#include "GhostDecorator.h"

GhostDecorator::GhostDecorator(Ghost* ghost)
    : wrappedGhost(ghost) {}

void GhostDecorator::move() {
    wrappedGhost->move();
}

void GhostDecorator::draw(float cellSize, int rows) {
    wrappedGhost->draw(cellSize, rows);
}

float GhostDecorator::getSpeed() const {
    return wrappedGhost->getSpeed();
}

std::string GhostDecorator::getColorName() const {
    return wrappedGhost->getColorName();
}
