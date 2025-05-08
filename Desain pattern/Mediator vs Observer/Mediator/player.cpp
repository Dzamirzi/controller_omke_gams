#include "Player.h"

Player::Player(EventMediator* m) : mediator(m) {}

void Player::attack(Enemy* enemy) {
    enemy->takeDamage(10);
    mediator->triggerEvent("attack", enemy);
}
