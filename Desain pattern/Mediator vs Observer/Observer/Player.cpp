#include "Player.h"

void Player::addObserver(IObserver* obs) {
    observers.push_back(obs);
}

void Player::notifyAll(Enemy* enemy) {
    for (auto obs : observers) {
        obs->onPlayerAttack(enemy);
    }
}

void Player::attack(Enemy* enemy) {
    enemy->takeDamage(10);
    notifyAll(enemy);
}
