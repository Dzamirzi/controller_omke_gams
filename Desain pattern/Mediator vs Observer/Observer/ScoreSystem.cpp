#include "ScoreSystem.h"
#include "Enemy.h"

void ScoreSystem::onPlayerAttack(Enemy* enemy) {
    if (enemy->isDead()) {
        std::cout << "Score Added if Enemy Dead" << std::endl;
    }
}
