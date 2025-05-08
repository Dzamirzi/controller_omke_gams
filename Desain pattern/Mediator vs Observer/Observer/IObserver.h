#pragma once

class Enemy;

class IObserver {
public:
    virtual void onPlayerAttack(Enemy* enemy) = 0;
    virtual ~IObserver() = default;
};
