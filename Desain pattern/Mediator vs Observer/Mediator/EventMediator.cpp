#include "EventMediator.h"

void EventMediator::registerListener(const std::string& eventName, IEventListener* listener) {
    listeners[eventName].push_back(listener);
}

void EventMediator::triggerEvent(const std::string& eventName, Enemy* enemy) {
    for (auto& listener : listeners[eventName]) {
        listener->onEvent(eventName, enemy);
    }
}
