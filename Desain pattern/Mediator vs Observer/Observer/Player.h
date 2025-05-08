#pragma once
#include <vector>
#include "IObserver.h"
#include "Enemy.h"

class Player {
private:
    std::vector<IObserver*> observers;
public:
    void attack(Enemy* enemy);
    void addObserver(IObserver* obs);
    void notifyAll(Enemy* enemy);
};
