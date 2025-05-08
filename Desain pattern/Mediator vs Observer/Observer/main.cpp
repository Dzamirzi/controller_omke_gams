#include "Player.h"
#include "Enemy.h"
#include "UI.h"
#include "SoundSystem.h"
#include "ScoreSystem.h"

int main() {
    Player player;
    Enemy enemy(20);

    UI ui;
    SoundSystem sound;
    ScoreSystem score;

    player.addObserver(&ui);
    player.addObserver(&sound);
    player.addObserver(&score);

    // Serangan pertama
    player.attack(&enemy);
    // Serangan kedua (musuh mati)
    player.attack(&enemy);

    return 0;
}
