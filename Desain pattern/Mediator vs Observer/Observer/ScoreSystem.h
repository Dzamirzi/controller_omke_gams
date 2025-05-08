#pragma once
#include "IObserver.h"
#include <iostream>

class ScoreSystem : public IObserver {
public:
    void onPlayerAttack(Enemy* enemy) override;
};
