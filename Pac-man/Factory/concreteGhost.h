#ifndef CONCRETE_GHOSTS_H
#define CONCRETE_GHOSTS_H

#include "Ghost.h"

// Red Ghost - Very Fast (10)
class RedGhost : public Ghost {
public:
    RedGhost(int startX, int startY) : Ghost(startX, startY) {}
    void move() override; // Implement custom move logic
    std::string getColorName() const override { return "Red"; }
    float getSpeed() const override { return 10.0f; }
};

// Orange Ghost - Fast (8)
class OrangeGhost : public Ghost {
public:
    OrangeGhost(int startX, int startY) : Ghost(startX, startY) {}
    void move() override;
    std::string getColorName() const override { return "Orange"; }
    float getSpeed() const override { return 8.0f; }
};

// Cyan Ghost - Average (4)
class CyanGhost : public Ghost {
public:
    CyanGhost(int startX, int startY) : Ghost(startX, startY) {}
    void move() override;
    std::string getColorName() const override { return "Cyan"; }
    float getSpeed() const override { return 4.0f; }
};

// Purple Ghost - Slow (2)
class PurpleGhost : public Ghost {
public:
    PurpleGhost(int startX, int startY) : Ghost(startX, startY) {}
    void move() override;
    std::string getColorName() const override { return "Purple"; }
    float getSpeed() const override { return 2.0f; }
};

#endif // CONCRETE_GHOSTS_H
