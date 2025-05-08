#include "UI.h"
#include "Enemy.h"

void UI::onPlayerAttack(Enemy* enemy) {
    std::cout << "Enemy HP Updated: " << enemy->getHealth() << std::endl;
}
