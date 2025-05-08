#pragma once
#include "IObserver.h"
#include <iostream>

class SoundSystem : public IObserver {
public:
    void onPlayerAttack(Enemy* enemy) override;
};
