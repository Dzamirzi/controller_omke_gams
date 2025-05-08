#pragma once

#include <string>

class Enemy;

class IEventListener {
public:
    virtual void onEvent(const std::string& eventName, Enemy* enemy) = 0;
    virtual ~IEventListener() = default;
};
