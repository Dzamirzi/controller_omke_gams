#include "ConcreteGhosts.h"
#include <cstdlib>

extern char map[21][22]; // reference your map from the original code!

// Common movement logic
void simpleMove(Ghost* ghost) {
    int dx[4] = { 0, 0, -1, 1 };
    int dy[4] = { -1, 1, 0, 0 };

    int dir = rand() % 4;
    int newX = ghost->getX() + dx[dir];
    int newY = ghost->getY() + dy[dir];

    if (map[newY][newX] != '#') {
        ghost->x = newX;
        ghost->y = newY;
    }
}

void RedGhost::move()    { simpleMove(this); }
void OrangeGhost::move() { simpleMove(this); }
void CyanGhost::move()   { simpleMove(this); }
void PurpleGhost::move() { simpleMove(this); }
