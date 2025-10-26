#include <GL/glut.h>
#include "Map.h"
#include "Render.h"
#include "GameManager.h"

void init() {
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluOrtho2D(0, cols * cellSize, 0, rows * cellSize);
    glMatrixMode(GL_MODELVIEW);
}

int main(int argc, char** argv) {
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
    glutInitWindowSize(cols * cellSize, rows * cellSize);
    glutCreateWindow("Pac-Man Game");

    init();
    setupGame();                  // Moved logic: findPacman, findGhosts, start timer
    glutDisplayFunc(display);     // From Render.h/.cpp
    glutSpecialFunc(keyboard);    // From GameManager

    glutMainLoop();
    return 0;
}
