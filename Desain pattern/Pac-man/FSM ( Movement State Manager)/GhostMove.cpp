#include "GhostMove.h"
#include <cmath>

void moveGhost(Ghost& ghost, int pacX, int pacY, char map[21][22]) {
    int bestDx = 0;
    int bestDy = 0;
    int minDistance = 99999;

    int directions[4][2] = {
        {0, -1}, {0, 1}, {-1, 0}, {1, 0}
    };

    if (ghost.state == CHASING) {
        for (int i = 0; i < 4; i++) {
            int dx = directions[i][0];
            int dy = directions[i][1];
            int newX = ghost.x + dx;
            int newY = ghost.y + dy;

            if (map[newY][newX] == '#') continue;
            if (dx == -ghost.lastDx && dy == -ghost.lastDy) continue;

            int distance = std::abs(pacX - newX) + std::abs(pacY - newY);
            if (distance < minDistance) {
                minDistance = distance;
                bestDx = dx;
                bestDy = dy;
            }
        }
    } else if (ghost.state == SEARCHING) {
        // Just move randomly (could be improved with more logic)
        for (int i = 0; i < 4; i++) {
            int dx = directions[i][0];
            int dy = directions[i][1];
            int newX = ghost.x + dx;
            int newY = ghost.y + dy;
            if (map[newY][newX] != '#' && !(dx == -ghost.lastDx && dy == -ghost.lastDy)) {
                bestDx = dx;
                bestDy = dy;
                break;
            }
        }
    }

    ghost.x += bestDx;
    ghost.y += bestDy;
    ghost.lastDx = bestDx;
    ghost.lastDy = bestDy;

    if (ghost.x == pacX && ghost.y == pacY) {
        exit(0);
    }
}
