#pragma once
#include "IObserver.h"
#include <iostream>

class UI : public IObserver {
public:
    void onPlayerAttack(Enemy* enemy) override;
};
