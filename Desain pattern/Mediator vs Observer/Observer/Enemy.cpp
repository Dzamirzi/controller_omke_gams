#include "Enemy.h"

Enemy::Enemy(int hp) : health(hp) {}

void Enemy::takeDamage(int amount) {
    health -= amount;
    if (health < 0) health = 0;
}

bool Enemy::isDead() const {
    return health <= 0;
}

int Enemy::getHealth() const {
    return health;
}
