#include "GhostFactory.h"
#include "ConcreteGhosts.h"

Ghost* GhostFactory::createGhost(GhostType type, int x, int y) {
    switch (type) {
        case RED:    return new RedGhost(x, y);
        case ORANGE: return new OrangeGhost(x, y);
        case CYAN:   return new CyanGhost(x, y);
        case PURPLE: return new PurpleGhost(x, y);
        default:     return nullptr;
    }
}
