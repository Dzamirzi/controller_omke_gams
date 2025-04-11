#ifndef GHOST_FACTORY_H
#define GHOST_FACTORY_H

#include "Ghost.h"

enum GhostType {
    RED,
    ORANGE,
    CYAN,
    PURPLE
};

class GhostFactory {
public:
    static Ghost* createGhost(GhostType type, int x, int y);
};

#endif // GHOST_FACTORY_H
