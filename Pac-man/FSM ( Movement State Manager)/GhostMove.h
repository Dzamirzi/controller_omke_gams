#ifndef GHOST_MOVE_H
#define GHOST_MOVE_H

enum GhostState {
    CHASING,
    SEARCHING
};

struct Ghost {
    int x, y;
    int lastDx = 0, lastDy = 0;
    char id;
    GhostState state = CHASING;
};

void moveGhost(Ghost& ghost, int pacX, int pacY, char map[21][22]);

#endif
