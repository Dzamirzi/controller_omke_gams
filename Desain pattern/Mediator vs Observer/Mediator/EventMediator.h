#pragma once

#include <string>
#include <vector>
#include <unordered_map>
#include "IEventListener.h"

class EventMediator {
private:
    std::unordered_map<std::string, std::vector<IEventListener*>> listeners;
public:
    void registerListener(const std::string& eventName, IEventListener* listener);
    void triggerEvent(const std::string& eventName, Enemy* enemy);
};
