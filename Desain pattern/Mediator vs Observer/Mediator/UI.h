#pragma once
#include "IEventListener.h"
#include <iostream>

class UI : public IEventListener {
public:
    void onEvent(const std::string& eventName, Enemy* enemy) override;
};
