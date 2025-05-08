#pragma once

class Enemy {
private:
    int health;
public:
    Enemy(int hp);
    void takeDamage(int amount);
    bool isDead() const;
    int getHealth() const;
};
