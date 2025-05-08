#include "ScoreSystem.h"
#include "Enemy.h"

void ScoreSystem::onEvent(const std::string& eventName, Enemy* enemy) {
    if (eventName == "attack" && enemy->isDead()) {
        std::cout << "Score Added if Enemy Dead" << std::endl;
    }
}
