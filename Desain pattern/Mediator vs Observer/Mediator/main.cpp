#include "Player.h"
#include "Enemy.h"
#include "EventMediator.h"
#include "UI.h"
#include "SoundSystem.h"
#include "ScoreSystem.h"

int main() {
    EventMediator mediator;
    Player player(&mediator);
    Enemy enemy(20);

    UI ui;
    SoundSystem sound;
    ScoreSystem score;

    mediator.registerListener("attack", &ui);
    mediator.registerListener("attack", &sound);
    mediator.registerListener("attack", &score);

    // Serangan pertama
    player.attack(&enemy);
    // Serangan kedua
    player.attack(&enemy);

    return 0;
}
