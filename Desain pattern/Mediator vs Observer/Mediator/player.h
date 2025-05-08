#pragma once
#include "EventMediator.h"
#include "Enemy.h"

class Player {
private:
    EventMediator* mediator;
public:
    Player(EventMediator* mediator);
    void attack(Enemy* enemy);
};
