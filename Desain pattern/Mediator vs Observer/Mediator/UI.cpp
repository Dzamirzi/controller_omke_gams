#include "UI.h"
#include "Enemy.h"

void UI::onEvent(const std::string& eventName, Enemy* enemy) {
    if (eventName == "attack") {
        std::cout << "Enemy HP Updated: " << enemy->getHealth() << std::endl;
    }
}
