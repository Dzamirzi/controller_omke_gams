#include "Ghost.h"

// Generic draw function, overridden if needed
void Ghost::draw(float cellSize, int rows) const {
    float drawX = x * cellSize;
    float drawY = (rows - y - 1) * cellSize;

    // Convert color name to RGB for OpenGL
    if (getColorName() == "Red")
        glColor3f(1.0f, 0.0f, 0.0f);
    else if (getColorName() == "Orange")
        glColor3f(1.0f, 0.5f, 0.0f);
    else if (getColorName() == "Cyan")
        glColor3f(0.0f, 1.0f, 1.0f);
    else if (getColorName() == "Purple")
        glColor3f(1.0f, 0.0f, 1.0f);

    glBegin(GL_QUADS);
    glVertex2f(drawX, drawY);
    glVertex2f(drawX + cellSize, drawY);
    glVertex2f(drawX + cellSize, drawY + cellSize);
    glVertex2f(drawX, drawY + cellSize);
    glEnd();
}
