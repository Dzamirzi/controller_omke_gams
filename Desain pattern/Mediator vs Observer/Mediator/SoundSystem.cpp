#include "SoundSystem.h"

void SoundSystem::onEvent(const std::string& eventName, Enemy* /*enemy*/) {
    if (eventName == "attack") {
        std::cout << "Play Attack Sound" << std::endl;
    }
}
